using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline_Hotel_Reservation.Errors
{
    class SeatAssignedException : Exception
    {
        public SeatAssignedException(int rowNumber, char seat) 
            : base($"{rowNumber}{seat} has already been assigned")
        {
        }
    }
}
