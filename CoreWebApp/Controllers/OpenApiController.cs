using ASP_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ASP_WebApp.Controllers
{
    public class OpenApiController : Controller
    {
        string baseURL = @"https://www.cryptingup.com/api/markets";
        public async Task<IActionResult> Index()
        {            
            List<Market> market = new List<Market>();
            try
            {
                using (var client = new HttpClient())
                {
                    //Passing service base url
                    client.BaseAddress = new Uri(baseURL);
                    client.DefaultRequestHeaders.Clear();
                    //Define request data format
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                    HttpResponseMessage responseMessage = await client.GetAsync(new Uri(baseURL));

                    //Checking the response is successful or not which is sent using HttpClient
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var content = await responseMessage.Content.ReadAsStringAsync();
                        var cryptoModel = JsonConvert.DeserializeObject<Crypto>(content);
                        market = cryptoModel.markets;
                    }
                    return View(market);
                }          
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }                
    }
}
