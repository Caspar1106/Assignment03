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
    
}
}
