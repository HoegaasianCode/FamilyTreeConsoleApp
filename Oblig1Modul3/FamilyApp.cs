using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Oblig1Modul3
{
    public class FamilyApp
    {
        public List<Person> People;

        public FamilyApp(params Person[] peoples)
        {
            People = new List<Person>(peoples);
        }

        public string WelcomeMessage()
        {
            return "Velkommen";
        }

        public string CommandPrompt = "Skriv en kommando her: ";

        public string HandleCommand(string command)
        {
            var toLowerCommand = command.ToLower();

            if (toLowerCommand == "hjelp")
            {
                return "'hjelp' for alle kommandoer. \n" +
                       "'list' for alle personer. \n" +
                       "'vis <id>' for å se vedkommende.";
            }

            if (toLowerCommand == "list")
            {
                string description = "";

                foreach (var person in People)
                {
                    description += person.GetDescription() + "\n";
                }

                return description;
            }

            if (toLowerCommand.Substring(0, 3) == "vis")
            {
                int typedId = short.Parse(toLowerCommand.Substring(4));
                return FindFamilyMember(typedId);
            }

            return "Ugyldig kommando";
        }

        public string FindFamilyMember(int typedId)
        {
            string result;

            foreach (var personSearch in People)
            {
                if (personSearch.Id == typedId)
                {
                    result = personSearch.GetDescription();
                    result += ChildDescription(typedId);
                    return result;
                }
            }

            result = "Ugyldig person";
            return result;
        }

        public string ChildDescription(int typedId)
        {
            var childCount = People.Count;
            string[] kinshipCounter = new string[childCount];
            string child = null;
            int i = 0;

            for (int j = 0; j < childCount; j++)
            {
                if (People[j].Mother != null && People[j].Mother.Id == typedId)
                {
                    kinshipCounter[i] = "    " + People[j].FirstName + " (Id=" + People[j].Id + ") Født: " + People[j].BirthYear +"\n";
                    i++;
                }
                else if (People[j].Father != null && People[j].Father.Id == typedId)
                {
                    kinshipCounter[i] = "    " + People[j].FirstName + " (Id=" + People[j].Id + ") Født: " + People[j].BirthYear + "\n";
                    i++;
                }
            }
            if (kinshipCounter[0] != null)
            {
                child = "\n  Barn:\n";
                for (int k = 0; k < kinshipCounter.Length; k++)
                {
                    if (kinshipCounter[k] != null)
                    {
                        child += kinshipCounter[k];
                    }
                }
            }
            else if (kinshipCounter[0] == null)
            {
                child = " ";
            }
            return child;
        }
    }
}