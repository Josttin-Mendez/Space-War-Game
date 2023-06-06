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
    public partial class Setting : Form
    {
        public static int scoreJefe = 100;
        public Setting()
        {
            InitializeComponent();
            timer1.Start();
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
        private void button2_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals("") && int.Parse(textBox1.Text) > 5)
            {
                scoreJefe = int.Parse(textBox1.Text);
                MessageBox.Show("¡Score de aparición jefe Cambiado exitosamente!", "Cambio Score Jefe", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Form2 form2 = new Form2();
            form2.sonidoBoton();
            this.Close();
        }
    }
}
