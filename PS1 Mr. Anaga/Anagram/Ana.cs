using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Anagram
{
    public class Ana
    {
        /// <summary>
        /// based off of Prof. Joe Zachary Jumble 5 algorithm
        /// Spring Semester 2018
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns>int</returns>
        public int anagrams(List<string> userInput)
        {
            List<string> solutions = new List<string>();
            HashSet<string> rejected = new HashSet<string>();

            foreach(string s in userInput)
            {
                string currentString = s;
                string sortedString = sort(currentString);

                if (solutions.Contains(sortedString))
                {
                    solutions.Remove(sortedString);
                    rejected.Add(sortedString);
                }
                else
                {
                    solutions.Add(sortedString);
                }
            }
            foreach (string s in rejected)
            {
                if (solutions.Contains(s))
                    solutions.Remove(s);
            }
            return solutions.Count;
        }
        /// <summary>
        ///   simple alphbetical sort founded on
        ///   https://www.dotnetperls.com/alphabetize-string
        /// </summary>
        /// <param name="sortee"></param>
        /// <returns></returns>
        public string sort(string sortee)
        {
            char[] a = sortee.ToCharArray();
            Array.Sort(a);
            return new string(a);
        }




    }
}
