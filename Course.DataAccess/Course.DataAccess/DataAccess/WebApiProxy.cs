using Newtonsoft.Json;
using OggettiCondivisi;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Course.DataAccess.DataAccess
{
    public class WebApiProxy
    {

        private static string BASE_URL = "http://192.168.1.143:5001/api/";
        HttpClient client = null;


        public WebApiProxy()
        {
            client = new HttpClient() {
                Timeout = TimeSpan.FromSeconds(10),
            };
        }



        public async Task<List<ServerDataItem>> GetAll()
        {
            // GetStringAsync fa 2 operazioni con una istruzione
            // var stringResponse = await client.GetStringAsync(BASE_URL + "values");

            var resp = await client.GetAsync(BASE_URL + "values");

            var stringResponse = await resp.Content.ReadAsStringAsync();

            var lista = JsonConvert.DeserializeObject<List<ServerDataItem>>(stringResponse);

            return lista;
        }

        public async Task Create(ServerDataItem o)
        { 
            var serializedString = JsonConvert.SerializeObject(o);

            StringContent content = new StringContent(serializedString, UTF8Encoding.UTF8, "application/json");

            var stringResponse = await client.PostAsync(BASE_URL + "values", content);

            if (!stringResponse.IsSuccessStatusCode)
            {
                throw new Exception(stringResponse.StatusCode.ToString()) { };
            }
        }

        public async Task Update(ServerDataItem o)
        {
            var serializedString = JsonConvert.SerializeObject(o);

            StringContent content = new StringContent(serializedString, UTF8Encoding.UTF8, "application/json");

            var stringResponse = await client.PutAsync(BASE_URL + "values/" + o.Id, content);

            if (!stringResponse.IsSuccessStatusCode)
            {
                throw new Exception(stringResponse.StatusCode.ToString()) { };
            }
        }

        public async Task Delete(ServerDataItem o)
        { 
            var stringResponse = await client.DeleteAsync(BASE_URL + "values/" + o.Id);

            if (!stringResponse.IsSuccessStatusCode)
            {
                throw new Exception(stringResponse.StatusCode.ToString()) { };
            }
        }
    }
}
