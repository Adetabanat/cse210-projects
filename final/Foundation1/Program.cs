using System;
using System.Collections.Generic;

namespace YouTubeTracker
{
    class Program
    {
        static void Main()
        {
            // Create a list to store videos
            List<Video> videos = new List<Video>();

            // Create videos and add comments
            Video video1 = new Video("Outdooring Of product", "Sales Manager", 300);
            video1.AddComment("Damian", "Nice presentation!");
            video1.AddComment("Nat", ", How do i get this awesome product!");
            video1.AddComment("Dan", ", Awesome");
            video1.AddComment("Dickson", ", This is a nice product");

            Video video2 = new Video("Online service", "Head of IT", 450);
            video2.AddComment("Junoir Apaah", "The explanation is clear, loved it!");
            video2.AddComment("Magi", "Thanks !");
            video2.AddComment("Patrick", "hope i can order for this product");

            Video video3 = new Video("Job Vaccancy", "Human Resource Manager", 400);
            video3.AddComment(" Brown", "How do i get emplyoed ?");
            video3.AddComment(" Mark", "Can you provide more details on this process?");

            // Add videos to the list
            videos.Add(video1);
            videos.Add(video2);
            videos.Add(video3);

            // Iterate through the list of videos and display information
            foreach (var video in videos)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.LengthSeconds} seconds");
                Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

                Console.WriteLine("Comments:");
                foreach (var comment in video.GetAllComments())
                {
                    Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
                }

                Console.WriteLine(); // Empty line for separation
            }
        }
    }
}
