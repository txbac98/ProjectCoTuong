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

            /* Xét nhánh các điểm đích BÊN TRÁI quân pháo */
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

            /* Xét nhánh các điểm đích BÊN PHẢI quân pháo */
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

            /* Xét nhánh các điểm đích BÊN TRÊN quân pháo */
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

            /* Xét nhánh các điểm đích BÊN DƯỚI quân pháo */
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
    }
}