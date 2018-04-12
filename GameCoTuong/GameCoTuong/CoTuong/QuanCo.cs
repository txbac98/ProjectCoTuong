using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace GameCoTuong
{


    public class QuanCo
    {
        /* Bien*/
        public Point toaDo;
        public int mau; //xanh 1, do 2;
        public List<Point> listO = new List<Point>();



        /* Các phương thức chung */
       

        protected Point TinhNuoc(int dx, int dy)  //Tinh nuoc, ham chung
        {
            Point temp = new Point(-1, -1);
            temp.X = toaDo.X + dx;
            temp.Y = toaDo.Y + dy;
            return temp;
        }

        public void DiChuyen(Point oMoi)
        {
            toaDo.X = oMoi.X;
            toaDo.Y = oMoi.Y;

            
        }

        public void AddList(Point oTemp, OCO oCo) // Thêm 1 điểm đích vào danh sách 'list0'
        {
            if (oCo.giaTri != mau) //khac mau: => o trong hoac doi phuong
            {
                listO.Add(oTemp);
            }
        }

        public void ClearListO()
        {
            listO.Clear();
        }

        public bool XetToaDo(int X, int Y)
        {
            //Xet co nam trong ban co hay k

            if (X<0 || X > 8)
            {
                return false;
            }
            if (Y < 0 || Y > 9)
            {
                return false;
            }

            return true;
        }

    }
}
