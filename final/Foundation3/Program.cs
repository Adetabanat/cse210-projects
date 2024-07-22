using System;

namespace EventPlanning
{
    class Program
    {
        static void Main()
        {
            // Create addresses
            Address address1 = new Address("St Augustine's College", "Cape Coast", "CP", "Ghana");
            Address address2 = new Address("Bakanoo st", "Cape coast", "CP", "Ghana");
            Address address3 = new Address("Los Angelos St", "Tem", "TM", "USA");

            // Create events
            Lecture lecture = new Lecture("Programming", "Introduction to Programming.", "2024-06-02", "07:00 AM", address1, "Dr. Adngo Damian", 200);
            Reception reception = new Reception("Technology Summit", "The 21st technology summit Abuja", "2024-08-02", "6:00 PM", address2, "rsvp@network.com");
            OutdoorGathering outdoorGathering = new OutdoorGathering("Party at the lobby", "A department party.", "2024-09-07", "15:00 PM", address3, "cloudy with a chance of rain");

            // Create an array of events
            Event[] events = { lecture, reception, outdoorGathering };

            // Display details for each event
            foreach (var evt in events)
            {
                Console.WriteLine("Standard Details:");
                Console.WriteLine(evt.GetStandardDetails());
                Console.WriteLine();

                Console.WriteLine("Full Details:");
                Console.WriteLine(evt.GetFullDetails());
                Console.WriteLine();

                Console.WriteLine("Short Description:");
                Console.WriteLine(evt.GetShortDescription());
                Console.WriteLine();
                Console.WriteLine(new string('-', 50));
                Console.WriteLine();
            }
        }
    }
}
