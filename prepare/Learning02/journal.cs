using System;
using System.Collections.Generic;
using System.IO;

class Entry {
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public Entry(string prompt, string response, string date) {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    public override string ToString() {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}

class Journal {
    private List<Entry> entries;

    public Journal() {
        entries = new List<Entry>();
    }

    public void AddEntry(string prompt, string response, string date) {
        entries.Add(new Entry(prompt, response, date));
    }

    public void DisplayEntries() {
        foreach (Entry entry in entries) {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string filename) {
        using (StreamWriter writer = new StreamWriter(filename)) {
            foreach (Entry entry in entries) {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
    }

    public void LoadFromFile(string filename) {
        entries.Clear();
        using (StreamReader reader = new StreamReader(filename)) {
            string line;
            while ((line = reader.ReadLine()) != null) {
                string[] parts = line.Split('|');
                entries.Add(new Entry(parts[1], parts[2], parts[0]));
            }
        }
    }
}

class Program1 {
    static void Main(string[] args) {
        Journal journal = new Journal();

        while (true) {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice) {
                case "1":
                    Console.WriteLine("Write a new entry:");
                    Console.Write("Enter the date: ");
                    string date = Console.ReadLine();
                    Console.WriteLine("Choose a prompt:");
                    string[] prompts = {
                        "Who was the most interesting person I interacted with today?",
                        "What was the best part of my day?",
                        "How did I see the hand of the Lord in my life today?",
                        "What was the strongest emotion I felt today?",
                        "If I had one thing I could do over today, what would it be?"
                    };
                    for (int i = 0; i < prompts.Length; i++) {
                        Console.WriteLine($"{i + 1}. {prompts[i]}");
                    }
                    Console.Write("Enter your choice: ");
                    int promptIndex = int.Parse(Console.ReadLine()) - 1;
                    string prompt = prompts[promptIndex];
                    Console.Write("Enter your response: ");
                    string response = Console.ReadLine();
                    journal.AddEntry(prompt, response, date);
                    break;
                case "2":
                    Console.WriteLine("Displaying journal entries:");
                    journal.DisplayEntries();
                    break;
                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    Console.WriteLine("Journal saved to file successfully.");
                    break;
                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    Console.WriteLine("Journal loaded from file successfully.");
                    break;
                case "5":
                    Console.WriteLine("Exiting program.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}