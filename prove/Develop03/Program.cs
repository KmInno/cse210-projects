using System;
using System.Collections.Generic;
using System.Linq;

class Scripture
{
    // lets reference the scripture to be use in the program
    // store the scripture text of the scripture
    // make a list to store the words to hide
    private string _reference;
    private string _text;
    private List<string> _hiddenWords;

    public Scripture(string reference, string text)
    {
        _reference = reference;
        _text = text;
        _hiddenWords = new List<string>();
    }

    public string GetReference()
    {
        return _reference;
    }

    public string GetText()
    {
        return _text;
    }

// looping through the words in the verse and replacing them with underscores but determinin the number of 
// letter in the word
    public void HideRandomWords()
    {
        string[] words = _text.Split(' ');
        Random random = new Random();
        int wordsToHide = random.Next(1, words.Length / 2);

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = random.Next(0, words.Length);
            _hiddenWords.Add(words[index]);
            words[index] = new string('_', words[index].Length);
        }

        _text = string.Join(" ", words);
    }

    public bool AllWordsHidden()
    {
        return _hiddenWords.Count == _text.Split(' ').Length;
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine(_reference);
        Console.WriteLine(_text);
    }
}

// create the scripture reference and the scripture txt
//  i will loop the code untill no more words in the verses
class Program
{
    static void Main(string[] args)
    {
        string reference = "1 Nephi 7:1-3";
        string text = "Behold, it came to pass that I, Nephi, did cry much unto the Lord my God, because of the anger of my brethren. "
                    + "But behold, their anger did increase against me, insomuch that they did seek to take away my life. "
                    + "Yea, they did murmur against me, saying: Our younger brother thinks to rule over us; and we have had much trial because of him; "
                    + "wherefore, now let us slay him, that we may not be afflicted more because of his words. "
                    + "For behold, we will not have him to be our ruler; for it belongs unto us, who are the elder brethren, to rule over this people.";

        Scripture scripture = new Scripture(reference, text);

        do
        {
            scripture.Display();
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords();

        } while (!scripture.AllWordsHidden());

        Console.WriteLine("All words in the scripture are hidden. Press any key to exit.");
        Console.ReadKey();
    }
}
