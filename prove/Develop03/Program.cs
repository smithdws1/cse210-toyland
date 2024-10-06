using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // Split the scripture text into an Array - I don't know if I did this correctly. Testing will show.
        string[] wordsArray = text.Split(' ');
        foreach (var word in wordsArray)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        for (int i = 0; i < numberToHide; i++)
        {
            int index = random.Next(_words.Count);
            _words[index].Hide();
        }
    }

    public string GetDisplayText()
    {
        List<string> wordDisplay = new List<string>();
        foreach (Word word in _words)
        {
            wordDisplay.Add(word.GetDisplayText());
        }
        return _reference.GetDisplayText() + " " + string.Join(" ", wordDisplay);
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}

public class Reference;
{
    private string _book;
    private string _chapter;
    private int _verse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    public srting GetDisplayText()
    {
        if (_endVerse == -1)
            return $"{_book} {_chapter}:{_verse}";
        else
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
    }
}

public class Word;
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = ThreadStart;
        _inHidden = false;
    }

    public void Hide()
    {
        _inHidden;
    }

    public void Show()
    {
        _inHidden()
    }
    
    public bool IsHidden()
    {
    return _inHidden;
    }

    public string GetDisplayText()
    {
    return _isHidden ? "________" : _text;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Reference scriptureReference = new Reference("Proverbs", 3, 5, 6);
        Scripture scripture = new Scripture(scruptureReference, "Trust in the Lord with all thine heart and lean not unto thine own understanding In all the ways acknowledge Him and He shall direct the paths");

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide more words or type quit to exit.");

            string input = Console.ReadLine();
            if (input == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine("You're all done!");
            }
        }
    }
}