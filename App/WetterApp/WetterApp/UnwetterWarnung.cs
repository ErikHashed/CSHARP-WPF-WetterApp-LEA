using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WetterApp
{
    internal class UnwetterWarnung 
    {
        private const string apiKey = "79270c12757b499a9d0e1ecfad188c3a";
        public async Task<List<UnwetterWarnung>> GetUnwetterWarnungen()
        {
            //string stadt = txtStadt.Text;
            string apiUrl = $"https://api.weatherbit.io/v2.0/alerts?&key=API_KEY&key={apiKey}&lang=de";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    List<UnwetterWarnung> warnungen = JsonConvert.DeserializeObject<List<UnwetterWarnung>>(content);
                    return warnungen;
                }
                else
                {
                    throw new Exception("Fehler beim Abrufen der Unwetterwarnungen.");
                }
            }
          

        }
        
    }
}
