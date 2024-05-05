using Ductus.FluentDocker.Services;
using Functions.Interfaces;
using Functions.Tests.Fakes;
using Microsoft.Extensions.DependencyInjection;

namespace Functions.Tests;

public static class TestCommon
{
    private static ServiceProvider _services;

    public static ICompositeService DockerServices { get; internal set; }

    public static ServiceProvider Services
    {
        get
        {
            if (_services == null)
            {
                _services = RegisterServices();
            }
            return _services;
        }
    }

    private static ServiceProvider RegisterServices()
    {
        var secretService = new RedisSecretService();

        var services = new ServiceCollection();
        services.AddSingleton<ISecretService>(secretService);

        return services.BuildServiceProvider();
    }
}
