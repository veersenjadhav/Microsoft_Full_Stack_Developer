using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    // Simple fixed-capacity library that stores book titles and checked-out state.
    class Library
    {
        private const int MaxBooks = 5;

        private class Book
        {
            public string Title { get; }
            public bool IsCheckedOut { get; set; }
            public Book(string title) => Title = title;
        }

        private readonly List<Book> books = new List<Book>(MaxBooks);

        public bool IsFull => books.Count >= MaxBooks;
        public bool HasAny => books.Count > 0;

        // Case-insensitive existence check
        public bool Contains(string title) =>
            books.Exists(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

        // Returns true if a book exists and is currently checked out
        public bool IsCheckedOut(string title)
        {
            var book = books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            return book != null && book.IsCheckedOut;
        }

        // Adds a book if there is space and it isn't already present (case-insensitive)
        public bool AddBook(string title)
        {
            if (string.IsNullOrWhiteSpace(title) || IsFull) return false;
            if (Contains(title)) return false;
            books.Add(new Book(title));
            return true;
        }

        // Removes a book by title (case-insensitive)
        public bool RemoveBook(string title)
        {
            if (string.IsNullOrWhiteSpace(title) || !HasAny) return false;
            int idx = books.FindIndex(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (idx < 0) return false;
            books.RemoveAt(idx);
            return true;
        }

        // Search for a book title (case-insensitive)
        public bool Search(string title) => Contains(title);

        // Attempts to borrow a book; returns true when successfully checked out
        public bool BorrowBook(string title)
        {
            var book = books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (book == null) return false;
            if (book.IsCheckedOut) return false;
            book.IsCheckedOut = true;
            return true;
        }

        // Attempts to check in a borrowed book; returns true when successfully checked in
        public bool CheckInBook(string title)
        {
            var book = books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (book == null) return false;
            if (!book.IsCheckedOut) return false;
            book.IsCheckedOut = false;
            return true;
        }

        // Prints the current list of books and their status
        public void DisplayBooks()
        {
            Console.WriteLine("Current books in the library:");
            if (!HasAny)
            {
                Console.WriteLine("(no books available)");
                return;
            }

            foreach (var book in books)
            {
                var status = book.IsCheckedOut ? " (checked out)" : string.Empty;
                Console.WriteLine("- " + book.Title + status);
            }
        }
    }

    class Program
    {
        private static readonly string[] ValidActions = { "add", "remove", "display", "exit", "search", "borrow", "checkin" };
        private const int MaxBorrowPerUser = 3;
        private static int userBorrowedCount = 0;

        static void Main()
        {
            var library = new Library();

            while (true)
            {
                Console.WriteLine();
                var action = ReadAction("Choose an action - add / remove / display / search / borrow / checkin / exit: ");
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
                    case "search":
                        HandleSearch(library);
                        break;
                    case "borrow":
                        HandleBorrow(library);
                        break;
                    case "checkin":
                        HandleCheckIn(library);
                        break;
                    default:
                        Console.WriteLine("Invalid action. Please enter add, remove, display, search, borrow, checkin or exit.");
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

        private static void HandleSearch(Library library)
        {
            var title = ReadTitle("Enter the book title to search for: ");
            if (title == null) return;

            var found = library.Search(title);
            Console.WriteLine(found ? $"'{title}' is available in the collection." : $"'{title}' is not in the collection.");
        }

        private static void HandleBorrow(Library library)
        {
            if (userBorrowedCount >= MaxBorrowPerUser)
            {
                Console.WriteLine($"You have reached the borrowing limit of {MaxBorrowPerUser} books. Return a book before borrowing more.");
                return;
            }

            if (!library.HasAny)
            {
                Console.WriteLine("No books are available to borrow.");
                return;
            }

            var title = ReadTitle("Enter the book title to borrow: ");
            if (title == null) return;

            if (!library.Contains(title))
            {
                Console.WriteLine($"Book titled '{title}' not found in the collection.");
                return;
            }

            if (library.IsCheckedOut(title))
            {
                Console.WriteLine($"'{title}' is already checked out.");
                return;
            }

            var borrowed = library.BorrowBook(title);
            if (borrowed)
            {
                userBorrowedCount++;
                Console.WriteLine($"You have borrowed '{title}'. You now have {userBorrowedCount} borrowed book(s).");
            }
            else
            {
                Console.WriteLine("Could not borrow the book.");
            }
        }

        private static void HandleCheckIn(Library library)
        {
            if (!library.HasAny)
            {
                Console.WriteLine("No books are available in the collection.");
                return;
            }

            var title = ReadTitle("Enter the book title to check in: ");
            if (title == null) return;

            if (!library.Contains(title))
            {
                Console.WriteLine($"Book titled '{title}' not found in the collection.");
                return;
            }

            if (!library.IsCheckedOut(title))
            {
                Console.WriteLine($"'{title}' is not currently checked out.");
                return;
            }

            var checkedIn = library.CheckInBook(title);
            if (checkedIn)
            {
                userBorrowedCount = Math.Max(0, userBorrowedCount - 1);
                Console.WriteLine($"'{title}' has been checked in. You now have {userBorrowedCount} borrowed book(s).");
            }
            else
            {
                Console.WriteLine("Could not check in the book.");
            }
        }
    }
}