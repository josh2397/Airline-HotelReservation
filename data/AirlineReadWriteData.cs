using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Airline_Hotel_Reservation.data
{
    class AirlineReadWriteData
    {
        public bool emptyFile(ref string filePath)
        {
            // Check if file exists and if it's empty.
            
            if (new FileInfo(filePath).Exists)
            {
                if (new FileInfo(filePath).Length == 0)
                {
                    return true;
                }
                
                return false;
                
            }
            else
            {
                return true;
            }
            

        }
 
            //TODO - Read in assignedSeats
        public IEnumerable<Models.Seat> ReadSeatsFromJson()
        {
            Console.WriteLine("Reading Json data into inventory object");
            string readPath = "C:\\Users\\JM123\\source\\repos\\Airline_Hotel_Reservation\\data\\airline.json";
            
            //TODO - decrypt json and read into object

            // Read in Json file and return 
            IEnumerable<Models.Seat> seats = JsonConvert.DeserializeObject<IEnumerable<Models.Seat>>(File.ReadAllText(readPath));

            //using (StreamReader file = File.OpenText(readPath))
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    Models.Seat seats = (Models.Seat)serializer.Deserialize(file, typeof(Models.Seat));
            //}
            return seats;

        }

        public List<string> ReadAssignedSeatsFromJson()
        {
            Console.WriteLine("Reading Assigned Seats");
            string readPath = "C:\\Users\\JM123\\source\\repos\\Airline_Hotel_Reservation\\data\\assignedSeats.json";

            List<string> assignedSeats = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(readPath));

            return assignedSeats;
        }

        // TODO - Store Assigned Seats
        public void StoreObjectToJson(ref IEnumerable<Models.Seat> seats)
        {
            Console.WriteLine("Storing variables for airline reservation");
            string writePath = "C:\\Users\\JM123\\source\\repos\\Airline_Hotel_Reservation\\data\\airline.json";

            File.WriteAllText(@writePath, JsonConvert.SerializeObject(seats));

            using (StreamWriter file = File.CreateText(@writePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, seats);
            }
            // TODO - Encrypt Json

        }
    }
}
