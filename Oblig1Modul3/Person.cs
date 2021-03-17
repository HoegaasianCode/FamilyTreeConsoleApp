using System;
using System.Collections.Generic;
using System.Text;

namespace Oblig1Modul3
{
    public class Person
    {
        public int Id;
        public string FirstName;
        public string LastName;
        public int BirthYear;
        public int DeathYear;
        public Person Father;
        public Person Mother;

        public string GetDescription()
        {
            string ping = "";
            if (FirstName != null) ping += $"{FirstName} ";
            if (LastName != null) ping += $"{LastName} ";
            if (Id != 0) ping += $"(Id={Id})";
            if (BirthYear != 0) ping += $" Født: {BirthYear}";
            if (DeathYear != 0) ping += $" Død: {DeathYear}";
            if (Father?.FirstName != null) ping += $" Far: {Father.FirstName}";
            if (Father != null) ping += $" (Id={Father.Id})";
            if (Mother != null) ping += $" Mor: {Mother.FirstName}";
            if (Mother != null) ping += $" (Id={Mother.Id})";

            return ping;
        }

    }
}
