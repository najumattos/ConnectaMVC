using System.Reflection;

namespace ConnectaMVC.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection AddSmartServices(this IServiceCollection services)
    {
        // Pega todos os tipos do seu projeto que terminam com "Service"
        var assembly = Assembly.GetExecutingAssembly();

        var serviceTypes = assembly.GetTypes()
            .Where(t => t.Name.EndsWith("Service") && !t.IsInterface && !t.IsAbstract);

        foreach (var serviceType in serviceTypes)
        {
            // Tenta encontrar a interface correspondente (ex: IAuthService para AuthService)
            var interfaceType = serviceType.GetInterface($"I{serviceType.Name}");

            if (interfaceType != null)
            {
                services.AddScoped(interfaceType, serviceType);
            }
            else
            {
                // Se não tiver interface, registra a classe pura
                services.AddScoped(serviceType);
            }
        }

        return services;
    }
}
