using System;
using System.Collections.Generic;
using System.Linq;

// this class represent the the words in the program
// store the orginal words in the progrma
// indicats wether the words are hidden or not
// and provide a way to get the hidden words
class Word
{
    private string _value;
    private bool _isHidden;

    public Word(string value)
    {
        _value = value;
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

    public string GetValue()
    {
        return _value;
    }

    public string GetHiddenValue()
    {
        return new string('_', _value.Length);
    }

    public override string ToString()
    {
        return _isHidden ? GetHiddenValue() : _value;
    }
}


// this class represents the reference  scripture in the program
class Reference
{
    private string _reference;
    private List<Scripture> _verses;

    public Reference(string reference)
    {
        _reference = reference;
        _verses = new List<Scripture>();
    }

    public void AddVerse(string text)
    {
        _verses.Add(new Scripture(_reference, text));
    }

    public void HideRandomWords()
    {
        foreach (var verse in _verses)
        {
            verse.HideRandomWords();
        }
    }

    public bool AllWordsHidden()
    {
        return _verses.All(verse => verse.AllWordsHidden());
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine(_reference);

        foreach (var verse in _verses)
        {
            verse.Display();
        }
    }
}

// this class represents a single scripture verse
class Scripture
{
    private string _text;
    private List<Word> _words;

    public Scripture(string reference, string text)
    {
        _text = text;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        int wordsToHide = random.Next(1, _words.Count / 2);

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = random.Next(0, _words.Count);
            _words[index].Hide();
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(word => word.IsHidden());
    }

    public void Display()
    {
        foreach (var word in _words)
        {
            Console.Write(word + " ");
        }
        Console.WriteLine();
    }
}

// this class represents the whole program
// initizes the reference object, enters a loop to display the reference and ask the user to hide words
// until all words are hidden
// then exit

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("John 3:16");
        reference.AddVerse("For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");
        reference.AddVerse("For God did not send his Son into the world to condemn the world, but to save the world through him.");

        do
        {
            reference.Display();
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            reference.HideRandomWords();

        } while (!reference.AllWordsHidden());

        Console.WriteLine("All words in the scripture are hidden. Press any key to exit.");
        Console.ReadKey();
    }
}


