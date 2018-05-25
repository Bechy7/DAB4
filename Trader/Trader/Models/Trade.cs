using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Trader.Models
{
    public class Trade
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "totalProduction")]
        public int TotalProduction { get; set; }
        [JsonProperty(PropertyName = "totalConsumption")]
        public int TotalConsumption { get; set; }
        [JsonProperty(PropertyName = "powerSourceOrDestination")]
        public string PowerSourceOrDestination { get; set; }
        [JsonProperty(PropertyName = "regularProducers")]
        public Producer[] RegularProducers { get; set; }
        [JsonProperty(PropertyName = "regularConsumers")]
        public Consumer[] RegularConsumers { get; set; }

        [JsonProperty(PropertyName = "companyProducers")]
        public Producer[] CompanyProducers { get; set; }
        [JsonProperty(PropertyName = "companyConsumers")]
        public Consumer[] CompanyConsumers { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}