using _1Breadcrumb.Data.Entities;
using _1Breadcrumb.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace _1Breadcrumb.Infra.Persistance;

public class BookRepository : IBookRepository
{
    private readonly IDbContextFactory<AppDbContext> _dbContextFactory;
    private readonly ILogger<BookRepository> _logger;

    public BookRepository(IDbContextFactory<AppDbContext> dbContextFactory, ILogger<BookRepository> logger)
    {
        _dbContextFactory = dbContextFactory;
        _logger = logger;
    }

    public async Task<IList<Book>> GetAllBooksAsync(CancellationToken cancellationToken)
    {
        await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

        return await dbContext.Books.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<bool> SetAvailabilityAsync(int bookId, bool available, CancellationToken cancellationToken)
    {
        await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        var book = await dbContext.Books.FindAsync([bookId], cancellationToken);
        if (book == null)
            return false;

        book.IsAvailable = available;

        try
        {
            await dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error setting availability for book with ID {BookId}", bookId);
            return false;
        }
    }
}