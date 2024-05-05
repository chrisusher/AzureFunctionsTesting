using Functions.Interfaces;
using StackExchange.Redis;

namespace Functions.Tests.Fakes;

public class RedisSecretService : ISecretService
{
    private readonly IDatabase _redisDb;

    public RedisSecretService()
    {
        var redisClient = ConnectionMultiplexer.Connect("localhost");

        _redisDb = redisClient.GetDatabase();
    }

    public string GetSecret(string keyName)
    {
        return _redisDb.StringGet(keyName);
    }

    public void SetSecret(string keyName, object value)
    {
        _redisDb.StringSet(keyName, value.ToString());
    }
}