using GameCoTuong.ProgramConfig;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCoTuong.CoTuong
{
    class QuanTinh : QuanCo
    {
        #region Code by Viet Anh
        public QuanTinh() { }
        public QuanTinh(Point toaDoBanDau)
        {
            toaDo = toaDoBanDau;
            danhSachDiemDich = new List<Point>();
            mau = ThongSo.MauQuanCo(toaDoBanDau);
            BanCo.alive.Add(this);
        }

        public override void TinhNuocDi()
        {
            // do something
        }
        #endregion

        public override void TinhOCoTheDi(OCO[,] viTri)
        {
            Point oTemp = new Point(-1, -1);

            //Xet o chan (1,1)
            if (XetToaDo(1, 1))
            {
                if (XetToaDo(toaDo.X + 2, toaDo.Y + 2)) //2 2
                {
                    if (viTri[toaDo.X + 2, toaDo.Y + 2].giaTri != mau)
                    {
                        oTemp = TinhNuoc(2, 2);
                        AddList(oTemp);
                    }
                }
            }
            if (XetToaDo(-1, -1))
            {
                if (XetToaDo(toaDo.X - 2, toaDo.Y - 2)) //-2 -2
                {

                    oTemp = TinhNuoc(-2, -2);

                    AddList(oTemp);
                }
            }
            if (XetToaDo(-1, 1))
            {
                if (XetToaDo(toaDo.X - 2, toaDo.Y + 2)) //-2 2
                {
                    if (viTri[toaDo.X - 2, toaDo.Y + 2].giaTri != mau)
                    {
                        oTemp = TinhNuoc(-2, +2);

                        AddList(oTemp);
                    }
                }
            }
            if (XetToaDo(1, -1))
            {
                if (XetToaDo(toaDo.X + 2, toaDo.Y - 2)) //2 -2
                {
                    if (viTri[toaDo.X + 2, toaDo.Y - 2].giaTri != mau)
                    {
                        oTemp = TinhNuoc(2, -2);

                        AddList(oTemp);
                    }
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

            if (mau == 2) //Do
            {
                if (toaDo.Y < 5) return false; // Qua song
            }
            else if (mau == 1) //Xanh
            {
                if (toaDo.Y > 4) return false;  //Qua xong
            }
            return true;
        }
    }
}