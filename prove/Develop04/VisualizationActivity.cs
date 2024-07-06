using System;

namespace MindfulnessApp
{
    public class VisualizationActivity : MindfulnessActivity
    {
        private static readonly string[] Prompts =
        {
            "Imagine you are in a peaceful meadow. Describe what you see, hear, and feel.",
            "Visualize achieving a significant goal. How does it feel? What steps did you take to get there?",
            "Picture yourself on a serene beach. What do the waves sound like? What does the sand feel like?",
            "Envision a place where you feel completely safe and relaxed. What does it look like? Who is there with you?"
        };

        protected override string Description => "This activity will help you relax and focus by guiding you through visualization exercises. Imagine the details and sensations of a peaceful scene or a positive outcome.";

        protected override void RunActivity()
        {
            Random random = new Random();
            string prompt = Prompts[random.Next(Prompts.Length)];
            Console.WriteLine(prompt);

            Console.WriteLine("Close your eyes and start visualizing...");
            ShowSpinner(Duration);
        }
    }
}
