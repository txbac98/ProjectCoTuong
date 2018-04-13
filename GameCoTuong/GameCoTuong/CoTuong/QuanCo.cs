using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace GameCoTuong.CoTuong
{
    public class QuanCo
    {
        #region properties
        public Point toaDo;
        public int mau; //xanh 1, do 2;
        public List<Point> listO;
        #endregion

        #region methods
        /* Cac phuong thuc chung */

        public QuanCo() // default constructor - moi khi khoi tao 1 the hien cua lop QuanCo dung lenh: QuanCo qc = new QuanCo();
        {
            listO = new List<Point>();
        }

        public virtual void TinhOCoTheDi(OCO[,] viTri) { } //Phuong thuc ao

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
            listO.Clear(); //clear list O
        }

        public void AddList(Point oTemp) // Thêm 1 điểm đích vào danh sách 'list0'
        {
            listO.Add(oTemp);
        }

        public void ClearListO()
        {
            listO.Clear();
        }

        public virtual bool XetToaDo(int X, int Y)
        {
            //Xet co nam trong ban co hay k

            if (X < 0 || X > 8)
            {
                return false;
            }
            if (Y < 0 || Y > 9)
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}