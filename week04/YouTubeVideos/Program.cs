using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold the videos
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("C# Basics in 10 Minutes", "Code Academy", 620);
        video1.AddComment(new Comment("Alice", "This was super clear, thanks!"));
        video1.AddComment(new Comment("Bob", "Helped me understand classes a lot better."));
        video1.AddComment(new Comment("Charlie", "Great video! Looking forward to part 2."));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Advanced LINQ Queries", "DevPro", 945);
        video2.AddComment(new Comment("David", "LINQ is so powerful once you get the hang of it."));
        video2.AddComment(new Comment("Emma", "Could you do a video on performance optimization next?"));
        video2.AddComment(new Comment("Frank", "Very concise tutorial. Bookmark saved!"));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Understanding Object-Oriented Principles", "Tech Insights", 1250);
        video3.AddComment(new Comment("Grace", "The explanation of abstraction made it click for me."));
        video3.AddComment(new Comment("Hannah", "Awesome analogy with the car engine!"));
        video3.AddComment(new Comment("Ian", "Thank you for this thorough guide."));
        videos.Add(video3);

        // Video 4
        Video video4 = new Video("Building a Web API with ASP.NET Core", "Code Craft", 1800);
        video4.AddComment(new Comment("Jack", "Top-notch walkthrough. Straight to the point."));
        video4.AddComment(new Comment("Kelly", "Had a minor error with routing, but fixed it thanks to this."));
        video4.AddComment(new Comment("Liam", "Subscribed! Keep up the great content."));
        videos.Add(video4);

        // Iterate through the list of videos and display their details
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.CommenterName}: \"{comment.Text}\"");
            }
            
            Console.WriteLine(new string('-', 50));
        }
    }
}