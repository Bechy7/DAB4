using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;
using Newtonsoft.Json;

namespace Trader.Models
{
    public class Producer
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public int Sell { get; set; }
       // public Consumer[] SellTo { get; set; } // Remove this?
    }
}