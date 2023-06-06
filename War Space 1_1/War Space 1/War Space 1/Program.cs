using NAudio.Wave;
using System.Media;

namespace War_Space_1
{
    internal static class Program
    {
        static public ApplicationContext contexto;

        private static AudioFileReader musicaFondo;
        public static WaveOutEvent musicaFondoPlay;


        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            musicaFondo = new AudioFileReader(@"Sounds\Start.wav");
            var volumen = 0.8f;
            var waveCanal = new WaveChannel32(musicaFondo);
            waveCanal.Volume = volumen;

            musicaFondoPlay = new WaveOutEvent();
            musicaFondoPlay.Init(waveCanal);
            musicaFondoPlay.Play();

            // Reproducir el sonido en segundo plano

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            contexto = new ApplicationContext(new Form2());
            Application.Run(contexto);

        }
    }
}