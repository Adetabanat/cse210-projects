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

    public override string ToString()
    {
        return VerseEnd.HasValue 
            ? $"{Book} {Chapter}:{VerseStart}-{VerseEnd}" 
            : $"{Book} {Chapter}:{VerseStart}";
    }
}

public class Word
{
    public string Text { get; private set; }
    public bool Hidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        Hidden = false;
    }

    public void Hide() => Hidden = true;

    public void Show() => Hidden = false;

    public override string ToString() => Hidden ? "_____" : Text;
}

public class Scripture
{
    private Reference Reference { get; set; }
    private List<Word> Words { get; set; }
    private string Context { get; set; }

    public Scripture(Reference reference, string verseText, string context)
    {
        Reference = reference;
        Context = context;
        Words = new List<Word>();
        foreach (var word in verseText.Split(' ', StringSplitOptions.RemoveEmptyEntries))
        {
            Words.Add(new Word(word));
        }
    }

    public void HideRandomWord()
    {
        Random random = new Random();
        int index;
        do
        {
            index = random.Next(Words.Count);
        } while (Words[index].Hidden);

        Words[index].Hide();
    }

    public void HideWordsByPercentage(int percentage)
    {
        int wordsToHide = Words.Count * percentage / 100;
        Random random = new Random();
        for (int i = 0; i < wordsToHide; i++)
        {
            int index;
            do
            {
                index = random.Next(Words.Count);
            } while (Words[index].Hidden);

            Words[index].Hide();
        }
    }

    public string Display()
    {
        return $"{Reference}\nContext: {Context}\n{string.Join(" ", Words)}";
    }

    public bool AllHidden() => Words.TrueForAll(word => word.Hidden);

    public void RevealAllWords() => Words.ForEach(word => word.Show());
}

public class Program
{
    public static void Main()
    {
        var john316to17Reference = new Reference("John", 3, 16, 17);
        var john316to17Scripture = new Scripture(john316to17Reference, 
            "For God so loved the world that He gave His only begotten Son, that whoever believes in Him should not perish but have everlasting life.", 
            "This verse highlights God's love for humanity and the promise of eternal life through faith.");

        Console.WriteLine("Initial Scripture:");
        Console.WriteLine(john316to17Scripture.Display());

        // Hide a percentage of words for practice
        john316to17Scripture.HideWordsByPercentage(20);
        Console.WriteLine("\nMemorization Challenge:");
        Console.WriteLine(john316to17Scripture.Display());

        while (!john316to17Scripture.AllHidden())
        {
            Console.WriteLine("\nPress Enter to hide another word, 'reveal' to show all, or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;
            else if (input.ToLower() == "reveal")
            {
                john316to17Scripture.RevealAllWords();
                Console.Clear();
                Console.WriteLine(john316to17Scripture.Display());
            }
            else
            {
                john316to17Scripture.HideRandomWord();
                Console.Clear();
                Console.WriteLine(john316to17Scripture.Display());
            }
        }

        Console.WriteLine("\nAll words hidden or revealed. Program ended.");
    }
}
