using System.Runtime.ConstrainedExecution;

namespace Cypher.Utils
{
    internal class Program
    {
        static char[] englishfrequent = {'E','T','A','O','I','N','S','H','R','D','L','C','U','M','W','F','G','Y','P','B','V','K','J','X','Q','Z'};


         
        static void Main(string[] args)
        {
            string frequencyToAnalyse;
            frequencyToAnalyse = Console.ReadLine();
            (int, char)[] analysed;
            analysed = frequencyAnalyse(frequencyToAnalyse);
            
            (char, char)[] translationArray = new (char, char)[26];

            for (int i = 0; i < 26; i++)
            {
                translationArray[i] = (englishfrequent[i], analysed[i].Item2);
                Console.WriteLine("English letter {0} likely matches to the letter {1} within this text (value of {2})", englishfrequent[i], analysed[i].Item2, analysed[i].Item1);
            }
            for (int i = 0; i < 26; i++)
            {
                Console.WriteLine("{0}:{1}", englishfrequent[i], analysed[i].Item2);
            }
            Console.WriteLine("An attempted decoding gives the following: ");
            
            Console.WriteLine(decode(frequencyToAnalyse, translationArray));


            

        }



        //write code to give an uncertainty to frequency values, any values within, say 5, get grouped as being possible for a certain letter, all of these posibiulities are tried and any that are intelligible (contain "THE" in this case) are displayed to the user

        //public static List<string> decodingPossibilities(string toDecode)
        //{
        //    string possibleDecoding;
        //   possibleDecoding = decode();
        //    possibleDecoding.Contains("THE");
        //}




        public static string decode(string toDecode, (char, char)[] translationTupleArray)
        {
            string decodedAnalysingString = "";

            foreach (char c in toDecode.ToUpper())
            {
                foreach ((char, char) translation in translationTupleArray)
                {
                    if (translation.Item1 == c)
                    {
                        decodedAnalysingString = decodedAnalysingString.Insert(decodedAnalysingString.Length, translation.Item2.ToString());
                    }
                }
            }

            return (decodedAnalysingString);
        }





        public static (int, char)[] frequencyAnalyse(string inputAnalyse)
        {
            string lowerInputAnalyse = inputAnalyse.ToUpper();
            (int, char)[] FrequencytupleArray = new (int, char)[26];
            for (int letter = 0; letter < 26; letter++)
            {
                int count = 0;
                foreach (char charecter in lowerInputAnalyse)
                {
                    if (charecter == englishfrequent[letter])
                    {
                        count++;
                    }
                } 
                FrequencytupleArray[letter] = (count, englishfrequent[letter]);
            }
            Array.Sort(FrequencytupleArray);
            Array.Reverse(FrequencytupleArray);
            return FrequencytupleArray;
        }





    }
}



