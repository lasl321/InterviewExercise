using System;
using NUnit.Framework;

namespace InterviewExercise
{
    public class PalindromeTests
    {
        private Palindrome _palindrome;

        [SetUp]
        public void SetUp()
        {
            _palindrome = new Palindrome();
        }

        [TestCase("aaaa", true)]
        [TestCase("abba", true)]
        [TestCase("amanaplanacanalpanama", true)]
        [TestCase("xyzyx", true)]
        [TestCase("", true)]
        [TestCase("A", true)]
        [TestCase("xx", true)]
        [TestCase("abc", false)]
        [TestCase("ab", false)]
        public void ShouldDetectPalindrome(string s, bool expected)
        {
            var isPalindrome = _palindrome.IsPalindrome(s);
            Assert.That(isPalindrome, Is.EqualTo(expected));
        }
    }

    public class Palindrome
    {
        public bool IsPalindrome(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException("s");
            }

            if (s == string.Empty)
            {
                return true;
            }

            var length = s.Length;

            if (length == 1)
            {
                return true;
            }

            var isEvenLength = length % 2 == 0;
            var endIndex = length - 1;
            if (isEvenLength)
            {

                for (var i = 0; i < length - 1; i++)
                {
                    if (s[i] != s[endIndex - i])
                    {
                        return false;
                    }
                }

                return true;
            }

            for (var i = 0; i < length - 2; i++)
            {
                if (s[i] != s[endIndex - i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}