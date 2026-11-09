using System;

namespace ScriptureMemorizer;

class Program
{
    static void Main(string[] args)
    {
        // Initialize multi-verse reference and scripture text
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        Scripture scripture = new Scripture(
            reference, 
            "Trust in the Lord with all thine heart and lean not unto thine own understanding"
        );

        string input = "";

        // Main game loop
        while (input.ToLower() != "quit" && !scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to continue or type 'quit' to finish:");
            
            input = Console.ReadLine();

            if (input.ToLower() != "quit")
            {
                scripture.HideRandomWords(3);
            }
        }

        // Final screen refresh to show the complete hidden passage before exit
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words are hidden! Great job practicing.");
    }
}


