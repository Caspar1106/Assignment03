using System;
using Xunit;

namespace Assignment03.Tests
{
    public class DelegatesTests
    {
        [Fact]
        public void Given_Hello_World_to_the_reverse_delegate_returns_dlroW_olleH()
        {
            var actual = Delegates.reverse("Hello World");

            var expect = "dlroW olleH";

            Assert.Equal(expect, actual);
        }
        [Fact]
        public void Given_4_and_6_to_the_product_delegate_returns_24()
        {
            var actual = Delegates.product(4,6);

            var expect = 24;

            Assert.Equal(expect, actual);
        }
        [Fact]
        public void Given_string_0042_and_int_42_returns_true()
        {

            bool actual = Delegates.numericallyEqual("0042", 42);

            Assert.True(actual);
        }
        
        [Fact]
        public void Given_string_4200_and_int_42_returns_false()
        {

            bool actual = Delegates.numericallyEqual("4200", 42);

            Assert.False(actual);
        }
        [Fact]
        public void Given_string_Яд_and_int_42_returns_false()
        {

            bool actual = Delegates.numericallyEqual("Яд", 42);

            Assert.False(actual);
        }
    }
}
