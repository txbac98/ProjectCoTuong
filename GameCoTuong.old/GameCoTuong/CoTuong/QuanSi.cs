using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GameCoTuong.ProgramConfig;

namespace GameCoTuong.CoTuong
{
    class QuanSi : QuanCo
    {
        #region Code by Viet Anh
        public QuanSi() { }
        public QuanSi(Point toaDoBanDau)
        {
            toaDo = toaDoBanDau;
            danhSachDiemDich = new List<Point>();
            mau = ThongSo.MauQuanCo(toaDoBanDau);
            BanCo.alive.Add(this);
        }
        #endregion

        public override void TinhNuocDi()
        {
            
        }

        public override void TinhOCoTheDi(OCO[,] viTri)
        {
            Point oTemp = new Point(-1, -1);
            if (XetToaDo(toaDo.X + 1, toaDo.Y + 1))
            //Kiem tra có tồn tại không
            {
                if (viTri[toaDo.X + 1, toaDo.Y + 1].giaTri != mau)
                // Kiểm tra xem có khác màu không, nếu khác màu là ô trống hoặc đối phương
                {

                    oTemp = TinhNuoc(1, 1);
                    AddList(oTemp);

                }
            }
            if (XetToaDo(toaDo.X + 1, toaDo.Y - 1))
            {
                if (viTri[toaDo.X + 1, toaDo.Y - 1].giaTri != mau)
                // Kiểm tra xem có khác màu không, nếu khác màu là ô trống hoặc đối phương
                {

                    oTemp = TinhNuoc(1, -1);
                    AddList(oTemp);
                }
            }
            if (XetToaDo(toaDo.X - 1, toaDo.Y + 1))
            {
                if (viTri[toaDo.X - 1, toaDo.Y + 1].giaTri != mau)
                // Kiểm tra xem có khác màu không, nếu khác màu là ô trống hoặc đối phương
                {

                    oTemp = TinhNuoc(-1, +1);
                    AddList(oTemp);
                }
            }
            if (XetToaDo(toaDo.X - 1, toaDo.Y - 1))
            {
                if (viTri[toaDo.X - 1, toaDo.Y - 1].giaTri != mau)
                // Kiểm tra xem có khác màu không, nếu khác màu là ô trống hoặc đối phương
                {
                    oTemp = TinhNuoc(-1, -1);
                    AddList(oTemp);
                }
            }
        }

        public override bool XetToaDo(int X, int Y)
        {
            //Chung
            if (X < 0 || X > 8)
            {
                return false;
            }
            if (Y < 0 || Y > 9)
            {
                return false;
            }

            if (mau == 2)
            {
                if (toaDo.X >= 3 && toaDo.X <= 5 && toaDo.Y >= 7 && toaDo.Y <= 9) // Sy mau do nam trong o
                    return true;
            }
            else if (mau == 1)
            {
                if ((toaDo.X >= 3 && toaDo.X <= 5 && toaDo.Y >= 0 && toaDo.Y <= 2)) // Sy mau xanh nam trong o
                    return true;
            }
            return false;
        }
    }
}