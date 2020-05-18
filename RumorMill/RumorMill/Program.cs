using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumorMill
{
    class Program
    {
        public static Dictionary<string, student> Classroom = new Dictionary<string, student>();

        static void Main(string[] args)
        {
            int numberOfStudents = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfStudents; i++)
            {
                student s = new student();

                string studentName = Console.ReadLine();

                s.name = studentName;
    
                Classroom.Add(studentName, s);
            }

            int friendships = Int32.Parse(Console.ReadLine()); ;

            for (int j = 0; j < friendships; j++)
            {

                string inp = Console.ReadLine();
                string[] spl = inp.Split(' ');
                string friend1 = spl[0];
                string friend2 = spl[1];       

                Classroom[friend1].friends.Add(Classroom[friend2]);
                Classroom[friend2].friends.Add(Classroom[friend1]);
            }


            int reports = Int32.Parse(Console.ReadLine());

            List<string> report = new List<string>();

            for(int k = 0; k <reports; k++)
            {      
                string studentName = Console.ReadLine();

                int day = BFS(studentName);     
                List<SortedSet<string>>dayReport = final_report(day);

                StringBuilder sb = new StringBuilder();

                foreach(SortedSet<string> ss in dayReport)
                {
                    foreach(string st in ss)
                    {
                        sb.Append(st);
                        sb.Append(" ");
                    }
                }
                report.Add(sb.ToString());
            }

            foreach(string final in report)
            {
                Console.WriteLine(final);
            }
            Console.Read();
        }

        private static int BFS(string studentName)
        {
            int days = 0;

            clean();

            student current = Classroom[studentName];

            current.distance = 0;

            Queue<student> qeue = new Queue<student>();

            qeue.Enqueue(Classroom[studentName]);

            while (qeue.Count > 0)
            {
                student u = qeue.Dequeue();

                foreach (student s in u.friends)
                {
                    if (s.distance == Int32.MaxValue)
                    {
                        qeue.Enqueue(s);
                        s.distance = u.distance + 1;
                        s.prev = u;
                    }
                }
                days++;
            }
            return days;
        }


        private static List<SortedSet<string>> final_report(int days) { 

            List<SortedSet<string>> dayReport = new List<SortedSet<string>>();

            for(int i =  0; i < days+1; i++)
            {
                dayReport.Add(new SortedSet<string>());
            }

            foreach (student s in Classroom.Values)
            {
                for (int i = 0; i < days; i++)
                {
                    if(s.distance == Int32.MaxValue)
                    {
                        dayReport[days].Add(s.name);
                    }
                    else if (s.distance == i)
                    {
                        dayReport[i].Add(s.name);
                    }
                }
            }
            return dayReport;
        }

        private static void clean()
        {
            foreach (student s in Classroom.Values)
            {
                s.prev = null;
                s.distance = Int32.MaxValue;
            }
        }
    }
    class student
    {
        public string name { get; set; }
        public bool visited { get; set; } = false;

        public HashSet<student> friends = new HashSet<student>();

        public student prev = null;
        public int distance { get; set; } = Int32.MaxValue;

    }
}
