using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Air_Tek.Models
{
    public class Orderdata
    {
        public class Flight
        {
            public int FlightNumber { get; set; }
            public string Departure { get; set; }
            public string Arrival { get; set; }
            public int Day { get; set; }
        }

        public class Order
        {
            public string OrderNumber { get; set; }
            public string Destination { get; set; }
        }
    }
}
