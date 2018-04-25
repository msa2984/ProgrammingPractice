using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPractice
{
    public class MathManipulation
    {
        /// <summary>
        /// Number of degrees in a circle.
        /// </summary>
        private const int DegreesInCircle = 360;
        /// <summary>
        /// Number of hours on a typical clock, which 
        /// follows AM / PM designation, not military time.
        /// </summary>
        private const int HoursOnClock = 12;
        /// <summary>
        /// Number of minutes in an hour.
        /// </summary>
        private const int MinutesInHour = 60;
        /// <summary>
        /// Conversion factor from degrees to radians.
        /// </summary>
        private const double RadianPerDecimal = Math.PI / 180;

        /// <summary>
        /// Method that calculates the angle between the hour and minute 
        /// hands on a standard 12-hour clock.
        /// </summary>
        /// <param name="hourInt">The hour in the day.</param>
        /// <param name="minuteInt">The minute in the day.</param>
        /// <returns>A Tuple with the angle in degrees, and in radians.</returns>
        public static Tuple<decimal, decimal> CalculateClockAngle(int hourInt, int minuteInt)
        {
            decimal hourAngle = DegreesInCircle / HoursOnClock * (hourInt + Decimal.Divide(minuteInt, MinutesInHour));
            decimal minuteAngle = DegreesInCircle / MinutesInHour * minuteInt;

            decimal degreeDifference = Math.Abs(hourAngle - minuteAngle);
            decimal radianDifference = degreeDifference * (decimal)RadianPerDecimal;

            return new Tuple<decimal, decimal>(degreeDifference, radianDifference);
        }

        /// <summary>
        /// Iteratively finds the Fibonacci sequence, up to n-entries. Takes O(n) time. 
        /// </summary>
        /// <param name="numberOfIteractions">n number of entries to calculate.</param>
        /// <returns>A string with the Fibonacci sequence, separated by a comma.</returns>
        public static string BruteForceFibonacciCalculation(int numberOfIterations)
        {
            List<ulong> fibonacciNumbers = new List<ulong>();

            for (int i = 0; i < numberOfIterations; i++)
            {

                switch (fibonacciNumbers.Count)
                {
                    case 0:
                        fibonacciNumbers.Add(0);
                        break;
                    case 1:
                    case 2:
                        fibonacciNumbers.Add(1);
                        break;
                    default:
                        fibonacciNumbers.Add(fibonacciNumbers[i - 1] + fibonacciNumbers[i - 2]);
                        break;
                }
            }
            return String.Join(" , ", fibonacciNumbers);
        }

        /// <summary>
        /// Iteratively finds the Fibonacci sequence, up to n-entries. Takes exponential time. 
        /// </summary>
        /// <param name="numberOfIteractions">n number of entries to calculate.</param>
        /// <returns>A string with the Fibonacci sequence, separated by a comma.</returns>
        public static string RecursiveFibonacciCalculation(int numberOfIterations)
        {
            string fibonacciNumbers = String.Empty;
            PerformFibonacciRecursion(0, 1, 1, numberOfIterations, ref fibonacciNumbers);
            return fibonacciNumbers;
        }

        /// <summary>
        /// Recursive helper method for RecursiveFibonacciCalculation.
        /// </summary>
        /// <param name="firstValueToAdd">The first Fibonacci value in this iteration</param>
        /// <param name="secondValueToAdd">The second Fibonacci value in this iteration</param>
        /// <param name="counter">tracker to determine when all of the Fibonacci values have been calculated.</param>
        /// <param name="nValue">the value of n - number of Fibonacci numbers to report</param>
        /// <param name="fibString">the string to append the first Fibonacci value to.</param>
        public static void PerformFibonacciRecursion(ulong firstValueToAdd, ulong secondValueToAdd,
            int counter, int nValue, ref string fibString)
        {
            fibString += firstValueToAdd;
            if (counter < nValue)
            {
                fibString += " , ";
                PerformFibonacciRecursion(secondValueToAdd, firstValueToAdd + secondValueToAdd,
                    counter + 1, nValue, ref fibString);
            }
        }

        /// <summary>
        /// Takes in an array of integers, and simplifies it: 
        /// Any adjacent duplicates are added together and the second instance set to 0;
        /// all zeroes are pushed to the end of the array.
        /// </summary>
        /// <param name="arrayToSimplify">The array to simplify.</param>
        /// <returns>The simplified array.</returns>
        public static int[] PerformArraySimplification(int[] arrayToSimplify)
        {
            int count = 0;
            for (int i = 0; i < arrayToSimplify.Length; i++)
            {
                if (i + 1 < arrayToSimplify.Length && arrayToSimplify[i] == arrayToSimplify[i + 1] && arrayToSimplify[i] != 0)
                {
                    arrayToSimplify[i] += arrayToSimplify[i + 1];
                    arrayToSimplify[i + 1] = 0;
                }

                if (arrayToSimplify[i] != 0)
                {
                    arrayToSimplify[count++] = arrayToSimplify[i];
                }
            }            

            while (count < arrayToSimplify.Length)
            {
                arrayToSimplify[count++] = 0;
            }

            return arrayToSimplify;
        }

        /// <summary>
        /// Takes in an array of integers, and sorts it
        /// by swapping adjacent integers in-line... O(n^2) 
        /// </summary>
        /// <param name="arrayToSort">The array to sort.</param>
        /// <returns>The sorted array.</returns>
        public static int[] PerformBubbleSort(int[] arrayToSort)
        {
            for (int i = 0; i < arrayToSort.Length - 1; i++)
            {
                for (int j = 0; j < arrayToSort.Length - i - 1; j++)
                {
                    if (arrayToSort[j] > arrayToSort[j + 1])
                    {
                        int temp = arrayToSort[j];
                        arrayToSort[j] = arrayToSort[j + 1];
                        arrayToSort[j + 1] = temp;
                    }
                }
            }

            return arrayToSort;
        }

        /// <summary>
        /// Takes in an array of integers, and sorts it: 
        /// If the current item is less than at least one previous item, 
        /// insert the current item in front of the item it is less than.
        /// O(n^2)
        /// </summary>
        /// <param name="arrayToSort">The array to sort.</param>
        /// <returns>The sorted array.</returns>
        public static int[] PerformInsertionSort(int[] arrayToSort)
        {
            for (int i = 1; i < arrayToSort.Length; ++i)
            {
                int currentValue = arrayToSort[i]; //Store this as the while loop will change the value of arrayToSort[i]
                int j = i - 1;

                while (j >= 0 && arrayToSort[j] > currentValue)
                {
                    arrayToSort[j + 1] = arrayToSort[j];
                    j = j - 1;
                }
                arrayToSort[j + 1] = currentValue;
            }
            return arrayToSort;
        }

        /// <summary>
        /// Determine the next pivot index for QuickSort -> i.e., 
        /// max of first array, min of second array.
        /// </summary>
        /// <param name="sortArray">array to sort</param>
        /// <param name="minIndex">the minimum index of the array.</param>
        /// <param name="maxIndex">the maximum index of the array.</param>
        /// <returns>an integer index to further pivot the index by.</returns>
        public static int GetIndexOfSplit(int[] sortArray, int minIndex, int maxIndex)
        {
            int splitIndex = sortArray[maxIndex];           
            int i = (minIndex - 1);
            for (int j = minIndex; j < maxIndex; j++)
            {
                if (sortArray[j] <= splitIndex)
                {
                    i++;

                    int temp = sortArray[i];
                    sortArray[i] = sortArray[j];
                    sortArray[j] = temp;
                }
            }

            int tempValue = sortArray[i + 1];
            sortArray[i + 1] = sortArray[maxIndex];
            sortArray[maxIndex] = tempValue;

            return i + 1;
        }

        /// <summary>
        /// Method to recursively call to perform a quick sort of
        /// an array of integers.
        /// </summary>
        /// <param name="arrayToSort">The array to sort</param>
        /// <param name="minIndex">the minimum index of the sort array</param>
        /// <param name="maxIndex">the maximum index of the sort array</param>
        public static void QuickSort(int[] arrayToSort, int minIndex, int maxIndex)
        {
            if (minIndex < maxIndex)
            {
                int partionIndex = GetIndexOfSplit(arrayToSort, minIndex, maxIndex);

                // Recursively sort elements before partition and after partition
                QuickSort(arrayToSort, minIndex, partionIndex - 1);
                QuickSort(arrayToSort, partionIndex + 1, maxIndex);
            }
        }
    }
}
