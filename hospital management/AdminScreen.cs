using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital_management
{
    class AdminScreen
    {
        public static void AdminMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t+═══════════════════════════════════════════════════+");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║          DOTNET Hospital Management System        ║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║═══════════════════════════════════════════════════║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║                Administrator Menu                 ║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t+═══════════════════════════════════════════════════+");
            Console.WriteLine("\n\t\t    1. List all doctors                            ");
            Console.WriteLine("\t\t    2. Check doctor details                          ");
            Console.WriteLine("\t\t    3. List all patients                             ");
            Console.WriteLine("\t\t    4. Check patient details                         ");
            Console.WriteLine("\t\t    5. Add Doctor                                    ");
            Console.WriteLine("\t\t    6. Add Patient                                   ");
            Console.WriteLine("\t\t    7. Logout                                        ");
            Console.WriteLine("\t\t    8. Exit                                          ");
            Console.WriteLine("\t\t                                                     ");
            Console.WriteLine("\t\t+═══════════════════════════════════════════════════+");
            Console.Write("\t\t   Please choose an option from 1-7: ");
            int docMenuCursorX = Console.CursorTop;
            int docMenuCursorY = Console.CursorLeft;

            Console.Write("                    ");
            int passwordCursorX = Console.CursorTop;
            int passwordCursorY = Console.CursorLeft;

            Console.WriteLine("\n\n\t\t                                                     ");

            Console.SetCursorPosition(docMenuCursorY, docMenuCursorX);

            ConsoleKeyInfo menuSelection = Console.ReadKey();
            switch (menuSelection.KeyChar)
            {
                case '1':
                    Console.Clear();
                    ListAllDoctors();

                    break;
                case '2':
                    Console.Clear();
                    SearchDoctorByID();

                    break;
                case '3':
                    Console.Clear();
                    ListAllPatients();

                    break;
                case '4':
                    Console.Clear();
                    Console.WriteLine("patient name age");

                    break;
                case '5':
                    Console.Clear();
                    AddDoctor();

                    break;
                case '6':
                    Console.Clear();
                    AddPatient();

                    break;
                case '7':
                    Console.Clear();
                    Login login = new Login();
                    login.LoginScreen();

                    break;
                case '8':
                    Console.Clear();
                    Environment.Exit(0);

                    break;

                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\t\t   Invalid input! please enter 1-8\n");
                    Console.ForegroundColor = ConsoleColor.White;

                    AdminMenu();
                    break;
            }
        }

        static void AddDoctor()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t+═══════════════════════════════════════════════════+");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║          DOTNET Hospital Management System        ║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║═══════════════════════════════════════════════════║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║                    Add Doctor                     ║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t+═══════════════════════════════════════════════════+");

            // Generate a random 7-digit ID for the doctor
            int doctorID = GenerateDoctorID();

            // Generate a random 5-digit password for the doctor
            string password = GenerateRandomPassword();

            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter Address: ");
            string address = Console.ReadLine();
            Console.Write("Enter Phone Number: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Enter State: ");
            string state = Console.ReadLine();

            // Create a new Doctor object with the generated ID and password
            Doctor doctor = new Doctor(doctorID, firstName, lastName, address, phoneNumber, state, password);

            // Append the doctor's information to the doctors.txt file
            using (StreamWriter writer = File.AppendText("doctors.txt"))
            {
                writer.WriteLine($"{doctor.ID}|{doctor.FirstName}|{doctor.LastName}|{doctor.Address}|{doctor.PhoneNumber}|{doctor.State}|{doctor.Password}");
            }

            Console.WriteLine("Doctor added successfully.");
            Console.WriteLine($"Your user ID is: {doctorID}");
            Console.WriteLine($"Your password is: {password}");

            Console.ReadKey();
            Console.Clear();

            AdminMenu();
        }

        static int GenerateDoctorID()
        {
            // Generate a random 7-digit ID for the doctor between 5000000 and 9999999
            Random random = new Random();
            return random.Next(5000000, 10000000);
        }

        static void AddPatient()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t+═══════════════════════════════════════════════════+");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║          DOTNET Hospital Management System        ║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║═══════════════════════════════════════════════════║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║                   Add Patient                     ║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t+═══════════════════════════════════════════════════+");

            // Generate a random 6-digit ID for the patient
            int patientID = GeneratePatientID();

            // Generate a random 5-digit password for the patient
            string password = GenerateRandomPassword();

            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter Address: ");
            string address = Console.ReadLine();
            Console.Write("Enter Phone Number: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Enter State: ");
            string state = Console.ReadLine();

            // Create a new Patient object with the generated ID and password
            Patient patient = new Patient(patientID, firstName, lastName, address, phoneNumber, state, password);

            // Append the patient's information to the patients.txt file
            using (StreamWriter writer = File.AppendText("patients.txt"))
            {
                writer.WriteLine($"{patient.ID}|{patient.FirstName}|{patient.LastName}|{patient.Address}|{patient.PhoneNumber}|{patient.State}|{patient.Password}");
            }

            Console.WriteLine("Patient added successfully.");

            Console.WriteLine($"Your user ID is: {patientID}");
            Console.WriteLine($"Your password is: {password}");

            Console.ReadKey();
            Console.Clear();

            AdminMenu();
        }

        static int GeneratePatientID()
        {
            // Generate a random 6-digit ID for the patient between 100000 and 999999
            Random random = new Random();
            return random.Next(100000, 1000000);
        }

        static string GenerateRandomPassword()
        {
            // Generate a random 5-digit password
            Random random = new Random();
            return random.Next(10000, 100000).ToString();
        }

        public static void ListAllDoctors()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t+═══════════════════════════════════════════════════+");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║          DOTNET Hospital Management System        ║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║═══════════════════════════════════════════════════║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║                   List All Doctors                ║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t+═══════════════════════════════════════════════════+");

            // Read and display doctor information from the doctors.txt file
            string[] doctorLines = File.ReadAllLines("doctors.txt");

            if (doctorLines.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No doctors found.");
            }
            else
            {
                // Define column widths
                int idWidth = 9;
                int firstNameWidth = 15;
                int lastNameWidth = 15;
                int addressWidth = 25;
                int phoneNumberWidth = 15;
                int stateWidth = 10;

                // Display table headers
                Console.WriteLine($"{"ID".PadRight(idWidth)}" +
                                  $"{"First Name".PadRight(firstNameWidth)}" +
                                  $"{"Last Name".PadRight(lastNameWidth)}" +
                                  $"{"Address".PadRight(addressWidth)}" +
                                  $"{"Phone Number".PadRight(phoneNumberWidth)}" +
                                  $"{"State".PadRight(stateWidth)}");

                foreach (string line in doctorLines)
                {
                    string[] doctorInfo = line.Split('|');

                    // Ensure that there are enough fields in the line
                    if (doctorInfo.Length >= 6)
                    {
                        // Display doctor information with padding for each field
                        Console.WriteLine($"{doctorInfo[0].PadRight(idWidth)}" +
                                          $"{doctorInfo[1].PadRight(firstNameWidth)}" +
                                          $"{doctorInfo[2].PadRight(lastNameWidth)}" +
                                          $"{doctorInfo[3].PadRight(addressWidth)}" +
                                          $"{doctorInfo[4].PadRight(phoneNumberWidth)}" +
                                          $"{doctorInfo[5].PadRight(stateWidth)}");
                    }
                }
            }

            Console.WriteLine("\nPress any key to return to the admin menu...");
            Console.ReadKey();
            Console.Clear();
            AdminMenu();
        }

        public static void ListAllPatients()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t+═══════════════════════════════════════════════════+");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║          DOTNET Hospital Management System        ║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║═══════════════════════════════════════════════════║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║                   List all Patients               ║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t+═══════════════════════════════════════════════════+");

            // Read and display patient information from the patients.txt file
            string[] patientLines = File.ReadAllLines("patients.txt");

            if (patientLines.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No patients found.");
            }
            else
            {
                // Define column widths
                int idWidth = 9;
                int firstNameWidth = 15;
                int lastNameWidth = 15;
                int addressWidth = 25;
                int phoneNumberWidth = 15;
                int stateWidth = 10;

                // Display table headers
                Console.WriteLine($"{"ID".PadRight(idWidth)}" +
                                  $"{"First Name".PadRight(firstNameWidth)}" +
                                  $"{"Last Name".PadRight(lastNameWidth)}" +
                                  $"{"Address".PadRight(addressWidth)}" +
                                  $"{"Phone Number".PadRight(phoneNumberWidth)}" +
                                  $"{"State".PadRight(stateWidth)}");

                foreach (string line in patientLines)
                {
                    string[] patientInfo = line.Split('|');

                    // Ensure that there are enough fields in the line
                    if (patientInfo.Length >= 6)
                    {
                        // Display patient information with padding for each field
                        Console.WriteLine($"{patientInfo[0].PadRight(idWidth)}" +
                                          $"{patientInfo[1].PadRight(firstNameWidth)}" +
                                          $"{patientInfo[2].PadRight(lastNameWidth)}" +
                                          $"{patientInfo[3].PadRight(addressWidth)}" +
                                          $"{patientInfo[4].PadRight(phoneNumberWidth)}" +
                                          $"{patientInfo[5].PadRight(stateWidth)}");
                    }
                }
            }

            Console.WriteLine("\nPress any key to return to the admin menu...");
            Console.ReadKey();
            Console.Clear();
            AdminMenu();
        }

        public static void SearchDoctorByID()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t+═══════════════════════════════════════════════════+");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║          DOTNET Hospital Management System        ║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║═══════════════════════════════════════════════════║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║                   Search Doctor                   ║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t+═══════════════════════════════════════════════════+");
            Console.Write("\nEnter Doctor ID to search: ");
            int searchID;

            if (int.TryParse(Console.ReadLine(), out searchID))
            {
                // Read and search for the doctor with the specified ID in doctors.txt
                string[] doctorLines = File.ReadAllLines("doctors.txt");
                bool found = false;

                // Define column widths
                int idWidth = 8;
                int firstNameWidth = 15;
                int lastNameWidth = 15;
                int addressWidth = 25;
                int phoneNumberWidth = 15;
                int stateWidth = 10;

                Console.WriteLine("\nDoctor Information\n");

                // Display table headers
                Console.WriteLine($"{"ID".PadRight(idWidth)}" +
                                  $"{"First Name".PadRight(firstNameWidth)}" +
                                  $"{"Last Name".PadRight(lastNameWidth)}" +
                                  $"{"Address".PadRight(addressWidth)}" +
                                  $"{"Phone Number".PadRight(phoneNumberWidth)}" +
                                  $"{"State".PadRight(stateWidth)}");

                foreach (string line in doctorLines)
                {
                    string[] doctorInfo = line.Split('|');

                    if (doctorInfo.Length >= 6)
                    {
                        int doctorID;

                        if (int.TryParse(doctorInfo[0], out doctorID) && doctorID == searchID)
                        {
                            // Display the doctor's information (excluding password) in tabular format
                            Console.WriteLine($"{doctorInfo[0].PadRight(idWidth)}" +
                                              $"{doctorInfo[1].PadRight(firstNameWidth)}" +
                                              $"{doctorInfo[2].PadRight(lastNameWidth)}" +
                                              $"{doctorInfo[3].PadRight(addressWidth)}" +
                                              $"{doctorInfo[4].PadRight(phoneNumberWidth)}" +
                                              $"{doctorInfo[5].PadRight(stateWidth)}");

                            found = true;
                            break;
                        }
                    }
                }

                if (!found)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Doctor with ID {searchID} not found.");
                    Console.ForegroundColor = ConsoleColor.White;
                    SearchDoctorByID();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid Doctor ID.");
            }

            Console.WriteLine("\nPress any key to return to the admin menu...");
            Console.ReadKey();
            AdminMenu();
        }

        public static void SearchPatientByID()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t+═══════════════════════════════════════════════════+");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║          DOTNET Hospital Management System        ║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║═══════════════════════════════════════════════════║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║                   Search Patient                  ║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t+═══════════════════════════════════════════════════+");
            Console.Write("\nEnter Patient ID to search: ");
            int searchID;

            if (int.TryParse(Console.ReadLine(), out searchID))
            {
                // Read and search for the doctor with the specified ID in doctors.txt
                string[] patientLines = File.ReadAllLines("patients.txt");
                bool found = false;

                // Define column widths
                int idWidth = 8;
                int firstNameWidth = 15;
                int lastNameWidth = 15;
                int addressWidth = 25;
                int phoneNumberWidth = 15;
                int stateWidth = 10;

                Console.WriteLine("\nPatient Information\n");

                // Display table headers
                Console.WriteLine($"{"ID".PadRight(idWidth)}" +
                                  $"{"First Name".PadRight(firstNameWidth)}" +
                                  $"{"Last Name".PadRight(lastNameWidth)}" +
                                  $"{"Address".PadRight(addressWidth)}" +
                                  $"{"Phone No.".PadRight(phoneNumberWidth)}" +
                                  $"{"State".PadRight(stateWidth)}");

                foreach (string line in patientLines)
                {
                    string[] patientInfo = line.Split('|');

                    if (patientInfo.Length >= 6)
                    {
                        int doctorID;

                        if (int.TryParse(patientInfo[0], out doctorID) && doctorID == searchID)
                        {
                            // Display the doctor's information (excluding password) in tabular format
                            Console.WriteLine($"{patientInfo[0].PadRight(idWidth)}" +
                                              $"{patientInfo[1].PadRight(firstNameWidth)}" +
                                              $"{patientInfo[2].PadRight(lastNameWidth)}" +
                                              $"{patientInfo[3].PadRight(addressWidth)}" +
                                              $"{patientInfo[4].PadRight(phoneNumberWidth)}" +
                                              $"{patientInfo[5].PadRight(stateWidth)}");

                            found = true;
                            break;
                        }
                    }
                }

                if (!found)
                {
                    Console.WriteLine($"Patient with ID {searchID} not found.");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid Patient ID.");
            }

            Console.WriteLine("\nPress any key to return to the admin menu...");
            Console.ReadKey();
            AdminMenu();
        }


    }

}
