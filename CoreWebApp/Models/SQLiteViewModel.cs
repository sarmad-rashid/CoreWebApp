using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ASP_WebApp.Models
{
    public class SQLiteViewModel : DbContext
    {
        public SQLiteViewModel()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=person.db");
        }
        public DbSet<Person> People { get; set; }
    }
}
