using System.Collections.Generic;

namespace YouTubeTracker
{
    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int LengthSeconds { get; set; }
        private List<Comment> comments = new List<Comment>();

        public Video(string title, string author, int lengthSeconds)
        {
            Title = title;
            Author = author;
            LengthSeconds = lengthSeconds;
        }

        public void AddComment(string commenterName, string commentText)
        {
            comments.Add(new Comment(commenterName, commentText));
        }

        public int GetNumberOfComments()
        {
            return comments.Count;
        }

        public List<Comment> GetAllComments()
        {
            return comments;
        }
    }
}
