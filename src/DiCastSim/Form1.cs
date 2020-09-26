using DiCastSim.Core;
using DiCastSim.Core.Base;
using DiCastSim.Core.Enums;
using DiCastSim.Core.Models;
using DiCastSim.Core.Services;
using DiCastSim.Envirolment;
using DiCastSim.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DiCastSim
{
    public partial class Form1 : Form
    {
        readonly Queue<Drops> repeatItems = new Queue<Drops>();

        private PlayerSprit _sprite1;
        PlayerSprit Sprite1
        {
            get
            {
                if (_sprite1 == null)
                    _sprite1 = CreateSprite(flowLayoutPanel1, Properties.Resources.superhero1, Player1);
                return _sprite1;
            }
        }

        private PlayerSprit _sprite2;
        PlayerSprit Sprite2
        {
            get
            {
                if (_sprite2 == null)
                    _sprite2 = CreateSprite(flowLayoutPanel2, Properties.Resources.superhero2, Player2);
                return _sprite2;
            }
        }

        PlayerSprit CurrentSprite => game.PlayerTurn == Game.Who.Player1 ? Sprite1 : Sprite2;

        Player Player1 => game.GetPlayer(Game.Who.Player1);
        Player Player2 => game.GetPlayer(Game.Who.Player2);

        readonly Inventario inventario = new Inventario();
        readonly Randomizer rand;
        readonly Game game;
        readonly MonsterService monsterS;

        public Form1()
        {
            InitializeComponent();
            game = IOC.Resolve<Game>();
            rand = IOC.Resolve<Randomizer>();
            monsterS = IOC.Resolve<MonsterService>();
            game.DiceAdded += Game_DiceAdded;
        }

        private void Game_DiceAdded(object sender, DiceInHand dice)
        {
            AddDice(CurrentSprite, dice);

            if (game.Hunting)
                game.Player.Hand.ValidateForHunting();
            else
                game.Player.Hand.Validate();

            for (int i = 0; i < game.Player.Hand.Count; i++)
            {
                CurrentSprite.Deck.Controls[i].Enabled = game.Player.Hand[i].Enabled;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            StartGame(Game.Who.Player1);
        }

        private void StartGame(Game.Who who)
        {
            game.Start(who);
            SetScreemItems();
            //game.TakeDice(Dice.Shuffle); // DEBUG
            game.AddDice();
        }

        private void SetScreemItems()
        {
            _sprite2 = _sprite1 = null;
            SpawnInitialItems();
            SetPlayer(Sprite1);
            SetPlayer(Sprite2);
            UpdateScreenItems();
        }

        private PlayerSprit CreateSprite(FlowLayoutPanel panel, Image img, Player player)
        {
            return new PlayerSprit(player)
            {
                Deck = panel,
                BackgroundImage = img
            };
        }

        private void SetPlayer(PlayerSprit sprite)
        {
            foreach (var dice in sprite.Player.Hand) AddDice(sprite, dice);
            MoveSprite(0, sprite);
            Controls.Remove(sprite);
            Controls.Add(sprite);
            sprite.BringToFront();
        }

        private void AddDice(PlayerSprit pv, DiceInHand dice)
        {
            var d = new DicePad(dice);
            d.Clicked += Dice_Clicked;
            pv.Deck.Controls.Add(d);
        }

        private void Dice_Clicked(object sender, DiceInHand e)
        {
            var dicePad = (DicePad)sender;

            // Avoid click out of turn
            if (dicePad.Parent == flowLayoutPanel1 && CurrentSprite != Sprite1) return;
            if (dicePad.Parent == flowLayoutPanel2 && CurrentSprite != Sprite2) return;

            var diceFace = dicePad.PaintDiceFace();

            if (diceFace.HasValue)
            {
                if (game.Player.LockEven)
                {
                    game.Player.LockEven = false;
                    game.Player.LockOdd = false;
                    if (diceFace.Value % 2 == 0)
                    {
                        MessageBox.Show("Break lock and don't move");
                        diceFace = 0;
                    }
                }

                if (game.Player.LockOdd)
                {
                    game.Player.LockEven = false;
                    game.Player.LockOdd = false;
                    if (diceFace.Value % 2 != 0)
                    {
                        MessageBox.Show("Break lock and don't move");
                        diceFace = 0;
                    }
                }

                if (game.Hunting)
                {
                    // Handle negative number as positive
                    var x = diceFace.Value < 0 ? diceFace.Value * -1 : diceFace.Value;

                    if (monsterS.AtackMonster(x))
                    {
                        MessageBox.Show("Monster Defeated");
                        game.Player.Atack += 1;
                        game.Player.Coins += monsterS.Coins;
                    }
                    else
                    {
                        MessageBox.Show("You lose");
                        game.Player.Life -= monsterS.Atack;
                    }

                    game.Hunting = false;
                    huntMonster1.Visible = game.Hunting;
                }
                else
                {
                    button1.Text = diceFace.ToString();
                    MoveSprite(diceFace.Value, CurrentSprite);
                    DoAction();
                }
            }
            else
            {
                if (dicePad.SpecialDice.Dice == Dice.LockEven)
                {
                    game.Opponent.LockEven = true;
                }
                else if (dicePad.SpecialDice.Dice == Dice.LockOdd)
                {
                    game.Opponent.LockOdd = true;
                }
                else if (dicePad.SpecialDice.Dice == Dice.DrawTwoDices)
                {
                    if (game.Player.Hand.Count == 5)
                        game.AddDice();

                    if (game.Player.Hand.Count < 5)
                    {
                        game.AddDice();
                        game.AddDice();
                    }
                }
                else if (dicePad.SpecialDice.Dice == Dice.Shuffle)
                {
                    game.Player.Turns++;
                    game.Player.Hand.Shuffle();
                    for (int i = 0; i < game.Player.Hand.Count; i++)
                    {
                        ((DicePad)CurrentSprite.Deck.Controls[i]).Change(game.Player.Hand[i].Dice);
                    }
                }
                else if (dicePad.SpecialDice.Dice == Dice.Home)
                {
                    game.Player.GoHome();
                    MoveSprite(0, CurrentSprite);
                    DoAction();
                }
                else if (dicePad.SpecialDice.Dice == Dice.Atack)
                {
                    game.Player.AddLife(game.PlayerTurn == Game.Who.Player1 ? -Player1.Atack : -Player2.Atack);
                }
                else if (dicePad.SpecialDice.Dice == Dice.Quick_Atack)
                {
                    game.Player.Turns++;
                    game.Player.AddLife(game.PlayerTurn == Game.Who.Player1 ? -Player1.Atack : -Player2.Atack);
                }
                else if (dicePad.SpecialDice.Dice == Dice.SmallPotion)
                {
                    game.Player.AddLife(7);
                }
                else if (dicePad.SpecialDice.Dice == Dice.Quick_SmallPotion)
                {
                    game.Player.Turns++;
                    game.Player.AddLife(7);
                }
                else if (dicePad.SpecialDice.Dice == Dice.BigPotion)
                {
                    game.Player.AddLife(15);
                }
                else if (dicePad.SpecialDice.Dice == Dice.Stunt)
                {
                    game.Player.Stun();
                }
            }

            CurrentSprite.Deck.Controls.Remove(dicePad);
            game.Player.Hand.Remove(e);

            // Lock player
            if (game.Player.Position % 24 == game.Opponent.Position % 24)
            {
                var prisioner = game.PlayerTurn == Game.Who.Player2 ? game.Player : game.Opponent;

                if (game.Player.Position % 24 == 0 || game.Player.Position % 24 == 12)
                {
                    game.Player.Imprisioned = game.Player.Position % 24 != game.Player.InitialPosition;
                }
                else
                {
                    prisioner.Imprisioned = true;
                }
            }

            if (!game.Hunting) game.SwitchPlayers();

            UpdateScreenItems();

            game.AddDice();
        }

        // Increased possibility to get a sword!
        public void SpawnOnMove(int position)
        {
            if (position % 6 == 0) return;
            var x = rand.Get(0, 2) == 0 ? inventario.CreateItem(Drops.Sword) : inventario.CreateItem(GetRandomItem);
            ((BaseItem)x).Index = position;
            Controls.Add(x);
            PlaceItem(x, position);
        }

        public void SpawnInitialItems()
        {
            for (int i = 0; i < 24; i++)
            {
                var x = inventario.CreateItem(AtPosition(i));
                ((BaseItem)x).Index = i;
                Controls.Add(x);
                PlaceItem(x, i);
            }
        }

        private Drops AtPosition(int i)
        {
            Drops item;
            if (i == 0 || i == 12) item = Drops.Castle;
            else if (i == 6 || i == 18) item = Drops.Portal;
            else if (i < 12) { item = GetRandomItem; repeatItems.Enqueue(item); }
            else item = repeatItems.Dequeue();
            return item;
        }

        private Drops GetRandomItem => (Drops)rand.Get(2, game.TotalItems);
        //private Items GetRandomItem => Items.Monster1; // DEBUG

        private void PlaceItem(UserControl item, int pos)
        {
            var sq = board1.GetSquare(pos);

            item.Location = new Point(
                board1.Location.X + sq.Location.X + sq.Width / 2 - item.Width / 2,
                board1.Location.Y + sq.Location.Y + sq.Height / 2 - item.Height / 2);

            item.BringToFront();
        }

        private void DoAction()
        {
            foreach (var kk in Controls)
            {
                if (kk is UserControl control)
                {
                    if (kk is BaseItem x1)
                    {
                        if (x1.Index == game.Player.Position % 24)
                        {
                            label1.Text = x1.Do();

                            huntMonster1.Visible = false;

                            if (x1 is PortalItem)
                            {
                                MoveSprite(0, CurrentSprite);
                            }

                            if (x1 is BagItem)
                            {
                                var x = new Dice[] { Dice.DrawTwoDices, Dice.LockEven, Dice.LockOdd };
                                var r = rand.Get(0, x.Length);
                                game.TakeDice(x[r]);
                            }

                            if (x1 is BagTwoItem)
                            {
                                var x = new Dice[] { Dice.Stunt, Dice.Key, Dice.GoldenShield };
                                var r = rand.Get(0, x.Length);
                                game.TakeDice(x[r]);
                            }

                            if (x1 is BookOneItem)
                            {
                                // Level up
                                // Damage the opponent
                                // Get 20 coin
                            }

                            if (x1 is BookTwoItem)
                            {
                                // Move yourself to any square, but the same you are at
                                // Move the opponent to any square, but the same you are at
                                // Thunderbolt
                            }

                            if (x1 is MonsterOneItem)
                            {
                                huntMonster1.Visible = true;
                                huntMonster1.Dices = monsterS.GetDices(rand.Get(0, 2) == 1 ? 5 : 4);
                            }

                            if (x1 is MonsterTwoItem)
                            {
                                huntMonster1.Visible = true;
                                huntMonster1.Dices = monsterS.GetDices(rand.Get(0, 2) == 1 ? 3 : 2);
                            }

                            if (x1 is MonsterThreeItem)
                            {
                                huntMonster1.Visible = true;
                                huntMonster1.Dices = monsterS.GetDices(1);
                            }

                            UpdateScreenItems();

                            if (x1.Index % 6 != 0) Controls.Remove(control);

                            break;
                        }
                    }
                }
            }
        }

        private void UpdateScreenItems()
        {
            pictureBox2.Visible = pictureBox1.Visible = false;
            flowLayoutPanel1.Enabled = flowLayoutPanel2.Enabled = false;

            if (game.PlayerTurn == Game.Who.Player1)
            {
                pictureBox1.Visible = true;
                flowLayoutPanel1.Enabled = true;
            }
            if (game.PlayerTurn == Game.Who.Player2)
            {
                pictureBox2.Visible = true;
                flowLayoutPanel2.Enabled = true;
            }

            playerStatus1.Player = Player1;
            playerStatus2.Player = Player2;

            label2.Text = game.Turn.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Game.Who who = radioButton1.Checked ? Game.Who.Player1 : Game.Who.Player2;
            if (radioButton3.Checked) who = (Game.Who)rand.Get(0, 2);
            StartGame(who);
            UpdateScreenItems();
        }

        private void MoveSprite(int move, PlayerSprit item)
        {
            item.Player.Position += move;
            if (item.Player.LastPosition >= 0)
            {
                if (!game.PlayerLandedOnBase)
                    SpawnOnMove(item.Player.LastPosition);
            }
            item.Player.LastPosition = item.Player.Position;

            PlaceItem(item, item.Player.Position);

            if (game.PlayerLandedOnBase && game.Turn > 1)
            {
                game.Player.LandOnBase(game);
            }
        }
    }
}