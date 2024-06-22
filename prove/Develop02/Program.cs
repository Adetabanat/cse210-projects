using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal myJournal = new Journal();
            bool running = true;

            while (running)
            {
                Console.WriteLine("Journal Menu:");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display the journal");
                Console.WriteLine("3. Save the journal to a file");
                Console.WriteLine("4. Load the journal from a file");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            myJournal.WriteEntry();
                            break;
                        case 2:
                            myJournal.DisplayEntries();
                            break;
                        case 3:
                            Console.Write("Enter filename to save to: ");
                            string saveFile = Console.ReadLine();
                            myJournal.SaveToFile(saveFile);
                            break;
                        case 4:
                            Console.Write("Enter filename to load from: ");
                            string loadFile = Console.ReadLine();
                            myJournal.LoadFromFile(loadFile);
                            break;
                        case 5:
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice, try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter a number.");
                }
            }
        }
    }

    // Represents a single journal entry
    public class JournalEntry
    {
        public string Prompt { get; set; }
        public string Response { get; set; }
        public string Date { get; set; }
        public string Mood { get; set; }
        public string Location { get; set; }
        public string Tags { get; set; }

        public JournalEntry(string prompt, string response, string mood, string location = "", string tags = "")
        {
            Prompt = prompt;
            Response = response;
            Date = DateTime.Now.ToString("yyyy-MM-dd");
            Mood = mood;
            Location = location;
            Tags = tags;
        }

        public override string ToString()
        {
            return $"Date: {Date}\nMood: {Mood}\nPrompt: {Prompt}\nResponse: {Response}\nLocation: {Location}\nTags: {Tags}\n";
        }

        public string ToFileString()
        {
            return $"{Date}|{Mood}|{Prompt}|{Response}|{Location}|{Tags}";
        }

        public static JournalEntry FromFileString(string fileString)
        {
            var parts = fileString.Split('|');
            string location = parts.Length > 4 ? parts[4] : "";
            string tags = parts.Length > 5 ? parts[5] : "";
            return new JournalEntry(parts[2], parts[3], parts[1], location, tags) { Date = parts[0] };
        }
    }

    // Manages a collection of journal entries
    public class Journal
    {
        private List<JournalEntry> _entries = new List<JournalEntry>();
        private List<string> _prompts = new List<string>
        {
            "What was the highlight of my week so far?",
            "Describe a moment when you felt proud of yourself today.",
            "Write about a place you visited today and how it made you feel.",
            "What is a new skill or knowledge you acquired recently?",
            "Reflect on a challenge you faced today and how you overcame it.",
            "Write about a person who positively influenced your day today.",
            "What is something you're grateful for right now?",
            "Describe an activity that brought you joy today.",
            "What is a goal you have progress towards recently?",
            "Reflect on a book, movie, or podcast you enjoyed recently and why it resonated with you."
        };

        public void WriteEntry()
        {
            Random rand = new Random();
            string prompt = _prompts[rand.Next(_prompts.Count)];
            Console.WriteLine(prompt);
            string response = Console.ReadLine();
            Console.Write("How do you feel today? ");
            string mood = Console.ReadLine();
            Console.Write("Where were you? ");
            string location = Console.ReadLine();
            Console.Write("Enter tags (comma-separated): ");
            string tags = Console.ReadLine();
            
            JournalEntry entry = new JournalEntry(prompt, response, mood, location, tags);
            _entries.Add(entry);
        }

        public void DisplayEntries()
        {
            foreach (var entry in _entries)
            {
                Console.WriteLine(entry);
            }
        }

        public void SaveToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in _entries)
                {
                    writer.WriteLine(entry.ToFileString());
                }
            }
        }

        public void LoadFromFile(string filename)
        {
            if (File.Exists(filename))
            {
                _entries.Clear();
                string[] lines = File.ReadAllLines(filename);
                foreach (string line in lines)
                {
                    _entries.Add(JournalEntry.FromFileString(line));
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
    }
}
