using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace testDijkstra2
{
    class Program
    {
        public static void testGraphA()
        {
            node first = new node("1", 0);
            graphtest g = new graphtest(first);
            node node2 = new node("2", 3);
            node node3 = new node("3", 2);
            node node4 = new node("4", 1);
            node node5 = new node("5", 2);
            node node6 = new node("6", 2);
            node node7 = new node("7", 3);
            node node8 = new node("8", 10);
            node node9 = new node("9", 4);
            node node10 = new node("10 ", 2);
            node last = new node("last", 7);

            first.addfriend(node2);
            first.addfriend(node3);
            first.addfriend(node4);

            node2.addfriend(node6);
            node2.addfriend(first);

            node3.addfriend(first);
            node3.addfriend(node4);
            node3.addfriend(node7);

            node4.addfriend(first);
            node4.addfriend(node3);
            node4.addfriend(node7);
            node4.addfriend(node5);

            node6.addfriend(node2);
            node6.addfriend(node7);


            node7.addfriend(node3);
            node7.addfriend(node4);
            node7.addfriend(node5);
            node7.addfriend(node6);
            node7.addfriend(node8);
            node7.addfriend(node9);


            node5.addfriend(node4);
            node5.addfriend(node7);
            node5.addfriend(node8);

            node8.addfriend(node5);
            node8.addfriend(node7);
            node8.addfriend(node10);

            node9.addfriend(node10);
            node9.addfriend(node7);

            node10.addfriend(node9);
            node10.addfriend(node8);
            node10.addfriend(last);

            last.addfriend(node10);
            List<node> ans = new List<node>();
            ans.Add(first);
            ans.Add(node4);
            ans.Add(node7);
            ans.Add(node9);
            ans.Add(node10);
            ans.Add(last);
            List<node> path = Dijekstra.GetPath<node>(g, first, last);
            Console.WriteLine("path from algo");
            String pathAns = "";
            foreach (node item in path)
            {
                Console.Write(item.getname() + " ");
                pathAns += item.getname() + " ";
            }
            Console.WriteLine();
            Console.WriteLine("path that should be");
            String realAns = "";
            foreach (node item in ans)
            {
                Console.Write(item.getname() + " ");
                realAns += item.getname() + " ";
            }
            Console.WriteLine();
            Debug.Assert(realAns == pathAns);
        }


        public static void testGraphB()
        {
            node first = new node("1", 0);
            graphtest g = new graphtest(first);
            node node2 = new node("2", 3);
            node node3 = new node("3", 2);
            node node4 = new node("4", 1);
            node node5 = new node("5", 2);
            node node6 = new node("6", 2);
            node node7 = new node("7", 3);
            node node8 = new node("8", 3);
            node node9 = new node("9", 4);
            node node10 = new node("10 ", 2);
            node last = new node("last", 7);

            first.addfriend(node2);
            first.addfriend(node3);
            first.addfriend(node4);

            node2.addfriend(node6);
            node2.addfriend(first);

            node3.addfriend(first);
            node3.addfriend(node4);
            node3.addfriend(node7);

            node4.addfriend(first);
            node4.addfriend(node3);
            node4.addfriend(node7);
            node4.addfriend(node5);

            node6.addfriend(node2);
            node6.addfriend(node7);


            node7.addfriend(node3);
            node7.addfriend(node4);
            node7.addfriend(node5);
            node7.addfriend(node6);
            node7.addfriend(node8);
            node7.addfriend(node9);


            node5.addfriend(node4);
            node5.addfriend(node7);
            node5.addfriend(node8);

            node8.addfriend(node5);
            node8.addfriend(node7);
            node8.addfriend(node10);

            node9.addfriend(node10);
            node9.addfriend(node7);

            node10.addfriend(node9);
            node10.addfriend(node8);
            node10.addfriend(last);

            last.addfriend(node10);
            List<node> ans = new List<node>();
            ans.Add(first);
            ans.Add(node4);
            ans.Add(node5);
            ans.Add(node8);
            ans.Add(node10);
            ans.Add(last);
            List<node> path = Dijekstra.GetPath<node>(g, first, last);
            Console.WriteLine("path from algo");
            String pathAns = "";
            foreach (node item in path)
            {
                Console.Write(item.getname() + " ");
                pathAns += item.getname() + " ";
            }
            Console.WriteLine();
            Console.WriteLine("path that should be");
            String realAns = "";
            foreach (node item in ans)
            {
                Console.Write(item.getname() + " ");
                realAns += item.getname() + " ";
            }
            Console.WriteLine();
            Debug.Assert(realAns == pathAns);
        }


        public static void testGraphNoRoute()
        {
            node first = new node("1", 0);
            graphtest g = new graphtest(first);
            node node2 = new node("2", 3);
            node node3 = new node("3", 2);
            node node4 = new node("4", 1);
            node node5 = new node("5", 2);
            node node6 = new node("6", 2);
            node node7 = new node("7", 3);
            node node8 = new node("8", 3);
            node node9 = new node("9", 4);
            node node10 = new node("10 ", 2);
            node last = new node("last", 7);

            first.addfriend(node2);
            first.addfriend(node3);
            first.addfriend(node4);

            node2.addfriend(node6);
            node2.addfriend(first);

            node3.addfriend(first);
            node3.addfriend(node4);
            node3.addfriend(node7);

            node4.addfriend(first);
            node4.addfriend(node3);
            node4.addfriend(node7);
            node4.addfriend(node5);

            node6.addfriend(node2);
            node6.addfriend(node7);


            node7.addfriend(node3);
            node7.addfriend(node4);
            node7.addfriend(node5);
            node7.addfriend(node6);
            node7.addfriend(node8);
            node7.addfriend(node9);


            node5.addfriend(node4);
            node5.addfriend(node7);
            node5.addfriend(node8);

            node8.addfriend(node5);
            node8.addfriend(node7);
            node8.addfriend(node10);

            node9.addfriend(node10);
            node9.addfriend(node7);

            node10.addfriend(node9);
            node10.addfriend(node8);
            //node10.addfriend(last);

            last.addfriend(node10);
            List<node> ans = new List<node>();
            List<node> path = Dijekstra.GetPath<node>(g, first, last);
            Console.WriteLine("path from algo");
            String pathAns = "";
            foreach (node item in path)
            {
                Console.Write(item.getname() + " ");
                pathAns += item.getname() + " ";
            }
            Console.WriteLine();
            Console.WriteLine("path that should be");
            String realAns = "";
            foreach (node item in ans)
            {
                Console.Write(item.getname() + " ");
                realAns += item.getname() + " ";
            }
            Console.WriteLine();
            Debug.Assert(realAns == pathAns);
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Graph A");
            testGraphA();
            Console.WriteLine("-------------");
            Console.WriteLine("Graph B");
            testGraphB();
            Console.WriteLine("-------------");
            Console.WriteLine("Graph C empty");
            testGraphNoRoute();
        }
    }
}
