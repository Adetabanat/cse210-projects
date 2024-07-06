using System;
using System.Threading;

namespace MindfulnessApp
{
    // Base class for activities
    public abstract class MindfulnessActivity
    {
        public int Duration { get; set; }
        protected abstract string Description { get; }

        public void Start()
        {
            ShowStartMessage();
            Thread.Sleep(3000); // Pause for 3 seconds
            RunActivity();
            ShowEndMessage();
        }

        private void ShowStartMessage()
        {
            Console.Clear();
            Console.WriteLine($"Starting {this.GetType().Name}...");
            Console.WriteLine(Description);
            Console.Write("Enter the duration of the activity in seconds: ");
            Duration = int.Parse(Console.ReadLine());
            Console.WriteLine("Prepare to begin...");
        }

        private void ShowEndMessage()
        {
            Console.WriteLine("Good job!");
            Console.WriteLine($"You have completed the {this.GetType().Name} activity for {Duration} seconds.");
            Thread.Sleep(3000); // Pause for 3 seconds
        }

        protected abstract void RunActivity();

        protected void ShowSpinner(int seconds)
        {
            for (int i = 0; i < seconds; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }
    }
}
