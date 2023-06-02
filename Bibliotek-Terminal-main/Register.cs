namespace bibliotek
{
    internal class Register
    {
        static string currentUser = "";

        // Register new user
        public static void RegisterPage()
    {
        Console.Clear();
        Console.WriteLine("To register, please enter social security number (YYYY-MM-DD-XXXX) and desired password.");
        Console.WriteLine("");

        Console.Write("Social secutity number: ");
        var persnumber = Console.ReadLine();

        Console.Write("Password: ");
        var password = Console.ReadLine();



        if (UserInfoIncomplete(persnumber, password))
        {
            Console.Clear();
            Console.WriteLine("Please enter actual information to register.");
            Console.WriteLine("");
            RegisterPage();
            return;
        }

        var line = $"{persnumber} {password}\n";

        File.AppendAllText(@"E:\bibliotek-uppgift-c#_elliot-vadi\Bibliotek-Terminal-main\Users.txt", line);

        Console.WriteLine("You're now registered and will be able to log in shortly. Please wait.");

        Thread.Sleep(6000);
    }

        // Log in existing user
        public static bool LoginPage()
        {
            Console.Clear();

            Console.WriteLine("Welcome!");


            Console.WriteLine("To log in, please enter social security number and password.");
            Console.WriteLine("");

            Console.Write("Social security number: ");
            var persnumber = Console.ReadLine();

            Console.Write("Password: ");
            var password = Console.ReadLine();

            string [] loginFromFile = File.ReadAllLines(@"E:\bibliotek-uppgift-c#_elliot-vadi\Bibliotek-Terminal-main\Users.txt");

            bool loginOk = false;
            foreach(var line in loginFromFile)
            {
                string[] tokens = line.Split(" ");
                Console.WriteLine(tokens[0]);
                Console.WriteLine(tokens[1]);

                string userIdFromFile = tokens[0];
                string userPassword = tokens[1];
                string userPassword = "12367";

                if (userIdFromFile == persnumber && userPassword == password)
                {
                    loginOk = true;
                    currentUser = persnumber;
                }
                
            }
            if (loginOk)
            {
                Console.WriteLine("Log in succeeded!");
                return true;
            }
            else
            {
                //LoginPage();
                return false;
            }
        }
            // Change user password
            public static void ChangePassword()
            {
                Console.Clear();
                Console.WriteLine("Please enter new desired password: ");
                var newPassword = Console.ReadLine();

                List<string> allUsers = new List<string>(File.ReadAllLines(@"E:\bibliotek-uppgift-c#_elliot-vadi\Bibliotek-Terminal-main\Users.txt"));  
                int i = 0;
                int lineNumber = 0;
                string line = "";
                foreach (var user in allUsers)
                {
                    string[] tokens1 = user.Split(" ");
                    string userIdFromFile = tokens1[0];
                    if(userIdFromFile == currentUser)
                    {
                        line = $"{userIdFromFile} {newPassword}";
                        Console.Write($"{currentUser} {userIdFromFile} {newPassword}");
                        lineNumber = i;
                    }
                    i++;
                }
                allUsers[i-1] = line;
                File.WriteAllLines(@"E:\bibliotek-uppgift-c#_elliot-vadi\Bibliotek-Terminal-main\Users.txt", allUsers.ToArray());
            }



        // Writes a line at register
        static bool UserInfoIncomplete(string? firstPersnumber, string? password)
        {
            if (firstPersnumber == null || firstPersnumber == "") return true;
            if (password == null || password == "") return true;

            return false;
        }
    }
}
