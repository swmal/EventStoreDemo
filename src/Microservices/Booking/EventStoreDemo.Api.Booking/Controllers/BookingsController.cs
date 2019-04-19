using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventStoreDemo.Api.Booking.Models;
using EventStoreDemo.Domain.Booking.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EventStoreDemo.Api.Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly BookingRepository _repository = new BookingRepository();

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<BookingRowModel>> Get()
        {
            var allBookings = _repository.GetAll();
            var result = allBookings.Select(x => new BookingRowModel
            {
                BookingNumber = x.BookingNumber,
                BookingDate = x.BookingDate,
                PickupDate = x.Info.PickupTime,
                ReturnDate = x.Info.ReturnTime,
                CustomerName = x.Customer.Name
            });
            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{bookingNumber}")]
        public ActionResult<BookingModel> Get(string bookingNumber)
        {
            var booking = _repository.GetOne(bookingNumber);
            if(booking == null)
            {
                return NotFound();
            }
            var model = new BookingModel
            {
                BookingNumber = booking.BookingNumber,
                BookingStatus = booking.BookingStatus,
                Customer = booking.Customer,
                PaymentStatus = booking.PaymentStatus
            };
            return Ok(model);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
