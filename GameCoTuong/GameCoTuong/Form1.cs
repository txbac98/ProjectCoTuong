using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GameCoTuong
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        struct oCo
        {
            public Point viTri;
            public bool tonTai;
        }
        oCo[,] o = new oCo[9,10];

        private void Form1_Load(object sender, EventArgs e)
        {
            SetViTri();

            //Test
            ChessMan quanCo = new ChessMan();
            quanCo.x = 4;
            quanCo.y = 4;
            quanCo.mau = "Xanh";
            quanCo.loai = "Ma";


            quanCo.TinhOCoTheDi();

            List<Button> bt = new List<Button>();
            foreach (Point i in quanCo.listO)
            {
                MessageBox.Show(i.X.ToString(), i.Y.ToString());
               // // Khai báo một Button mới
               // Button bte = new Button();

               // //Cài đặt thuộc tính cho button
               // bte = button2;
               // bte.Location = o[i.X,i.Y].viTri;
               // bte.Tag = i;
               // //Tạo sự kiện cho button
               // bte.Click += new EventHandler(Buttons_Click);

               //this.Controls.Add(bte);

            }
          

        }
    
        private void Buttons_Click(object sender, EventArgs e)
        {
            //Lấy id đã lưu ở bt.tag
            //int id = (int)((Button)sender).Tag;
            //Hiển thị thông tin khi nhấn nút tương ứng
            //MessageBox.Show("Bạn vừa nhấn nút " + id.ToString());

        }
        public Point[] a = new Point[10];

        void SetViTri()
        {

            int khoangCach=50;

            int xGoc, yGoc;

            xGoc = 45;
            yGoc = 45;
            
            for (int _y=0;_y < 10; _y++)
            {
                for (int _x=0; _x<9; _x++)
                {
                    o[_x, _y].tonTai = false;
                    //Set Y
                    if (_y == 0) o[_x, _y].viTri.Y = yGoc;
                    else
                    {
                        o[_x, _y].viTri.Y = o[_x, _y - 1].viTri.Y + khoangCach;
                    }

                    //Set X
                    if (_x == 0)
                    {
                        o[_x, _y].viTri.X = xGoc;                  
                    }
                    else
                    {
                            o[_x, _y].viTri.X = o[_x - 1, _y].viTri.X + khoangCach;  
                    }
                }
            }

        }



       
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ptbBanCo_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
