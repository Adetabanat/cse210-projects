using System;
using System.Collections.Generic;

namespace MindfulnessApp
{
    public class ListingActivity : MindfulnessActivity
    {
        private static readonly string[] Prompts =
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        protected override string Description => "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

        protected override void RunActivity()
        {
            Random random = new Random();
            string prompt = Prompts[random.Next(Prompts.Length)];
            Console.WriteLine(prompt);

            Console.WriteLine("You have a few seconds to think...");
            ShowSpinner(3);

            List<string> items = new List<string>();
            Console.WriteLine("Start listing items:");
            DateTime endTime = DateTime.Now.AddSeconds(Duration);
            while (DateTime.Now < endTime)
            {
                string item = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(item)) break;
                items.Add(item);
            }

            Console.WriteLine($"You listed {items.Count} items.");
        }
    }
}
