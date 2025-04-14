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
        private Queue q; // Dùng Queue 
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
                pre[i] = -2; // Chưa được thăm
                g[i] = 0; // Khởi tạo chi phí ban đầu là o
            }

            pre[dt.Start] = NIL;
            g[dt.Start] = 0;
            q.Enqueue(dt.Start);
        }

        public bool LCBFSsearch()
        {
            bool goal = false;
            int k = 0;

            while (q.Count > 0)
            {
                // Xử lý tất cả các trạng thái ở mức k hiện tại
                int v_size = q.Count;      
                for (int i = 0; i < v_size; i++)
                {
                    int s = (int)q.Dequeue();            
                    // Duyệt tất cả các trạng thái kề 
                    for (int s1 = 0; s1 < dt.Sodinh; s1++)
                    {
                        // Kiểm tra xem có đường đi từ s đến s1 không
                        if (dt.Matran[s, s1] > 0)
                        {
                            // Chi phí
                            int cp = g[s] + dt.Matran[s, s1];
                            // Nếu s1 chưa được gán nhãn HAY nếu g(s) + Cost(s,s1) < g(s1)
                            if (pre[s1] == -2 || cp < g[s1])
                            {
                                // Đặt previous(s1) := s
                                pre[s1] = s;
                                // Đặt g(s1) := g(s) + Cost(s,s1)
                                g[s1] = cp;
                                // Thêm s1 vào Vk+1 nếu chưa nằm trong queue
                                bool trongHangDoi = false;
                                foreach (int it in q)
                                {
                                    if (it == s1)
                                    {
                                        trongHangDoi = true;
                                        break;
                                    }
                                }                         
                                if (!trongHangDoi)
                                {
                                    q.Enqueue(s1);
                                }
                                // Kiểm tra nếu tìm thấy đích
                                if (s1 == dt.Goal)
                                {
                                    goal = true;
                                    // Không return ngay để tìm được đường đi tối ưu
                                }
                            }
                        }
                    }
                }
                k++; // Tăng k
            }
            return goal;
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
            Console.Write("\nDuong di: ");
            while (stack.Count > 1)
            {
                Console.Write(stack.Pop() + " -> ");
            }
            Console.Write(stack.Pop());
           Console.WriteLine();
        }

        public void printG()
        {
            Console.WriteLine("Tong chi phi: = {0}", g[dt.Goal]);
        }
    }

}
