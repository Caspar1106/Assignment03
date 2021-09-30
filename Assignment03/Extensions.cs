using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment03
{
    public static class Extensions
    {

        static IReadOnlyCollection<Wizard> wizards = Wizard.Wizards.Value;

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

            
            
            var listards = wizards.Where(w => w.Creator.Contains(sName)).Select(w => w.Name).Distinct().ToList();
            listards.Sort();
            return listards;
            
        
        }

        public static IReadOnlyCollection<string> WizardNamesByCreatorLINQ(string sName){

            var listards = (from w in wizards
                            where w.Creator.Contains(sName)
                            select w.Name).Distinct().ToList();
            listards.Sort();
            return (IReadOnlyCollection<string> )listards.AsReadOnly();
        }

        public static int YearOfFirstSithLord(){

            var sithyear = wizards.Where(w => w.Name.Contains("Darth"))
                                  .OrderBy(w => w.Year)
                                  .Select(w => w.Year.GetValueOrDefault());

            return sithyear.ElementAt(0);
        }

        public static int YearOfFirstSithLordLINQ(){

            var sithyear = (from w in wizards
                            where w.Name.Contains("Darth")
                            orderby w.Year
                            select w.Year.GetValueOrDefault()).ToList().AsReadOnly();
            return sithyear.ElementAt(0);

        }

        public static IReadOnlyCollection<(string, int)> uniqueHPWizards(){

            var listards = wizards.Where(w => w.Medium.Contains("Harry Potter"))
                                  .GroupBy(w => w.Name)
                                  .Select(w => (w.First().Name, w.First().Year.GetValueOrDefault())).ToList();

            return listards.AsReadOnly();



        }

        public static IReadOnlyCollection<(string, int)> uniqueHPWizardsLINQ(){

            var listards = (from w in wizards
                           where w.Medium.Contains("Harry Potter")
                           group w by w.Name into w
                           select (w.First().Name, w.First().Year.GetValueOrDefault())).Distinct().ToList();

            return listards.AsReadOnly();


        }

        public static IReadOnlyCollection<string> WizardsOrderedByCreatorAndName(){

            var listards = wizards.OrderByDescending(w => w.Creator).ThenBy(w => w.Name).Select(w => w.Name).Distinct().ToList();
            return listards.AsReadOnly();

        }

        public static IReadOnlyCollection<string> WizardsOrderedByCreatorAndNameLINQ(){

            var listards = (from w in wizards
                           orderby w.Creator descending, w.Name
                           select w.Name).Distinct().ToList();

            return listards.AsReadOnly();
        }
        


    }

}
