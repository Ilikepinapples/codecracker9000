using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class CaesarCipher
{
private static readonly string COMMON_WORDS = "THE AND IS IN OF TO IT YOU FOR ON IF";

public static void Main()
{
Console.Write("Enter ciphertext: ");
string ciphertext = Console.ReadLine().ToUpper();

List<(int shift, string decryptedText)> candidates = new List<(int, string)>();

// Try Caesar decryption for all shifts from 0 to 25
for (int shift = 0; shift < 26; shift++)
{
string decryptedText = CaesarDecrypt(ciphertext, shift);
candidates.Add((shift, decryptedText));
}

// Rank candidates based on common word presence
var ranked = RankCandidates(candidates);

Console.WriteLine("\nTop guesses:");
foreach (var (score, guess) in ranked.Take(5))
{
Console.WriteLine($"[Score {score}] {guess}");
}
}

private static string CaesarDecrypt(string text, int shift)
{
string result = string.Empty;
foreach (char c in text)
{
if (char.IsLetter(c))
{
char decryptedChar = (char)((((c - 'A') - shift + 26) % 26) + 'A');
result += decryptedChar;
}
else
{
result += c; // Keep non-alphabetic characters
}
}
return result;
}

private static int WordScore(string text)
{
var words = Regex.Split(text, @"\W+").Select(w => w.ToUpper());
return words.Count(w => COMMON_WORDS.Split(' ').Contains(w));
}

private static List<(int score, string text)> RankCandidates(List<(int shift, string decryptedText)> candidates)
{
var scoredCandidates = candidates
.Select(c => (WordScore(c.decryptedText), c.decryptedText))
.OrderByDescending(c => c.Item1) 
.ToList();

return scoredCandidates;
}
}
