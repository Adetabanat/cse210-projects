using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    class Program
    {
        static void Main()
        {
            List<Activity> activities = new List<Activity>
            {
                new Running(new DateTime(2024, 01, 2), 50, 1.0),
                new Cycling(new DateTime(2024, 01, 3), 30, 15.0),
                new Swimming(new DateTime(2024, 01, 4), 40, 40)
            };

            foreach (var activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
                Console.WriteLine();
            }
        }
    }
}
