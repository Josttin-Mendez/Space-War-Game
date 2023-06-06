using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace War_Space_1
{
    public partial class Record : Form
    {
        public Record()
        {
            InitializeComponent();
            timer1.Start();
            compararScores();
        }
        void Stars()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "star")
                {
                    x.Left -= 5;
                    if (x.Left < 0)
                    {
                        x.Left = 800;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.sonidoBoton();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Stars();
        }

        private void compararScores()
        {
            label8.Text = Form1.score1[0].ToString();
            label12.Text = Form1.score1[1].ToString();
            label16.Text = Form1.score1[2].ToString();
            label20.Text = Form1.score1[3].ToString();
            label24.Text = Form1.score1[4].ToString();
        }
    }
}
