using System.Net;
using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO;
using Utility;

namespace BookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController(IRoomRepository roomRepository, ICustomerRepository customerRepository
        , IBookingDetailsRepository detailsRepository, IBookingRoomDetailsRepository bookingRoom, IHotelRoomRepository hotelRoom) : ControllerBase
    {
        [HttpPost]
        public async Task<BookingResponseDto> NewBooking(BookingRequestDto bookingRequest)
        {
            if (bookingRequest.CheckInDate < DateTime.Now.AddDays(1))
            {
                ModelState.AddModelError("CheckInDate", "Check-In date is invalid");
            }
            else if (bookingRequest.CheckOutDate < bookingRequest.CheckInDate)
            {
                ModelState.AddModelError("CheckOutDate", "Check-Out date is invalid");
            }
            if (ModelState.IsValid)
            {
                var PricePerNight = 0.0;
                var discount = 1.0;
                var customer = await customerRepository.GetAsync(u => u.NationalId == bookingRequest.customerRequest.NationalId);
                if (customer == null)
                {
                    //Register New Customer
                    customer = new Customer
                    {
                        NationalId = bookingRequest.customerRequest.NationalId,
                        Name = bookingRequest.customerRequest.Name,
                        PhoneNumber = bookingRequest.customerRequest.PhoneNumber,
                    };
                    await customerRepository.CreateAsync(customer);
                }
                else
                {
                    //Check for previous booking
                    var IsBookedBefore = await detailsRepository.CheckOldBookings(customer.Id);
                    if (IsBookedBefore)
                    {
                        discount = 0.95;
                    }
                }
                //Add New Booking
                var BookingDetails = new BookingDetails
                {
                    CustomerId = customer.Id,
                    BranchId = bookingRequest.HotelBranchId,
                    CheckInDate = bookingRequest.CheckInDate,
                    CheckOutDate = bookingRequest.CheckOutDate,
                    ReservationDate = DateTime.Now,
                    Status = SD.Pending
                };
                await detailsRepository.CreateAsync(BookingDetails);
                //Add Rooms details
                var firstRoom = await roomRepository.GetAsync(u => u.Type == bookingRequest.FirstRoom.RoomType);
                var BookingRoomList = new List<BookingRoomDetails> {
                        new BookingRoomDetails
                        {
                        BookingDetailsId = BookingDetails.Id,
                        RoomTypeId = firstRoom.Id,
                        NoOfAdults = bookingRequest.FirstRoom.NoOfAdults,
                        NoOfChildren = bookingRequest.FirstRoom.NoOfChildren
                        }};
                PricePerNight += await hotelRoom.GetRoomPriceAsync(firstRoom.Id, BookingDetails.BranchId);
                if (bookingRequest.SecondRoom.RoomType == "Single" || bookingRequest.SecondRoom.RoomType == "Double"
                    || bookingRequest.SecondRoom.RoomType == "Suite")
                {
                    var SecondRoom = await roomRepository.GetAsync(u => u.Type == bookingRequest.SecondRoom.RoomType);
                    BookingRoomList.Add(new BookingRoomDetails
                    {
                        BookingDetailsId = BookingDetails.Id,
                        RoomTypeId = SecondRoom.Id,
                        NoOfAdults = bookingRequest.SecondRoom.NoOfAdults,
                        NoOfChildren = bookingRequest.SecondRoom.NoOfChildren
                    });
                    PricePerNight += await hotelRoom.GetRoomPriceAsync(firstRoom.Id, BookingDetails.BranchId);
                }
                if (bookingRequest.ThirdRoom.RoomType == "Single" || bookingRequest.ThirdRoom.RoomType == "Double"
                    || bookingRequest.ThirdRoom.RoomType == "Suite")
                {
                    var ThirdRoom = await roomRepository.GetAsync(u => u.Type == bookingRequest.ThirdRoom.RoomType);
                    BookingRoomList.Add(new BookingRoomDetails
                    {
                        BookingDetailsId = BookingDetails.Id,
                        RoomTypeId = ThirdRoom.Id,
                        NoOfAdults = bookingRequest.ThirdRoom.NoOfAdults,
                        NoOfChildren = bookingRequest.ThirdRoom.NoOfChildren
                    });
                    PricePerNight += await hotelRoom.GetRoomPriceAsync(firstRoom.Id, BookingDetails.BranchId);
                }
                await bookingRoom.CreateRangeAsync(BookingRoomList);
                //Calculate Total Price with Discount
                BookingDetails.TotalPrice = (PricePerNight * (bookingRequest.CheckOutDate - bookingRequest.CheckInDate).Days) * discount;
                await detailsRepository.UpdateAsync(BookingDetails);
                return new BookingResponseDto
                {
                    bookingId = BookingDetails.Id,
                    StatusCode = HttpStatusCode.Created,
                    TotalPrice = BookingDetails.TotalPrice,
                    Discount = (1 - discount) * 100
                };
            }
            return new BookingResponseDto
            {
                StatusCode = HttpStatusCode.BadRequest,
                StatusMessage = ModelState.ToString()
            };
        }
        [HttpGet]
        public async Task<List<BookingListDto>> GetBookingList()
        {
            var DetailsList = await detailsRepository.GetAllAsync(IncludeProperties: "Customer,HotelBranch");
            var BookingList = new List<BookingListDto>();
            foreach (var Detail in DetailsList)
            {
                BookingList.Add(new BookingListDto
                {
                    DetailId = Detail.Id,
                    CutomerName = Detail.Customer.Name,
                    Branch = Detail.HotelBranch.Name,
                    ReservationDate = Detail.ReservationDate
                });
            }
            return BookingList;
        }

        [HttpGet("{id:int}")]
        public async Task<BookingDetailsDto> GetBookingDetails(int id)
        {
            var details = await detailsRepository.GetAsync(u=>u.Id == id,IncludeProperties: "Customer,HotelBranch,RoomDetails"); 
            var DetailsDto = new BookingDetailsDto
            {
                DetailsId = details.Id,
                Name = details.Customer.Name,
                NationalId = details.Customer.NationalId,
                PhoneNumber = details.Customer.PhoneNumber,
                NoOfRooms = details.RoomDetails.Count,
                status = details.Status,
                HotelBranch = details.HotelBranch.Name,
                CheckInDate = details.CheckInDate,
                CheckOutDate = details.CheckOutDate,
                ReservationDate = details.ReservationDate,
                TotalPrice = details.TotalPrice
            };
            return DetailsDto;
        }
        [HttpPut("Confirm/{id:int}")]
        public async Task<ActionResult<BookingDetails>> ConfirmBooking(int id)
        {
            var details = await detailsRepository.GetAsync(u => u.Id == id);
            details.Status = SD.Confirmed;
            await detailsRepository.UpdateAsync(details);
            return Ok(details);
        }
        [HttpPut("Cancel/{id:int}")]
        public async Task<ActionResult<BookingDetails>> CancelBooking(int id)
        {
            var details = await detailsRepository.GetAsync(u => u.Id == id);
            details.Status = SD.Cancelled;
            await detailsRepository.UpdateAsync(details);
            return Ok(details);
        }
    }
}
