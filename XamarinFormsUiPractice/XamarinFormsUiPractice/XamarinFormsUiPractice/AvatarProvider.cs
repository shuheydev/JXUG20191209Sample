using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace XamarinFormsUiPractice
{
    public static class AvatarProvider
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public static async Task<string> GetAvatarUri()
        {
            var response = await _httpClient.GetAsync("https://randomuser.me/api/");
            return await response.Content.ReadAsStringAsync();
        }
    }
}
