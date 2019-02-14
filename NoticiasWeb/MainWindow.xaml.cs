using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Windows;

namespace NoticiasWeb
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        string url = "https://newsapi.org/v2/top-headlines?sources=google-news-br&apiKey=f11b582f67c84a48b3b5739428440120";
        List<Article> lista = new List<Article>();
        public MainWindow()
        {
            InitializeComponent();

            var root = _downloadJsonPOG<RootObject>(url);
            foreach (var r in root.articles)
            {
                lista.Add(new Article() { title = r.title+"\n\n"+r.description ,  url = r.url, urlToImage = r.urlToImage });
            }

            grid.ItemsSource = lista;
        }



        private static T _downloadJsonPOG<T>(string url) where T : new()
        {
            using (var w = new WebClient())
            {
                var data = string.Empty;
                try
                {
                    w.Encoding = System.Text.Encoding.UTF8;
                    w.Headers.Add("Accept-Charset", "ISO-8859-1,utf-8;q=0.7,*;q=0.7");
                    data = w.DownloadString(url);
                    new StringContent(data, System.Text.Encoding.UTF8, "text/plain");
                }
                catch (Exception) { }
                return !string.IsNullOrEmpty(data) ? JsonConvert.DeserializeObject<T>(data) : new T();
            }
        }

        private void Grid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
