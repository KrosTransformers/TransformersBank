using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transformers.Bank.Entities;

namespace Transformers.Bank.App
{
    public class ApiClient
    {
        System.Net.Http.HttpClient HttpClient { get; } = new System.Net.Http.HttpClient();

        public async Task<List<Account>> GetAccountsAsync()
        {
            HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "1LNpW9SHT1Yb7IqU5KWg");
            var msg = await HttpClient.GetAsync("http://localhost:65516/api/accounts");
            var json = await msg.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Account>>(json);
        }
    }
}
