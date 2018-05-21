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
        #region attributes

        protected Point toaDo;
        public Point ToaDo
        {
            get { return toaDo; }
            set { toaDo = value; }
        }

        protected int mau; //xanh 1, do 2;
        public int Mau { get { return mau; } }

        public List<Point> danhSachDiemDich;

        #endregion

        #region methods

        public QuanCo() { }

        public QuanCo(int X, int Y)
        {
            toaDo = new Point(X, Y);
        }

        public QuanCo(Point toaDoBanDau)
        {
            if (toaDoBanDau == ThongSo.ToaDoNULL)
                mau = 0;
            toaDo = toaDoBanDau;
        }

        public bool Equals(QuanCo quanCoSoSanh)
        {
            return (this.ToaDo == quanCoSoSanh.ToaDo) && (this.Mau == quanCoSoSanh.Mau);
        }

        public virtual void TinhNuocDi() { }

        public void MoveTo(Point location)
        {
            toaDo = location;
            danhSachDiemDich.Clear();
        }

        public bool NamTrongBanCo(int X, int Y)
        {
            if (X < 0 || X > 8 || Y < 0 || Y > 9)
                return false;
            return true;
        }

        public bool NamTrongBanCo(Point diem)
        {
            return NamTrongBanCo(diem.X, diem.Y);
        }

        #endregion
    }
}