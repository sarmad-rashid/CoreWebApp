using ASP_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebApp.Controllers
{
    public class WebAPIController : Controller
    {
        string baseURL = @"http://localhost:49887/api/People/";

        public async Task<ActionResult> Index()
        {
            List<PersonApiModel> peopleList = new List<PersonApiModel>();

            try
            {
                using (var client = new HttpClient())
                {
                    //Passing base url
                    client.BaseAddress = new Uri(baseURL);
                    client.DefaultRequestHeaders.Clear();
                    //Define request data format
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Sending Get request from website
                    HttpResponseMessage response = await client.GetAsync(new Uri(baseURL));
                    //Checking if the response is successful
                    if (response.IsSuccessStatusCode)
                    {
                        var content = response.Content.ReadAsStringAsync().Result;
                        peopleList = JsonConvert.DeserializeObject<List<PersonApiModel>>(content);
                    }
                    return View(peopleList);
                }
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        //CREATE
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(PersonApiModel person)
        {
            try
            {
                HttpClient client = new HttpClient();

                //Put object in database
                string serializedObject = JsonConvert.SerializeObject(person);
                var content = new StringContent(serializedObject, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(baseURL, content);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        //EDIT
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                PersonApiModel person = new PersonApiModel();
                HttpClient client = new HttpClient();

                //Get URL
                string URL = baseURL + id;
                //Get response
                var response = await client.GetAsync(new Uri(URL));
                if (response.IsSuccessStatusCode)
                {
                    //Get content
                    var content = await response.Content.ReadAsStringAsync();
                    //Convert to object
                    person = JsonConvert.DeserializeObject<PersonApiModel>(content);
                }
                return View(person);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(PersonApiModel person)
        {
            try
            {
                HttpClient client = new HttpClient();
                string URL = baseURL + person.Id;
                var response = await client.GetAsync(URL);

                if (response.IsSuccessStatusCode)
                {
                    string serializedObject = JsonConvert.SerializeObject(person);
                    var content = new StringContent(serializedObject, Encoding.UTF8, "Application/json");
                    var update = await client.PutAsync(URL, content);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        //DELETE
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                PersonApiModel person = new PersonApiModel();
                HttpClient client = new HttpClient();

                //Get URL
                string URL = baseURL + id;
                //Get response
                var response = await client.GetAsync(new Uri(URL));
                if (response.IsSuccessStatusCode)
                {
                    //Get content
                    var content = await response.Content.ReadAsStringAsync();
                    //Convert to object
                    person = JsonConvert.DeserializeObject<PersonApiModel>(content);
                }
                return View(person);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }                    
        }
        [HttpPost]
        public async Task<IActionResult> Delete(PersonApiModel person)
        {
            try
            {
                HttpClient client = new HttpClient();

                string URL = baseURL + person.Id;
                var response = await client.GetAsync(new Uri(URL));
                if (response.IsSuccessStatusCode)
                {
                    var delete = await client.DeleteAsync(new Uri(URL));
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
