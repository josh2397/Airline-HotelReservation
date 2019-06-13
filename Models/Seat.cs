using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline_Hotel_Reservation.Models
{
    class Seat
    {
        public Seat()
        {
        }

        public Seat(int row, char seatId)
        {
            Row = row;
            SeatId = seatId;
        }

        public int Row { get; set; }

        public char SeatId { get; set; }

        public override string ToString()
        {
            return $"{this.Row}{this.SeatId}";
        }
    }
}
