using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicketBooking.Application.DTOs;
using TicketBooking.Application.Features.PaymentFeatures.Command.DeletePayment;
using TicketBooking.Application.Features.PaymentFeatures.Command.NewFolder;
using TicketBooking.Application.Features.PaymentFeatures.Command.UpdatePayment;
using TicketBooking.Application.Features.PaymentFeatures.Query.GetAllPayments;
using TicketBooking.Application.Features.PaymentFeatures.Query.GetPaymentById;
using TicketBooking.Demo;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PaymentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetPayments()
    {
        var payments = await _mediator.Send(new GetAllPaymentsQuery());
        return Ok(payments);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPaymentById(int id)
    {
        var payment = await _mediator.Send(new GetPaymentByIdQuery(id));
        if (payment == null)
        {
            return NotFound($"Payment with ID {id} not found.");
        }
        return Ok(payment);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePayment([FromBody] PaymentDto paymentDto)
    {
        var createdPayment = await _mediator.Send(new CreatePaymentCommand(paymentDto));
        return CreatedAtAction(nameof(GetPaymentById), new { id = createdPayment.Id }, createdPayment);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePayment(int id, [FromBody] PaymentDto paymentDto)
    {
        var updatedPayment = await _mediator.Send(new UpdatePaymentCommand(id, paymentDto));
        return Ok(updatedPayment);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePayment(int id)
    {
        var isDeleted = await _mediator.Send(new DeletePaymentCommand(id));
        if (!isDeleted)
        {
            return NotFound($"Payment with ID {id} not found.");
        }
        return NoContent();
    }
    

    // Optional: Endpoint for Payments by Status
    /*
    [HttpGet("status/{status}")]
    public async Task<IActionResult> GetPaymentsByStatus(string status)
    {
        var payments = await _mediator.Send(new GetPaymentsByStatusQuery(status));
        return Ok(payments);
    }
    */
}


