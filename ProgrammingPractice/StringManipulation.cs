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

            for(int i = (input.ToCharArray().Count() - 1); i >= 0; i--)
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
                output[output.Count() -1 - i] = output[i];
                output[i] = secondChar;
            }

            return new string(output);
        }
    }
}
