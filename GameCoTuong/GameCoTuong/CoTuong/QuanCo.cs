using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace GameCoTuong
{


    public class QuanCo: BanCo
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
            viTri[toaDo.X, toaDo.Y].giaTri = 0; //o cu trong => 0
            viTri[oMoi.X, oMoi.Y].giaTri = mau; //o moi co con moi
        }

        public void AddList(Point oTemp, List<Point> a) // Thêm 1 điểm đích vào danh sách 'list0'
        {
            if (XetToaDo(oTemp.X,oTemp.Y))
            if (viTri[oTemp.X, oTemp.Y].giaTri != mau) //khac mau: => o trong hoac doi phuong
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
