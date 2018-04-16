using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GameCoTuong.ProgramConfig;

namespace GameCoTuong.CoTuong
{
    class QuanTuong : QuanCo
    {
        #region Code by Viet Anh

        public QuanTuong() { }

        public QuanTuong(Point toaDoBanDau)
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
            if (XetToaDo(toaDo.X + 1, toaDo.Y))  //+1 0
            {
                if (viTri[toaDo.X + 1, toaDo.Y].giaTri == 0)  //Khong bi chan
                {
                    oTemp = TinhNuoc(1, 0);
                    AddList(oTemp);
                }
            }
            if (XetToaDo(toaDo.X - 1, toaDo.Y))  //+1 0
            {
                if (viTri[toaDo.X - 1, toaDo.Y].giaTri == 0)  //Khong bi chan
                {
                    oTemp = TinhNuoc(-1, 0);
                    AddList(oTemp);
                }
            }
            if (XetToaDo(toaDo.X, toaDo.Y + 1))  //+1 0
            {
                if (viTri[toaDo.X, toaDo.Y + 1].giaTri == 0)  //Khong bi chan
                {
                    oTemp = TinhNuoc(0, 1);
                    AddList(oTemp);
                }
            }
            if (XetToaDo(toaDo.X, toaDo.Y - 1))  //+1 0
            {
                if (viTri[toaDo.X, toaDo.Y - 1].giaTri == 0)  //Khong bi chan
                {
                    oTemp = TinhNuoc(0, -1);
                    AddList(oTemp);
                }
            }
        }

        public override bool XetToaDo(int X, int Y)
        {
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