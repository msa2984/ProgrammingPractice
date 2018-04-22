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
    }
}
