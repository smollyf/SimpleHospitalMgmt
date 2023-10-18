using System;

namespace hospital_management
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;

            // New User Login
            Login user = new Login();
            user.LoginScreen();
        }
    }
}
