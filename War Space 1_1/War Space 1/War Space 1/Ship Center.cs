using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using NAudio.Wave;

namespace War_Space_1
{
    public partial class Form4 : Form
    {
        public static int naveSeleccionada;
        bool seleccion = false;
        public Form4()
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
        private void pictureBox16_Click(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Stars();
        }

        private void player_1_Click(object sender, EventArgs e)
        {
            var buttonSound = new AudioFileReader(@"Sounds\Ship_1.wav");
            var buttonSoundPlayer = new WaveOutEvent();
            buttonSoundPlayer.Init(buttonSound);
            buttonSoundPlayer.Play();

            naveSeleccionada = 1;
            player_1.BorderStyle = BorderStyle.Fixed3D;
            player_2.BorderStyle = BorderStyle.None;
            player_3.BorderStyle = BorderStyle.None;
            player_4.BorderStyle = BorderStyle.None;
            player_5.BorderStyle = BorderStyle.None;
            player_6.BorderStyle = BorderStyle.None;
            SoundPlayer music = new SoundPlayer();
            music.SoundLocation = @"";
            music.Play();
            seleccion = true;
        }

        private void player_2_Click(object sender, EventArgs e)
        {
            var buttonSound = new AudioFileReader(@"Sounds\Ship_2.wav");
            var buttonSoundPlayer = new WaveOutEvent();
            buttonSoundPlayer.Init(buttonSound);
            buttonSoundPlayer.Play();

            naveSeleccionada = 2;
            player_1.BorderStyle = BorderStyle.None;
            player_2.BorderStyle = BorderStyle.Fixed3D;
            player_3.BorderStyle = BorderStyle.None;
            player_4.BorderStyle = BorderStyle.None;
            player_5.BorderStyle = BorderStyle.None;
            player_6.BorderStyle = BorderStyle.None;
            SoundPlayer music2 = new SoundPlayer();
            music2.SoundLocation = @"";
            music2.Play();
        }

        private void player_3_Click(object sender, EventArgs e)
        {
            var buttonSound = new AudioFileReader(@"Sounds\Ship_3.wav");
            var buttonSoundPlayer = new WaveOutEvent();
            buttonSoundPlayer.Init(buttonSound);
            buttonSoundPlayer.Play();

            naveSeleccionada = 3;
            player_1.BorderStyle = BorderStyle.None;
            player_2.BorderStyle = BorderStyle.None;
            player_3.BorderStyle = BorderStyle.Fixed3D;
            player_4.BorderStyle = BorderStyle.None;
            player_5.BorderStyle = BorderStyle.None;
            player_6.BorderStyle = BorderStyle.None;
            SoundPlayer music3 = new SoundPlayer();
            music3.SoundLocation = @"";
            music3.Play();
        }

        private void player_4_Click(object sender, EventArgs e)
        {
            var buttonSound = new AudioFileReader(@"Sounds\Ship_4.wav");
            var buttonSoundPlayer = new WaveOutEvent();
            buttonSoundPlayer.Init(buttonSound);
            buttonSoundPlayer.Play();

            naveSeleccionada = 4;
            player_1.BorderStyle = BorderStyle.None;
            player_2.BorderStyle = BorderStyle.None;
            player_3.BorderStyle = BorderStyle.None;
            player_4.BorderStyle = BorderStyle.Fixed3D;
            player_5.BorderStyle = BorderStyle.None;
            player_6.BorderStyle = BorderStyle.None;
            SoundPlayer music4 = new SoundPlayer();
            music4.SoundLocation = @"";
            music4.Play();
        }

        private void player_5_Click(object sender, EventArgs e)
        {
            var buttonSound = new AudioFileReader(@"C:\Users\LENOVO\Downloads\War Space 1_1 (2)\War Space 1_1\War Space 1\War Space 1\Sounds\Ship_5.wav");
            var buttonSoundPlayer = new WaveOutEvent();
            buttonSoundPlayer.Init(buttonSound);
            buttonSoundPlayer.Play();

            naveSeleccionada = 5;
            player_1.BorderStyle = BorderStyle.None;
            player_2.BorderStyle = BorderStyle.None;
            player_3.BorderStyle = BorderStyle.None;
            player_4.BorderStyle = BorderStyle.None;
            player_5.BorderStyle = BorderStyle.Fixed3D;
            player_6.BorderStyle = BorderStyle.None;
            SoundPlayer music5 = new SoundPlayer();
            music5.SoundLocation = @"";
            music5.Play();
        }

        private void player_6_Click(object sender, EventArgs e)
        {
            var buttonSound = new AudioFileReader(@"Sounds\Ship_6.wav");
            var buttonSoundPlayer = new WaveOutEvent();
            buttonSoundPlayer.Init(buttonSound);
            buttonSoundPlayer.Play();

            naveSeleccionada = 6;
            player_1.BorderStyle = BorderStyle.None;
            player_2.BorderStyle = BorderStyle.None;
            player_3.BorderStyle = BorderStyle.None;
            player_4.BorderStyle = BorderStyle.None;
            player_5.BorderStyle = BorderStyle.None;
            player_6.BorderStyle = BorderStyle.Fixed3D;
            SoundPlayer music6 = new SoundPlayer();
            music6.SoundLocation = @"";
            music6.Play();
        }

        private void player_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.sonidoBoton();

            Form1 Game = new Form1();
            Program.contexto.MainForm = Game;
            Game.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.sonidoBoton();

            Form3 Game = new Form3();
            Program.contexto.MainForm = Game;
            Game.Show();
            this.Hide();
        }
    }
}
