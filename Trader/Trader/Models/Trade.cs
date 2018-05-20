﻿using System;
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
       // [JsonProperty(PropertyName = "timestamp")]
        //public string Timestamp { get; set; }
        //public string TimestampStart { get; set; }
        //public string TimestampEnd { get; set; }
        [JsonProperty(PropertyName = "producers")]
        public Producer[] Producers { get; set; }
        [JsonProperty(PropertyName = "consumers")]
        public Consumer[] Consumers { get; set; }

        //public override string ToString()
        //{
        //    return JsonConvert.SerializeObject(this);
        //}
    }
}