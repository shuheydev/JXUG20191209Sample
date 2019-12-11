using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace AvatarDownloader
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string downloadFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "avatar");
            Directory.CreateDirectory(downloadFolder);

            for (int i = 1; i < 100; i++)
            {
                string uri = $"https://randomuser.me/api/portraits/women/{i}.jpg";
                await AvatarProvider.Download(uri, downloadFolder);
            }
        }
    }

    public static class AvatarProvider
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public static async Task Download(string uri, string downloadFolder)
        {
            var response = await _httpClient.GetAsync(uri,
                HttpCompletionOption.ResponseContentRead);

            string filePath = Path.Combine(downloadFolder,$"avatar_women_{Path.GetFileName(uri)}");
            using (var fs = File.Create(filePath))
            {
                using (var hs = await response.Content.ReadAsStreamAsync())
                {
                    await hs.CopyToAsync(fs);
                }
            }
        }
    }
}
