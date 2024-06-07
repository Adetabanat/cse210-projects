using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("what is your grade in percentage ");
        string marks= Console.ReadLine();
        int grade= int.Parse(marks);
        
        if (grade >= 90) 
        {
          Console.WriteLine(" You have an A grade.");
        }
        else if (grade>=80)
        {
             Console.WriteLine(" You have an B grade.");
        }
        else if (grade>=70)
        {
             Console.WriteLine(" You have an C grade.");

        }
        else if (grade>=60)
        {
             Console.WriteLine(" You have an D grade.");
        }
        else if (grade< 50)
        {
             Console.WriteLine(" You have an  failed.");
        }
    
    }
}