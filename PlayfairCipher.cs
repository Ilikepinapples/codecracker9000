// Made by Ohno 
// 12/10/2025

using System;
using System.Text;

namespace Cypher.Utils
{
    public static class PlayfairCipher
    {
        public static string Encrypt(string text, string keyword)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(keyword))
                return "";

            text = PrepareText(text);
            char[,] table = GenerateTable(keyword);
            return ProcessPlayfair(text, table, encrypt: true);
        }

        public static string Decrypt(string text, string keyword)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(keyword))
                return "";

            char[,] table = GenerateTable(keyword);
            return ProcessPlayfair(text, table, encrypt: false);
        }

        private static string PrepareText(string text)
        {
            text = text.ToUpper().Replace("J", "I");
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                sb.Append(text[i]);
                if (i + 1 < text.Length && text[i] == text[i + 1])
                    sb.Append('X'); // Insert X between repeated letters
            }
            if (sb.Length % 2 != 0)
                sb.Append('X'); // pad with X if odd
            return sb.ToString();
        }

        private static char[,] GenerateTable(string keyword)
        {
            string alphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
            string keyString = "";
            keyword = keyword.ToUpper().Replace("J", "I");

            foreach (char c in keyword)
                if (!keyString.Contains(c) && alphabet.Contains(c))
                    keyString += c;

            foreach (char c in alphabet)
                if (!keyString.Contains(c))
                    keyString += c;

            char[,] table = new char[5, 5];
            int k = 0;
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    table[i, j] = keyString[k++];
            return table;
        }

        private static string ProcessPlayfair(string text, char[,] table, bool encrypt)
        {
            StringBuilder result = new StringBuilder();
            int step = encrypt ? 1 : 4; // 1 for encrypt, 4 = -1 mod 5 for decrypt

            for (int i = 0; i < text.Length; i += 2)
            {
                char a = text[i];
                char b = text[i + 1];
                int row1 = 0, col1 = 0, row2 = 0, col2 = 0;

                for (int r = 0; r < 5; r++)
                    for (int c = 0; c < 5; c++)
                    {
                        if (table[r, c] == a) { row1 = r; col1 = c; }
                        if (table[r, c] == b) { row2 = r; col2 = c; }
                    }

                if (row1 == row2)
                {
                    result.Append(table[row1, (col1 + step) % 5]);
                    result.Append(table[row2, (col2 + step) % 5]);
                }
                else if (col1 == col2)
                {
                    result.Append(table[(row1 + step) % 5, col1]);
                    result.Append(table[(row2 + step) % 5, col2]);
                }
                else
                {
                    result.Append(table[row1, col2]);
                    result.Append(table[row2, col1]);
                }
            }

            return result.ToString();
        }
    }
}