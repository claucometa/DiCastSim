using DiCastSim.Core;
using DiCastSim.Core.Enums;
using DiCastSim.Core.Models;
using DiCastSim.Core.Services;
using DiCastSim.Envirolment;
using DiCastSim.Objects;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DiCastSim
{
    public partial class Form1 : Form
    {
        PlayerSprit sprite1, sprite2;
        PlayerSprit CurrentSprite => game.PlayerTurn == Game.Who.Player1 ? sprite1 : sprite2;
        readonly LinkItem linkedItem = new LinkItem();
        readonly RandomContext rand;
        readonly Game game;
        readonly MonsterService monsterS;
        Player player1 => game.GetPlayer(Game.Who.Player1);
        Player player2 => game.GetPlayer(Game.Who.Player2);

        public Form1()
        {
            InitializeComponent();
            game = IOC.Resolve<Game>();
            rand = IOC.Resolve<RandomContext>();
            monsterS = IOC.Resolve<MonsterService>();
        }

        protected override void OnLoad(EventArgs e)
        {
            StartGame(Game.Who.Player1);
        }

        private void StartGame(Game.Who who)
        {
            SpawnInitialItems();

            game.Start(who);

            if (who == Game.Who.Player1)
            {
                PlayerTwoInit();
                PlayerOneInit();
                AddDice(sprite1);
            }
            else
            {
                PlayerOneInit();
                PlayerTwoInit();
                AddDice(sprite2);
            }

            SwitchPlayers();

            Controls.Remove(sprite1);
            Controls.Remove(sprite2);
            Controls.Add(sprite1);
            Controls.Add(sprite2);
            sprite1.BringToFront();
            sprite2.BringToFront();
            UpdateStatus();
        }

        private void PlayerOneInit()
        {
            sprite1 = new PlayerSprit
            {
                deck = flowLayoutPanel1,
                BackgroundImage = Properties.Resources.superhero1
            };
            sprite1.deck.Controls.Clear();
            foreach (var item in player1.SpecialDices) AddDice(sprite1, item);
            player1.GoHome();
            Mov(0, sprite1);
        }

        private void PlayerTwoInit()
        {
            sprite2 = new PlayerSprit
            {
                deck = flowLayoutPanel2,
                BackgroundImage = Properties.Resources.superhero2
            };
            sprite2.deck.Controls.Clear();
            foreach (var item in player2.SpecialDices) AddDice(sprite2, item);
            player2.GoHome();
            Mov(12, sprite2);
        }

        private void AddDice(PlayerSprit pv, Dice dice)
        {
            var d = new DiceView(dice);
            d.Clicked += Dice_Clicked;
            pv.deck.Controls.Add(d);
        }

        private void AddDice(PlayerSprit pv, bool forceNumber = false)
        {
            if (forceNumber)
                game.Player.Hand.GetNumberDice();
            else
                game.Player.Hand.GetNextDice();

            var dice = game.Player.Hand.Last();

            AddDice(pv, dice);
        }

        private void Dice_Clicked(object sender, EventArgs e)
        {
            var obj = (DiceView)sender;

            // Avoid click out of turn
            if (obj.Parent == flowLayoutPanel1 && CurrentSprite != sprite1) return;
            if (obj.Parent == flowLayoutPanel2 && CurrentSprite != sprite2) return;

            var diceFace = obj.ThrowDice();

            if (game.Hunting && diceFace.HasValue)
            {
                // Evita numeros negativos
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

                huntMonster1.Visible = false;

                CurrentSprite.deck.Controls.Remove(obj);

                SwitchPlayers();

                game.Hunting = false;

                UpdateStatus();
                AddDice(CurrentSprite);
                return;
            }

            if (diceFace.HasValue)
            {
                button1.Text = diceFace.ToString();
                Mov(diceFace.Value, CurrentSprite);
                DoAction();
            }
            else
            {
                if (obj.SpecialDice == Dice.Home)
                {
                    game.Player.GoHome();
                    Mov(0, CurrentSprite);
                    DoAction();
                }
                else if (obj.SpecialDice == Dice.SmallPotion)
                {
                    game.Player.AddLife(7);
                }
                else if (obj.SpecialDice == Dice.BigPotion)
                {
                    game.Player.AddLife(15);
                }
                else if (obj.SpecialDice == Dice.Stunt)
                {
                    game.Player.Stun();
                }
            }

            CurrentSprite.deck.Controls.Remove(obj);

            if (!game.Hunting) SwitchPlayers();

            UpdateStatus();
            AddDice(CurrentSprite);
        }

        private void SwitchPlayers()
        {
            pictureBox2.Visible = pictureBox1.Visible = false;
            flowLayoutPanel1.Enabled = flowLayoutPanel2.Enabled = false;

            game.SwitchPlayers();

            if (game.Player == game.GetPlayer(Game.Who.Player1))
            {
                pictureBox1.Visible = true;
                flowLayoutPanel1.Enabled = true;
            }
            if (game.Player == game.GetPlayer(Game.Who.Player2))
            {
                pictureBox2.Visible = true;
                flowLayoutPanel2.Enabled = true;
            }
        }

        public void SpawnOnMove(int position)
        {
            if (position % 6 == 0) return;
            var x = CreateItem(CreateRandomItem());
            ((BaseItem)x).Index = position;
            Controls.Add(x);
            Move(x, position);
        }

        public void SpawnInitialItems()
        {
            Items item;

            for (int i = 0; i < 24; i++)
            {
                if (i == 0 || i == 12) item = Items.Castle;
                else if (i == 6 || i == 18) item = Items.Portal;
                else item = CreateRandomItem();

                var x = CreateItem(item);

                if (i == 0) ((CastleItem)x).Owner = game.GetPlayer(Game.Who.Player1);
                if (i == 12) ((CastleItem)x).Owner = game.GetPlayer(Game.Who.Player2);

                ((BaseItem)x).Index = i;
                Controls.Add(x);
                Move(x, i);
            }
        }

        private Items CreateRandomItem() => (Items)rand.Get(2, game.TotalItems);

        private UserControl CreateItem(Items item) =>
            (UserControl)Activator.CreateInstance(linkedItem[item]);

        private new void Move(UserControl item, int pos)
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

                            if (x1 is MonsterOneItem)
                            {
                                huntMonster1.Visible = true;
                                huntMonster1.SetDices(rand.Get(0, 2) == 1 ? 5 : 4);
                                game.Hunting = true;
                                AddDice(CurrentSprite, true);
                            }

                            if (x1 is MonsterTwoItem)
                            {
                                huntMonster1.Visible = true;
                                huntMonster1.SetDices(rand.Get(0, 2) == 1 ? 3 : 2);
                                game.Hunting = true;
                                AddDice(CurrentSprite, true);
                            }

                            if (x1 is MonsterThreeItem)
                            {
                                huntMonster1.Visible = true;
                                huntMonster1.SetDices(1);
                                game.Hunting = true;
                                AddDice(CurrentSprite, true);
                            }

                            UpdateStatus();

                            if (x1.Index % 6 != 0) Controls.Remove(control);

                            break;
                        }
                    }
                }
            }
        }

        private void UpdateStatus()
        {
            playerStatus1.Player = game.GetPlayer(Game.Who.Player1);
            playerStatus2.Player = game.GetPlayer(Game.Who.Player2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StartGame(Game.Who.Player1);
            UpdateStatus();
        }

        private void Mov(int move, PlayerSprit item)
        {
            game.Player.Position += move;
            if (game.Player.LastPosition >= 0)
            {
                if (!new int[] { 0, 12, 18 }.Contains(game.Player.LastPosition % 24))
                {
                    SpawnOnMove(game.Player.LastPosition);
                }
            }
            game.Player.LastPosition = game.Player.Position;

            Move(item, game.Player.Position);
        }
    }
}