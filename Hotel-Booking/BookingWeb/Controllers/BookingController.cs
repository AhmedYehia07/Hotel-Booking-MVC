using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using Newtonsoft.Json;
using Utility;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BookingWeb.Controllers
{
    public class BookingController(HttpClient httpClient) : Controller
    {
        public async Task<IActionResult> Index()
        {
            string url = SD.ApiUrl + "/api/Booking";
            var response = await httpClient.GetAsync(url);
            var data = new List<BookingListDto>();
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                data = JsonConvert.DeserializeObject<List<BookingListDto>>(jsonString);
                return View(data);
            }
            return View();
        }
        public async Task<IActionResult> CreateNewBooking()
        {
            string url = SD.ApiUrl + "/api/Branch";
            var response = await httpClient.GetAsync(url);
            var data = new List<HotelBranch>();
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                data = JsonConvert.DeserializeObject<List<HotelBranch>>(jsonString);
            }
            ViewBag.HotelBranches = data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewBooking(BookingRequestDto bookingRequest)
        {
            var url = SD.ApiUrl + "/api/Booking";
            var jsonContent = JsonConvert.SerializeObject(bookingRequest);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, content);
            if(response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<BookingResponseDto>(jsonString);
                if(data!=null && data.StatusCode == HttpStatusCode.Created)
                {
                    return RedirectToAction("Summary",new {detailsId = data.bookingId});
                }
            }
            return View();
        }
        public async Task<IActionResult> Summary(int detailsId)
        {
            string url = SD.ApiUrl + $"/api/Booking/{detailsId}";
            var response = await httpClient.GetAsync(url);
            var data = new BookingDetailsDto();
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                data = JsonConvert.DeserializeObject<BookingDetailsDto>(jsonString);
            }
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> CancelBooking(int detailsId)
        {
            string url = SD.ApiUrl + $"/api/Booking/Cancel/{detailsId}";
            var response = await httpClient.PutAsync(url,null);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmBooking(int detailsId)
        {
            string url = SD.ApiUrl + $"/api/Booking/Confirm/{detailsId}";
            var response = await httpClient.PutAsync(url,null);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ErrorMessage = "Booking failed. Please try again.";
            return View() ;
        }
    }
}
