using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace TicketBooking.API.Controllers;

[ApiController]
[Route("bookings")]
[EnableCors("AllowAll")]
public class BookingsController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Booking>> GetAll()
    {
        return Ok(BookingStore.GetAll());
    }

    [HttpGet("{id:int}")]
    public ActionResult<Booking> GetById(int id)
    {
        var booking = BookingStore.GetById(id);

        if (booking is null)
        {
            return NotFound();
        }

        return Ok(booking);
    }

    [HttpPost]
    public ActionResult<Booking> Create([FromBody] Booking booking)
    {
        var created = BookingStore.Add(booking);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, [FromBody] Booking booking)
    {
        if (!BookingStore.Update(id, booking))
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        if (!BookingStore.Delete(id))
        {
            return NotFound();
        }

        return NoContent();
    }
}
