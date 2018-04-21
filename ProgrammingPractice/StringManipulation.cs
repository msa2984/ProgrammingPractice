using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPractice
{
    public class StringManipulation
    {
        /// <summary>
        /// Takes in a string and returns the reversal of that string.
        /// Algorithm iterates through the input backwards, writing
        /// each character to the output string, taking n iterations
        /// to perform. (n is the number of characters in the string)
        /// </summary>
        /// <param name="input">The string to reverse.</param>
        /// <returns>The reversed string.</returns>
        public static string BruteForceStringReversal(string input)
        {
            string output = String.Empty;

            for (int i = (input.ToCharArray().Count() - 1); i >= 0; i--)
            {
                output += input.ToCharArray()[i];
            }
            return output;
        }

        /// <summary>
        /// Takes in a string and returns the reversal of that string. 
        /// Algorithms recursively reverses the string, needing to look
        /// at every element.
        /// </summary>
        /// <param name="input">The string to reverse.</param>
        /// <returns>The reversed string.</returns>
        public static string RecursiveStringReversal(string input)
        {
            string currentCharacter = input.ToCharArray()[(input.Length - 1)].ToString();
            if (input.Length > 1)
            {
                currentCharacter += RecursiveStringReversal(input.Substring(0, input.Length - 1));
            }
            return currentCharacter;
        }

        /// <summary>
        /// Takes in a string and returns the reversal of that string. 
        /// Algorithms swaps characters within the char array, 
        /// taking n/2 iterations to perform. 
        /// (n is the number of characters in the string)
        /// </summary>
        /// <param name="input">The string to reverse.</param>
        /// <returns>The reversed string.</returns>
        public static string SwappingStringReversal(string input)
        {
            char[] output = input.ToCharArray();

            for (int i = 0; i < output.Count() / 2; i++)
            {
                char secondChar = output[output.Count() - 1 - i];
                output[output.Count() - 1 - i] = output[i];
                output[i] = secondChar;
            }

            return new string(output);
        }

        /// <summary>
        /// Takes in a string, and returns the first repeated character. 
        /// Because of the nested for loops, this take O(n^2) to complete,
        /// so it is slow.
        /// </summary>
        /// <param name="input">The string to search for the recurring character.</param>
        /// <returns>the first recurring character, or null if no character is repeated.</returns>
        public static string BruteForceRecurringDetection(string input)
        {
            bool matchFound = false;
            char repeatedChar = ' ';
            for (int i = 0; i <= input.Count() - 1; i++)
            {
                for (int j = i + 1; j <= input.Count() - 1; j++)
                {
                    if (input[i] == input[j])
                    {
                        repeatedChar = input[i];
                        matchFound = true;
                        break;
                    }
                }

                if (matchFound)
                {
                    repeatedChar = input[i];
                    break;
                }
            }

            return matchFound ? repeatedChar.ToString() : null;
        }

        /// <summary>
        /// Takes in a string, and returns the first repeated character. 
        /// While storing the characters in a separate List takes up
        /// more space in memory, this function is faster because it 
        /// doesn't require nested for loops. {O(n)}
        /// </summary>
        /// <param name="input">The string to search for the recurring character.</param>
        /// <returns>the first recurring character, or null if no character is repeated.</returns>
        public static string DictionaryLookupRecurringDetection(string input)
        {
            bool matchFound = false;
            //A normal Dictionary generally does not guarantee item order 
            //But since items aren't being removed in this function, 
            //that isn't a concerned - otherwise SortedDictionary could be used.
            Dictionary<char,int> occuringCharacters = new Dictionary<char, int>();
            for (int i = 0; i <= input.Count() - 1; i++)
            {
                if (!occuringCharacters.ContainsKey(input[i]))
                {
                    occuringCharacters.Add(input[i], 1);
                }
                else
                {
                    occuringCharacters[input[i]]++;
                    matchFound = true;
                    break;
                }
            }
            return matchFound ? occuringCharacters.First(c => c.Value > 1).Key.ToString() : null;
        }
    }
}

