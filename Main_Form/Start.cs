using GameTesting;
using study;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using teamproject;

namespace team9_wm
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SuikaGame form = new SuikaGame();
            form.Owner = this;
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tetris form = new Tetris();
            form.Owner = this;
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pyramid form = new pyramid();
            form.Owner = this;
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            omok form = new omok();
            form.Owner = this;
            form.Show();
        }
    }
}
