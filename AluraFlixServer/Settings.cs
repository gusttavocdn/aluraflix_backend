using System.Security.Cryptography;

namespace AluraFlixServer;

public static class Settings
{
    public static readonly string Secret = GenerateKey();

    private static string GenerateKey()
    {
        var key = new byte[32];
        using var generator = RandomNumberGenerator.Create();
        generator.GetBytes(key);
        var base64Key = Convert.ToBase64String(key);

        return base64Key;
    }
}
