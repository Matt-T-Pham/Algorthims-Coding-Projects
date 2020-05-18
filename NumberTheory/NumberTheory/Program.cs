using System;
using System.Collections.Generic;
using System.Text;

namespace NumberTheory
{
    class Program
    {
        static void Main(string[] args)
        {
            //string input;

            //while ((input = Console.ReadLine()) != null)
            //{
            //    string[] s = input.Split(' ');
            //    if (s[0] == "gcd")
            //    {
            //        long a = long.Parse(s[1]);
            //        long b = long.Parse(s[2]);
            //        Console.WriteLine(gcd(a, b));
            //    }
            //    else if (s[0] == "exp")
            //    {
            //        long x = long.Parse(s[1]);
            //        long y = long.Parse(s[2]);
            //        long n = long.Parse(s[3]);
            //        Console.WriteLine(Exp(x, y, n));
            //    }
            //    else if (s[0] == "inverse")
            //    {
            //        long a = long.Parse(s[1]);
            //        long b = long.Parse(s[2]);
            //        long answer = inverse(a, b);
            //        if (answer == -1)
            //        {
            //            Console.WriteLine("none");
            //        }
            //        else
            //        {
            //            Console.WriteLine(answer);
            //        }
            //    }
            //    else if (s[0] == "isprime")
            //    {
            //        long a = long.Parse(s[1]);
            //        Console.WriteLine(isprime(a));

            //    }
            //    else if (s[0] == "key")
            //    {
                    //long a = long.Parse(s[1]);
                    //long b = long.Parse(s[2]);
                    long a = 23;
                    long b = 29;
                    List<long> ans = key(a, b);
                    StringBuilder sb = new StringBuilder();
                    foreach (long an in ans)
                    {
                        sb.Append(an);
                        sb.Append(" ");
                    }
                    Console.WriteLine(sb.ToString());
            Console.Read();
             //   }
            //}
        }
        /// <summary>
        /// Joe Zachery slides
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static List<long> key(long a, long b)
        {
            List<long> answers = new List<long>();

            long mod = a * b;
            answers.Add(mod);

            long euler = (a - 1) * (b - 1);

            long e = 0;
            for (int i = 2; i <= euler; i++)
            {
                if (gcd(i, euler) == 1)
                {
                    e = i;
                    answers.Add(e);
                    break;
                }
            }

            long d = inverse(e, euler);
            answers.Add(d);
            return answers;
        }
        /// <summary>
        /// https://www.geeksforgeeks.org/prime-numbers/
        /// https://stackoverflow.com/questions/627463/how-can-i-test-for-primality
        /// references
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        private static string isprime(long a)
        {

            if (a % 2 == 0 || a < 2)
            {
                return "no";
            }
            else if (a == 2)
            {
                return "yes";
            }

            long max = (long)Math.Sqrt(a);

            for (int i = 3; i*i < a; i+=2 )
            {
                if (a % i == 0)
                {
                    return "no";
                }
            }
            return "yes";


        }

        /// <summary>
        /// https://www.geeksforgeeks.org/multiplicative-inverse-under-modulo-m/
        /// used this as a guide to understandc and implement
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static long inverse(long a, long m)
        {

            long _m = m;
            long y = 0, x = 1;
            if (m == 1)
                return 0;

            while (a>1)
            {
                if (m == 0)
                {
                    return -1;                   
                }
                long q = a / m;

                long t = m;

                m = a % m;
                a = t;
                t = y;

                y = x - q * y;
                x = t;                                     
            }

            if (x < 0)
                x += _m;
            return x;
        }
        /// <summary>
        /// https://www.geeksforgeeks.org/modular-exponentiation-power-in-modular-arithmetic/
        /// used that as a guide
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        private static long Exp(long x, long y, long n)
        {
            long res = 1;

            x = x % n;
            while (y > 0)
            {
                if ((y & 1) == 1)
                    res = (res * x) % n;

                y = y >> 1;
                x = (x * x) % n;
            }
            return res;
        }

        private static long gcd(long a, long b)
        {
            if (b == 0)
            {
                return a;
            }
            else
            {
                return gcd(b, a % b);
            }
        }
    }
}
