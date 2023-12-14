using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Air_Tek.Models.Orderdata;

namespace Air_Tek
{
    public class FlightScheduler
    {
        private List<Flight> flightSchedule = new List<Flight>();
        public List<Order> orders = new List<Order>();

        public void LoadFlightSchedule()
        {
            // Populate flight schedule for two days
            for (int day = 1; day <= 2; day++)
            {
                flightSchedule.Add(new Flight { FlightNumber = day * 3 - 2, Departure = "YUL", Arrival = "YYZ", Day = day });
                flightSchedule.Add(new Flight { FlightNumber = day * 3 - 1, Departure = "YUL", Arrival = "YYC", Day = day });
                flightSchedule.Add(new Flight { FlightNumber = day * 3, Departure = "YUL", Arrival = "YVR", Day = day });
            }
        }

        public void DisplayFlightSchedule()
        {
            foreach (var flight in flightSchedule)
            {
                Console.WriteLine($"Flight: {flight.FlightNumber}, departure: {flight.Departure}, arrival: {flight.Arrival}, day: {flight.Day}");
            }
        }

        public void LoadOrders(string jsonFilePath)
        {
            // Read orders from JSON file
            string jsonData = File.ReadAllText(jsonFilePath);
            JObject ordersJson = JObject.Parse(jsonData);
            // Deserialize JSON to C# object
            foreach (var order in ordersJson)
            {
                string orderKey = order.Key;
                string destination = order.Value["destination"].ToString();
                // Create Order object and add to the list
                Order newOrder = new Order { OrderNumber = orderKey, Destination = destination };
                orders.Add(newOrder);
            }
        }

        public void GenerateFlightItineraries()
        {
            foreach (var order in orders)
            {
                var scheduledFlight = flightSchedule.FirstOrDefault(flight =>
                    flight.Departure == "YUL" && flight.Arrival == order.Destination);

                if (scheduledFlight != null)
                {
                    Console.WriteLine($"order: {order.OrderNumber}, flightNumber: {scheduledFlight.FlightNumber}, " +
                                      $"departure: {scheduledFlight.Departure}, arrival: {scheduledFlight.Arrival}, day: {scheduledFlight.Day}");
                }
                else
                {
                    Console.WriteLine($"order: {order.OrderNumber}, flightNumber: not scheduled");
                }
            }
        }
    }
}
