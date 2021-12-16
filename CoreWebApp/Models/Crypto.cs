using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_WebApp.Models
{
    public class Crypto
    {
        public List<Market> markets { get; set; }
        public string next { get; set; }
    }
}
