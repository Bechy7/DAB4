using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Trader.Models
{
    public class Consumer
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "buy")]
        public int Buy { get; set; }
        [JsonProperty(PropertyName = "buyFrom")]
        public Producer[] BuyFrom { get; set; }
    }
}