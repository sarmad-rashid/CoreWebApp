using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_WebApp.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Fornamn { get; set; }
        public string Efternamn { get; set; }
        public string Personnummer { get; set; }
        public string Adress { get; set; }
        public string Telefonnummer { get; set; }
        public string Email { get; set; }
        public string Kommentarer { get; set; }
    }
}
