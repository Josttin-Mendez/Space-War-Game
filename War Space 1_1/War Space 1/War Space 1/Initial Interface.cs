using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NAudio.Wave;


namespace War_Space_1
{
    public partial class Form2 : Form
    {



        public Form2()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sonidoBoton();
            Form7 form1 = new Form7();
            Program.contexto.MainForm = form1;
            form1.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        public void sonidoBoton()
        {
            var buttonSound = new AudioFileReader(@"Sounds\Click.wav");
            var volumen = 0.2f;
            var waveCanal = new WaveChannel32(buttonSound);
            waveCanal.Volume = volumen;

            var buttonSoundPlayer = new WaveOutEvent();
            buttonSoundPlayer.Init(waveCanal);
            buttonSoundPlayer.Play();
        }
    }
}

