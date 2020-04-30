using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GpsCoordinatesSerialPortReader
{
    public class GpsCoordinatesFormatter
    {
        /// <summary>
        /// Parses latitude to human readable DMS format
        /// </summary>
        /// <param name="value">Coordinate in Decimal degrees</param>
        /// <returns></returns>
        public static string ParseLatitude(double value)
        {
            var direction = value < 0 ? Direction.S : Direction.N;
            return ParseLatitudeOrLongitude(value, direction);
        }
        /// <summary>
        /// Parses longitude to human readable DMS format
        /// </summary>
        /// <param name="value">Coordinate in Decimal degrees</param>
        /// <returns></returns>
        public static string ParseLongitude(double value)
        {
            var direction = value < 0 ? Direction.W : Direction.E;
            return ParseLatitudeOrLongitude(value, direction);
        }
        private static string ParseLatitudeOrLongitude(double value, Direction direction)
        {
            value = Math.Abs(value);
            var degrees = Math.Truncate(value);
            value = (value - degrees) * 60;
            var minutes = Math.Truncate(value);
            var seconds = Math.Round((value - minutes) * 60, 1);
            return degrees + "°" + minutes + "'" + seconds.ToString().Replace(',', '.') + "\"" + direction.ToString();
        }
    }
}
