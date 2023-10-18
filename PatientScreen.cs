using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital_management
{
    class PatientScreen
    {
        public static void PatientMenu(int patientID)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t+═══════════════════════════════════════════════════+");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║          DOTNET Hospital Management System        ║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║═══════════════════════════════════════════════════║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║                   Patient Menu                    ║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t+═══════════════════════════════════════════════════+");
            //Console.WriteLine("\t\t                                                     ");
            Console.WriteLine("\n\t\t    1. List patient details                        ");
            Console.WriteLine("\t\t    2. List my doctor details                        ");
            Console.WriteLine("\t\t    3. Book appointment                              ");
            Console.WriteLine("\t\t    4. List all appointments                         ");
            Console.WriteLine("\t\t    5. Exit to login                                 ");
            Console.WriteLine("\t\t    6. Exit System                                  ");
            Console.WriteLine("\t\t                                                     ");
            Console.WriteLine("\t\t+═══════════════════════════════════════════════════+");
            Console.Write("\t\t   Please choose an option from 1-6: ");
            int patientMenuCursorX = Console.CursorTop;
            int patientMenuCursorY = Console.CursorLeft;

            Console.Write("                    ");
            int passwordCursorX = Console.CursorTop;
            int passwordCursorY = Console.CursorLeft;

            Console.WriteLine("\n\n\t\t                                                     ");

            Console.SetCursorPosition(patientMenuCursorY, patientMenuCursorX);

            ConsoleKeyInfo menuSelection = Console.ReadKey();
            switch (menuSelection.KeyChar)
            {
                case '1':
                    Console.Clear();
                    ViewMyDetails(patientID);

                    break;
                case '2':
                    Console.Clear();
                    ViewMyDoctors(patientID);

                    break;
                case '3':
                    Console.Clear();
                    BookAppointment(patientID);

                    break;
                case '4':
                    Console.Clear();
                    ViewAppointments(patientID);

                    break;
                case '5':
                    Console.Clear();
                    Login login = new Login();
                    login.LoginScreen();

                    break;
                case '6':
                    Console.Clear();
                    Environment.Exit(0);

                    break;

                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\t\t   Invalid input! please enter 1-6\n");
                    Console.ForegroundColor = ConsoleColor.White;

                    PatientMenu(patientID);
                    break;
            }
        }

        private static void ViewMyDetails(int patientID)
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
            string[] patientLines = File.ReadAllLines("patients.txt");
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

            foreach (string line in patientLines)
            {
                string[] patientInfo = line.Split('|');

                if (patientInfo.Length >= 6)
                {
                    int currentPatientID;

                    if (int.TryParse(patientInfo[0], out currentPatientID) && currentPatientID == patientID)
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Patient not found.");
            }

            Console.WriteLine("\nPress any key to return to the doctor menu...");
            Console.ReadKey();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            PatientMenu(patientID); // Return to the patient menu with the doctor's ID
        }

        public static void BookAppointment(int patientID)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t+═══════════════════════════════════════════════════+");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║          DOTNET Hospital Management System        ║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║═══════════════════════════════════════════════════║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║                 Book an appointment               ║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t+═══════════════════════════════════════════════════+");

            // Load doctor data from the "doctors.txt" file
            string[] doctorLines = File.ReadAllLines("doctors.txt");

            // Display a list of available doctors for the patient to choose from
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nAvailable Doctors:");
            Console.WriteLine("-------------------");

            Console.ForegroundColor = ConsoleColor.White;

            Dictionary<int, string> doctorList = new Dictionary<int, string>();

            foreach (string line in doctorLines)
            {
                string[] doctorInfo = line.Split('|');
                int doctorID;

                if (doctorInfo.Length >= 7 && int.TryParse(doctorInfo[0], out doctorID))
                {
                    doctorList.Add(doctorID, $"{doctorInfo[1]} {doctorInfo[2]}");
                    Console.WriteLine($"{doctorID}. {doctorInfo[1]} {doctorInfo[2]}");
                }
            }

            Console.Write("\nEnter the ID of the doctor you want to book an appointment with (or 0 to cancel): ");
            if (int.TryParse(Console.ReadLine(), out int selectedDoctorID))
            {
                if (selectedDoctorID == 0)
                {
                    // Cancel the appointment booking
                    Console.WriteLine("Appointment booking canceled.");
                }
                else if (doctorList.ContainsKey(selectedDoctorID))
                {
                    // Get the selected doctor's name
                    string selectedDoctorName = doctorList[selectedDoctorID];

                    // Ask for the appointment date and time
                    Console.Write($"Enter appointment date and time with {selectedDoctorName}: ");
                    string appointmentDateTime = Console.ReadLine();

                    // Store the appointment information in a file or database
                    // For simplicity, you can add it to a text file, e.g., "appointments.txt"
                    using (StreamWriter writer = File.AppendText("appointments.txt"))
                    {
                        writer.WriteLine($"{patientID}|{selectedDoctorID}|{appointmentDateTime}");
                    }

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Appointment with {selectedDoctorName} booked on {appointmentDateTime} !");
                    Console.ReadKey();
                    Console.Clear();
                    PatientMenu(patientID);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid doctor ID. Appointment booking canceled.");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Appointment booking canceled.");
            }

            Console.WriteLine("\nPress any key to go back to the main menu...");
            Console.ReadKey();
        }

        public static void ViewAppointments(int patientID)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t+═══════════════════════════════════════════════════+");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║          DOTNET Hospital Management System        ║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║═══════════════════════════════════════════════════║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║                   My Appointments                 ║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t+═══════════════════════════════════════════════════+");

            // Load appointment data from the "appointments.txt" file
            string[] appointmentLines = File.ReadAllLines("appointments.txt");

            bool foundAppointments = false;

            foreach (string line in appointmentLines)
            {
                string[] appointmentInfo = line.Split('|');

                if (appointmentInfo.Length >= 3 && int.TryParse(appointmentInfo[0], out int bookedPatientID) && bookedPatientID == patientID)
                {
                    int doctorID = int.Parse(appointmentInfo[1]);
                    string appointmentDateTime = appointmentInfo[2];

                    // Load doctor data from the "doctors.txt" file to get the doctor's name
                    string[] doctorLines = File.ReadAllLines("doctors.txt");
                    string doctorName = "Unknown Doctor";

                    foreach (string doctorLine in doctorLines)
                    {
                        string[] doctorInfo = doctorLine.Split('|');

                        if (doctorInfo.Length >= 3 && int.TryParse(doctorInfo[0], out int currentDoctorID) && currentDoctorID == doctorID)
                        {
                            doctorName = $"{doctorInfo[1]} {doctorInfo[2]}";
                            break;
                        }
                    }

                    // Display the patient's appointments
                    Console.WriteLine($"Doctor: {doctorName}");
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
            PatientMenu(patientID);
        }

        public static void ViewMyDoctors(int patientID)
        {
            Console.Clear();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t+═══════════════════════════════════════════════════+");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║          DOTNET Hospital Management System        ║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║═══════════════════════════════════════════════════║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t║                   My Appointments                 ║");
            Console.WriteLine("\t\t║                                                   ║");
            Console.WriteLine("\t\t+═══════════════════════════════════════════════════+\n");

            // Load appointment data from the "appointments.txt" file
            string[] appointmentLines = File.ReadAllLines("appointments.txt");

            bool foundDoctors = false;

            foreach (string line in appointmentLines)
            {
                string[] appointmentInfo = line.Split('|');

                if (appointmentInfo.Length >= 3 && int.TryParse(appointmentInfo[0], out int bookedPatientID) && bookedPatientID == patientID)
                {
                    int doctorID = int.Parse(appointmentInfo[1]);

                    // Load doctor data from the "doctors.txt" file
                    string[] doctorLines = File.ReadAllLines("doctors.txt");

                    foreach (string doctorLine in doctorLines)
                    {
                        string[] doctorInfo = doctorLine.Split('|');

                        if (doctorInfo.Length >= 3 && int.TryParse(doctorInfo[0], out int currentDoctorID) && currentDoctorID == doctorID)
                        {
                            string doctorName = $"{doctorInfo[1]} {doctorInfo[2]}";
                            string doctorAddress = doctorInfo[3];
                            string doctorPhoneNumber = doctorInfo[4];
                            string doctorState = doctorInfo[5];

                            // Display the doctor's details
                            Console.WriteLine($"Doctor Name: {doctorName}");
                            Console.WriteLine($"Doctor Address: {doctorAddress}");
                            Console.WriteLine($"Doctor Phone Number: {doctorPhoneNumber}");
                            Console.WriteLine($"Doctor State: {doctorState}\n");

                            foundDoctors = true;
                        }
                    }
                }
            }

            if (!foundDoctors)
            {
                Console.WriteLine("You have no appointments with doctors.");
            }

            Console.WriteLine("\nPress any key to go back to the main menu...");
            Console.ReadKey();
            Console.Clear();
            PatientMenu(patientID);
        }


    }
}
