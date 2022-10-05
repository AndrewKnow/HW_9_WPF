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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ДЗ_9_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Task result { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {

            ImageDownloader imageDownloader = new ImageDownloader();

            imageDownloader.Begin += ImageDownloader_Begin;
            imageDownloader.Finish += ImageDownloader_Finish;

            // imageDownloader.Download();
            result = imageDownloader.DownloadAsync();


        }

        private void Status_Click(object sender, RoutedEventArgs e)
        {
            if (result.IsCompleted == true)
            {
                StatusTXT_Copy.Text = result.IsCompleted.ToString();
            }
            else
            {
                StatusTXT_Copy.Text = result.IsCompleted.ToString();
            }
        }

        private void ImageDownloader_Begin()
        {

            StatusTXT.Text = "Скачивание файла началось";


        }

        private void ImageDownloader_Finish()
        {

            StatusTXT.Text = "Скачивание файла закончилось";

        }
    }
}
