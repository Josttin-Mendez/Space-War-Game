using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;

namespace War_Space_1
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
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
            Form2 sonido = new Form2();
            sonido.sonidoBoton();

            History_2 Game = new History_2();
            Program.contexto.MainForm = Game;
            Game.Show();
            this.Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Stars();
        }
    }
}
