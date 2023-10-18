using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital_management
{
    class Person
    {
        public int ID { get; protected set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
        public string State { get; private set; }

        public Person(int id, string firstName, string lastName, string address, string phoneNumber, string state)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
            State = state;
        }

        public override string ToString()
        {
            return $"ID: {ID}\nName: {FirstName} {LastName}\nAddress: {Address}\nPhone Number: {PhoneNumber}\nState: {State}";
        }
    }

    class Doctor : Person 
    {
        public string Password { get; private set; }

        public Doctor(int id, string firstName, string lastName, string address, string phoneNumber, string state, string password)
            : base(id, firstName, lastName, address, phoneNumber, state)
        {
            Password = password;
        }
    }

    class Patient : Person
    {
        public string Password { get; private set; }

        public Patient(int id, string firstName, string lastName, string address, string phoneNumber, string state, string password)
            : base(id, firstName, lastName, address, phoneNumber, state)
        {
            Password = password;
        }
    }

}
