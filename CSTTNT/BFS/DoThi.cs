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
        }
        public void readDothi(String path)  //Đọc file từ ổ đĩa
        {
            string textFile = path; //Thay đổi đường dẫn phù hợp với ứng dụng của bạn
            if (File.Exists(textFile))
            {
                // Đọc tập tin dữ liệu theo từng dòng
                // Mỗi dòng lưu vào mảng lines[]
                string[] lines = File.ReadAllLines(textFile);
                string line0 = lines[0].Trim(); // Dòng thứ nhất cho biết số đỉnh
                this.n = Convert.ToInt16(line0); // Chuyển kiểu dữ liệu. Sử dụng Parse nếu bạn không thích sử dụng Convert

                string line1 = lines[1].Trim();
                string[] tam = line1.Split(' ');
                this.start = Convert.ToInt16(tam[0]); // Dòng thứ 2 cho biết đỉnh Start và Goal
                this.goal = Convert.ToInt16(tam[1]);

                for (int i = 0; i < this.n; i++)
                { // Dòng thứ 3 trở về sau cho biết ma trận kề
                    string linei = lines[i + 2].Trim();
                    string[] arr1 = linei.Split(' ');
                    for (int j = 0; j < this.n; j++)
                    {
                        this.arr[i, j] = Convert.ToInt32(arr1[j]);
                        //Console.Write(matran[i,j] + " ");
                    }
                    //Console.WriteLine();
                }
            }
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
        // This function return a list of path with minumun fee 
        public List<int> BFS()
        {
            Queue<int> queue = new Queue<int>();
            Dictionary<int, int> previous = new Dictionary<int, int>();
            // path will return 
            List<int> solution = new List<int>();
            List<int> V_current = new List<int> { start };

            // init pre of start is NIL = -1
            previous[start] = -1;
            int k = 0;

            while (!V_current.Contains(goal) && V_current.Count > 0)
            {
                List<int> V_next = new List<int>();

                foreach (int s in V_current)
                {
                    for (int sPrime = 0; sPrime < n; sPrime++)
                    {
                        if (arr[s, sPrime] != 0 && !previous.ContainsKey(sPrime))
                        {
                            previous[sPrime] = s;
                            V_next.Add(sPrime);
                        }
                    }
                }

                V_current = V_next;
                k++;
            }

            if (V_current.Count == 0)
            {
                Console.WriteLine("FAILURE");
                return null;
            }
            else
            {
                int state = goal;
                while (state != -1)
                {
                    solution.Insert(0, state);
                    state = previous[state];
                }
            }

            return solution;
        }
    }
}
