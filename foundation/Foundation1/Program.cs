using System;
using System.Collections.Generic;
using System.Transactions;

public class Video
{
    private List<Comment> _comments = new List<Comment>();

    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthSeconds { get; set; }

    public Video(string title, string author, int lengthSeconds)
    {
        Title = title;
        Author = author;
        LengthSeconds = lengthSeconds;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, Length: {LengthSeconds} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        foreach (var comment in _comments)
        {
            Console.WriteLine($"Comment by {comment.NameCommentator}: {comment.CommentText}");
        }
        Console.WriteLine();
    }
}

public class Comment
{
    public string NameCommentator { get; set; }
    public string CommentText { get; set; }

    public Comment(string nameCommentator, string commentText)
    {
        NameCommentator = nameCommentator;
        CommentText = commentText;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Video video1 = new Video("First Video Title", "First Author", 10);
        Video video2 = new Video("TBD", "Second Author", 20);
        Video video3 = new Video("Third Thing Here", "Third Author", 30);

        video1.AddComment(new Comment("David", "Awesome video!"));
        video1.AddComment(new Comment("Lindsay", "Gross video!"));
        video1.AddComment(new Comment("Samuel", "What did I just watch?"));

        video2.AddComment(new Comment("Becky", "Terrible Video."));
        video2.AddComment(new Comment("John", "I hated it!"));
        video2.AddComment(new Comment("NewNameHeer", "The best video ever!"));

        video3.AddComment(new Comment("William", "Meh..."));
        video3.AddComment(new Comment("Richard", "Simply the best!"));
        video3.AddComment(new Comment("Natasha", "What a waste of time."));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
