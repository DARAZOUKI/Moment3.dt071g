using MyGuestBookApp;


Guestbook guestbook = new();
guestbook.LoadFromFile();

while (true)
{
    Console.Clear();
    Console.WriteLine("Welcome to My Guestbook!");
    Console.WriteLine("1- Add Entry");
    Console.WriteLine("2- Remove Entry");
    Console.WriteLine("3- Show Entries");
    Console.WriteLine("4- Exit");

    Console.Write("Choose an option: ");
    string? choice = Console.ReadLine();

    switch (choice)  // This checks what option the user picked
    {
        case "1":
            
            string? owner;
            do
            {
                Console.Write("Enter the owner's name: ");
                owner = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(owner))
                {
                    Console.WriteLine("Owner's name cannot be empty. Please try again.");
                }
            } while (string.IsNullOrWhiteSpace(owner)); 

           
            string? content;
            do
            {
                Console.Write("Enter the content: ");
                content = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(content))
                {
                    Console.WriteLine("Content cannot be empty. Please try again.");
                }
            } while (string.IsNullOrWhiteSpace(content)); 

            try
            {
                guestbook.AddEntry(owner, content); // Add the entry
                Console.WriteLine("Entry added successfully");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            break;

        case "2":
            guestbook.ShowEntries(); // Show all the entries
            Console.Write("Enter the index of the entry to remove: ");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                try
                {
                    guestbook.RemoveEntry(index); // Remove the entry at the specifice index
                    Console.WriteLine("Entry removed successfully.");
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
            else
            {
                Console.WriteLine("Invalid index!");
            }
            break;

        case "3":
            guestbook.ShowEntries(); // show the current entries
            break;

        case "4":
            guestbook.SaveToFile();
            Console.WriteLine("Goodbye!");
            return;

        default:
            Console.WriteLine("Invalid choice!");
            break;
    }

    Console.WriteLine("Press Enter to continue.");
    Console.ReadLine();
}
