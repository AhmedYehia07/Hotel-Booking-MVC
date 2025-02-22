using System.Diagnostics;
using BookingWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using Utility;

namespace BookingWeb.Controllers
{
    public class HomeController(HttpClient httpClient) : Controller
    {
        

        public async Task<IActionResult> Index()
        {
            string url = SD.ApiUrl + "/api/Branch";
            var response = await httpClient.GetAsync(url);
            var data = new List<HotelBranch>();
            if(response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                data = JsonConvert.DeserializeObject<List<HotelBranch>>(jsonString);
            }
            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
