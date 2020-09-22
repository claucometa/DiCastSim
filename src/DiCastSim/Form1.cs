﻿using DiCastSim.Core;
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
            SetPlayer(Sprite1);
            SetPlayer(Sprite2);
            UpdateScreenItems();
            game.AddDice();
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
            if (obj.Parent == flowLayoutPanel1 && CurrentSprite != Sprite1) return;
            if (obj.Parent == flowLayoutPanel2 && CurrentSprite != Sprite2) return;

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
                    MoveSprite(diceFace.Value, CurrentSprite);
                    DoAction();
                }
            }
            else
            {
                if (obj.SpecialDice == Dice.Home)
                {
                    game.Player.GoHome();
                    MoveSprite(0, CurrentSprite);
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
            var x = inventario.CreateItem(GetRandomItem);
            ((BaseItem)x).Index = position;
            Controls.Add(x);
            PlaceItem(x, position);
        }

        public void SpawnInitialItems()
        {
            for (int i = 0; i < 24; i++)
            {
                var x = inventario.CreateItem(CreateAllItems(i));
                ((BaseItem)x).Index = i;
                Controls.Add(x);
                PlaceItem(x, i);
            }
        }

        private Items CreateAllItems(int i)
        {
            Items item;
            if (i == 0 || i == 12) item = Items.Castle;
            else if (i == 6 || i == 18) item = Items.Portal;
            else item = GetRandomItem;
            return item;
        }

        private Items GetRandomItem => (Items)rand.Get(2, game.TotalItems);

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

        private void MoveSprite(int move, PlayerSprit item)
        {
            item.Player.Position += move;
            if (item.Player.LastPosition >= 0)
            {
                if (!new int[] { 0, 12, 18 }.Contains(item.Player.LastPosition % 24))
                {
                    SpawnOnMove(item.Player.LastPosition);
                }
            }
            item.Player.LastPosition = item.Player.Position;

            PlaceItem(item, item.Player.Position);
        }
    }
}