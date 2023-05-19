namespace Spoon.NuGet.Core.Encryption.Interfaces;

/// <summary>
///  Provides methods to encrypt and decrypt strings.
/// </summary>
public interface IEncryptionService
{
    /// <summary>
    /// Encrypts the specified string.
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    string Encrypt(string str);
    /// <summary>
    ///  Decrypts the specified string.
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    string Decrypt(string str);
}