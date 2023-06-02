namespace bibliotek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creates a new instance of Library
            Library myLibrary = new Library();
            string answer = "";
            bool loggedIn = false;

            Console.WriteLine("Welcome!");
            
            // Login
            while ((answer != "4"))
            {
                if (!loggedIn)
                {
                    Console.WriteLine("Please pick one of the following options:");
                    Console.WriteLine("1. Register a new user");
                    Console.WriteLine("2. Log in");
                    Console.WriteLine("4. Quit");
                    answer = Console.ReadLine();

                    if (answer == "1")
                    {
                        Console.Clear();
                        Register.RegisterPage();
                    }
                    else if (answer == "2")
                    {
                        Console.Clear();
                        loggedIn = Register.LoginPage();
                    }
                }
                else
                {
                    // Once the user is logged in
                    Console.Clear();
                    Console.WriteLine("You are now logged in. Please choose an option");
                    Console.WriteLine("1. Search for a book");
                    Console.WriteLine("2. Borrow a book");
                    Console.WriteLine("3. Return a book");
                    Console.WriteLine("4. Quit");
                    Console.WriteLine("5. Change password");
                    answer = Console.ReadLine();

                    if (answer == "1")
                    {
                        Library.Search();
                    }
                    else if (answer == "2")
                    {
                        Library.BorrowBook();
                    }
                    else if (answer == "3")
                    {
                        Library.ReturnBook();
                    }
                    else if (answer == "5")
                    {
                        Register.ChangePassword();
                    }
                }
            }
            Console.WriteLine("You are being logged out. We'll see you again!");
            
        }
        }   
}
