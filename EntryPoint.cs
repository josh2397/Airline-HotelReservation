using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airline_Hotel_Reservation.Errors;
using Newtonsoft.Json;

namespace Airline_Hotel_Reservation
{
 


    class EntryPoint
    {
        public EntryPoint()
        {

        }

        static void Main()
        {
            //bool exit = false;
            string input;
            int noRows = -1;
            // int seat;

            Console.WriteLine("Airline or Hotel");
            input = Console.ReadLine();

            input = "Airline";
            while (!Equals(input, "exit"))
            {
                
                // Init DataAcess Object
                // Read in Json data
                // Pass to inventory
                // If no data is available, then create a new object with default values
                // Otherwise load an object with details from JSON into an inventory object
                // Enter loop to get Occupant details
                // When loop exits update the current inventory object for the user and then overwrite their details to the JSON file
                // 

                
    
                


                
                if (Equals(input, "Airline"))
                {
                    string filePath = "C:\\Users\\JM123\\source\\repos\\Airline_Hotel_Reservation\\data\\airline.json";
                    // init dataAcess object
                    var airlineDataAccess = new data.AirlineReadWriteData();
                    

                    if (airlineDataAccess.emptyFile(ref filePath))
                    {
                        var airlineSeatingInventory = new AirlineSeatingInventory();
                    }
                    else
                    {
                        var airlineSeatingInventory = new AirlineSeatingInventory(airlineDataAccess.ReadSeatsFromJson(),  airlineDataAccess.ReadAssignedSeatsFromJson()); 
                    }
                    

                    
                    var airlineReservation = new AirlineReservation();



                    //try
                    //{
                    //    airlineSeatingInventory.AssignSeat(1, 'a');
                    //}
                    //catch (SeatAssignedException ex)
                    //{
                    //    Console.WriteLine(ex.Message);
                    //    // Handle do soemthing else. 
                    //}

                    airlineReservation.SetDetails();
                    
                }
                else if (Equals(input, "Hotel"))
                {
                    Console.WriteLine("Not yet Implemented");

                }
                Console.WriteLine("Airline or Hotel");
                input = Console.ReadLine();

            }
        }
    }

    class Person
    {
        public string Name { get; set; }
         
        public long PhoneNumber{ get; set; }

        //public int Stay{ get; set;}

        public Person()
        {
            this.Name = "";
            this.PhoneNumber = -1;
            //this.Stay = -1;
        }
       
    }

    class Seats
    {
        public Person Occupant { get; set; }

        public char SeatLetter { get; set; }

        public Seats()
        {
            this.Occupant = new Person();

        }

    }


    class Rows
    {
        public Seats[] Seating { get; set; }

        public long Cost { get; set; }

        public int Row { get; set; }

        public Rows(int rowNumber)
        {
            this.Row = rowNumber;

            this.Seating = new Seats[6];
            for (int i = 0; i < 6; i++)
            {
                this.Seating[i] = new Seats();
            }
        }
    }

}
