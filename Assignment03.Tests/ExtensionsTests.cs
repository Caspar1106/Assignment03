using System;
using Xunit;
using System.Collections.Generic;
using static Assignment03.Extensions;

namespace Assignment03.Tests
{
    public class ExtensionsTests
    {
        [Fact]
        public void flatten_return_yield_returns_1_2_3_4_5_3times()
        {
            var input = new List<List<int>>() { new List<int>() { 1, 2, 3, 4, 5 }, new List<int>() { 1, 2, 3, 4, 5 }, new List<int>() { 1, 2, 3, 4, 5 } };


            var output = Assignment03.Extensions.Flatten(input);
            var expected = new List<int>() { 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5 };

            Assert.Equal(expected, output);

        }


        [Fact]
        public void Names_Of_Wizards_By_Rowling()
        {

            List<string> expected = new List<string> {"Hagrid", "Happy Potter", "Hermione Granger", 
                                                    "Ron Weasley", "Tom Riddle"};

            Assert.Equal(expected.AsReadOnly(), WizardNamesByCreator("Rowling"));
            Assert.Equal(expected.AsReadOnly(), WizardNamesByCreatorLINQ("Rowling"));

        }

        [Fact]
        public void Year_Of_First_Sith_Lord_Returns_1947(){

            Assert.Equal(1947, YearOfFirstSithLord());
            Assert.Equal(1947, YearOfFirstSithLordLINQ());
        }

        [Fact]
        public void All_Unique_HP_Wizards(){

            var expected = new List<(string, int)>
            {
                ("Happy Potter", 2001), 
                ("Hermione Granger", 2001), 
                ("Ron Weasley", 2001),
                ("Tom Riddle", 2001), 
                ("Hagrid", 2001)
            };

            Assert.Equal(expected, uniqueHPWizards());
            Assert.Equal(expected, uniqueHPWizardsLINQ());

        }

        [Fact]
        public void Wizard_Names_Ordered_By_Reverse_Creator_Then_Names(){

            var expected = new List<string>{"Alatar", "Gandalf", "Radagast", "Sauron", "Hagrid", "Happy Potter", "Hermione Granger", "Ron Weasley", "Tom Riddle", "Darth Maul", "Darth Vader", "Geralt", "Yennefer"};
            
            Assert.Equal(expected.AsReadOnly(), WizardsOrderedByCreatorAndName());
            Assert.Equal(expected.AsReadOnly(), WizardsOrderedByCreatorAndNameLINQ());
        }
    

        [Fact]
        public void test_flatten_on_the_collection_iteself()
        {
            var input = new List<List<int>>() { new List<int>() { 1, 2, 3, 4, 5 }, new List<int>() { 1, 2, 3, 4, 5 }, new List<int>() { 1, 2, 3, 4, 5 } };

            var expected = new List<int>() { 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5 };
            Assert.Equal(expected, input.Flatten());
        }

        [Fact]
        public void filter_returns_2_4_6_from_1_to_6()
        {
            Predicate<int> even = Even;
            var input = new List<int>() { 1, 2, 3, 4, 5, 6 };
            var output = Assignment03.Extensions.Filter<int>(input, even);
            Assert.Equal(new List<int>() { 2, 4, 6 }, output);
        }

        [Fact]
        public void Filter_On_Collection_Returns_70()
        {
            Predicate<int> pred = div7_And_Above_42;
            var input = new List<int>() { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };

            Assert.Equal(new List<int>() { 70 }, input.Filter(pred));
        }

        [Fact]
        public void Filter_isLeapYear_Returns_1860_and_2000()
        {
            Predicate<int> pred = isLeapYear;
            var input = new List<int>() { 1800, 1900, 1860, 2000, 2191, 4300 };

            Assert.Equal(new List<int>() { 1860, 2000 }, input.Filter(pred));
        }

        [Fact]
        public void URI_IsSecure_returns_true()
        {
            Uri uri = new Uri("https://example.myExample.com");
            Assert.True(uri.isSecure());
        }

        [Fact]
        public void wordCount_returns_4()
        {
            var s = "this is my string";
            Assert.Equal(4, s.wordCount());
        }

        public static bool Even(int i)
        {
            return i % 2 == 0;
        }

        public static bool div7_And_Above_42(int i)
        {
            if (i > 42)
            {
                return i % 7 == 0;
            }
            return false;
        }

        public static bool isLeapYear(int year)
        {
            if ((year % 400 == 0) || (year % 4 == 0 && year % 100 != 0)) return true;
            else return false;
        
        }
    }

}
