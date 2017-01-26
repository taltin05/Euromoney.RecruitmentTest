using System;
using System.Collections.Generic;
using Models2;


namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string content;

            Console.Write("Please make a selection [1=User], [2=Admin]: ");
            var selection = Console.ReadLine();

            while (true)
            {
                if (selection != "1" && selection != "2")
                {
                    Console.Write("Please enter a valid selection: ");
                    selection = Console.ReadLine();
                }
                else
                    break;
            }

            switch (selection)
            {
                case "1":
                    Console.Write("Enter Content: ");
                    content = Console.ReadLine();

                    User u = new User();                  
                    int cntBadWords = u.CountNegativeWords(content);
                    u.DisplayOutput(content, cntBadWords);
                    Console.WriteLine("Press ANY key to exit.");
                    Console.ReadKey();

                    break;
                case "2":
                   
                    break;

            }


        }
    }

}
