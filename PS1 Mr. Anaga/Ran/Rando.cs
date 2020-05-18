using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ran
{
    public class Rando
    {

        Random r = new Random();
        //helper random methods regions
        #region
        //helper methods
        public int RandomNumLengthofArray(int input)
        {          
            int number = r.Next(10, input);
            return number;
        }
        public int RandomNumLengthofWords(int input)
        {        
            int number = r.Next(5, input);
            return number;
        }
        /// <summary>
        /// taken from the example at dotnetperls
        /// to generate random lowercase letters
        /// https://www.dotnetperls.com/random-lowercase-letter
        /// </summary>
        /// <returns></returns>
        public char RandomLetters()
        {
            int number = r.Next(1, 26);
            char let = (char)('a' + number);
            return let;
        }
        public int RandomNumOfAnagrams(int input)
        {
            int number = r.Next(5, input);
            return number;
        }
        #endregion

        /// <summary>
        /// randomy generates a list
        /// </summary>
        /// <param name="sizeOfList"></param>
        /// <param name="lengthOfWords"></param>
        /// <param name="numberOfAna"></param>
        /// <returns></returns>
        public List<string> randomGen(int sizeOfList, int lengthOfWords, int numberOfAna)
        {
            char[] lettersForAnagrams = new char[lengthOfWords];

            int numberOfWordsNotAnagrams = sizeOfList - numberOfAna;

            StringBuilder sb = new StringBuilder();

            List<string> final = new List<string>();          

            for (int i = 0; i < lengthOfWords; i++)
            {
                lettersForAnagrams[i] = RandomLetters();
            }

            for (int i = 0; i < numberOfWordsNotAnagrams; i++)
            {
                for (int k = 0; k < lengthOfWords; k++)
                {
                    sb.Append(RandomLetters());
                }
                final.Add(sb.ToString());
                sb.Clear();
            }
            for (int j = 0; j < numberOfAna; j++)
            {
                final.Add(anaMixer(lettersForAnagrams));
            }
            return final;
        }

        /// <summary>
        /// scrambles the char array for the annagram
        /// StackOverflow Fisher-Yates Shuffle Example
        /// </summary>
        /// <param name="ana"></param>
        /// <returns></returns>
        public string anaMixer(char[] ana)
        {
            int n = ana.Length;
            while (n > 1)
            {
                n--;
                int k = r.Next(n + 1);
                var value = ana[k];
                ana[k] = ana[n];
                ana[n] = value;
            }

            return new string(ana);
        }
    }
}
