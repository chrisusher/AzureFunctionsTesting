using DockerBuilder = Ductus.FluentDocker.Builders.Builder;

namespace Functions.Tests;

[SetUpFixture]
public class AssemblyLifecycle
{
    [OneTimeSetUp]
    public async Task AssemblySetupAsync()
    {
        
    }

    [OneTimeTearDown]
    public async Task AssemblyTeardownAsync()
    {
        
    }
}
