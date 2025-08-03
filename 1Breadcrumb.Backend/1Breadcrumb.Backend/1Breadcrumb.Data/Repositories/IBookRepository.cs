using _1Breadcrumb.Data.Entities;

namespace _1Breadcrumb.Data.Repositories;

public interface IBookRepository
{
    Task<IList<Book>> GetAllBooksAsync(CancellationToken cancellationToken);
    Task<bool> SetAvailabilityAsync(int bookId, bool available, CancellationToken cancellationToken);
}