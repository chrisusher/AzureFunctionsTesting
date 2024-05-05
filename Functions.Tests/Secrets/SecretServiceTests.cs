using Functions.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Functions.Tests.Secrets;

[TestFixture]
public class SecretServiceTests
{
    private readonly ISecretService _secretService;

    public SecretServiceTests()
    {
        _secretService = TestCommon.Services.GetService<ISecretService>();
    }
    
    [Test]
    public void GetSecret_IsNotNullOrEmpty()
    {
        var secret = _secretService.GetSecret("MySecret");

        Assert.That(secret, Is.Not.Null.Or.Empty, "Secret should not be null or empty");
    }
}