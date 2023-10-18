using Microsoft.VisualBasic;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace hospital_management
{
    class Login
    {
        private string idInput;
        private string passwordInput;

        public void LoginScreen()
        {
            Console.Clear();

            Console.WriteLine("\t\t+═══════════════════════════════════════════════════+");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║          DOTNET Hospital Management System        ║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║═══════════════════════════════════════════════════║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║                       Login                       ║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t+═══════════════════════════════════════════════════+");
            Console.Write("\n\t\t UserName: ");

            int idCursorX = Console.CursorTop;
            int idCursorY = Console.CursorLeft;

            Console.Write("\n\n\t\t Password: ");

            int passwordCursorX = Console.CursorTop;
            int passwordCursorY = Console.CursorLeft;

            Console.SetCursorPosition(idCursorY, idCursorX);
            Console.ForegroundColor = ConsoleColor.Yellow;
            idInput = Console.ReadLine().Trim();

            Console.SetCursorPosition(passwordCursorY, passwordCursorX);

            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
                {
                    passwordInput += keyInfo.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (keyInfo.Key == ConsoleKey.Backspace && passwordInput.Length > 0)
                    {
                        passwordInput = passwordInput.Substring(0, passwordInput.Length - 1);
                        Console.Write("\b \b");
                    }
                    else if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            } while (true);
            Console.ForegroundColor = ConsoleColor.Yellow;

            IsLoginValid(idInput, passwordInput);

        }

        private void IsLoginValid(string userName, string password)
        {
            try
            {
                if (userName == "admin" && password == "09876")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\n\n\n\t\t\tValid Admin Credentials!... Please Enter");
                    Console.ForegroundColor = ConsoleColor.White;

                    // Display the Admin menu
                    AdminScreen.AdminMenu();
                    return;
                }

                // Check if the ID is 6 digits (patient) or 7 digits (doctor)
                if (userName.Length == 6)
                {
                    string[] patientLines = File.ReadAllLines("patients.txt");
                    foreach (string patientData in patientLines)
                    {
                        // Split each line into fields
                        string[] patientInfo = patientData.Split('|');
                        string patientID = patientInfo[0];
                        string filePassword = patientInfo[6]; // Password is in the last field (index 6)

                        if (userName == patientID && password == filePassword)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("\n\n\n\t\t\tValid Patient Credentials!... Please Enter");
                            Console.ForegroundColor = ConsoleColor.White;

                            // Display the Patient menu with the patient's ID
                            Console.Clear();
                            PatientScreen.PatientMenu(int.Parse(patientID)); // Pass the patient's ID
                            return;
                        }
                    }
                }
                else if (userName.Length == 7)
                {
                    // Check if the user input matches doctor credentials in doctors.txt
                    string[] doctorLines = File.ReadAllLines("doctors.txt");
                    foreach (string doctorData in doctorLines)
                    {
                        // Split each line into fields
                        string[] doctorInfo = doctorData.Split('|');
                        string doctorID = doctorInfo[0];
                        string filePassword = doctorInfo[6]; // Password is in the last field (index 6)

                        if (userName == doctorID && password == filePassword)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("\n\n\n\t\t\tValid Doctor Credentials!... Please Enter");
                            Console.ForegroundColor = ConsoleColor.White;

                            // Display the Doctor menu with the doctor's ID
                            DoctorScreen.DocMenu(int.Parse(doctorID)); // Pass the doctor's ID
                            return;
                        }
                    }
                }

                // If user login credentials are not found in either file or invalid input, display an error message
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n\n\n\t\t\tIncorrect credentials... \n\t\t\tPlease press any key to try again!");
                Console.ForegroundColor = ConsoleColor.White;

                // Reset input values
                idInput = null;
                passwordInput = null;

                Console.ReadKey();
                LoginScreen();
            }
            catch (FileNotFoundException)
            {
                Console.Clear();
                Console.WriteLine("File not found");
                Console.ReadKey();
            }
        }
    }

}
