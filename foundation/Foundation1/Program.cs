using System;
using System.Collections.Generic;
using System.Transactions;

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthSeconds { get; set; }
    private List<Comment> comments = new List<Comment>();

    public video(string title, string author, int lengthSeconds)
    {
        Title = title;
        Author = author;
        LengthSeconds = lengthSeconds;
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, Length: {LengthSeconds} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        foreach (var comment in comments)
        {
            Console.WriteLine($"Comment by {comment.NameCommentator}: {comment.Text}");
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
        Video video2 = new Video("Second Video Title", "Second Author", 20);
        Video video3 = new Video("Thrid Video Title", "Third Author", 30);

        video1.AddComment(new Comment("David", "Awesome video!"));
        video1.AddComment(new Comment("Lindsay", "Gross video!"));
        video1.AddComment(new Comment("Samuel", "What did I just watch?"));

        
    }
}