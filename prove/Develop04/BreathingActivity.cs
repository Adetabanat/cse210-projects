using System;

namespace MindfulnessApp
{
    public class BreathingActivity : MindfulnessActivity
    {
        protected override string Description => "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";

        protected override void RunActivity()
        {
            int halfDuration = Duration / 2;
            for (int i = 0; i < halfDuration; i++)
            {
                Console.WriteLine("Breathe in...");
                ShowSpinner(3);
                Console.WriteLine("Breathe out...");
                ShowSpinner(3);
            }
        }
    }
}
