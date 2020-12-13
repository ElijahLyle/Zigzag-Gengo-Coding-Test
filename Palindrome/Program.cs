using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Palindrome
{
    public class Program
    {
        private List<String> left_list;
        private List<String> right_list;
        static void Main(string[] args)
        {
            Program run = new Program();
            Console.WriteLine("Enter a string: ");
            String r = Console.ReadLine();
            Console.WriteLine("Is the whole string a palindrome?" + run.checkPalindrome(r));
            Console.WriteLine("The longest palindrome in the string is: " + run.longestPalindrome(r));
            Console.WriteLine("The number of cuts needed so the remaining substrings are palindromes: " + run.cutPalindrome(r));
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

        private String findPalindrome(String original)
        {
            left_list = new List<String>();
            right_list = new List<String>();
            int index_of_longest_left = 0, index_of_longest_right = 0;
            String reversed_left = reverseString(original);
            String reversed_right = reverseString(original);
            original = Regex.Replace(original, @"\s+", "").ToUpper();
            String palindrome_left = original.Substring(0, 1);
            String palindrome_right = original.Substring(original.Length - 1, 1);
            for (int a = 1; a <= original.Length; a++)
            {
                if (a == original.Length)
                {                    
                    palindrome_left += " ";
                    palindrome_right = " " + palindrome_right; 
                }
                else
                {
                    palindrome_left += original[a];
                    palindrome_right = original[original.Length - 1 - a] + palindrome_right;
                }
                if (!reversed_left.Contains(palindrome_left))
                {
                    left_list.Add(palindrome_left.Substring(0, palindrome_left.Length - 1));
                    reversed_left = reversed_left.Remove(reversed_left.IndexOf(palindrome_left.Substring(0, palindrome_left.Length - 1)),
                        palindrome_left.Substring(0, palindrome_left.Length - 1).Length);
                    palindrome_left = palindrome_left.Substring(palindrome_left.Length - 1, 1);
                    if (left_list.Count > 1)
                    {
                        if (left_list[left_list.Count - 1].Length > left_list[index_of_longest_left].Length)
                            index_of_longest_left = left_list.Count - 1;
                    }
                }
                if(!reversed_right.Contains(palindrome_right))
                {
                    right_list.Add(palindrome_right.Substring(1, palindrome_right.Length - 1));
                    reversed_right = reversed_right.Remove(reversed_right.IndexOf(palindrome_right.Substring(1, palindrome_right.Length - 1)),
                        palindrome_right.Substring(1, palindrome_right.Length - 1).Length);
                    palindrome_right = palindrome_right.Substring(0, 1);
                    if(right_list.Count > 1)
                    {
                        if (right_list[right_list.Count - 1].Length > right_list[index_of_longest_right].Length)
                            index_of_longest_right = right_list.Count - 1;
                    }
                }
            }
            if (left_list[index_of_longest_left].Length >= right_list[index_of_longest_right].Length)
                return left_list[index_of_longest_left];
            else
                return right_list[index_of_longest_right];
        }

        public String longestPalindrome(String s)
        {
            return findPalindrome(s);
        }

        public int cutPalindrome(String s)
        {
            String index = findPalindrome(s);
            int number_of_cuts_from_left = 0, number_of_cuts_from_right = 0;
            foreach (String element in left_list)
                if (element.Length > 1)
                    number_of_cuts_from_left++;
            foreach (String element in right_list)
                if (element.Length > 1)
                    number_of_cuts_from_right++;
            if (number_of_cuts_from_left <= number_of_cuts_from_right)
                return number_of_cuts_from_left;
            else
                return number_of_cuts_from_right;
        }
    }
}
