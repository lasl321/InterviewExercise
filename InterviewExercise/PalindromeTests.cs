using System;
using NUnit.Framework;

namespace InterviewExercise
{
    public class Exercise
    {
        private string[] ReadLinesFromSource()
        {
            return new[]
            {
                "aaaa",
                "abba",
                "amanaplanacanal",
                "xyz"
            };
        }

        [Test]
        public void ShouldCreateNewPalindromes()
        {
            var maker = new PalindromeMaker();
            var lines = ReadLinesFromSource();
            foreach (var line in lines)
            {
                Console.WriteLine("Source: {0}. Result: {1}",
                                  line,
                                  maker.MakePalindrome(line));
            }
        }
    }

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
            // Would normally use dependency injection. Would normally use 
            // interface for more complex cases (i.e. IPalindrome).
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

            var length = input.Length;
            var previousAttempt = string.Empty;

            for (var i = 0; i < length; i++)
            {
                var currentCharacter = input[i];
                var currentAttempt = string.Concat(currentCharacter, previousAttempt);
                var candidate = string.Concat(input, currentAttempt);

                if (_palindrome.IsPalindrome(candidate))
                {
                    return candidate;
                }

                previousAttempt = currentAttempt;
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