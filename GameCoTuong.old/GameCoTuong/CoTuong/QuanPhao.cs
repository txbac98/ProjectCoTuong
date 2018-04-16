using GameCoTuong.ProgramConfig;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCoTuong.CoTuong
{
    class QuanPhao : QuanCo
    {
        #region Code by Viet Anh
        public QuanPhao() { }
        public QuanPhao(Point toaDoBanDau)
        {
            toaDo = toaDoBanDau;
            danhSachDiemDich = new List<Point>();
            mau = ThongSo.MauQuanCo(toaDoBanDau);
            BanCo.alive.Add(this);
        }
        public override void TinhNuocDi()
        {
            Point toaDoMucTieu;
            QuanCo quanCoMucTieu;

            /* Đi qua phía Đông */
            for (int x = toaDo.X - 1; x >= 0; x--)
            {
                toaDoMucTieu = new Point(x, toaDo.Y);
                if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                    danhSachDiemDich.Add(toaDoMucTieu);
                else
                {
                    for (x -= 1; x >= 0; x--)
                    {
                        toaDoMucTieu = new Point(x, toaDo.Y);
                        if (BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                        {
                            quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                                danhSachDiemDich.Add(toaDoMucTieu);
                            break;
                        }
                    }
                    break;
                }
            }

            /* Đi sang phía Tây */
            for (int x = toaDo.X + 1; x < 9; x++)
            {
                toaDoMucTieu = new Point(x, toaDo.Y);
                if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                    danhSachDiemDich.Add(toaDoMucTieu);
                else
                {
                    for (x += 1; x < 9; x++)
                    {
                        toaDoMucTieu = new Point(x, toaDo.Y);
                        if (BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                        {
                            quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                                danhSachDiemDich.Add(toaDoMucTieu);
                            break;
                        }
                    }
                    break;
                }
            }

            /* Đi lên phía Bắc */
            for (int y = toaDo.Y - 1; y >= 0; y--)
            {
                toaDoMucTieu = new Point(toaDo.X, y);
                if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                    danhSachDiemDich.Add(toaDoMucTieu);
                else
                {
                    for (y -= 1; y >= 0; y--)
                    {
                        toaDoMucTieu = new Point(toaDo.X, y);
                        if (BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                        {
                            quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                                danhSachDiemDich.Add(toaDoMucTieu);
                            break;
                        }
                    }
                    break;
                }
            }

            /* Đi xuống phía Nam */
            for (int y = toaDo.Y + 1; y < 10; y++)
            {
                toaDoMucTieu = new Point(toaDo.X, y);
                if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                    danhSachDiemDich.Add(toaDoMucTieu);
                else
                {
                    for (y += 1; y < 10; y++)
                    {
                        toaDoMucTieu = new Point(toaDo.X, y);
                        if (BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                        {
                            quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                                danhSachDiemDich.Add(toaDoMucTieu);
                            break;
                        }
                    }
                    break;
                }
            }
        }
        #endregion

        public override void TinhOCoTheDi(OCO[,] viTri)
        {
            Point oTemp = new Point(-1, -1);
            for (int i = 0; i < 9; i++)
            {
                if (i != toaDo.X)
                {
                    oTemp.X = i;
                    oTemp.Y = toaDo.Y;
                    AddList(oTemp);
                }
                for (int j = 0; j < 10; j++)
                {
                    if (j != toaDo.Y)
                    {
                        oTemp.X = toaDo.X;
                        oTemp.Y = j;
                        AddList(oTemp);
                    }
                }
            }
        }
    }
}