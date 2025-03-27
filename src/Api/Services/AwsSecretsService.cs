using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using System.Text.Json;
using System.Threading.Tasks;

public class AwsSecretsManagerService
{
    private readonly IAmazonSecretsManager _secretsManager;

    public AwsSecretsManagerService(IAmazonSecretsManager secretsManager)
    {
        _secretsManager = secretsManager;
    }

    public async Task<Dictionary<string, string>> GetSecretAsync(string secretName)
    {
        var request = new GetSecretValueRequest { SecretId = secretName };
        var response = await _secretsManager.GetSecretValueAsync(request);

        return JsonSerializer.Deserialize<Dictionary<string, string>>(response.SecretString);
    }
}
