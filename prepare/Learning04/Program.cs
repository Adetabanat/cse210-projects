using System;

namespace MyApplication
{
   class Program
   {
      static void MyMethod(int myNum=4)
      {
        Console.WriteLine(myNum);
      }
      static void Main(string[] args)
       {
        string name = "nat";
        MyMethod(15);
        MyMethod();
        

       
        Console.WriteLine(name);
        Console.WriteLine(name   +  "myNum");
       }
   }
}