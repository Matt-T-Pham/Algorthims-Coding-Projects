using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anagram;
using Ran;

namespace PS1_Mr.Anaga
{
    /// <summary>
    /// Determines the number of words that are not anagrams.
    /// using Kattis propiertary I/O kattio.cs
    /// for getting inputs
    /// 
    /// </summary>
    class Program
    {
        public const int DURATION = 1000;

        static void Main(string[] args)
        {
            Ana a = new Ana();
            Rando r = new Rando();


            Console.WriteLine("\nsize\tTime (msec)\tRation (msec)");

            double previousTime = 0;

            int size = 32;

            for (int i = 0; i <= 17; i++)
            {
                size = size * 2;

                double currentTime = Timer();

                Console.Write((size - 1) + "\t" + currentTime.ToString("G3"));
                if (i > 0)
                {
                    Console.WriteLine("     \t" + (currentTime / previousTime).ToString("G3"));
                }
                else
                {
                    Console.WriteLine();
                }
                previousTime = currentTime;

            }

            //random generations
            #region
            //int x = r.RandomNumLengthofArray(500);
            //int y = r.RandomNumLengthofWords(20);
            //int z = r.RandomNumOfAnagrams(60);

            //int fin = x - z;
            //double finalCount = a.anagrams(r.randomGen(x, y, z));

            //Console.WriteLine("Total Number of words");
            //Console.WriteLine(x);
            //Console.WriteLine("Total Number of Anagrams");
            //Console.WriteLine(z);
            //Console.WriteLine("what my algorthim produces");
            //Console.WriteLine(finalCount);
            //Console.WriteLine("Actual number of non anagrams");
            //Console.WriteLine(fin);
            #endregion


            //commented code for taken in console input
            #region
            //string size = Console.ReadLine();

            //string[] split = size.Split(' ');

            //int numberofwords = int.Parse(split[0]);
            //int lengthofwords = int.Parse(split[1]);

            //List<string> wordlist = new List<string>();

            //for (int j = 0; j < numberofwords; j++)
            //{
            //    string userinput = Console.ReadLine();
            //    if (userinput.Length == lengthofwords)
            //    {
            //        wordlist.Add(userinput);
            //    }
            //}

            //int fianl = anagram(wordlist);

            //Console.WriteLine(fianl);
            #endregion
            Console.Read();
        }
        /// <summary>
        /// taken for Prof. Joe Zachery ArrarySearch
        /// Returns the number of milliseconds that have elapsed on the Stopwatch.
        /// </summary>
        public static double msecs(Stopwatch sw)
        {
            return (((double)sw.ElapsedTicks) / Stopwatch.Frequency) * 1000;
        }

        public static double Timer()
        {
            Rando r = new Rando();
            Ana a = new Ana();





            Stopwatch sw = new Stopwatch();

            double elapsed = 0;
            long repetitions = 1;

            int size = 32;
            do
            {
                repetitions *= 2;

                int _x = r.RandomNumLengthofArray(size);
                int _y = r.RandomNumLengthofWords(100);
                int _z = r.RandomNumOfAnagrams(size);

                List<string> Time = r.randomGen(size, _y, _z);

                sw.Restart();
                for (long i = 0; i < repetitions; i++)
                {
                    double time = a.anagrams(Time);
                }
                sw.Stop();
                elapsed = msecs(sw);
                size = size * 2;
            } while (elapsed < DURATION);


            double totalAverage = elapsed / repetitions;

            return totalAverage;

        }

    }

}
