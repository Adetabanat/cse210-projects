using System;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

public class Program
{
    private Scripture Scripture{ get; set;}
    public void Start()
    {
        Reference reference= new Reference("john",3, 16);
        string verseText = " for god so love the world and he gave his only brgotten son";
        Scripture = new 
        Scripture(reference, verseText);
    }
    public void Run()
    {
        Console.WriteLine("Initial Display:");
        Console.WriteLine(Scripture.Display());
        Console.WriteLine("\nHiding a Random Word:");
        Scripture.HideRandomWord();
        Console.WriteLine(Scripture.Display());

    }
    public static void Main(string[] args)
    {
        Program program = new Program ();
        program.Start();
        program.Run();
    }
} 

public class Reference
{
    public string Book { get; private set;}
    public int Chapter { get; private set;}
    public int VerseStart { get; private set;}
    public int? VerseEnd { get; private set;}
    public Reference(string book, int chapter, int verseStart, int? verseEnd=null)
    {
        Book=book;
        Chapter=chapter;
        VerseStart=verseStart;
        VerseEnd=verseEnd;
    }
    public override string ToString()
    {
       if ( VerseEnd.HasValue)
       {
        return $"{Book} {Chapter}: {VerseStart}-{VerseEnd}";
       }
       else
       {
        return $" {Book} {Chapter}: {VerseStart}";
       }
    }
}

public class Word 
{
    public string Text { get; private set;}
    public bool Hidden { get; private set;}
    public Word(string text)
    {
        Text=text;
        Hidden=false;
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
        return Hidden ? "______": Text;
    }

}

public class Scripture
{
    private Reference Reference {get; set;}
    private List<Word> Words { get; set;}
    public Scripture(Reference reference, string verseText)
    {
        Reference = reference;
        Words= new List<Word> ();
        string[] words=verseText.Split(' ',StringSplitOptions.RemoveEmptyEntries);
        foreach (var word in words)
        {
            Words.Add(new Word(word));
        }
    }

    public void HideRandomWord()
    {
        Random random = new Random ();
        int randomIndex = random.Next (0, Words.Count);
        Words[randomIndex].Hide ();
    }
        
    public string Display()
    {
        string referenceStr=Reference.ToString();
        string wordsStr= string.Join(" ", Words);
        return $" { referenceStr}\n {wordsStr}";
    }

    public bool  AllHidden()
    {
        return Words.TrueForAll(w => w.Hidden);
    }
}