using System;
using System.Collections.Generic;
using System.IO;

// defining the variable to be used in the journal program
class Record
{
    public string question;
    public string answer;
    public string Date;
}
// starting the main program
class Journal
{
    // main login of the journal programe
    static void Main(string[] args)
    {
        List<Record> journal = new List<Record>();
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
                    WriteNewEntry(journal);
                    break;
                case "2":
                    DisplayJournal(journal);
                    break;
                case "3":
                    SaveJournal(journal);
                    break;
                case "4":
                    LoadJournal(journal);
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
// getting reposnce from the user of journal program
    static void WriteNewEntry(List<Record> journal)
    {
        string[] questions = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
        };

        Random random = new Random();
        string randomQuestion = questions[random.Next(questions.Length)];

        Console.WriteLine("Question: " + randomQuestion);
        Console.Write("Enter your answer: ");
        string answer = Console.ReadLine();

        Record entry = new Record();
        entry.question = randomQuestion;
        entry.answer = answer;
        entry.Date = DateTime.Now.ToString("yyyy-MM-dd");
        journal.Add(entry);
    }

// displaying journal entries to the user
    static void DisplayJournal(List<Record> journal)
    {
        foreach (Record entry in journal)
        {
            Console.WriteLine("Date: " + entry.Date);
            Console.WriteLine("Question: " + entry.question);
            Console.WriteLine("Answer: " + entry.answer);
            Console.WriteLine();
        }
    }

    static void SaveJournal(List<Record> journal)
    {
        Console.Write("Enter filename to save: ");
        string saveFilename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(saveFilename))
        {
            foreach (Record entry in journal)
            {
                writer.WriteLine($"{entry.Date}|{entry.question}|{entry.answer}");
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

// loading from of the saved journal txt
    static void LoadJournal(List<Record> journal)
    {
        Console.Write("Enter the filename to load: ");
        string loadFilename = Console.ReadLine();

        journal.Clear();
        string[] lines = File.ReadAllLines(loadFilename);
        foreach (var line in lines)
        {
            string[] parts = line.Split('|');

            if (parts.Length >= 3)
            {
                Record entry = new Record()
                {
                    Date = parts[0].Trim(),
                    question = parts[1].Trim(),
                    answer = parts[2].Trim()
                };
                journal.Add(entry);
            }
            else
            {
                Console.WriteLine($"Invalid entry format: {line}. Skipping.");
            }
        }
        Console.WriteLine("Journal loaded successfully");
    }
}

