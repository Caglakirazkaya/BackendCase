using System;
using System.Collections.Generic;
using System.Security.Cryptography;

public class Program
{
    const string CharSet = "ACDEFGHKLMNPRTXYZ234579";
    const int CodeLength = 8;
    static HashSet<string> generatedCodes = new HashSet<string>(); // Benzersiz kodları saklamak için

    public static void Main()
    {
        for (int i = 0; i < 100; i++) // Örnek 100 kod üretilmesi için bir döngü oluşturdum
        {
            string code = GenerateUniqueSecureCode();
            Console.WriteLine("Generated Code: " + code);
        }
    }

    /// <summary>
    /// Fonksiyonun amacı "ACDEFGHKLMNPRTXYZ234579" dizini içeren ve 8 karakterli bir kod üretmek. Kodun benzersiz olması için HashSet kullandım. 
    /// </summary>
    /// <returns></returns>
    public static string GenerateUniqueSecureCode()
    {
        string newCode;
        do
        {
            newCode = GenerateSecureCode();
        } while (generatedCodes.Contains(newCode)); // Kod zaten üretilmişse, yeni bir kod üretilene kadar döngü devam eder

        generatedCodes.Add(newCode); // Yeni üretilen kodu kaydediyoruz
        return newCode;
    }

    public static string GenerateSecureCode()
    {
        var code = new char[CodeLength];
        using (var rng = new RNGCryptoServiceProvider())
        {
            byte[] randomNumber = new byte[1];
            for (int i = 0; i < CodeLength; i++)
            {
                rng.GetBytes(randomNumber);
                int pos = randomNumber[0] % CharSet.Length;
                code[i] = CharSet[pos];
            }
        }
        return new string(code);
    }

}
