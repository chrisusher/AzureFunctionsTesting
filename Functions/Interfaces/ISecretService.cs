namespace Functions.Interfaces;

public interface ISecretService
{
    public string GetSecret(string keyName);

    public void SetSecret(string keyName, object value);
}