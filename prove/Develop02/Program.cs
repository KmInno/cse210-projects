using System;
using System.Collections.Generic;
using System.IO;

// definig the blueprints for the jounal program
class Record
{
    public string _date;
    public string _promptText;
    public string _entryText;
}

// the start of the main program
class Journal
{
    private List<Record> _entries = new List<Record>();


// main class for the program which generate questions for the user to choose from
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        string choice;
        do
        {
            Console.WriteLine("1. Write a new entry: ");
            Console.WriteLine("2. Display the Journal: ");
            Console.WriteLine("3. Save the Journal: ");
            Console.WriteLine("4. Load the Journal to file: ");
            Console.WriteLine("5. Exit: ");
            Console.Write("Enter your choice: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.WriteNewEntry();
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    journal.SaveJournal();
                    break;
                case "4":
                    journal.LoadJournal();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

        } while (choice != "5");
    }

// iteraates through the questions
    void WriteNewEntry()
    {
        PromptGenerator promptGenerator = new PromptGenerator();
        string randomPrompt = promptGenerator.GetRandomPrompt();

        Console.WriteLine("Question: " + randomPrompt);
        Console.Write("Enter your answer: ");
        string response = Console.ReadLine();

        Record entry = new Record();
        entry._promptText = randomPrompt;
        entry._entryText = response;
        entry._date = DateTime.Now.ToString("yyyy-MM-dd");
        _entries.Add(entry);
    }
// looks through the journal to display questions to the user
    void DisplayJournal()
    {
        foreach (Record entry in _entries)
        {
            Console.WriteLine("Date: " + entry._date);
            Console.WriteLine("Prompt: " + entry._promptText);
            Console.WriteLine("Response: " + entry._entryText);
            Console.WriteLine();
        }
    }

// asking the user how they want to save their recorded journal
    void SaveJournal()
    {
        Console.Write("Enter filename to save: ");
        string saveFilename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(saveFilename))
        {
            foreach (Record entry in _entries)
            {
                writer.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

// loads a journal from a file saved by the user
    void LoadJournal()
    {
        Console.Write("Enter the filename to load: ");
        string loadFilename = Console.ReadLine();

        _entries.Clear();
        string[] lines = File.ReadAllLines(loadFilename);
        foreach (var line in lines)
        {
            string[] parts = line.Split('|');

            if (parts.Length >= 3)
            {
                Record entry = new Record()
                {
                    _date = parts[0].Trim(),
                    _promptText = parts[1].Trim(),
                    _entryText = parts[2].Trim()
                };
                _entries.Add(entry);
            }
            else
            {
                Console.WriteLine($"Invalid entry format: {line}. Skipping.");
            }
        }
        Console.WriteLine("Journal loaded successfully");
    }
}

// making the journal program more nteresting by using random questions strategy
class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}
