using System;
using System.Collections.Generic;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<string> BSTflowers = new BinarySearchTree<string>("sunflower");
            BSTflowers.AddNode("daisy");
            BSTflowers.AddNode("poppy");
            BSTflowers.AddNode("rose");
            BSTflowers.AddNode("lily");
            BSTflowers.AddNode("tulip");
            BSTflowers.AddNode("orchid");
            BSTflowers.AddNode("peonies");
            BSTflowers.AddNode("marigold");
            BSTflowers.AddNode("buttercup");
            BSTflowers.AddNode("chrysanthemum");
            BSTflowers.AddNode("iris");
            PrintList(BSTflowers.InOrder("sunflower"));
            BSTflowers.Remove("marigold");
            BSTflowers.Contains("marigold");
            BSTflowers.Contains("iris");
            BSTflowers.Remove("iris");
            PrintList(BSTflowers.InOrder("lily"));
            Console.Read();
        }

        static void PrintList(List<string> list)
        {
            foreach(string item in list)
            {
                Console.WriteLine(item);
            }
        }
        static void PrintList(List<int> list)
        {
            foreach (int item in list)
            {
                Console.WriteLine(item);
            }
        }
        static void PrintList(List<float> list)
        {
            foreach (float item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
