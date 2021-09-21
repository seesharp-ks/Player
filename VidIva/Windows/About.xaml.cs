using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VidIva.Windows
{
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
            Description.Text = "Программа 'Видеоплеер'\n" +
                "Курсовая работа по теме №19.\"Разработка мобильного приложения «Видеопроигрыватель».\"\n" +
                "Начало: 20.09.2021\n" +
                "Версия:\t09.2021\n" +
                "Разработал:\tИванов А.А.\n" +
                "Руководитель:\tТокарь И.А.\n" +
                "Колледж связи №54 - 2021";
        }

        private void Accept_Click(object sender, RoutedEventArgs e) { this.Close(); }
    }
}