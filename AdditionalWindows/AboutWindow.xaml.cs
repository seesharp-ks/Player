using System.Windows;

namespace NovemberPlayer.AdditionalWindows
{
    /// <summary>
    /// Логика взаимодействия для AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();
            Description.Text = "Программа 'Видеоплеер'\n" +
                "Курсовая работа по теме №19.\"Разработка мобильного приложения «Видеопроигрыватель».\"\n" +
                "Начало: 20.09.2021\n" +
                "Версия:\t11.2021\n" +
                "Разработал:\tИванов А.А.\n" +
                "Руководитель:\tТокарь И.А.\n" +
                "Колледж связи №54 - 2021";
        }//палитра https://lospec.com/palette-list/2-bit-blue

        private void Accept_Click(object sender, RoutedEventArgs e) { this.Close(); }
    }
}
