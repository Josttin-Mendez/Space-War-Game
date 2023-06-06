using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace War_Space_1
{
    public partial class Form3 : Form
    {
        public Form3()
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
        private void timer1_Tick(object sender, EventArgs e)
        {
            Stars();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.sonidoBoton();
            Record form = new Record();
            form.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.sonidoBoton();

            Form1 Game = new Form1();
            Program.contexto.MainForm = Game;
            Game.Show();
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.sonidoBoton();

            Setting Game = new Setting();
            Game.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.sonidoBoton();

            Form4 ship = new Form4();
            Program.contexto.MainForm = ship;
            ship.Show();
            this.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.sonidoBoton();

            DialogResult result = MessageBox.Show("¿Seguro que desea salir?", "KillProgram", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
