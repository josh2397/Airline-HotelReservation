using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline_Hotel_Reservation
{
    class AirlineOccupantDetails
    {
            public string Name { get; set; }

            public long PhoneNumber { get; set; }

            //public int Stay{ get; set;}

            public AirlineOccupantDetails()
            {
                this.Name = "";
                this.PhoneNumber = -1;
                //this.Stay = -1;
            }

    }
}
