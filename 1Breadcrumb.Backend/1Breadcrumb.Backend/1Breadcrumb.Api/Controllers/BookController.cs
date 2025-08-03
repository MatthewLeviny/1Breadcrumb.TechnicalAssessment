using _1Breadcrumb.Application.DTO;
using _1Breadcrumb.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace _1Breadcrumb.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<BookDto>), 200)]
    public async Task<IActionResult> GetAllBooks(CancellationToken cancellationToken)
    {
        var books = await _bookService.GetAllBooksAsync(cancellationToken);
        return Ok(books);
    }

    [HttpPatch("{id}/availability")]
    [ProducesResponseType(typeof(bool), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateAvailability(int id, [FromBody] bool newAvailability,
        CancellationToken cancellationToken)
    {
        var result = await _bookService.SetBookAvailabilityAsync(id, newAvailability, cancellationToken);

        return result ? Ok(result) : NotFound();
    }
}