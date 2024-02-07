using System;
using System.Security.Cryptography;
using System.Text;

public class HashConstructor
{
    public static string CreateHash(string input)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
    public static bool VerifyPassword(string inputPassword, string hashedPassword)
    {
        string hashedInput = CreateHash(inputPassword);
        return string.Equals(hashedInput, hashedPassword, StringComparison.OrdinalIgnoreCase);
    }
}