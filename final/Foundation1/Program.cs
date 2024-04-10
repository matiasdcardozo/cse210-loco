using System;
using System.Collections.Generic;

class Comment
{
    public string CommenterName { get; }
    public string Text { get; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

class Video
{
    public string Title { get; }
    public string Author { get; }
    public int Length { get; }
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        comments = new List<Comment>();
    }

    public void AddComment(string commenterName, string text)
    {
        Comment comment = new Comment(commenterName, text);
        comments.Add(comment);
    }

    public int GetNumComments()
    {
        return comments.Count;
    }

    public void DisplayInfo()
    {
        Console.WriteLine("Title: " + Title);
        Console.WriteLine("Author: " + Author);
        Console.WriteLine("Length: " + Length + " seconds");
        Console.WriteLine("Number of comments: " + GetNumComments());
        Console.WriteLine("Comments:");
        foreach (Comment comment in comments)
        {
            Console.WriteLine("- " + comment.CommenterName + " says: " + comment.Text);
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating videos and adding comments
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Video 1", "Author 1", 120);
        video1.AddComment("User1", "Great video!");
        video1.AddComment("User2", "I learned a lot from this.");
        videos.Add(video1);

        Video video2 = new Video("Video 2", "Author 2", 180);
        video2.AddComment("User3", "Not very helpful.");
        video2.AddComment("User4", "Could have been better.");
        videos.Add(video2);

        Video video3 = new Video("Video 3", "Author 3", 90);
        video3.AddComment("User5", "Amazing content!");
        videos.Add(video3);

        // Displaying information about each video
        foreach (Video video in videos)
        {
            video.DisplayInfo();
        }
    }
}