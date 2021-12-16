using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_WebApp.Models
{
    public class PersonApiModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string IDnumber { get; set; }
        public string Adress { get; set; }
        public string Phonenumber { get; set; }
        public string Email { get; set; }
    }
}
