using System;
using System.Media;
using System.Windows;
using System.Windows.Input;
using System.IO;
using System.Threading;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Threading.Tasks;

namespace FunnyMemoryGame
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        bool start_game = false;
        int rounds = 0;
        int[] num = new int[1000];

        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < 1000; i++)
            {
                num[i] = random.Next(6);
            }
        }

        private void label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (start_game == false)
            {
                PlaySound("start.wav");
                SequentionAsync();
            }
        }
        async Task SequentionAsync()
        {
            label.Content = "Next round in: 2";
            //Application.DoEvents();
            await Task.Delay(2000);
            //Thread.Sleep(5000);
            label.Content = "Next round in: 1";
            //Thread.Sleep(1000);
            await Task.Delay(2000);
            label.Content = "Memory the sequention";
            rounds++;

            for (int i = 0; i < rounds; i++)
            {
                switch (num[i])
                {
                    case 1:
                        ChangeImage(p1, "p1a.bmp");
                        PlaySound("d1.wav");
                        break;
                    case 2:
                        ChangeImage(p2, "p2a.bmp");
                        PlaySound("d2.wav");
                        break;
                    case 3:
                        ChangeImage(p3, "p3a.bmp");
                        PlaySound("d3.wav");
                        break;
                    case 4:
                        ChangeImage(p4, "p4a.bmp");
                        PlaySound("d4.wav");
                        break;
                    case 5:
                        ChangeImage(p5, "p5a.bmp");
                        PlaySound("d5.wav");
                        break;
                    default:
                        break;
                }//switch
                //Thread.Sleep(1200);
                await Task.Delay(1200);
                ChangeImage(p1, "p1.bmp");
                ChangeImage(p2, "p2.bmp");
                ChangeImage(p3, "p3.bmp");
                ChangeImage(p4, "p4.bmp");
                ChangeImage(p5, "p5.bmp");
                //Thread.Sleep(100);
                await Task.Delay(200);
            }//for

            label.Content = "Repeat the sequention.";
        }
        void PlaySound(string name)
        {
            string path = Path.Combine(@"C:\Users\bklima\source\repos\FunnyMemoryGame\FunnyMemoryGame\Resources\", "Sounds", name);
            SoundPlayer sound = new SoundPlayer(path);
            sound.Load();
            sound.Play();
        }
        void ChangeImage(Image image, string imgName)
        {
            var uriSource = new Uri(@"Resources/Images/"+ imgName, UriKind.Relative);
            image.Source = new BitmapImage(uriSource);
        }
    }
}
