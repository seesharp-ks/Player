using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Threading;
using VidIva.Windows;

namespace VidIva
{
    public partial class MainWindow : Window
    {
        public MainWindow()
		{
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer{ Interval = TimeSpan.FromSeconds(1) };
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (Player.Source != null)
            {
                if (Player.NaturalDuration.HasTimeSpan)
                    Status.Content = String.Format("{0} / {1}", Player.Position.ToString(@"mm\:ss"), Player.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
            }
            else
                Status.Content = "Плеер неактивен...";
        }

        private void Play_Click(object sender, RoutedEventArgs e){Player.Play();}
        private void Pause_Click(object sender, RoutedEventArgs e) {Player.Pause();}
        private void Stop_Click(object sender, RoutedEventArgs e) {Player.Stop();}

        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) //изменение значения слайдера звука
        {
            if (Player != null)
                Player.Volume = VolumeSlider.Value;
        }

        private void SlowDown_Click(object sender, RoutedEventArgs e)
        {
            if (Player.SpeedRatio > 0)
                Player.SpeedRatio -= 0.25;  //замедление воспроизведения
            UpdateMultiplier(Player.SpeedRatio);
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            Player.SpeedRatio = 1;  //сброс скорости
            UpdateMultiplier(Player.SpeedRatio);
        }

        private void SpeedUp_Click(object sender, RoutedEventArgs e)
        {
            if (Player.SpeedRatio < 4)  //ускорение
                Player.SpeedRatio += 0.25;
            UpdateMultiplier(Player.SpeedRatio);
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog  //инициализация диалогового окна открытия файла
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),//dialog.InitialDirectory = @"c:\\";
                Filter = "Видеофайлы (*.mp4,*.wmv)|*.mp4;*.wmv|Аудиофайлы(*.mp3, *.wav, *.aac) | *.mp3; *.wav; *.aac ",//|Все файлы (*.*)|*.*
                RestoreDirectory = true
            };

            if (dialog.ShowDialog() == true)
            {
                Player.Source = new Uri(dialog.FileName);
                Player.Play();
            }
        }

        private void ExitProgram_Click(object sender, RoutedEventArgs e)    //нажатие на выход
        {
            Application.Current.Shutdown();
        }

        private void AboutProgram_Click(object sender, RoutedEventArgs e)   //нажатие на справку
        {
            About about = new About{ Owner = this };
            about.Show();
        }

        public void UpdateMultiplier(double ratio)  //изменение текста множителя скорости воспроизведения видео
        {
            this.Multiplier.Content = "×" + ratio;
        }
    }
}
