using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    // Simple fixed-capacity library that stores book titles.
    class Library
    {
        private const int MaxBooks = 5;
        private readonly List<string> books = new List<string>(MaxBooks);

        public bool IsFull => books.Count >= MaxBooks;
        public bool HasAny => books.Count > 0;

        // Case-insensitive existence check
        public bool Contains(string title) =>
            books.Exists(b => b.Equals(title, StringComparison.OrdinalIgnoreCase));

        // Adds a book if there is space and it isn't already present (case-insensitive)
        public bool AddBook(string title)
        {
            if (string.IsNullOrWhiteSpace(title) || IsFull) return false;
            if (Contains(title)) return false;
            books.Add(title);
            return true;
        }

        // Removes a book by title (case-insensitive)
        public bool RemoveBook(string title)
        {
            if (string.IsNullOrWhiteSpace(title) || !HasAny) return false;
            int idx = books.FindIndex(b => b.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (idx < 0) return false;
            books.RemoveAt(idx);
            return true;
        }

        // Prints the current list of books
        public void DisplayBooks()
        {
            Console.WriteLine("Current books in the library:");
            if (!HasAny)
            {
                Console.WriteLine("(no books available)");
                return;
            }

            foreach (var book in books)
                Console.WriteLine("- " + book);
        }
    }

    class Program
    {
        private static readonly string[] ValidActions = { "add", "remove", "display", "exit" };

        static void Main()
        {
            var library = new Library();

            while (true)
            {
                Console.WriteLine();
                var action = ReadAction("Choose an action - add / remove / display / exit: ");
                if (action == "exit")
                {
                    Console.WriteLine("Exiting program.");
                    break;
                }

                switch (action)
                {
                    case "add":
                        HandleAdd(library);
                        break;
                    case "remove":
                        HandleRemove(library);
                        break;
                    case "display":
                        library.DisplayBooks();
                        break;
                    default:
                        // ReadAction already validates, but keep a fallback.
                        Console.WriteLine("Invalid action. Please enter add, remove, display or exit.");
                        break;
                }
            }
        }

        // Read and validate an action from the user
        private static string ReadAction(string prompt)
        {
            Console.Write(prompt);
            var input = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();
            return Array.Exists(ValidActions, a => a == input) ? input : string.Empty;
        }

        // Read a non-empty title from the user; returns null when invalid
        private static string ReadTitle(string prompt)
        {
            Console.Write(prompt);
            var title = (Console.ReadLine() ?? "").Trim();
            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Invalid title. Try again.");
                return null;
            }
            return title;
        }

        private static void HandleAdd(Library library)
        {
            if (library.IsFull)
            {
                Console.WriteLine("All book slots are full. Remove a book before adding.");
                return;
            }

            var title = ReadTitle("Enter the book title to add: ");
            if (title == null) return;

            if (library.Contains(title))
            {
                Console.WriteLine($"A book titled '{title}' already exists (case-insensitive).");
                return;
            }

            var added = library.AddBook(title);
            Console.WriteLine(added ? $"'{title}' added." : "Could not add the book.");
        }

        private static void HandleRemove(Library library)
        {
            if (!library.HasAny)
            {
                Console.WriteLine("No books to remove.");
                return;
            }

            var title = ReadTitle("Enter the book title to remove: ");
            if (title == null) return;

            var removed = library.RemoveBook(title);
            Console.WriteLine(removed ? $"'{title}' removed." : $"Book titled '{title}' not found.");
        }
    }
}