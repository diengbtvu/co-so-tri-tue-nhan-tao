using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BFS
{
    class DoThi
    {
        public int n=-999;
        public int start=-999;
        public int goal=-999;
        public int[,] arr;

        public DoThi()
        {
//            this.readFile(@"D:\co-so-tri-tue-nhan-tao\CSTTNT\BFS\input.txt");
      
        }


        public void readFile(String path)
        {
            string[] lines = File.ReadAllLines(path);
            if (lines.Length > 0)
            {
                // The first line contains the number of vertices
                n = int.Parse(lines[0].Trim());

                // Initialize the adjacency matrix
                arr = new int[n, n];

                // The second line contains the start and goal nodes
                string[] startGoal = lines[1].Trim().Split(' ');
                start = int.Parse(startGoal[0].Trim());
                goal = int.Parse(startGoal[1].Trim());

                // The remaining lines contain the adjacency matrix
                for (int i = 2; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < parts.Length; j++)
                    {
                        if (!int.TryParse(parts[j].Trim(), out arr[i - 2, j]))
                        {
                            throw new FormatException($"Invalid integer value at line {i + 1}, column {j + 1}");
                        }
                    }
                }
            }
        }


        public void printMatrix()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }



    }
}
