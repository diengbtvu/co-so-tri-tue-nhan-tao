using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS
{
    class BFS
    {
        DoThi G = new DoThi();

       public void init()
        {
            G.readFile(@"D:\co-so-tri-tue-nhan-tao\CSTTNT\BFS\input.txt");
            Console.WriteLine("Graph:");
            G.printMatrix();
            List<int> ans =  G.BFS_MinimumFee();
            if (ans != null)
            {
                Console.WriteLine("Path with minimum fee: " + string.Join(" -> ", ans));
            }
            else
            {
                Console.WriteLine("No path found.");
            }
        }
      
    }
}
