using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Palindrome
{
    public class Program
    {
        private List<String> list;
        static void Main(string[] args)
        {
            Program run = new Program();
            String r = "Step on no pets";
            Console.WriteLine(r);
            Console.WriteLine(run.checkPalindrome(r));
            Console.WriteLine(run.longestPalindrome(r));
            Console.WriteLine(run.cutPalindrome(r));
        }

        private static string reverseString(String s)
        {
            char[] array = Regex.Replace(s, @"\s+", "").ToUpper().ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }

        public Boolean checkPalindrome(String s)
        {
            return Regex.Replace(s, @"\s+", "").ToUpper().Equals(reverseString(s));
        }

        private int findPalindrome(String original)
        {
            list = new List<String>();
            int index_of_longest = 0;
            String reversed = reverseString(original);
            original = Regex.Replace(original, @"\s+", "").ToUpper();
            String palindrome = original.Substring(0, 1);
            for (int a = 1; a <= original.Length; a++)
            {
                if (a == original.Length)
                    palindrome += " ";
                else
                    palindrome += original[a];
                if (!reversed.Contains(palindrome))
                {
                    list.Add(palindrome.Substring(0, palindrome.Length - 1));
                    reversed = reversed.Remove(reversed.IndexOf(palindrome.Substring(0, palindrome.Length - 1)),
                        palindrome.Substring(0, palindrome.Length - 1).Length);
                    palindrome = palindrome.Substring(palindrome.Length - 1, 1);
                    if (list.Count > 1)
                    {
                        if (list[list.Count - 1].Length > list[index_of_longest].Length)
                            index_of_longest = list.Count - 1;
                    }
                }
            }
            return index_of_longest;
        }

        public String longestPalindrome(String s)
        {
            int index = findPalindrome(s);
            return list[index];
        }

        public int cutPalindrome(String s)
        {
            int index = findPalindrome(s);
            int number_of_cuts = 0;
            foreach (String element in list)
                if (element.Length > 1)
                    number_of_cuts++;
            return number_of_cuts;
        }
    }
}
