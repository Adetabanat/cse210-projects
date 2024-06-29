using System;
using System.Collections.Generic;

public class Reference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int VerseStart { get; private set; }
    public int? VerseEnd { get; private set; }

    public Reference(string book, int chapter, int verseStart, int? verseEnd = null)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verseStart;
        VerseEnd = verseEnd;
    }
}

public class Word
{
    public string Text { get; private set; }
    public bool Hidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        Hidden = false;  // Words are initially not hidden
    }

    public void Hide()
    {
        Hidden = true;
    }

    public void Show()
    {
        Hidden = false;
    }

    public override string ToString()
    {
        return Hidden ? "_____" : Text;
    }
}

public class Scripture
{
    private Reference Reference { get; set; }
    private List<Word> Words { get; set; }

    public Scripture(Reference reference, string verseText)
    {
        Reference = reference;
        Words = new List<Word>();
        string[] words = verseText.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (var word in words)
        {
            Words.Add(new Word(word));
        }
    }

    public void HideRandomWord()
    {
        Random random = new Random();
        int index = random.Next(Words.Count);
        Words[index].Hide();
    }

    public string Display()
    {
        // Constructing the scripture display with reference and words
        string display = $"{Reference.Book} {Reference.Chapter}:{Reference.VerseStart}-{Reference.VerseEnd}\n";
        foreach (var word in Words)
        {
            display += word.ToString() + " ";
        }
        return display.Trim();
    }

    public bool AllHidden()
    {
        foreach (var word in Words)
        {
            if (!word.Hidden)
            {
                return false;
            }
        }
        return true;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Example usage
        Reference john316to17Reference = new Reference("John", 3, 16, 17);
        Scripture john316to17Scripture = new Scripture(john316to17Reference, "For God so loved the world that He gave His only begotten Son, that whoever believes in Him should not perish but have everlasting life.");
        
        Console.WriteLine("Initial Scripture:");
        Console.WriteLine(john316to17Scripture.Display());
        
        // Hide random words until all are hidden
        while (!john316to17Scripture.AllHidden())
        {
            Console.WriteLine("\nPress Enter to hide a word (or type 'quit' to exit):");
            string input = Console.ReadLine();
            
            if (input.ToLower() == "quit")
                break;
            
            john316to17Scripture.HideRandomWord();
            Console.Clear();
            Console.WriteLine(john316to17Scripture.Display());
        }
        
        Console.WriteLine("\nAll words hidden. Program ended.");
    }
}
