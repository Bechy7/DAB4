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
        public int Buy { get; set; }
        public Producer[] BuyFrom { get; set; }
    }
}