using System;
using NUnit.Framework;

namespace InterviewExercise
{
    public class PalindromeMakerTests
    {
        private Palindrome _palindrome;
        private PalindromeMaker _palindromeMaker;


        [SetUp]
        public void SetUp()
        {
            _palindrome = new Palindrome();
            _palindromeMaker = new PalindromeMaker();
        }

        [TestCase(null, ExpectedException = typeof (ArgumentNullException))]
        [TestCase("aaaa")]
        [TestCase("abba")]
        [TestCase("amanaplanacanal")]
        [TestCase("xyz")]
        [TestCase("")]
        [TestCase("A")]
        public void ShouldCreatePalindrome(string input)
        {
            var palindrome = _palindromeMaker.MakePalindrome(input);
            Assert.That(_palindrome.IsPalindrome(palindrome), Is.True);
        }
    }

    public class PalindromeMaker
    {
        private readonly Palindrome _palindrome;

        internal PalindromeMaker(Palindrome palindrome)
        {
            _palindrome = palindrome;
        }

        public PalindromeMaker() : this(new Palindrome())
        {
        }

        public string MakePalindrome(string input)
        {
            if (_palindrome.IsPalindrome(input))
            {
                return input;
            }

            //0
            //1

            var length = input.Length;
            var previous = "";

            for (var i = 0; i < length; i++)
            {
                var substringToAppend = input[i];
                var candidate = string.Concat(input, substringToAppend, previous);
                Console.WriteLine(candidate);

                if (_palindrome.IsPalindrome(candidate))
                {
                    return candidate;
                }

                previous = string.Concat(substringToAppend, previous);
            }
            return input;
        }
    }

    public class PalindromeTests
    {
        private Palindrome _palindrome;

        [SetUp]
        public void SetUp()
        {
            _palindrome = new Palindrome();
        }

        [TestCase(null, true, ExpectedException = typeof (ArgumentNullException))]
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
            var lastIndex = length - 1;
            var iterationLimit = isEvenLength ? lastIndex : lastIndex - 1;

            for (var i = 0; i < iterationLimit; i++)
            {
                if (s[i] != s[lastIndex - i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}