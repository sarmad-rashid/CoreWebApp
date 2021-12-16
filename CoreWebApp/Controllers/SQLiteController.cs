using ASP_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApp.Controllers
{
    public class SQLiteController : Controller
    {
        public IActionResult Index()
        {
            using (SQLiteViewModel db = new SQLiteViewModel())
            {
                var personList = db.People.ToList();
                return View(personList);
            }
        }

        //Detailsview
        public IActionResult Details(int id)
        {
            using (SQLiteViewModel db = new SQLiteViewModel())
            {
                Person person = db.People.Find(id);
                return View(person);
            }
        }

        //Createview
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Person person)
        {
            using (SQLiteViewModel db = new SQLiteViewModel())
            {
                db.People.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        //Editview
        public IActionResult Edit(int id)
        {
            using (SQLiteViewModel db = new SQLiteViewModel())
            {
                Person person = db.People.Find(id);
                return View(person);
            }
        }
        [HttpPost]
        public IActionResult Edit(Person person)
        {
            using (SQLiteViewModel db = new SQLiteViewModel())
            {
                db.Entry(person).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        //Deleteview
        public IActionResult Delete(int id)
        {
            using (SQLiteViewModel db = new SQLiteViewModel())
            {
                Person person = db.People.Find(id);
                return View(person);
            }
        }
        [HttpPost]
        public IActionResult Delete(Person person)
        {
            using (SQLiteViewModel db = new SQLiteViewModel())
            {
                db.Entry(person).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}
