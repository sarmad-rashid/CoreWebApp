using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_WebApp.Models
{
    public class Market
    {
        public string exchange_id { get; set; }
        public string symbol { get; set; }
        public string base_asset { get; set; }
        public string quote_asset { get; set; }
        public double price_unconverted { get; set; }
        public double price { get; set; }
        public double change_24h { get; set; }
        public double spread { get; set; }
        public double volume_24h { get; set; }
        public string status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
