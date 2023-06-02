using System.Security.Cryptography.X509Certificates;

namespace bibliotek
{
    internal class Library
    {
        // Checks status of book
        static bool[] isBookBorrowed = new bool[10];
        public Library()
        {
            for (int i = 0; i < 10; i++)
            {
                isBookBorrowed[i] = false;
            }
        }

        // Looks up availability of books
        public static void Search()
        {
            Console.Clear();
            string rentGive = "";

            Console.WriteLine("Välkommen! Vill du låna eller lämna tillbaka? (l/t) ");
            rentGive = Console.ReadLine();

            if (rentGive == "l")
            {
                BorrowBook();
            }
            else if (rentGive == "t")
            {
                ReturnBook();
            }
        }

        // Borrow book
        public static void BorrowBook()
        {
            Console.Clear();
            bool bookFound = false;
            string bookNum = "";

            Console.WriteLine("Welcome! Please enter the title of the book you wish to borrow: ");
            var bookTitle = Console.ReadLine();

            Console.WriteLine("Please enter the name of the author: ");
            var bookAuthor = Console.ReadLine();

            Console.WriteLine("Please enter ISBN: ");
            var bookISBN = Console.ReadLine();

            string[] booksFromFile = File.ReadAllLines(@"E:\bibliotek-uppgift-c#_elliot-vadi\Bibliotek-Terminal-main\Books.txt");
            foreach (var line in (booksFromFile))
            {
                string[] tokens = line.Split(" ");
                if (line.Contains(bookTitle.ToString()))
                {
                    bookFound = true;
                    bookNum = tokens[0];
                }

                else if (line.Contains(bookAuthor.ToString()))
                {
                    bookFound = true;
                    bookNum = tokens[0];

                }
                else if (line.Contains(bookISBN.ToString()))
                {
                    bookFound = true;
                    bookNum = tokens[0];
                }

            }

            if (bookFound)
            {
                int bookIndex = Int16.Parse(bookNum);

                if (isBookBorrowed[bookIndex] == false)
                {
                    Console.WriteLine("The book is available for borrowing. Would you like to borrow it? (y/n):  ");
                    var rentBook = Console.ReadLine();
                    if (rentBook == "y")
                    {
                        isBookBorrowed[bookIndex] = true;
                        Console.WriteLine("Success! The book has been borrowed. You will now be taken back to the main menu...");
                        Thread.Sleep(4000);
                    }
                    else
                    {
                        Console.WriteLine("You will be taken back to the main menu. Please wait.");
                        Thread.Sleep(4000);
                    }
                }
                else
                {
                    Console.WriteLine("Unfortunateky, the book you're looking for is not available right now. We apologize for the inconvenience.");
                    Console.WriteLine("You will be taken back to the main menu. Please wait.");
                    Thread.Sleep(4000);
                }
            }
        }

        // Return book
        public static void ReturnBook()
        {
            Console.Clear();
            bool bookFound = false;
            string bookNum = "";

            Console.WriteLine("Return borrowed book.");
            Console.WriteLine("Enter the book's ISBN: ");
            var ISBNnumber = Console.ReadLine();

            string[] booksFromFile = File.ReadAllLines(@"E:\bibliotek-uppgift-c#_elliot-vadi\Bibliotek-Terminal-main\Books.txt");
            foreach (var line in (booksFromFile))
            {
                string[] tokens = line.Split(" ");
                if (line.Contains(ISBNnumber.ToString()))
                {
                    bookFound = true;
                    bookNum = tokens[0];
                    Console.WriteLine($"Please confirm that you wish to return the book with ISBN {ISBNnumber}: (y/n)");
                    var answer = Console.ReadLine();

                    if (answer == "y")
                    {
                        isBookBorrowed[Int16.Parse(bookNum)] = false;
                        Console.WriteLine("The book has now been returned. Have a nice day!");
                    }
                    else
                    {
                        Console.WriteLine("You will be taken back to the main menu...s");
                        Thread.Sleep(3000);
                    }
                }
            }
        }
    }
}
