using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ceiling_Function
{
    class Program
    {
        static void Main(string[] args)
        {

            string size = Console.ReadLine();

            string[] split = size.Split(' ');

            int numberOfSets = int.Parse(split[0]);
            int numberOfNumbers = int.Parse(split[1]);

            int finalCount = numberOfSets;

            List<Node> Holder = new List<Node>();

            for (int i = 0; i < numberOfSets; i++)
            {
                Tree t = new Tree();
                List<int> IntList = new List<int>();

                string userInput = Console.ReadLine();
                string[] splitInput = userInput.Split(' ');

                for (int j = 0; j < splitInput.Length; j++)
                {
                    IntList.Add(int.Parse(splitInput[j]));
                }

                int[] tj = IntList.ToArray();
                Holder.Add(t.StartAdd(tj));
            }

            for(int j = 0; j < Holder.Count; j++)
            {
                Tree q = new Tree();

                Node t = Holder[0];

                Holder.RemoveAt(0);

                for (int i = 0; i < Holder.Count; i++)
                {
                    if (q.Compare(t, Holder[i]))
                    {
                        Holder.RemoveAt(i);
                        finalCount--;
                        i--;
                    }                       
                }
                j--;
            }

            if (finalCount <= 0)
                Console.WriteLine(1);
            else
                Console.WriteLine(finalCount);
            Console.Read();
        }
    }

    public class Node
    {
        public int root;
        public Node left_child;
        public Node right_child;

        public Node(int value)
        {
            root = value;
            left_child = null;
            right_child = null;
        }
        public int rootValue()
        {
            return root;
        }
    }
    public class Tree
    {
        public Node roots;

        public Node StartAdd(int[] Number)
        {
            for (int i = 0; i < Number.Length; i++)
            {
                roots = RecursiveAdd(roots, Number[i]);
            }

            return roots;
        }
        private Node RecursiveAdd(Node current, int num)
        {
            if (current == null)
                return new Node(num);
            else if (current.rootValue() > num)
                current.left_child = RecursiveAdd(current.left_child, num);
            else if (current.rootValue() < num)
                current.right_child = RecursiveAdd(current.right_child, num);
            else
                return current;

            return current;
        }
        public bool Compare(Node Comp1, Node Comp2)
        {
            if (Comp1 == null && Comp2 == null)
                return true;

               
            if (Comp1 == null && Comp2 != null || Comp1 != null && Comp2 == null)
                return false;

            return Compare(Comp1.right_child, Comp2.right_child) && Compare(Comp1.left_child, Comp2.left_child);

        }
    }
}
