// Made by Ohno 
// 12/10/2025

using System;
using System.Linq.Expressions;
using System.Net;
using Cypher.Utils; 

class MainProgram
{
    static void Main()
    {
        // Initialize variables
        string onlinePoints = "0"; 
        string localPoints = "0";   
        string userVersion = "1.0.0"; // Current program version
        string versionUrl = "https://raw.githubusercontent.com/Ilikepinapples/codecracker9000/refs/heads/main/version.txt"; // URL for latest version
        string pointsUrl = "https://raw.githubusercontent.com/Ilikepinapples/codecracker9000/refs/heads/main/points.txt"; // URL for online points
        string restartStr = "hi world"; 
        bool restart = true; // Main loop

        // Checking the version
        using (WebClient client = new WebClient())
        {
            string onlineVersion = client.DownloadString(versionUrl).Trim();

            if (onlineVersion == userVersion)
            {
                Console.WriteLine("You're on the latest version, noice!");
            }
            else
            {
                Console.WriteLine("\nPlease upgrade to the latest version :)");
                Console.WriteLine($"Your version is: {userVersion}  →  the latest is: {onlineVersion}");
                Console.WriteLine("Please update via the github: https://github.com/YourUsername/YourRepo");
                restart = false; // Stop the whole script if the it is on the old version
            }
        }

        // Online points
        using (WebClient client = new WebClient())
        {
            onlinePoints = client.DownloadString(pointsUrl).Trim();
        }

        // Shove everything inside this loop
        while (restart == true)
        {
            Console.WriteLine($"\n=== Epic Encryption Toolkit ===");

            // Choose cipher
            string choice = "";
            while (choice != "1" && choice != "2")
            {
                Console.WriteLine("Please choose a cipher:");
                Console.WriteLine($@"
╔════════════════════════════════════════════════════════════════╗
║  ____            _           _     _ _ _ _                     ║
║ |  _ \ _ __ ___ | |__   __ _| |__ (_) (_) |_ _   _             ║
║ | |_) | '__/ _ \| '_ \ / _` | '_ \| | | | __| | | |            ║
║ |  __/| | | (_) | |_) | (_| | |_) | | | | |_| |_| |            ║
║ |_|   |_|  \___/|_.__/ \__,_|_.__/|_|_|_|\__|\__, |            ║
║ (_)___                                       |___/             ║
║ | / __|                                                        ║
║ | \__ \      _                                                 ║
║ |_|___/ __ _(_)_ __                                            ║
║ | '_ \ / _` | | '_ \                                           ║
║ | |_) | (_| | | | | |                                          ║
║ | .__/ \__,_|_|_| |_|                                          ║
║ |_|                                                            ║      
╠════════════════════════════════════════════════════════════════╣
║                          Cypher Toolkit                        ║
║                V{userVersion}  •  by Probability is pain               ║ // Compensates for the {} so DONT move
╠════════════════════════════════════════════════════════════════╣
║  1) Ceaser Cypher            |       6) Points checker         ║
║  2) Frequency Analysis       |       7) Leaderboard            ║
║  3) Playfair Cypher          |       8) Website                ║
║  4) Possibility generation   |       9) Update Check           ║
║  5) Unknown                  |       0) Exit                   ║
╠════════════════════════════════════════════════════════════════╣
║  Type in the number then press ENTER to choose an option       ║
║  Ctrl+C to quit                                                ║
╚════════════════════════════════════════════════════════════════╝
");

                choice = Console.ReadLine() ?? ""; // A cool command ("??") which automatically adds a space between the previous line
            }

            // Choices
            if (choice == "1") // Caesar cipher
            {
                Console.WriteLine("Enter the text: ");
                string text = Console.ReadLine();

                Console.WriteLine("Enter shift value (0–25):");
                int shift = int.Parse(Console.ReadLine());

                string encrypted = CaesarShift.EncryptDecrypt(text, shift);
                string decrypted = CaesarShift.EncryptDecrypt(encrypted, shift, decrypt: true);

                Console.WriteLine($"\nEncrypted: {encrypted}");
                Console.WriteLine($"Decrypted: {decrypted}");
            }
            else if (choice == "2") // Playfair cipher
            {
                Console.WriteLine("Enter text:");
                string text = Console.ReadLine();

                Console.WriteLine("Enter keyword:");
                string keyword = Console.ReadLine();

                string encrypted = PlayfairCipher.Encrypt(text, keyword);
                string decrypted = PlayfairCipher.Decrypt(encrypted, keyword);

                Console.WriteLine($"\nEncrypted: {encrypted}");
                Console.WriteLine($"Decrypted: {decrypted}");
            }
            else if (choice == "3" || choice == "4" || choice == "5")
            {
                Console.WriteLine("In progress...");
            }
            else if (choice == "6") // Points checker
            {
                Console.WriteLine($"You have {onlinePoints}");
            }

            
            Console.WriteLine("Would you like to quit? (y/n)");
            restartStr = Console.ReadLine();
            if (restartStr == "y")
            {
                restart = false; // Exit the loop
            }
            else
            {
                Console.WriteLine("\nLife's great!");
                restart = true; // Stay in the loop
            }
        }
    }
}
