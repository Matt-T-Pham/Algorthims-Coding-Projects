using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GalaxyQuest.Program;

namespace GalaxyQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = Console.ReadLine();

            string[] split = userInput.Split(' ');

            long diameter = int.Parse(split[0]);
            long numberOfStars = int.Parse(split[1]);

            Pairs[] StarHolder = new Pairs[numberOfStars];

            for (int i = 0; i < numberOfStars; i++)
            {
                string StarLocation = Console.ReadLine();

                string[] s = StarLocation.Split(' ');

                long x = long.Parse(s[0]);
                long y = long.Parse(s[1]);

                Pairs star = new Pairs(x,y);

               StarHolder[i] = star;
            }

            Pairs Final = findMajority(StarHolder, diameter);

            if (Final == null)
            {
                Console.WriteLine("NO");
                Console.Read();
                return;
            }

            int finalCount = 0;

            foreach(Pairs p in StarHolder)
            {
                if ((Math.Pow((p.x - Final.x), 2) + Math.Pow((p.y - Final.y), 2)) < Math.Pow(diameter, 2))
                {
                    finalCount++;
                }
            }
            Console.WriteLine(finalCount);
            Console.Read();
        }
        public static Pairs findMajority(Pairs[] A, long d)
        {
            if (A.Length == 0)
            {
                return null;
            }
            else if (A.Length == 1)
            {
                return A[0];
            }
            else
            {
                int mid = A.Length / 2;
                Pairs[] p1 = A.Take(mid).ToArray();
                Pairs[] p2 = A.Skip(mid).ToArray();

                var x = findMajority(p1, d);
                var y = findMajority(p2, d);

                if (x == null && y == null)
                {
                    return null;
                }
                else if (x == null)
                {
                    long co = countOccurrences(A, y, d);
                    if (co > mid)
                    {
                        return y;
                    }
                    return null;
                }
                else if (y == null)
                {
                    long co = countOccurrences(A, x, d);
                    if (co > mid)
                    {
                        return x;
                    }
                    return null;
                }
                else
                {
                    long co1 = countOccurrences(A, x, d);
                    long co2 = countOccurrences(A, y, d);
                    if (co1 > mid)
                    {
                        return x;
                    }
                    else if (co2 > mid)
                    {
                        return y;
                    }
                    else
                    {
                        return null;
                    }

                }
            }


        }
        public static long countOccurrences(Pairs[] a, Pairs current, long d)
        {
            long finalCount = 0;
            
            foreach (Pairs p in a)
            {              
                if ((Math.Pow((p.x - current.x), 2) + Math.Pow((p.y - current.y), 2)) < Math.Pow(d, 2))
                {
                    finalCount++;
                }
            }
            return finalCount;
        }

        public class Pairs
       {
            public long x;
            public long y;

            public Pairs (long _x, long _y)
            {
                this.x = _x;
                this.y = _y;
            }
       }


}

}
