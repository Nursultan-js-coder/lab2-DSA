

using System;
using System.Collections.Generic;
namespace main
{
    public class Tree
    {
        static Node root;
        public char[] charArray;
        public Tree(char[] charArray)
        {
            this.charArray = charArray;
            root = new Node(charArray[0]);
        }

        public class Node
        {
            public char data;
            public List<Node> children;
            public Node(char data)
            {
                this.data = data;
                this.children = new List<Node>();
            }
        }
        public static void Push(Node node, char[] charArray)
        {
            foreach (char ch in charArray)
            {
                node.children.Add(new Node(ch));
            }
        }
        public static void Insert(char[] arrChar)
        {

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            Node temp = new Node('c');

            // Do level order traversal until we find
            // an empty place.
            int n = 0;
            double sum = 0;
            double basis = arrChar.Length;
            for (int i = 0; i < basis - 1; i++)
            {
                sum += Math.Pow(basis, i);
            }

            while (n < sum)
            {
                temp = q.Peek();
                q.Dequeue();
                for (int i = 0; i < arrChar.Length; i++)
                {
                    Node new_node = new Node(arrChar[i]);
                    temp.children.Add(new_node);
                    q.Enqueue(new_node);
                }
                n++;

            }
        }

        public static void Display(Node node, char[] arr, int n)
        {
            if (n == arr.Length) return;
            Display(node.children[n], arr, n);

            for (int i = 0; i < arr.Length; i++)
            {

                Console.WriteLine("{node.children[i]}");
            }


        }
        public static void DisplayWrapper(char[] charArray)
        {
            int n = 0;
            Display(root, charArray, n);
        }



        public static void Traverse(char[] arrChar)
        {

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            Node temp = new Node('c');

            // Do level order traversal until we find
            // an empty place.
            int n = 0;
            double sum = 0;
            double basis = arrChar.Length;
            for (int i = 0; i < basis - 1; i++)
            {
                sum += Math.Pow(basis, i);
            }

            while (n < sum)
            {
                temp = q.Peek();
                q.Dequeue();
                for (int i = 0; i < arrChar.Length; i++)
                {
                    Console.WriteLine($"|{temp.children[i].data}|");

                    q.Enqueue(temp.children[i]);
                }
                n++;

            }
        }
    }
}
