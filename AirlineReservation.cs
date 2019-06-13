using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Airline_Hotel_Reservation.Helpers;

namespace Airline_Hotel_Reservation
{
    // 
    class AirlineReservation : IReservation
    {
        private Rows[] rows;
        private int noRows;
        private int seatsPerRow = 6;

        public AirlineReservation() 
        {
            
            

            // Structs have value type semantics while classes are reference type semantics
            // So by default struct fields are private

        }

        T[] InitArray<T>(int arraySize) where T : new()
        {
            T[] array = new T[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                array[i] = new T();
            }
            return array;
        }

        public void SetDetails()
        {
            bool continueEnteringDetails = true;

            while (continueEnteringDetails)
            {


                int row = -1;
                int seatLetterIndex = -1;
                string name = "";
                long phoneNumber = -1;
                char seatLetter = ' ';

                // Get the row number from user
                ReadRowNumber(ref row);

                // Get seat letter from user
                ReadSeatLetter(ref seatLetterIndex, ref seatLetter);


                CheckAvailability(ref row, ref seatLetterIndex, ref seatLetter);

                // Get occupant's name
                ReadOccupantDetails(ref name, ref phoneNumber);

                // Check if seat has been allocated already

                this.rows[row].Seating[seatLetterIndex].SeatLetter = seatLetter;
                this.rows[row].Seating[seatLetterIndex].Occupant.Name = name;
                this.rows[row].Seating[seatLetterIndex].Occupant.PhoneNumber = phoneNumber;

                Console.WriteLine("Continue entering Details?");
                if (Equals(Console.ReadLine(), "exit"))
                {
                    continueEnteringDetails = false;
                }
            }

            // return to entry point to store data in JSON

        }

        public void CheckAvailability(ref int row, ref int seatLetterIndex, ref char seatLetter)
        {
            

            Console.WriteLine($"Row : {row} \nSeatLetterIndex: {seatLetterIndex}");

            while (Equals(this.rows[row].Seating[seatLetterIndex].SeatLetter, ' '))
            {
                //int[,] availableSeating = new int[this.noRows, this.seatsPerRow];
                Console.WriteLine("Seat is already taken, please choose another");
                // Show the currently available seats
                //for (int i = 0; i < this.noRows; i++)
                //{
                    
                //}

                // Get the row number from user
                ReadRowNumber(ref row);

                // Get seat letter from user
                ReadSeatLetter(ref seatLetterIndex, ref seatLetter);

                Console.WriteLine($"Row : {row} \nSeatLetterIndex: {seatLetterIndex}");
            }



        }

        public void ReadOccupantDetails(ref string name, ref long phoneNumber)
        {
            Console.WriteLine("Enter your name");

            name = Console.ReadLine();

            while (!name.IsAWord())
            {

                Console.WriteLine("Name isn't a vaid string");
                Console.WriteLine("Enter your name");
                name = Console.ReadLine();
            }

            // get phone number
            Console.WriteLine("Enter your phone number");
            //phoneNumber = 

            while (!long.TryParse(Console.ReadLine(), out phoneNumber))
            {
                Console.WriteLine("Couldn't read phone number");
                Console.WriteLine("Enter your phone number");
            }

        }

        public void ReadSeatLetter(ref int seatLetterIndex, ref char seatLetter)
        {

            IDictionary<char, int> rowsSeatsMap = new Dictionary<char, int>()
            {
                {'a', 0 },
                {'b', 1 },
                {'c', 2 },
                {'d', 3 },
                {'e', 4 },
                {'f', 5 },
            };

            Console.WriteLine("Enter the Seat Letter");
            int seatLetterInput = Console.Read();
            seatLetter = Convert.ToChar(seatLetterInput);

            // Check if char is letter
            while (!Char.IsLetter(seatLetter))
            {
                Console.WriteLine("Please enter a valid letter : " + seatLetter);
                Console.WriteLine("Enter the Seat Letter");
                seatLetterInput = Console.Read();
                seatLetter = Convert.ToChar(seatLetterInput);
            }
            Console.ReadLine();

            seatLetterIndex = rowsSeatsMap[seatLetter];

        }

        private void ReadRowNumber(ref int row)
        {
            // Get the row number
            
            Console.WriteLine("Enter a row number");
            int.TryParse(Console.ReadLine(), out row);
            
            while (((0 > row) || (row > (this.noRows - 1))))
            {
                Console.WriteLine("Incorrect row number entered");
                Console.WriteLine("Enter a row number");
                int.TryParse(Console.ReadLine(), out row);
            }
        }




    }

}