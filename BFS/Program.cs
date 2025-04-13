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
            // 1. Test đọc dữ liệu từ file
            Dothi dt = new Dothi();
            dt.readDothi();
            dt.printDothi();

            // 2. Test Kết quả của BFS
            BFSAlg bFS = new BFSAlg();
            bFS.BFSsearch();
            Console.WriteLine("\nPath: ");
            bFS.printDuongdi();

            Console.ReadLine();

        }
    }
}
