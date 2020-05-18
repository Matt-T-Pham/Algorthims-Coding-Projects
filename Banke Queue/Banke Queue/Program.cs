using System;
using System.Collections.Generic;
using System.Linq;

namespace Banke_Queue
{

    class Program
    {

        static void Main(string[] args)
        {
            Dictionary<int, List<int>> bank = new Dictionary<int, List<int>>();
          
            int final = 0;
            string userinput = Console.ReadLine();
            string[] split = userinput.Split(' ');

            int N = int.Parse(split[0]);
            int T = int.Parse(split[1]);

            for(int i = 0; i < N; i++)
            {
                string people = Console.ReadLine();
                string[] person = people.Split(' ');

                int money = int.Parse(person[0]);
                int time = int.Parse(person[1]);

                if (bank.ContainsKey(time))
                    bank[time].Add(money);
                else
                    bank[time] = new List<int>() { money };                                  
            }
            for(int j  = T; j >= 0; j--)
            {
                if (bank.ContainsKey(j))
                {
                    int greatestSum = bank[j].Max();
                    int temp = j;

                    for (int k = T;  k > j; k--)
                    {
                        if (bank.ContainsKey(k) && bank[k].Count > 0)
                        {
                            if (greatestSum < bank[k].Max())
                            {
                                greatestSum = bank[k].Max();
                                temp = k;
                            }
                        }
                    }
                    bank[temp].Remove(greatestSum);                
                    final += greatestSum;
                }              
            }
            Console.WriteLine(final);
            Console.Read();
        }
    }
}
