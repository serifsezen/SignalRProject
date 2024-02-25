using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            Booking booking = new Booking()
            {
                BookingName = createBookingDto.Name,
                BookingMail = createBookingDto.Mail,
                BookingDate = createBookingDto.Date,
                BookingPersonCount = createBookingDto.PersonCount,
                BookingPhone = createBookingDto.Phone
                //Description = createBookingDto.Description
            };
            _bookingService.TAdd(booking);
            return Ok("Rezervasyon Yapıldı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            _bookingService.TDelete(value);
            return Ok("Rezervasyon Silindi");
        }
        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            Booking booking = new Booking()
            {
                BookingMail = updateBookingDto.Mail,
                BookingID = updateBookingDto.BookingID,
                BookingName = updateBookingDto.Name,
                BookingPersonCount = updateBookingDto.PersonCount,
                BookingPhone = updateBookingDto.Phone,
                BookingDate = updateBookingDto.Date
            };
            _bookingService.TUpdate(booking);
            return Ok("Rezervasyon Güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            return Ok(value);
        }
        //[HttpGet("BookingStatusApproved/{id}")]
        //public IActionResult BookingStatusApproved(int id)
        //{
        //    _bookingService.BookingStatusApproved(id);
        //    return Ok("Rezervasyon Açıklaması Değiştirildi");
        //}
        //[HttpGet("BookingStatusCancelled/{id}")]
        //public IActionResult BookingStatusCancelled(int id)
        //{
        //    _bookingService.BookingStatusCancelled(id);
        //    return Ok("Rezervasyon Açıklaması Değiştirildi");
        //}
    }
}
