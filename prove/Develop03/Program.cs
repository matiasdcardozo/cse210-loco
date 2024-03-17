using System;
using System.Collections.Generic;
using System.Linq;

// Word class represents a single word in the scripture
class Word
{
    public string Text { get; private set; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    // Method to hide the word
    public void Hide()
    {
        IsHidden = true;
    }

    // Method to get the display text of the word (hidden if needed)
    public string GetDisplayText()
    {
        return IsHidden ? "___" : Text;
    }
}

// Reference class represents the reference of the scripture
class Reference
{
    public string Text { get; private set; }

    public Reference(string text)
    {
        Text = text;
    }

    // Method to get the display text of the reference
    public string GetDisplayText()
    {
        return Text;
    }
}

// Scripture class represents the scripture containing both reference and text
class Scripture
{
    private Reference reference;
    private List<Word> words;

    public Scripture(string referenceText, string scriptureText)
    {
        reference = new Reference(referenceText);
        words = new List<Word>();

        // Split the scripture text into words
        string[] wordArray = scriptureText.Split(' ');

        // Create Word objects for each word in the scripture
        foreach (string word in wordArray)
        {
            words.Add(new Word(word));
        }
    }

    // Method to hide a few random words in the scripture
    public void HideRandomWords()
    {
        Random random = new Random();

        // Determine the number of words to hide (let's say 10% of total words)
        int wordsToHideCount = (int)Math.Ceiling(words.Count * 0.1);

        // Hide random words
        for (int i = 0; i < wordsToHideCount; i++)
        {
            int index = random.Next(words.Count);
            words[index].Hide();
        }
    }

    // Method to check if all words in the scripture are hidden
    public bool AllWordsHidden()
    {
        return words.All(word => word.IsHidden);
    }

    // Method to display the complete scripture including reference and text
    public void DisplayScripture()
    {
        Console.WriteLine("Scripture: " + reference.GetDisplayText());
        foreach (Word word in words)
        {
            Console.Write(word.GetDisplayText() + " ");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a scripture
        Scripture scripture = new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        // Loop until all words are hidden
        while (!scripture.AllWordsHidden())
        {
            // Display the scripture
            scripture.DisplayScripture();

            // Prompt user to press Enter to continue or type "quit" to exit
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit:");
            string input = Console.ReadLine().ToLower();

            if (input == "quit")
                break;

            // Hide random words and clear the console
            Console.Clear();
            scripture.HideRandomWords();
        }
    }
}