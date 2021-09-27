using System;
using System.Collections.Generic;

namespace Assignment03
{
    public static class Extensions
    {
        public static IEnumerable<T> Flatten<T>(this IEnumerable<IEnumerable<T>> items)
        {
            foreach (var item in items)
            {
                foreach (var t in item)
                {
                    yield return t;
                }
            }
        }

        public static IReadOnlyCollection<string> WizardNamesByCreator (string sName){

            var wiList = new List<string>();
            var wizards = Wizard.Wizards.Value;

            foreach(Wizard w in wizards){

                if (w.Creator.Contains(sName))wiList.Add(w.Name);

            }
            wiList.Sort();
            return wiList.AsReadOnly();

        }

        public static int YearOfFirstSithLord(){

            var wiList = new List<int>();
            var wizards = Wizard.Wizards.Value;

            foreach(Wizard w in wizards){

                if (w.Name.Contains("Darth"))wiList.Add(w.Year.GetValueOrDefault());


            }

            wiList.Sort((x,y) => x.CompareTo(y));
            return wiList[0];

        }

        public static IReadOnlyCollection<(string, int)> uniqueHPWizards(){

            var wiList = new List<(string, int)>();
            var wizards = Wizard.Wizards.Value;

            foreach(Wizard w in wizards){

                if(w.Medium.StartsWith("Harry Potter") /* && !wizards.Contains(x => x.Item1 == w.Name)*/) wiList.Add((w.Name, w.Year.GetValueOrDefault()));

            }

            return wiList.AsReadOnly();



        }

        


    }

}
