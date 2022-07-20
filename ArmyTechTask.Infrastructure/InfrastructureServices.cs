using ArmyTechTask.Domain.Repositories;
using ArmyTechTask.Infrastructure.Data;
using ArmyTechTask.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ArmyTechTask.Infrastructure;

public static class InfrastructureServices
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>();
        services.AddScoped<ICashierRepository, CashierRepository>();
    }
}
