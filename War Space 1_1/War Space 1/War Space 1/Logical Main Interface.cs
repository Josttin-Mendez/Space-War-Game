using NAudio.Wave;
using System.Media;

namespace War_Space_1
{
    public partial class Form1 : Form
    {
        public static int[] score1 = new int[5];
        int score = 0, kill, vecesMuerto = 0, j = 0, numExtraido, numMayor, tirosAcertados = 0,
        scoreJefe = Setting.scoreJefe, musicBossReproducir = 0, cont = 0;
        bool bajar = false, disparoBoss = false, viewBoss = false, viewEnemy = false;
        Image skin = Properties.Resources.player;
        SoundPlayer musicaBossAparicion = new SoundPlayer(@"Sounds\purga.wav");
        SoundPlayer musicaFondo = new SoundPlayer(@"Sounds\Start.wav");
        SoundPlayer musicaVictoria = new SoundPlayer(@"Sounds\victoria.wav");

        public Form1()
        {
            Program.musicaFondoPlay.Stop();
            musicaVictoria.Stop();
            InitializeComponent();
            switch (Form4.naveSeleccionada)
            {
                case 1:
                    player.Image = Properties.Resources.player_1;
                    skin = Properties.Resources.player_1;
                    break;
                case 2:
                    player.Image = Properties.Resources.player_2;
                    skin = Properties.Resources.player_2;
                    break;
                case 3:
                    player.Image = Properties.Resources.player_3;
                    skin = Properties.Resources.player_3;
                    break;
                case 4:
                    player.Image = Properties.Resources.player_4;
                    skin = Properties.Resources.player_4;
                    break;
                case 5:
                    player.Image = Properties.Resources.player_5;
                    skin = Properties.Resources.player_5;
                    break;
                case 6:
                    player.Image = Properties.Resources.player_6;
                    skin = Properties.Resources.player_6;
                    break;
            }
            timer1.Start();
            musicaFondo.Play();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Bullet();
            Stars();
            Planets();

            if (score < scoreJefe)
            {
                disparoBoss = false;
                Enemy();
                Game_Result();
            }
            else
            {
                musicBossReproducir++;
                musicBoss(musicBossReproducir);
                if (cont == 0)
                {
                    Thread.Sleep(8000);
                }
                cont++;
                Boss();
                Game_Result();
            }
        }
        void Game_Result()
        {
            foreach (Control c in this.Controls)
            {
                if (!disparoBoss)
                {
                    if (c is PictureBox && c.Tag == "enemy")
                    {
                        if (bullet.Bounds.IntersectsWith(c.Bounds))
                        {
                            score += 5;
                            kill++;
                            lbl_kill.Text = "Kills : " + kill;
                            lbl_score.Text = "Score : " + score;
                            c.Left = 1500;
                            bullet.Image = Properties.Resources.explosion_img;
                        }
                        if (player.Bounds.IntersectsWith(c.Bounds))
                        {
                            musicaDestruccion();
                            ingresarScoreArray();
                            b_1.Visible = false;
                            gameOverShow();
                        }
                    }
                }
                else
                {
                    if (c is PictureBox && c.Tag == "boss")
                    {
                        if (bullet.Bounds.IntersectsWith(c.Bounds))
                        {
                            tirosAcertados++;
                            score += 8;
                            lbl_score.Text = "Score : " + score;
                            bullet.Image = Properties.Resources.explosion_img;
                            if (tirosAcertados >= 4)
                            {
                                score += 150;
                                musicaVictoria.Play();
                                b_1.Image = Properties.Resources.explosion_img;
                                kill++;
                                lbl_kill.Text = "Kills : " + kill;
                                ingresarScoreArray();
                                gameWinning();
                                timer1.Stop();
                            }
                        }
                        if (player.Bounds.IntersectsWith(c.Bounds))
                        {
                            visibleBoss(viewBoss = false);
                            musicaDestruccion();
                            ingresarScoreArray();
                            gameOverShow();
                        }
                    }
                }
            }
        }
        void Bullet()
        {
            bullet.Left += 100;
            if (bullet.Left > 600)
            {
                bullet.Image = Properties.Resources.bullet;
                bullet.Left = player.Left;
                bullet.Top = player.Top + 35;
            }
            if (!disparoBoss)
            {
                e_1_bullet.Left -= 25;

                if (e_1_bullet.Left < 0)
                {
                    e_1_bullet.Left = e_1.Left;
                    e_1_bullet.Top = e_1.Top + 25;
                }
                e_2_bullet.Left -= 25;
                if (e_2_bullet.Left < 0)
                {
                    e_2_bullet.Left = e_2.Left;
                    e_2_bullet.Top = e_2.Top + 25;
                }
                e_3_bullet.Left -= 25;
                if (e_3_bullet.Left < 0)
                {
                    e_3_bullet.Left = e_3.Left;
                    e_3_bullet.Top = e_3.Top + 25;
                }
            }
            else
            {
                b_1_bullet.Left -= 25;

                if (b_1_bullet.Left < 0)
                {
                    b_1_bullet.Left = b_1.Left - 5;
                    b_1_bullet.Top = b_1.Top + 50;
                }
                b_2_bullet.Left -= 25;

                if (b_2_bullet.Left < 0)
                {
                    b_2_bullet.Left = b_1.Left;
                    b_2_bullet.Top = b_1.Top + 100;
                }
                b_3_bullet.Left -= 25;

                if (b_3_bullet.Left < 0)
                {
                    b_3_bullet.Left = b_1.Left - 5;
                    b_3_bullet.Top = b_1.Top + 170;
                }
            }
        }
        void Enemy()
        {
            Random rnd = new Random();
            int a, b, c;
            e_1.Left -= 20;
            if (e_1.Left < 0)
            {
                a = rnd.Next(0, 200);
                e_1.Location = new Point(800, a);
            }
            e_2.Left -= 10;
            if (e_2.Left < 0)
            {
                b = rnd.Next(0, 400);
                e_2.Location = new Point(800, b);
            }
            e_3.Left -= 20;
            if (e_3.Left < 0)
            {
                c = rnd.Next(0, 500);
                e_3.Location = new Point(800, c);
            }

        }
        void Boss()
        {
            visibleBoss(viewBoss = true);
            disparoBoss = true;
            visibleEnemy(viewEnemy = false);
            b_1.Left -= 10;
            if (bajar == false)
            {
                b_1.Top -= 10;
            }
            if (b_1.Location.Y == -30)
            {
                bajar = true;
            }
            if (bajar)
            {
                b_1.Top += 10;
            }
            if (b_1.Location.Y == 180)
            {
                bajar = false;
            }
            if (b_1.Left < 0)
            {
                b_1.Location = new Point(800);
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (player.Top > 20)
                {
                    player.Top -= 5;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (player.Top < 350)
                {
                    player.Top += 5;
                }
            }
            if (e.KeyCode == Keys.Left)
            {
                if (player.Left > 20)
                {
                    player.Left -= 5;
                }
            }
            if (e.KeyCode == Keys.Right)
            {
                if (player.Left < 500)
                {
                    player.Left += 5;
                }
            }
        }
        private void exit_Click(object sender, EventArgs e)
        {
            musicBossReproducir = 0;
            musicaBossAparicion.Stop();
            musicaVictoria.Stop();
            Program.musicaFondoPlay.Play();

            Form3 Game = new Form3();
            Program.contexto.MainForm = Game;
            Game.Show();
            this.Hide();
        }
        void ResetGame()
        {
            cont = 0;
            musicaVictoria.Stop();
            musicBossReproducir = 0;
            musicaBossAparicion.Stop();
            musicaFondo.Play();
            b_1.Image = Image.FromFile("C:\\Users\\LENOVO\\Downloads\\War Space 1_1 (2)\\War Space 1_1\\War Space 1\\War Space 1\\Resources\\b_1.png");
            tirosAcertados = 0;
            score = 0;
            kill = 0;
            visibleBoss(viewBoss = false);
            visibleEnemy(viewEnemy = true);
            lbl_over.Visible = false;
            exit.Visible = false;
            play_again.Visible = false;
            lbl_kill.Text = "Kills : " + kill;
            lbl_score.Text = "Score : " + score;
            lbl_win.Visible = false;
            bullet.Left = player.Left;
            bullet.Top = player.Top + 35;
            player.Top = 180;
            player.Left = 50;
            player.Image = skin;
            this.KeyPreview = true;
            e_1.Location = new Point(800, 100);
            e_2.Location = new Point(1000, 200);
            e_3.Location = new Point(1200, 300);
            planet_1.Location = new Point(800, 150);
            planet_2.Location = new Point(1000, 250);
            b_1.Location = new Point(711, 100);
            b_1_bullet.Location = new Point(678, 140);
            b_2_bullet.Location = new Point(711, 200);
            b_3_bullet.Location = new Point(678, 260);
            e_1_bullet.Left = e_1.Left;
            e_1_bullet.Top = e_1.Top + 25;
            e_2_bullet.Left = e_2.Left;
            e_2_bullet.Top = e_2.Top + 25;
            e_3_bullet.Left = e_3.Left;
            e_3_bullet.Top = e_3.Top + 25;
            e_1.Location = new Point(800, 100);
            e_2.Location = new Point(1000, 200);
            e_3.Location = new Point(1200, 300);
            timer1.Start();
        }
        private void play_again_Click(object sender, EventArgs e)
        {
            ResetGame();
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
        void Planets()
        {
            Random rnd = new Random();
            int x, y;
            planet_1.Left -= 2;
            if (planet_1.Left < 0)
            {
                x = rnd.Next(0, 348);
                planet_1.Location = new Point(800, x);
            }
            planet_2.Left -= 2;
            if (planet_2.Left < 0)
            {
                y = rnd.Next(0, 500);
                planet_2.Location = new Point(700, y);
            }
        }
        public void musicaDestruccion()
        {
            musicaFondo.Stop();
            var buttonSound = new AudioFileReader(@"Sounds\End.wav");
            var volumen = 0.2f;
            var waveCanal = new WaveChannel32(buttonSound);
            waveCanal.Volume = volumen;

            var buttonSoundPlayer = new WaveOutEvent();
            buttonSoundPlayer.Init(waveCanal);
            buttonSoundPlayer.Play();
        }
        public void ingresarScoreArray()
        {
            numMayor = score1[0];
            j = 0;
            if (vecesMuerto <= 4)
            {
                score1[vecesMuerto] = score;
                compararaNumeros();
            }
            else
            {
                if (score > score1[4])
                {
                    score1[4] = score;
                }
                compararaNumeros();
            }
        }
        public void compararaNumeros()
        {
            numMayor = score1[0];
            while (j < 5)
            {
                if (numMayor >= score1[j])
                {
                    numMayor = score1[j];
                }
                else
                {
                    if (numMayor < score1[j] && j != 0)
                    {
                        numExtraido = score1[j - 1];
                        score1[j - 1] = score1[j];
                        score1[j] = numExtraido;
                        numMayor = score1[j - 1];

                        j = 0;
                        continue;
                    }
                }
                j++;
            }
        }
        public void visibleBoss(bool viewBoss)
        {
            var controls = this.Controls.Cast<Control>()
                  .Where(c => c.Tag != null && c.Tag.ToString() == "boss")
                  .ToList();
            foreach (Control control in controls)
            {
                if (viewBoss)
                {
                    control.Visible = true;
                    control.Enabled = true;
                }
                else
                {
                    disparoBoss = false;
                    control.Visible = false;
                    control.Enabled = false;
                }
            }
        }
        public void visibleEnemy(bool enemy)
        {
            var controls = this.Controls.Cast<Control>()
                  .Where(c => c.Tag != null && c.Tag.ToString() == "enemy")
                  .ToList();

            foreach (Control control in controls)
            {
                if (enemy)
                {
                    control.Visible = true;
                    control.Enabled = true;
                }
                else
                {
                    control.Visible = false;
                    control.Enabled = false;
                }
            }
        }
        public void gameOverShow()
        {
            player.Image = Properties.Resources.explosion_img;
            vecesMuerto++;
            lbl_over.Visible = true;
            exit.Visible = true;
            play_again.Visible = true;
            Record record = new Record();
            record.Show();
            timer1.Stop();
        }
        public void gameWinning()
        {
            lbl_win.Visible = true;
            exit.Visible = true;
            play_again.Visible = true;
            Record record = new Record();
            record.Show();
            timer1.Stop();
        }
        public void musicBoss(int musica)
        {
            if (musica == 1)
            {
                musicaFondo.Stop();
                musicaBossAparicion.Play();
            }
        }
    }
}