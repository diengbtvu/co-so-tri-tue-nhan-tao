using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCBFS
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Test đọc dữ liệu từ file
            Dothi dt = new Dothi();
            dt.printDothi();

            // 2. Test Thực thi giải thuật LCBFS

             LCBFSAlg alg = new LCBFSAlg();
             alg.LCBFSsearch();
             System.Console.WriteLine("In duong di: ");
             alg.printDuongDi();
             alg.printG();
            System.Console.ReadLine();

        }
    }
}
