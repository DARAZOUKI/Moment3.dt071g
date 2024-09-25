
using System.Text.Json;

namespace MyGuestBookApp
{
    
    public class Guestbook
    {
        private List<Entry> entries = [];  // A list to store the guestbook entries
        private readonly string filePath = "GuestBook.dat";

        public void AddEntry(string owner, string content)
        {
            if (string.IsNullOrWhiteSpace(owner) || string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentException("Owner and content cannot be empty.");
            }
            entries.Add(new Entry(owner, content)); 
            SaveToFile();
        }

        // method to remove an entry by its index
        public void RemoveEntry(int index)
        {
            if (index < 0 || index >= entries.Count)
            {
                throw new IndexOutOfRangeException("Invalid index");
            }
            entries.RemoveAt(index);
            SaveToFile();
        }
             
        // method to show all the entries in the guestbook
        public void ShowEntries()
        {
            if (entries.Count == 0)
            {
                Console.WriteLine("No entries found");
            }
            else
            {
                for (int i = 0; i < entries.Count; i++)
                {
                    Console.WriteLine($"{i}: {entries[i]}");
                }
            }
        }


      // method to load entries from the file when the program starts
        public void LoadFromFile()
        {
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                entries = JsonSerializer.Deserialize<List<Entry>>(jsonString) ?? [];
            }
        }
         // method to save the current list of entries to the file
        public void SaveToFile()
        {
            // convert the entries list to a JSON string
            string jsonString = JsonSerializer.Serialize(entries);
            File.WriteAllText(filePath, jsonString);
        }
    }
}