using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Schema;
using Air_Tek;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

class Program
{
    static void Main()
    {
        // Create an instance of FlightScheduler
        FlightScheduler flightScheduler = new FlightScheduler();

        // Load flight schedule
        flightScheduler.LoadFlightSchedule();

        // Display loaded flight schedule
        flightScheduler.DisplayFlightSchedule();

        // Load orders from the provided JSON file
        flightScheduler.LoadOrders("C:\\Users\\harsh\\OneDrive\\Desktop\\Project\\Air-Tek\\Json\\orders.json");

        // Generate and display flight itineraries based on loaded orders
        flightScheduler.GenerateFlightItineraries();
    }
}
