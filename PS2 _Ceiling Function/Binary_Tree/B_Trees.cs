using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Tree
{


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

        public void StartAdd (int[] Number)
        {
            for (int i = 0; i < Number.Length; i++)
            {
                roots = RecursiveAdd(roots, Number[i]);
            }
  
        }
        private Node RecursiveAdd(Node current,int num)
        {         
            if (current == null)
                return new Node(num);
            
            if (current.rootValue() > num)            
                current.left_child = RecursiveAdd(current.left_child, num);           
            else if (current.rootValue() < num)
                current.right_child = RecursiveAdd(current.right_child, num);            
            else
                return current;            

            return current;
        }
        public bool Compare(Node a, Node b)
        {
            if (a == null && b == null)
                return true;

            if (a == null && b != null || a != null && b == null)
                return false;

            return Compare(a.right_child, b.right_child) && Compare(a.left_child, b.left_child);
                    
        }
         
    }

}
