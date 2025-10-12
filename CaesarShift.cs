using System;
namespace Cypher.Utils
{
    public static class CaesarShift
    {
        public static string EncryptDecrypt(string text, int shift, bool decrypt = false)
        {
            if (string.IsNullOrEmpty(text)) return "";

            if (decrypt)
                shift = 26 - shift;

            string output = "";
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    char baseChar = char.IsUpper(c) ? 'A' : 'a';
                    char shifted = (char)((((c - baseChar) + shift) % 26) + baseChar);
                    output += shifted;
                }
                else
                {
                    output += c;
                }
            }
            return output;
        }
    }
}