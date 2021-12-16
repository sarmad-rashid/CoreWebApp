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
        string baseURL = @"http://localhost:49887/api/People";
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
                    HttpResponseMessage Res = await client.GetAsync(new Uri(baseURL));
                    //Checking it the response is successful
                    if (Res.IsSuccessStatusCode)
                    {
                        var response = Res.Content.ReadAsStringAsync().Result;
                        peopleList = JsonConvert.DeserializeObject<List<PersonApiModel>>(response);
                    }
                    return View(peopleList);
                }
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        //Createview
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(PersonApiModel person)
        {
            try
            {
                HttpClient client = new HttpClient();

                //Put object in database
                string serializedObject = JsonConvert.SerializeObject(person);
                var content = new StringContent(serializedObject, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(baseURL, content);

                return View("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
