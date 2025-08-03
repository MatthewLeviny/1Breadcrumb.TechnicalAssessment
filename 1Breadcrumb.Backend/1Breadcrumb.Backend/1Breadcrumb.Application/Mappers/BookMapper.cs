using _1Breadcrumb.Application.DTO;

namespace _1Breadcrumb.Application.Mappers;

public static class BookMapper
{
    public static IList<BookDto> MapBooksToDto(this IEnumerable<Data.Entities.Book> books)
    {
        return books.Select(MapToDto).ToList();
    }

    public static BookDto MapToDto(this Data.Entities.Book book)
    {
        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Isbn = book.Isbn,
            PublishedDate = book.PublishedDate,
            IsAvailable = book.IsAvailable,
            Owner = book.Owner
        };
    }
}