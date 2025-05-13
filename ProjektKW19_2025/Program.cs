
using System;

namespace WorldsWorstGamedev
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "World’s Worst Gamedev: Das Debug-Abenteuer";
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            GameManager.Start();
        }
    }
}
