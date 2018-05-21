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

        public Point ToaDo { get; protected set; }

        public int Mau { get; protected set; } // xanh 1, đỏ 2;

        public List<Point> DanhSachDiemDich { get; protected set; }

        #endregion

        #region methods

        public QuanCo() { }

        public QuanCo(int X, int Y)
        {
            ToaDo = new Point(X, Y);
        }

        public QuanCo(Point toaDoBanDau)
        {
            if (toaDoBanDau == ThongSo.ToaDoNULL)
                Mau = 0;
            ToaDo = toaDoBanDau;
        }

        public bool Equals(QuanCo quanCoSoSanh)
        {
            return (this.ToaDo == quanCoSoSanh.ToaDo) && (this.Mau == quanCoSoSanh.Mau);
        }

        public virtual void TinhNuocDi() { }

        public void MoveTo(Point location)
        {
            ToaDo = location;
            DanhSachDiemDich.Clear();
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