using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS
{
    class Program
    {
        static void Main(string[] args)
        {
            BFS b = new BFS();
            b.run();
            Console.WriteLine("Press any key to close program!");
            Console.ReadKey();
        }
    }
}