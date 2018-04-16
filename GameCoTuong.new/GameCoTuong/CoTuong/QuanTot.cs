using GameCoTuong.ProgramConfig;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCoTuong.CoTuong
{
    class QuanTot : QuanCo
    {
        #region Code by Viet Anh
        public QuanTot() { }
        public QuanTot(Point toaDoBanDau)
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
            if (mau == 1) //Xanh
            {
                if (XetToaDo(toaDo.X, toaDo.Y + 1)) //0,1
                {
                    if (viTri[toaDo.X, toaDo.Y + 1].giaTri != mau)
                    {
                        oTemp = TinhNuoc(0, 1);
                        AddList(oTemp);
                    }
                }
                if (QuaXong())
                {
                    if (XetToaDo(toaDo.X + 1, toaDo.Y))
                    {
                        if (viTri[toaDo.X + 1, toaDo.Y].giaTri != mau)
                        {
                            oTemp = TinhNuoc(1, 0);
                            AddList(oTemp);
                        }
                    }
                    if (XetToaDo(toaDo.X - 1, toaDo.Y))
                    {
                        if (viTri[toaDo.X - 1, toaDo.Y].giaTri != mau)
                        {
                            oTemp = TinhNuoc(-1, 0);
                            AddList(oTemp);
                        }
                    }
                }
            }
            else if (mau == 2) //Do
            {
                if (XetToaDo(toaDo.X, toaDo.Y - 1)) //0,-1
                {
                    if (viTri[toaDo.X, toaDo.Y - 1].giaTri != mau)
                    {
                        oTemp = TinhNuoc(0, -1);
                        AddList(oTemp);
                    }
                }
                if (QuaXong())
                {
                    if (XetToaDo(toaDo.X + 1, toaDo.Y))
                    {
                        if (viTri[toaDo.X + 1, toaDo.Y].giaTri != mau)
                        {
                            oTemp = TinhNuoc(1, 0);
                            AddList(oTemp);
                        }
                    }
                    if (XetToaDo(toaDo.X - 1, toaDo.Y))
                    {
                        if (viTri[toaDo.X - 1, toaDo.Y].giaTri != mau)
                        {
                            oTemp = TinhNuoc(-1, 0);
                            AddList(oTemp);
                        }
                    }
                }
            }

        }

        bool QuaXong()
        {
            if (mau == 1) //xanh
            {
                if (toaDo.Y > 4) return true;
            }
            else if (mau == 2) //Do
            {
                if (toaDo.Y < 5) return true;
            }
            return false;
        }
    }
}