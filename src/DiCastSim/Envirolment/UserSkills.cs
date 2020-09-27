using DiCastSim.Core.Enums;
using DiCastSim.Core.Models;
using System.Windows.Forms;

namespace DiCastSim
{
    public partial class UserSkills : UserControl
    {
        public UserSkills()
        {
            InitializeComponent();
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
        }

        public Player Player
        {
            set
            {
                var x = value;
                label1.Text = x.Skill[Skills.One].Level.ToString();
                label2.Text = x.Skill[Skills.Two].Level.ToString();
                label3.Text = x.Skill[Skills.Three].Level.ToString();
            }
        }
    }
}
