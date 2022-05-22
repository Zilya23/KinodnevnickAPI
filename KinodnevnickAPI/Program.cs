using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Windows.UI.Xaml.Media.Imaging;
using System.Drawing.Imaging;
using System.Drawing;

namespace KinodnevnickAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "https://cloud-api.kinopoisk.dev/movies/44795/token/aab8f9c6d8117d06a9f8858f39cec7a5";

            var request = WebRequest.Create(url);

            var response = request.GetResponse();
            var httpStatusCode = (response as HttpWebResponse).StatusCode;

            if (httpStatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine(httpStatusCode);
                return;
            }

            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                var news = JsonConvert.DeserializeObject<Root>(result);
                
                var date_usue = news.premiere_world.Split(' ');
                string mounth = date_usue[1];
                DateTime dateTime = new DateTime();
                if (mounth == "января")
                {
                    dateTime = new DateTime(Convert.ToInt32(date_usue[2]), 1, Convert.ToInt32(date_usue[0]));
                }
                else if(mounth == "февраля")
                {
                    dateTime = new DateTime(Convert.ToInt32(date_usue[2]), 2, Convert.ToInt32(date_usue[0]));
                }
                else if(mounth == "марта")
                {
                    dateTime = new DateTime(Convert.ToInt32(date_usue[2]), 3, Convert.ToInt32(date_usue[0]));
                }
                else if (mounth == "апреля")
                {
                    dateTime = new DateTime(Convert.ToInt32(date_usue[2]), 4, Convert.ToInt32(date_usue[0]));
                }
                else if (mounth == "мая")
                {
                    dateTime = new DateTime(Convert.ToInt32(date_usue[2]), 5, Convert.ToInt32(date_usue[0]));
                }
                else if (mounth == "июня")
                {
                    dateTime = new DateTime(Convert.ToInt32(date_usue[2]), 6, Convert.ToInt32(date_usue[0]));
                }
                else if (mounth == "июля")
                {
                    dateTime = new DateTime(Convert.ToInt32(date_usue[2]), 7, Convert.ToInt32(date_usue[0]));
                }
                else if (mounth == "августа")
                {
                    dateTime = new DateTime(Convert.ToInt32(date_usue[2]), 8, Convert.ToInt32(date_usue[0]));
                }
                else if (mounth == "сентября")
                {
                    dateTime = new DateTime(Convert.ToInt32(date_usue[2]), 9, Convert.ToInt32(date_usue[0]));
                }
                else if (mounth == "октября")
                {
                    dateTime = new DateTime(Convert.ToInt32(date_usue[2]), 10, Convert.ToInt32(date_usue[0]));
                }
                else if (mounth == "ноября")
                {
                    dateTime = new DateTime(Convert.ToInt32(date_usue[2]), 11, Convert.ToInt32(date_usue[0]));
                }
                else if (mounth == "декабря")
                {
                    dateTime = new DateTime(Convert.ToInt32(date_usue[2]), 12, Convert.ToInt32(date_usue[0]));
                }
                else
                {
                    dateTime = new DateTime(Convert.ToInt32(date_usue[2]), 1, Convert.ToInt32(date_usue[0]));
                }
                //string der = "";
                //foreach (var i in news.collapse.duration)
                //{
                //    var dura = i.Split(' ');
                //    der = dura[0];
                //}
                Film film = new Film();
                film.Name = news.title;
                film.Description = news.description;
                film.Date_Issue = dateTime;
                //film.Duration = Convert.ToInt32(der);
                

                string path = @"C:\Users\Зилязавр\img\" + news.id.ToString() + ".jpg";
                Console.WriteLine(path);
                Console.WriteLine(news.poster);
                var uril = "https://images.kinopoisk.dev/posters/1143242.jpg";

                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadFile(uril, path);
                }
                film.Poster = File.ReadAllBytes(path);
                bd_connection.connection.Film.Add(film);
                bd_connection.connection.SaveChanges();

                Console.WriteLine('.');
                Console.WriteLine('.');
                Console.WriteLine(film.Name);
                Console.WriteLine(film.Date_Issue);
                Console.WriteLine(film.Description);
                Console.WriteLine(film.Duration);
                Console.ReadKey();

            }
        }

        public void SaveImage(string imageUrl, string filename, ImageFormat format)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(imageUrl);
            Bitmap bitmap; 
            bitmap = new Bitmap(stream);

            if (bitmap != null)
            {
                bitmap.Save(filename, format);
            }

            stream.Flush();
            stream.Close();
            client.Dispose();
        }

        public class Collapse
        {
            public List<string> url { get; set; }
            public List<string> quality { get; set; }
            public List<string> duration { get; set; }
            public List<string> voice { get; set; }
        }

        public class Root
        {
            public int id { get; set; }
            public int id_kinopoisk { get; set; }
            public string url { get; set; }
            public string type { get; set; }
            public string title { get; set; }
            public string title_alternative { get; set; }
            public string tagline { get; set; }
            public string description { get; set; }
            public int year { get; set; }
            public string poster { get; set; }
            public string trailer { get; set; }
            public string age { get; set; }
            public object budget { get; set; }
            public double rating_kinopoisk { get; set; }
            public double rating_imdb { get; set; }
            public object kinopoisk_votes { get; set; }
            public object imdb_votes { get; set; }
            public string fees_world { get; set; }
            public object fees_russia { get; set; }
            public string premiere_world { get; set; }
            public string premiere_russia { get; set; }
            public object screenshots { get; set; }
            public Collapse collapse { get; set; }
        }
    }
}
