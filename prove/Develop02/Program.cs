using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

// Class for a journal entry
public class Entry
{
    public string Date { get; set; }
    public string PromptQuestion { get; set; }
    public string EntryText { get; set; }

    public Entry(string promptQuestion)
    {
        PromptQuestion = promptQuestion;
    }

    public Entry() { } 

    public void SetEntryText()
    {
        Console.WriteLine("Prompt: " + PromptQuestion);
        Console.Write("Your Response: ");
        EntryText = Console.ReadLine();
    }

    public void SetDate()
    {
        Console.WriteLine("Enter the date (YYYY-MM-DD):");
        Date = Console.ReadLine();
    }

    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {PromptQuestion}\nEntry: {EntryText}\n";
    }
}

// Class to generate random prompts
public class PromptGenerator
{
    private List<string> _prompts;
    private Random _random;

    public PromptGenerator()
    {
        _random = new Random();
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "Who did I have a chance to serve today?",
            "How did I show my wife I love her?",
            "What did I do with my children today?"
        };
    }

    // Method to get a random prompt
    public string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }
}

// Journal class
public class Journal
{
    private List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    // Method to create a new entry with user input for entry text and date
    public void CreateNewEntry(PromptGenerator promptGenerator)
    {
        string prompt = promptGenerator.GetRandomPrompt();
        Entry newEntry = new Entry(prompt);

        newEntry.SetEntryText();
        newEntry.SetDate();

        _entries.Add(newEntry);
        Console.WriteLine("Entry saved.\n");
    }

    // Display all journal entries
    public void DisplayJournal()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.\n");
        }
        else
        {
            Console.WriteLine("Journal Entries:\n");
            foreach (Entry entry in _entries)
            {
                Console.WriteLine(entry);
            }
        }
    }

    // Save journal to a JSON file
    public void SaveJournalToFile()
    {
        Console.Write("Enter a filename to save your journal: ");
        string filename = Console.ReadLine();
        if (!filename.EndsWith(".json"))
        {
            filename += ".json";
        }

        JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(_entries, options);
        File.WriteAllText(filename, json);
        Console.WriteLine("Your journal is saved to a file.\n");
    }

    // Load journal from a JSON file
    public void LoadJournalFromFile()
    {
        Console.Write("Enter a filename to load Journal: ");
        string filename = Console.ReadLine();
        if (!filename.EndsWith(".json"))
        {
            filename += ".json";
        }

        if (File.Exists(filename))
        {
            string json = File.ReadAllText(filename);
            _entries = JsonSerializer.Deserialize<List<Entry>>(json);
            Console.WriteLine("Journal loaded from file.\n");
        }
        else
        {
            Console.WriteLine("File not found.\n");
        }
    }
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        while (running)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.CreateNewEntry(promptGenerator);
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    journal.SaveJournalToFile();
                    break;
                case "4":
                    journal.LoadJournalFromFile();
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Exiting now!");
                    break;
                default:
                    Console.WriteLine("Please choose again.\n");
                    break;
            }
        }
    }
}
