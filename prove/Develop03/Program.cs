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

}

public class Word;
{

}

class Program
{
    static void Main(string[] args)
    {
        
    }
}