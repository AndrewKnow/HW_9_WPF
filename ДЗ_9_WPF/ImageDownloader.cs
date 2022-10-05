using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;



namespace ДЗ_9_WPF
{
    public delegate void ImageStarted();
    public delegate void ImageCompleted();

    public class ImageDownloader
    {

        public event ImageStarted Begin;
        public event ImageCompleted Finish;

        public void Download()
        {

            if (Begin != null)
            {
                Begin();
            }

            // Откуда будем качать
            string remoteUri = "https://effigis.com/wp-content/uploads/2015/02/Iunctus_SPOT5_5m_8bit_RGB_DRA_torngat_mountains_national_park_8bits_1.jpg";
            // Как назовем файл на диске
            string fileName = "bigimage.jpg";

            // Качаем картинку в текущую директорию
            var myWebClient = new WebClient();
            Console.WriteLine("Качаю \"{0}\" из \"{1}\" .......\n\n", fileName, remoteUri);

            myWebClient.DownloadFile(remoteUri, fileName);

            Console.WriteLine("Успешно скачал \"{0}\" из \"{1}\"", fileName, remoteUri);

            if (Finish != null)
            {
                Finish();
            }

        }

        public async Task DownloadAsync()
        {

            if (Begin != null)
            {
                Begin();
            }

            string remoteUri = "https://effigis.com/wp-content/uploads/2015/02/Iunctus_SPOT5_5m_8bit_RGB_DRA_torngat_mountains_national_park_8bits_1.jpg";
            string fileName = "bigimage.jpg";
            var myWebClient = new WebClient();

            Console.WriteLine("Качаю асинхронно \"{0}\" из \"{1}\" .......\n\n", fileName, remoteUri);

            await myWebClient.DownloadFileTaskAsync(remoteUri, fileName);

            Console.WriteLine("Успешно скачал асинхронно\"{0}\" из \"{1}\"", fileName, remoteUri);


            if (Finish != null)
            {
                Finish();
            }

        }


    }
}
