using _1Breadcrumb.Data.Repositories;
using _1Breadcrumb.Infra.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace _1Breadcrumb.Infra.IoC;

public class InfraIoC
{
    public static IServiceCollection InfraRegisterServices(IServiceCollection services)
    {
        services.AddSingleton<IBookRepository, BookRepository>();
        services.AddDbContextFactory<AppDbContext>(options =>
            options.UseInMemoryDatabase("InMemoryDb"));

        return services;
    }
}