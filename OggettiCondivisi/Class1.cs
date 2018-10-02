using Newtonsoft.Json;
using System;

namespace OggettiCondivisi
{
    public class ServerDataItem
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("dataElemento")]
        public DateTime DataElemento { get; set; }

    }
}
