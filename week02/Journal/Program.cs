using System;

class Program
{
    // Exceeding Requirements Note:
    // 1. Implemented a unique custom delimiter (~|~) for file saving and loading to safely handle commas, quotes, and multi-line thoughts without breaking text parsing.
    // 2. Added robust try-catch error handling in the Journal class to prevent application crashes on invalid file paths or read/write errors.
    // 3. Expanded the prompt list beyond the mandatory minimum of five.

    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Load the journal from file");
            Console.WriteLine("4. Save the journal to file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out choice))
            {
                switch (choice)
                {
                    case 1:
                        string prompt = promptGenerator.GetRandomPrompt();
                        Console.WriteLine($"\n{prompt}");
                        Console.Write("> ");
                        string entryText = Console.ReadLine();

                        Entry newEntry = new Entry();
                        newEntry._date = DateTime.Now.ToShortDateString();
                        newEntry._promptText = prompt;
                        newEntry._entryText = entryText;

                        theJournal.AddEntry(newEntry);
                        Console.WriteLine("Entry added successfully!\n");
                        break;

                    case 2:
                        Console.WriteLine("\n--- Journal Entries ---");
                        theJournal.DisplayJournal();
                        break;

                    case 3:
                        Console.Write("\nWhat is the filename to load? ");
                        string loadFile = Console.ReadLine();
                        theJournal.LoadFromFile(loadFile);
                        break;

                    case 4:
                        Console.Write("\nWhat is the filename to save? ");
                        string saveFile = Console.ReadLine();
                        theJournal.SaveToFile(saveFile);
                        break;

                    case 5:
                        Console.WriteLine("\nGoodbye!");
                        break;

                    default:
                        Console.WriteLine("\nInvalid choice. Please select a number between 1 and 5.\n");
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nPlease enter a valid number.\n");
            }
        }
    }
}