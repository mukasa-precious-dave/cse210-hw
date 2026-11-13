using System;

class Program
{
    /* 
     * EXCEEDING REQUIREMENTS NOTE:
     * 1. Non-Repeating Prompts & Questions: In both ReflectingActivity and ListingActivity, 
     *    items are removed from active lists as they are pulled so that random prompts/questions 
     *    are never duplicated until the entire bank has been exhausted.
     * 2. Session Tracking: A running log tracks how many times each activity was performed 
     *    during the application's runtime and displays a session summary when exiting.
     */
    static void Main(string[] args)
    {
        int breathingCount = 0;
        int reflectingCount = 0;
        int listingCount = 0;

        string choice = "";

        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
                breathingCount++;
            }
            else if (choice == "2")
            {
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.Run();
                reflectingCount++;
            }
            else if (choice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
                listingCount++;
            }
            else if (choice == "4")
            {
                Console.Clear();
                Console.WriteLine("Session Summary:");
                Console.WriteLine($" - Breathing Activities completed: {breathingCount}");
                Console.WriteLine($" - Reflecting Activities completed: {reflectingCount}");
                Console.WriteLine($" - Listing Activities completed: {listingCount}");
                Console.WriteLine("\nThank you for practicing mindfulness. Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Press enter to try again.");
                Console.ReadLine();
            }
        }
    }
}