using _1Breadcrumb.Data.Entities;

namespace _1Breadcrumb.Infra.Persistance;

public static class DbSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (!context.Books.Any())
        {
            context.Books.AddRange(
                new Book
                {
                    Id = 1,
                    Title = "1984",
                    Author = "George Orwell",
                    PublishedDate = new DateTimeOffset(1949, 6, 8, 0, 0, 0, TimeSpan.Zero),
                    Isbn = "978-0451524935",
                    Owner = "Library A",
                    IsAvailable = true
                },
                new Book
                {
                    Id = 2,
                    Title = "Brave New World",
                    Author = "Aldous Huxley",
                    PublishedDate = new DateTimeOffset(1932, 8, 30, 0, 0, 0, TimeSpan.Zero),
                    Isbn = "978-0060850524",
                    Owner = "Library B",
                    IsAvailable = true
                },
                new Book
                {
                    Id = 3,
                    Title = "Fahrenheit 451",
                    Author = "Ray Bradbury",
                    PublishedDate = new DateTimeOffset(1953, 10, 19, 0, 0, 0, TimeSpan.Zero),
                    Isbn = "978-1451673319",
                    Owner = "Library C",
                    IsAvailable = true
                }
            );

            context.SaveChanges();
        }
    }
}