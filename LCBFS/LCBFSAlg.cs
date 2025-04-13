using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace LCBFS
{
    class LCBFSAlg
    {
        private Dothi dt;
        private Queue q; // Dùng Queue có sẵn trong .NET 4.5
        private int[] pre; // Lưu trữ đỉnh trước đỉnh i trong quá trình tìm kiếm
        private int[] g;   // Lưu chi phí đến đỉnh i từ đỉnh bắt đầu
        static readonly int NIL = -5;

        public LCBFSAlg() // Hàm khởi tạo
        {
            dt = new Dothi();
            q = new Queue();
            pre = new int[dt.Sodinh];
            g = new int[dt.Sodinh];

            for (int i = 0; i < dt.Sodinh; i++)
            {
                pre[i] = -2;
                g[i] = 0;
            }

            pre[dt.Start] = NIL;
            g[dt.Start] = 0;
            q.Enqueue(dt.Start);
        }

        public bool LCBFSsearch()
        {
            bool kq = false;

            while (q.Count > 0)
            {
                int u = (int)q.Dequeue();

                for (int v = 0; v < dt.Sodinh; v++)
                {
                    if (dt.Matran[u, v] > 0 && pre[v] == -2)
                    {
                        pre[v] = u;
                        g[v] = g[u] + dt.Matran[u, v];
                        q.Enqueue(v);

                        if (v == dt.Goal)
                        {
                            kq = true;
                            return true;
                        }
                    }
                }
            }

            return kq;
        }

        public void printDuongDi()
        {
            Stack stack = new Stack();
            int v = dt.Goal;

            while (v != NIL)
            {
                stack.Push(v);
                v = pre[v];
            }

            Console.Write("Duong di: ");
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop() + " ");
            }
            Console.WriteLine();
        }

        public void printG()
        {
            Console.WriteLine("Tong chi phi: = {0}", g[dt.Goal]);
        }
    }

}
