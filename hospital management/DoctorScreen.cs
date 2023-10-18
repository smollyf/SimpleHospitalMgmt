using ConsoleTables;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace hospital_management
{
    class DoctorScreen
    {
        public static void DocMenu(int doctorID)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t+═══════════════════════════════════════════════════+");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║          DOTNET Hospital Management System        ║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║═══════════════════════════════════════════════════║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║                   Doctor Menu                     ║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t+═══════════════════════════════════════════════════+");
            Console.WriteLine("\n\t\t    1. List doctor details                         ");
            Console.WriteLine("\t\t    2. List patients                                 ");
            Console.WriteLine("\t\t    3. List appointment                              ");
            Console.WriteLine("\t\t    4. Check particular patient                      ");
            Console.WriteLine("\t\t    5. List appointments with patient                ");
            Console.WriteLine("\t\t    6. Logout                                        ");
            Console.WriteLine("\t\t    7. Exit                                          ");
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
                    ViewMyDetails(doctorID);

                    break;
                case '2':
                    Console.Clear();
                    ViewMyPatients(doctorID);

                    break;
                case '3':
                    Console.Clear();
                    ViewAppointments(doctorID);

                    break;
                case '4':
                    Console.Clear();
                    AdminScreen.SearchPatientByID();

                    break;
                case '5':
                    Console.Clear();
                    Console.WriteLine("was not sure what to display here as it it very similar to list appointments");

                    break;
                case '6':
                    Console.Clear();
                    Login login = new Login();
                    login.LoginScreen();

                    break;
                case '7':
                    Console.Clear();
                    Environment.Exit(0);

                    break;

                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\t\t   Invalid input! please enter 1-7\n");
                    Console.ForegroundColor = ConsoleColor.White;

                    DocMenu(doctorID);
                    break;
            }
        }

        public static void ViewMyDetails(int doctorID)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t+═══════════════════════════════════════════════════+");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║          DOTNET Hospital Management System        ║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║═══════════════════════════════════════════════════║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║                    My Details                     ║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t+═══════════════════════════════════════════════════+");

            // Read and search for the doctor with the specified ID in doctors.txt
            string[] doctorLines = File.ReadAllLines("doctors.txt");
            bool found = false;

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

                if (doctorInfo.Length >= 6)
                {
                    int currentDoctorID;

                    if (int.TryParse(doctorInfo[0], out currentDoctorID) && currentDoctorID == doctorID)
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
            // error message if doctor not found
            if (!found)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Doctor not found.");
            }

            Console.WriteLine("\nPress any key to return to the doctor menu...");
            Console.ReadKey();
            Console.Clear();
            DocMenu(doctorID); // Return to the doctor menu with the doctor's ID
        }

        public static void ViewAppointments(int doctorID)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t+═══════════════════════════════════════════════════+");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║          DOTNET Hospital Management System        ║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║═══════════════════════════════════════════════════║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║                  All Appointments                 ║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t+═══════════════════════════════════════════════════+");

            // Load appointment data from the "appointments.txt" file
            string[] appointmentLines = File.ReadAllLines("appointments.txt");

            bool foundAppointments = false;

            foreach (string line in appointmentLines)
            {
                string[] appointmentInfo = line.Split('|');

                if (appointmentInfo.Length >= 3 && int.TryParse(appointmentInfo[1], out int bookedDoctorID) && bookedDoctorID == doctorID)
                {
                    int patientID = int.Parse(appointmentInfo[0]);
                    string appointmentDateTime = appointmentInfo[2];

                    // Load patient data from the "patients.txt" file to get the patient's name
                    string[] patientLines = File.ReadAllLines("patients.txt");
                    string patientName = "Unknown Patient";

                    foreach (string patientLine in patientLines)
                    {
                        string[] patientInfo = patientLine.Split('|');

                        if (patientInfo.Length >= 3 && int.TryParse(patientInfo[0], out int currentPatientID) && currentPatientID == patientID)
                        {
                            patientName = $"{patientInfo[1]} {patientInfo[2]}";
                            break;
                        }
                    }

                    // Display the doctor's appointments
                    Console.WriteLine($"Patient: {patientName}");
                    Console.WriteLine($"Appointment Date and Time: {appointmentDateTime}\n");

                    foundAppointments = true;
                }
            }

            if (!foundAppointments)
            {
                Console.WriteLine("You have no upcoming appointments.");
            }

            Console.WriteLine("\nPress any key to go back to the main menu...");
            Console.ReadKey();
            Console.Clear();
            DocMenu(doctorID);
        }

        public static void ViewMyPatients(int doctorID)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t+═══════════════════════════════════════════════════+");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║          DOTNET Hospital Management System        ║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║═══════════════════════════════════════════════════║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║                   My Patients                     ║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t+═══════════════════════════════════════════════════+");

            // Load appointment data from the "appointments.txt" file
            string[] appointmentLines = File.ReadAllLines("appointments.txt");

            bool foundPatients = false;

            foreach (string line in appointmentLines)
            {
                string[] appointmentInfo = line.Split('|');

                if (appointmentInfo.Length >= 3 && int.TryParse(appointmentInfo[1], out int bookedDoctorID) && bookedDoctorID == doctorID)
                {
                    int patientID = int.Parse(appointmentInfo[0]);

                    // Load patient data from the "patients.txt" file
                    string[] patientLines = File.ReadAllLines("patients.txt");

                    foreach (string patientLine in patientLines)
                    {
                        string[] patientInfo = patientLine.Split('|');

                        if (patientInfo.Length >= 3 && int.TryParse(patientInfo[0], out int currentPatientID) && currentPatientID == patientID)
                        {
                            string patientName = $"{patientInfo[1]} {patientInfo[2]}";
                            string patientAddress = patientInfo[3];
                            string patientPhoneNumber = patientInfo[4];
                            string patientState = patientInfo[5];

                            // Display the patient's details
                            Console.WriteLine($"Patient Name: {patientName}");
                            Console.WriteLine($"Patient Address: {patientAddress}");
                            Console.WriteLine($"Patient Phone Number: {patientPhoneNumber}");
                            Console.WriteLine($"Patient State: {patientState}\n");

                            foundPatients = true;
                        }
                    }
                }
            }

            if (!foundPatients)
            {
                Console.WriteLine("You have no patients with appointments.");
            }

            Console.WriteLine("\nPress any key to go back to the main menu...");
            Console.ReadKey();
        }


    }
}
