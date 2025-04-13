using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LCBFS
{
    class Dothi
    {
        private int sodinh;   // Số đỉnh của đồ thị

        public int Sodinh
        {
            get { return sodinh; }
            set { sodinh = value; }
        }
        private int start;    // Đỉnh bắt đầu

        public int Start
        {
            get { return start; }
            set { start = value; }
        }
        private int goal;     // Đỉnh kết thúc

        public int Goal
        {
            get { return goal; }
            set { goal = value; }
        }
        private int[,] matran; // Ma trận trọng số

        public int[,] Matran
        {
            get { return matran; }
            set { matran = value; }
        }

        public Dothi()
        {
            this.sodinh = -1;
            this.start = -1;
            this.matran = new int[12, 12]; // Có thể sử dụng 1 hàng nào đó nếu bạn muốn
            readDothi(); // Gọi phương thức đọc file .txt
        }

        public void readDothi() // Đọc file từ ổ đĩa
        {
            string textFile = @"c:\users\nguyen hoang\documents\visual studio 2013\Projects\co-so-tri-tue-nhan-tao\LCBFS\LCBFSinput.txt"; // Thay đổi đường dẫn phù hợp với ứng dụng của bạn
            if (File.Exists(textFile))
            {
                // Đọc tập tin dữ liệu theo từng dòng
                // Mỗi dòng lưu vào mảng lines[]
                string[] lines = File.ReadAllLines(textFile);
                string line0 = lines[0].Trim(); // Dòng thứ nhất cho biết số đỉnh
                this.Sodinh = Convert.ToInt16(line0); // Chuyển kiểu dữ liệu. SD Parse nếu bạn không thích sd convert

                string line1 = lines[1].Trim();
                string[] tam = line1.Split(' ');
                this.Start = Convert.ToInt16(tam[0]); // Dòng thứ 2 cho biết đỉnh Start và Goal
                this.Goal = Convert.ToInt16(tam[1]);

                for (int i = 0; i < this.Sodinh; i++) // Dòng thứ 3 trở về sau cho biết ma trận kề
                {
                    string linei = lines[i + 2].Trim();
                    // Console.WriteLine(linei);
                    string[] arr = linei.Split(' ');
                    for (int j = 0; j < this.Sodinh; j++)
                    {
                        Console.WriteLine(arr[j]);
                        this.Matran[i, j] = Convert.ToInt32(arr[j]);
                        // Console.Write(matran[i, j] + " ");
                    }
                    // Console.WriteLine();
                }
            }
        }
        public void printDothi() // Hiển thị nội dung đã đọc or nội dung của đồ thị
        {
            System.Console.WriteLine("So dinh: {0}", Sodinh);
            System.Console.WriteLine("Start: {0} Goal: {1}", Start, Goal);
            for (int i = 0; i < this.Sodinh; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < this.Sodinh; j++)
                    Console.Write(this.Matran[i, j] + " ");
            }
        }


    }
}
