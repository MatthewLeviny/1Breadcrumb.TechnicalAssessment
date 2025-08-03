using _1Breadcrumb.Application.DTO;
using _1Breadcrumb.Application.Mappers;
using _1Breadcrumb.Data.Repositories;

namespace _1Breadcrumb.Application.Services;

public interface IBookService
{
    Task<IList<BookDto>> GetAllBooksAsync(CancellationToken cancellationToken);
    Task<bool> SetBookAvailabilityAsync(int id, bool newAvailability, CancellationToken none);
}

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<IList<BookDto>> GetAllBooksAsync(CancellationToken cancellationToken)
    {
        var books = await _bookRepository.GetAllBooksAsync(cancellationToken);

        return books.MapBooksToDto();
    }

    public async Task<bool> SetBookAvailabilityAsync(int id, bool available, CancellationToken cancellationToken)
    {
        return await _bookRepository.SetAvailabilityAsync(id, available, cancellationToken);
    }
}