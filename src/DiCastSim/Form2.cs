using DiCastSim.Core.Enums;
using DiCastSim.Core.Models;
using System;
using System.Windows.Forms;

namespace DiCastSim
{
    public partial class Form2 : Form
    {
        public Skills skill;

        public Form2(Player x)
        {
            InitializeComponent();

            button1.Enabled = x.Skill[Skills.One].Level < 3;
            button2.Enabled = x.Skill[Skills.Two].Level < 3;
            button3.Enabled = x.Skill[Skills.Three].Level < 3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            skill = Skills.One;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            skill = Skills.Two;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            skill = Skills.Three;
            this.Close();
        }
    }
}
