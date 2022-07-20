using ArmyTechTask.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace ArmyTechTask.Infrastructure;

public static class InfrastructureServices
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>();
    }
}
