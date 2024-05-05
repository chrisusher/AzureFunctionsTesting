using Functions.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using DockerBuilder = Ductus.FluentDocker.Builders.Builder;

namespace Functions.Tests;

[SetUpFixture]
public class AssemblyLifecycle
{
    [OneTimeSetUp]
    public async Task AssemblySetupAsync()
    {
        var builder = new DockerBuilder()
            .UseContainer()
            .UseCompose()
            .FromFile("docker-compose.yml");

        TestCommon.DockerServices = builder.Build().Start();

        var secretService = TestCommon.Services.GetService<ISecretService>();
        secretService.SetSecret("MySecret", "MySecretValue");
    }

    [OneTimeTearDown]
    public async Task AssemblyTeardownAsync()
    {
        TestCommon.DockerServices?.Dispose();
    }
}
