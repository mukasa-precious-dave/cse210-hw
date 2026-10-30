using System;

class Program
{
    static void Main(string[] args)
    {
        // EXCEEDING REQUIREMENTS NOTE: 
        // To exceed requirements, I implemented a custom custom separator (~|~) 
        // and robust splitting logic to cleanly handle multi-line text entries and 
        // prevent CSV comma/quote corruption without breaking file integrity.

        Journal theJournal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();
        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string input = Console.ReadLine();
            if (int.TryParse(input, out choice))
            {
                switch (choice)
                {
                    function:
                    case 1:
                        string prompt = promptGen.GetRandomPrompt();
                        Console.WriteLine($"\n{prompt}");
                        Console.Write("> ");
                        string response = Console.ReadLine();
                        
                        Entry newEntry = new Entry
                        {
                            _date = DateTime.Now.ToShortDateString(),
                            _promptText = prompt,
                            _entryText = response
                        };
                        theJournal.AddEntry(newEntry);
                        Console.WriteLine();
                        break;

                    case 2:
                        Console.WriteLine("\n--- Journal Entries ---");
                        theJournal.DisplayJournal();
                        break;

                    case 3:
                        Console.Write("Enter filename to save (e.g., journal.txt): ");
                        string saveFile = Console.ReadLine();
                        theJournal.SaveToFile(saveFile);
                        break;

                    case 4:
                        Console.Write("Enter filename to load: ");
                        string loadFile = Console.ReadLine();
                        theJournal.LoadFromFile(loadFile);
                        break;

                    case 5:
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.\n");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.\n");
            }
        }
    }
}