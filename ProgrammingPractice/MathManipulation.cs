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

    }
}
