using Application;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1;

[ApiController]
[Route("[controller]")]
public class PaymentController : ControllerBase
{
    private readonly PaymentService _paymentService;

    public PaymentController(PaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpPost]
    public IActionResult CompletePayment(Guid bookingId, decimal amount)
    {
        _paymentService.CompletePayment(bookingId, amount);
        return Ok();
    }
}