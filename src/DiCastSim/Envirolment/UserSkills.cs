using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiCastSim.Core.Models;

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
                label1.Text = x.Skill1.ToString();
                label2.Text = x.Skill2.ToString();
                label3.Text = x.Skill3.ToString();

            }
        }
    }
}
