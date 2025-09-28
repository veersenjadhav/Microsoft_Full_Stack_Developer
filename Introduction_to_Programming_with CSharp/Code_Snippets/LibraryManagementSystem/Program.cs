using System;

namespace LibraryManagementSystem
{
    class Library
    {
        // Five string variables for books
        private string book1 = string.Empty;
        private string book2 = string.Empty;
        private string book3 = string.Empty;
        private string book4 = string.Empty;
        private string book5 = string.Empty;

        public bool HasEmptySlot()
        {
            return string.IsNullOrEmpty(book1) ||
                   string.IsNullOrEmpty(book2) ||
                   string.IsNullOrEmpty(book3) ||
                   string.IsNullOrEmpty(book4) ||
                   string.IsNullOrEmpty(book5);
        }

        public bool HasAnyBook()
        {
            return !string.IsNullOrEmpty(book1) ||
                   !string.IsNullOrEmpty(book2) ||
                   !string.IsNullOrEmpty(book3) ||
                   !string.IsNullOrEmpty(book4) ||
                   !string.IsNullOrEmpty(book5);
        }

        public bool AddBook(string title)
        {
            if (!HasEmptySlot()) return false;

            if (string.IsNullOrEmpty(book1)) { book1 = title; return true; }
            if (string.IsNullOrEmpty(book2)) { book2 = title; return true; }
            if (string.IsNullOrEmpty(book3)) { book3 = title; return true; }
            if (string.IsNullOrEmpty(book4)) { book4 = title; return true; }
            if (string.IsNullOrEmpty(book5)) { book5 = title; return true; }

            return false;
        }

        public bool RemoveBook(string title)
        {
            // case-insensitive match
            if (!string.IsNullOrEmpty(book1) && book1.Equals(title, StringComparison.OrdinalIgnoreCase)) { book1 = string.Empty; return true; }
            if (!string.IsNullOrEmpty(book2) && book2.Equals(title, StringComparison.OrdinalIgnoreCase)) { book2 = string.Empty; return true; }
            if (!string.IsNullOrEmpty(book3) && book3.Equals(title, StringComparison.OrdinalIgnoreCase)) { book3 = string.Empty; return true; }
            if (!string.IsNullOrEmpty(book4) && book4.Equals(title, StringComparison.OrdinalIgnoreCase)) { book4 = string.Empty; return true; }
            if (!string.IsNullOrEmpty(book5) && book5.Equals(title, StringComparison.OrdinalIgnoreCase)) { book5 = string.Empty; return true; }

            return false;
        }

        public void DisplayBooks()
        {
            Console.WriteLine("Current books in the library:");
            int count = 0;

            if (!string.IsNullOrEmpty(book1)) { Console.WriteLine("- " + book1); count++; }
            if (!string.IsNullOrEmpty(book2)) { Console.WriteLine("- " + book2); count++; }
            if (!string.IsNullOrEmpty(book3)) { Console.WriteLine("- " + book3); count++; }
            if (!string.IsNullOrEmpty(book4)) { Console.WriteLine("- " + book4); count++; }
            if (!string.IsNullOrEmpty(book5)) { Console.WriteLine("- " + book5); count++; }

            if (count == 0)
                Console.WriteLine("(no books available)");
        }
    }

    class Program
    {
        static void Main()
        {
            var library = new Library();

            while (true)
            {
                Console.WriteLine();
                Console.Write("Choose an action - add / remove / display / exit: ");
                var action = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();

                if (action == "exit")
                {
                    Console.WriteLine("Exiting program.");
                    break;
                }

                if (action == "add")
                {
                    if (!library.HasEmptySlot())
                    {
                        Console.WriteLine("All book slots are full. Remove a book before adding.");
                        continue;
                    }

                    Console.Write("Enter the book title to add: ");
                    var title = (Console.ReadLine() ?? "").Trim();
                    if (string.IsNullOrEmpty(title))
                    {
                        Console.WriteLine("Invalid title. Try again.");
                        continue;
                    }

                    var added = library.AddBook(title);
                    Console.WriteLine(added ? $"'{title}' added." : "Could not add the book.");
                }
                else if (action == "remove")
                {
                    if (!library.HasAnyBook())
                    {
                        Console.WriteLine("No books to remove.");
                        continue;
                    }

                    Console.Write("Enter the book title to remove: ");
                    var title = (Console.ReadLine() ?? "").Trim();
                    if (string.IsNullOrEmpty(title))
                    {
                        Console.WriteLine("Invalid title. Try again.");
                        continue;
                    }

                    var removed = library.RemoveBook(title);
                    Console.WriteLine(removed ? $"'{title}' removed." : $"Book titled '{title}' not found.");
                }
                else if (action == "display")
                {
                    library.DisplayBooks();
                }
                else
                {
                    Console.WriteLine("Invalid action. Please enter add, remove, display or exit.");
                }
            }
        }
    }
}