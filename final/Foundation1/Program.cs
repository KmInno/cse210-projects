using System;
using System.Collections.Generic;

// Comment class
class Comment
{
    // Attributes
    private string _nameOfPerson;
    private string _textOfComment;

    // Constructor
    public Comment(string nameOfPerson, string textOfComment)
    {
        _nameOfPerson = nameOfPerson;
        _textOfComment = textOfComment;
    }

    // Method to represent the comment
    public string CommentRepresentation()
    {
        return $"{_nameOfPerson}: {_textOfComment}";
    }
}

// Video class
class Video
{
    // Attributes
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _commentsList;

    // Constructor
    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _commentsList = new List<Comment>();
    }

    // Method to add a comment
    public void AddComment(Comment comment)
    {
        _commentsList.Add(comment);
    }

    // Method to get the number of comments
    public int NumberOfComments()
    {
        return _commentsList.Count;
    }

    // Method to display comments
    public void DisplayComments()
    {
        foreach (var comment in _commentsList)
        {
            Console.WriteLine(comment.CommentRepresentation());
        }
    }

    // Method to display video details
    public void DisplayVideoDetails()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length} seconds");
        Console.WriteLine($"Number of Comments: {NumberOfComments()}");
        Console.WriteLine("Comments:");
        DisplayComments();
        Console.WriteLine();
    }
}

// Main Program class
class Program
{
    static void Main(string[] args)
    {
        // Creating video objects
        Video video1 = new Video("How to make kikomando inn 2 mins", "Chef Ronnie", 300);
        Video video2 = new Video("Understanding Luganda in 30days", "Lubuulwa Kenny", 1200);
        Video video3 = new Video("Mpele for Beginners", "Dancer Ug", 1800);

        // Adding comments to video1
        video1.AddComment(new Comment("Jose", "That was da best!"));
        video1.AddComment(new Comment("Abraham", "Its only two days but am already picking up ,great video."));
        video1.AddComment(new Comment("Derrick", "Am soon startingg my own stall this is agreat vidoe for me"));

        // Adding comments to video2
        video2.AddComment(new Comment("Dave", "This is so helpful!"));
        video2.AddComment(new Comment("Eva", "I learned a lot, thanks!"));
        video2.AddComment(new Comment("Frank", "Amazing tutorial!"));

        // Adding comments to video3
        video3.AddComment(new Comment("Grace the dancing girl ug ", "Soon i will be showing off my new moves to my freinds."));
        video3.AddComment(new Comment("Muzinyi", "Bro, can you make a nother video, i already have these down already, am rocking man."));
        video3.AddComment(new Comment("kakole", "maan am rocking this side!"));

        // Adding videos to a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Displaying video details
        foreach (var video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}
