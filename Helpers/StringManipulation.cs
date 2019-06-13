using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Airline_Hotel_Reservation.Helpers
{
    public static class StringManipulation
    {
        public static bool IsAWord(this string text)
        {
            var regex = new Regex(@"\b[\w']+\b");
            var match = regex.Match(text);
            return match.Value.Equals(text);
        }
    }
}
