using Spoon.NuGet.Core.Encryption.Interfaces;

namespace Spoon.NuGet.Core.Encryption;

/// <summary>
/// Provides methods to encrypt and decrypt strings.
/// </summary>
public class NoneEncryptionService : IEncryptionService
{
    /// <summary>
    ///  Encrypts the specified string.
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public string Encrypt(string str)
    {
        return str;
    }

    /// <summary>
    ///  Decrypts the specified string.
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public string Decrypt(string str)
    {
        return str;
    }
}