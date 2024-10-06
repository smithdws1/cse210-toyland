using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // Split the scripture text into an array
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

public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = -1; 
    }

    public string GetDisplayText()
    {
        if (_endVerse == -1)
            return $"{_book} {_chapter}:{_verse}";
        else
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
    }
}

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
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
        Reference scriptureReference = new Reference("Proverbs", 3, 5);
        Scripture scripture = new Scripture(scriptureReference, "Trust in the Lord with all thine heart and lean not unto thine own understanding In all thy ways acknowledge Him and He shall direct thy paths");

        while (true)
        {
            try
            {
                Console.Clear();
            }
            catch (System.IO.IOException)
            {
                // If Console.Clear() fails, ignore the exception and continue
            }

            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type quit to exit.");

            string input = Console.ReadLine();
            if (input == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);

            if (scripture.IsCompletelyHidden())
            {
                try
                {
                    Console.Clear();
                }
                catch (System.IO.IOException)
                {
                    // Ignore the exception if Console.Clear() fails
                }

                Console.WriteLine("You're all done!");
                break;
            }
        }
    }
}