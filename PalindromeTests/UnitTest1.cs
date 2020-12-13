using Microsoft.VisualStudio.TestTools.UnitTesting;
using Palindrome;

namespace PalindromeTests
{
    [TestClass]
    public class UnitTest1
    {

        private string input_1 = "abcdcba";
        private string input_2 = "abaxyzzyxf";
        private string input_3 = "noonabbad";
        private string input_4 = "Step on no pets";

        Program palindrome = new Program();

        [TestMethod]
        public void Palindrome_Level1()
        {
            Assert.AreEqual(true, palindrome.checkPalindrome(input_1));
            Assert.AreEqual(false, palindrome.checkPalindrome(input_2));
            Assert.AreEqual(false, palindrome.checkPalindrome(input_3));
            Assert.AreEqual(true, palindrome.checkPalindrome(input_4));
        }

        [TestMethod]
        public void Palindrome_Level2()
        {
            Assert.AreEqual("abcdcba".ToUpper(), palindrome.longestPalindrome(input_1));
            Assert.AreEqual("xyzzyx".ToUpper(), palindrome.longestPalindrome(input_2));
            Assert.AreEqual("noon".ToUpper(), palindrome.longestPalindrome(input_3));
        }

        [TestMethod]
        public void Palindrome_Level3()
        {
            Assert.AreEqual(1, palindrome.cutPalindrome(input_1));
            Assert.AreEqual(2, palindrome.cutPalindrome(input_2));
            Assert.AreEqual(2, palindrome.cutPalindrome(input_3));
            Assert.AreEqual(1, palindrome.cutPalindrome(input_4));
        }
    }
}
