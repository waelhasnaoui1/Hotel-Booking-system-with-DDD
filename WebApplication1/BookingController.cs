using Application;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1;

[ApiController]
[Route("[controller]")]
public class BookingController : ControllerBase
{
    private readonly BookingService _bookingService;

    public BookingController(BookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpPost]
    public IActionResult CreateBooking(Guid customerId, decimal totalPrice)
    {
        _bookingService.CreateBooking(customerId, totalPrice);
        return Ok();
    }
    
    [HttpGet]
    public IActionResult Hello()
    {
        
        return Ok("hello from booking");
    }
}