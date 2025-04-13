using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Collections;namespace BFS
{
    class BFSAlg
    {
        private Dothi dt;
        private Queue q; // SV tự cài đặt Hàng đợi để đáp ứng yêu cầu của bài toán
        // Hoặc SV có thể sử dụng Lớp Queue có sẵn trong dotNet;
        // Trong giải thuật là V
        private int[] pre; // Lưu trữ đỉnh trước đỉnh i trong quá trình tìm kiếm
        static readonly int NIL = -5;

        public BFSAlg() // Hàm khởi tạo BFS --
        {
            // Khởi tạo các giá trị cho dữ liệu thành viên của LCBFSAlg
            dt = new Dothi();
            q = new Queue();
            pre = new int[dt.Sodinh];

            for (int i = 0; i < dt.Sodinh; i++)  // Cho biết đỉnh i chưa được duyệt tới
            {
                pre[i] = -2;
            }

            // Từ dòng 2 -->4 của giải thuật
            pre[dt.Start] = NIL; // Đỉnh trước của đỉnh bắt đầu là NIL
            q.Enqueue(dt.Start); // Thêm đỉnh bắt đầu vào hàng đợi
        }

        public void BFSsearch()
        {
            bool kq = false;

            while (!q.Contains(dt.Goal) && q.Count > 0) // Dòng 5: tiếp tục nếu chưa tìm thấy Goal và hàng đợi chưa rỗng
            {
                int s = (int)q.Dequeue(); // lấy đỉnh s từ hàng đợi

                for (int t = 0; t < dt.Sodinh; t++) // Duyệt tất cả các đỉnh kề với s
                {
                    if (dt.Matran[s, t] != 0 && pre[t] == -2) // Nếu có cạnh s -> t và t chưa được thăm
                    {
                        pre[t] = s;     // Gán đỉnh trước của t là s
                        q.Enqueue(t);   // Đưa t vào hàng đợi Vk+1
                    }
                }
            }

        }

        public void printDuongdi()
        {
            if (pre[dt.Goal] == -2)
                Console.WriteLine("KHONG tim duoc duong di ");
            else
            {
                int curr = dt.Goal;
                while (curr != dt.Start)
                {
                    Console.Write("{0}<= ", curr);
                    curr = pre[curr];
                }
                Console.Write("{0} ", dt.Start);
            }
        }




    }
}
