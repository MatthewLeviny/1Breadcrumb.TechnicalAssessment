using _1Breadcrumb.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace _1Breadcrumb.Application.IoC;

public class ApplicationIoC
{
    public static IServiceCollection ApplicationRegisterServices(IServiceCollection services)
    {
        services.AddSingleton<IBookService, BookService>();

        return services;
    }
}