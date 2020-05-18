using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSink
{
    class Program
    {
        public static Dictionary<string, City> Cities = new Dictionary<string, City>();
        public static List<City> sorted = new List<City>();

        static void Main(string[] args)
        {

            int numberOfCitys = Int32.Parse(Console.ReadLine());

           for(int i = 0; i < numberOfCitys; i++)
           {
                City c = new City();

                string input = Console.ReadLine();

                string[] split = input.Split(' ');
                string cityName = split[0];
                int toll = int.Parse(split[1]);

                c.cityName = cityName;
                c.Toll = toll;

                Cities.Add(c.cityName, c);           
           }

            int numberOfHighways = Int32.Parse(Console.ReadLine());   ;

            for (int j = 0; j < numberOfHighways; j++)
            {

                string inp = Console.ReadLine();
                string[] spl = inp.Split(' ');
                string cityStart = spl[0];
                string cityEnd = spl[1];
                Cities[cityStart].Connections.Add(Cities[cityEnd]);
            }

            int numberOfTrips = Int32.Parse(Console.ReadLine());

            topologicalSort(Cities);
            sorted.Reverse();

            List<string> Answers = new List<string>();

            for (int k = 0; k < numberOfTrips; k++)
            {               
                string trip = Console.ReadLine();
                string[] tri = trip.Split(' ');

                string startingCity = tri[0];
                string endingCity = tri[1];
                findCost(startingCity, endingCity);

                City end = Cities[endingCity];

                if (startingCity == endingCity)
                {
                    Answers.Add("0");
                }
                else if (Cities[startingCity].Connections == null)
                {
                    Answers.Add("NO");
                }
                else if (Cities[startingCity].post > Cities[endingCity].post)
                {
                    if(end.cost == Int32.MaxValue)
                    {
                        Answers.Add("NO");
                    }
                    else
                    {
                        Answers.Add(end.cost.ToString());
                    }                  
                }
                else
                {
                    Answers.Add("NO");
                }
            }
            foreach (string s in Answers)
            {
                Console.WriteLine(s);
            }
            Console.Read();
        }

        private static void findCost(string startingCity, string endingCity)
        {
            clean();

            City current = Cities[startingCity];
            City ending = Cities[endingCity];
            current.cost = 0;

            foreach (City city in sorted)
            {
                if (city.cost != Int32.MaxValue && city.Connections != null)
                {
                    foreach(City ci in city.Connections)
                    {
                   
                        if (Cities[ci.cityName].cost >= city.cost + Cities[ci.cityName].Toll)
                        {
                            Cities[ci.cityName].cost = city.cost + Cities[ci.cityName].Toll;
                        }
                           
                    }
                }
            }
        }
        private static void clean()
        {
            foreach(City cit in sorted)
            {
                cit.cost = Int32.MaxValue;
            }
            foreach (City city in Cities.Values)
            {
                city.cost = Int32.MaxValue;
            }
        }
        //start recursvie topological sort 
        private static void topologicalSort(Dictionary<string, City> c)
        {
            int count = 1;
            foreach(City city in c.Values)
            {
                if (!city.visited)
                {
                    InDepthSearchy(city, ref count);
                }
            }
        }
        private static void InDepthSearchy (City c, ref int count)
        {
            c.visited = true;
            c.pre = count++;
                foreach (City con in c.Connections)
                {
                    if (!con.visited)
                    {
                        InDepthSearchy(con, ref count);
                    }
                }           
            Cities[c.cityName].post = count++;
            sorted.Add(Cities[c.cityName]);
        }
    }
    class City
    {
        public string cityName { get; set; }
        public int Toll { get; set; }
        public int pre { get; set; }
        public int post { get; set;}
        public bool visited { get; set; } = false;
    
        public HashSet<City> Connections = new HashSet<City>();
        public int cost { get; set; } = Int32.MaxValue;
    }
}
