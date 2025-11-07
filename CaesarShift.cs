using System;
using System.Text;

namespace Cypher.Utils
{
    public static class CaesarShift
    {
        public static string EncryptDecrypt(string text, int shift, bool decrypt = false)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            // Normalize shift so it always sits between 0–25
            shift = ((shift % 26) + 26) % 26;
            if (decrypt)
                shift = -shift;

            var output = new StringBuilder(text.Length);

            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    char baseChar = char.IsUpper(c) ? 'A' : 'a';
                    // add 26 before mod to avoid negatives when decrypting
                    char shifted = (char)(((c - baseChar + shift + 26) % 26) + baseChar);
                    output.Append(shifted);
                }
                else
                {
                    output.Append(c);
                }
            }

            return output.ToString();
        }
    }
}
