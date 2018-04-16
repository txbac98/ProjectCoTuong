using GameCoTuong.ProgramConfig;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCoTuong.CoTuong
{
    public class QuanCo
    {
        #region properties
        protected Point toaDo;
        public Point ToaDo
        {
            get { return toaDo; }
            set { toaDo = value; }
        }

        protected int mau; //xanh 1, do 2;
        public int Mau { get { return mau; } }

        protected List<Point> danhSachDiemDich;
        public List<Point> DanhSachDiemDich { get { return danhSachDiemDich; } }
        #endregion

        #region methods
        /* Cac phuong thuc chung */
        #region Code by Viet Anh
        public QuanCo() { }

        public QuanCo(int X, int Y)
        {
            toaDo = new Point(X, Y);
        }

        public QuanCo(Point toaDoBanDau)
        {
            if (toaDoBanDau == ThongSo.ToaDoNULL)
            {
                mau = 0;
            }
            toaDo = toaDoBanDau;
        }
        #endregion

        public virtual void TinhOCoTheDi(OCO[,] viTri) { } //Phuong thuc ao

        public virtual void TinhNuocDi() { }

        protected Point TinhNuoc(int dx, int dy)  //Tinh nuoc, ham chung
        {
            Point temp = new Point(-1, -1);
            temp.X = toaDo.X + dx;
            temp.Y = toaDo.Y + dy;
            return temp;
        }

        public void DiChuyen(Point diemDich)
        {
            toaDo = diemDich;
            danhSachDiemDich.Clear(); // xóa danh sách các đích đến cũ sau mỗi nước đi
        }

        #region Code by Viet Anh
        public bool Equals(QuanCo quanCoSoSanh)
        {
            return (this.ToaDo == quanCoSoSanh.ToaDo) && (this.Mau == quanCoSoSanh.Mau);
        }

        public void Move(Point destination)
        {
            BanCo.alive.Remove(BanCo.GetQuanCo(destination));
            toaDo = destination;
            danhSachDiemDich.Clear();
        }
        #endregion

        public void AddList(Point oTemp) // Thêm 1 điểm đích vào danh sách 'list0'
        {
            danhSachDiemDich.Add(oTemp);
        }

        public void ClearListO()
        {
            danhSachDiemDich.Clear();
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