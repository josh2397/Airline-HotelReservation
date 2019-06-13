using Airline_Hotel_Reservation.Errors;
using Airline_Hotel_Reservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline_Hotel_Reservation
{
    class AirlineSeatingInventory
    {
        private const int noRows = 10;
        private const int seatsPerRow = 6;

        private readonly IEnumerable<Seat> seats;
        private readonly List<string> assignedSeats;

        public AirlineSeatingInventory()
        {
            this.assignedSeats = new List<string>();
            var seats = new List<Seat>();

            for (int i = 0; i < noRows; i++)
            {
                for (int j = 0; j < seatsPerRow; j++)
                {
                    seats.Add(new Seat(i + 1, (char)(j + 1)));
                }
            }

            this.seats = seats;
        }

        public AirlineSeatingInventory(IEnumerable<Models.Seat> seatsFromFile, List<string> assignedSeatsFromFile)
        {
            this.seats = seatsFromFile;
            this.assignedSeats = assignedSeatsFromFile;
        }

        public bool IsAvailable(int rowNumber, char seat)
        {
            return this.assignedSeats.Any(x => x != $"{rowNumber}{seat}");
        }

        public void AssignSeat(int rowNumber, char seat)
        {
            if (this.IsAvailable(rowNumber, seat))
            { 
                this.assignedSeats.Add($"{rowNumber}{seat}");
                return;
            }

            throw new SeatAssignedException(rowNumber, seat);
        }

        public IEnumerable<Seat> AvailableSeats()
        {
            return this.seats.Where(x => !this.assignedSeats.Contains(x.ToString()));
        }

        // TODO - Remove Occupant from Seat

        // TODO - Get particular occupants details and their seating ID

        // TODO - Edit Occupants details


    }
}
