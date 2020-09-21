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
        Player Player1 => game.GetPlayer(Game.Who.Player1);
        Player Player2 => game.GetPlayer(Game.Who.Player2);

        public Form1()
        {
            InitializeComponent();
            game = IOC.Resolve<Game>();
            rand = IOC.Resolve<RandomContext>();
            monsterS = IOC.Resolve<MonsterService>();
            game.DiceAdded += Game_DiceAdded;
        }

        private void Game_DiceAdded(object sender, Dice dice)
        {
            AddDice(CurrentSprite, dice);
        }

        protected override void OnLoad(EventArgs e)
        {
            StartGame(Game.Who.Player1);
        }

        private void StartGame(Game.Who who)
        {
            SpawnInitialItems();

            game.Start(who);

            PlayerTwoInit(); // Has to come first, otherwise, bug! LOL
            PlayerOneInit();

            game.AddDice();

            Controls.Remove(sprite1);
            Controls.Remove(sprite2);
            Controls.Add(sprite1);
            Controls.Add(sprite2);
            sprite1.BringToFront();
            sprite2.BringToFront();
            UpdateScreenItems();
        }

        private void PlayerOneInit()
        {
            sprite1 = new PlayerSprit
            {
                Deck = flowLayoutPanel1,
                BackgroundImage = Properties.Resources.superhero1
            };
            foreach (var item in Player1.Hand) AddDice(sprite1, item);
            Mov(Player1.Position, sprite1);
        }

        private void PlayerTwoInit()
        {
            sprite2 = new PlayerSprit
            {
                Deck = flowLayoutPanel2,
                BackgroundImage = Properties.Resources.superhero2
            };
            foreach (var item in Player2.Hand) AddDice(sprite2, item);
            Mov(Player2.Position, sprite2);
        }

        private void AddDice(PlayerSprit pv, Dice dice)
        {
            var d = new DiceView(dice);
            d.Clicked += Dice_Clicked;
            pv.Deck.Controls.Add(d);
        }

        private void Dice_Clicked(object sender, EventArgs e)
        {
            var obj = (DiceView)sender;

            // Avoid click out of turn
            if (obj.Parent == flowLayoutPanel1 && CurrentSprite != sprite1) return;
            if (obj.Parent == flowLayoutPanel2 && CurrentSprite != sprite2) return;

            var diceFace = obj.ThrowDice();

            if (diceFace.HasValue)
            {
                if (game.Hunting)
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

                    game.Hunting = false;
                    huntMonster1.Visible = game.Hunting;
                }
                else
                {
                    button1.Text = diceFace.ToString();
                    Mov(diceFace.Value, CurrentSprite);
                    DoAction();
                }
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

            CurrentSprite.Deck.Controls.Remove(obj);

            if (!game.Hunting) game.SwitchPlayers();

            UpdateScreenItems();

            game.AddDice();
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
                                game.AddDice(true);
                            }

                            if (x1 is MonsterTwoItem)
                            {
                                huntMonster1.Visible = true;
                                huntMonster1.SetDices(rand.Get(0, 2) == 1 ? 3 : 2);
                                game.Hunting = true;                                
                                game.AddDice(true);
                            }

                            if (x1 is MonsterThreeItem)
                            {
                                huntMonster1.Visible = true;
                                huntMonster1.SetDices(1);
                                game.Hunting = true;
                                game.AddDice(true);
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StartGame(Game.Who.Player1);
            UpdateScreenItems();
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