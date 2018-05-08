using GameCoTuong.ProgramConfig;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCoTuong.CoTuong
{
    public class QuanMa : QuanCo
    {
        public QuanMa() { }

        public QuanMa(Point toaDoBanDau)
        {
            toaDo = toaDoBanDau;
            danhSachDiemDich = new List<Point>();
            mau = PheDo.MauQuanCo(toaDoBanDau);
            BanCo.alive.Add(this);
        }
        
        public override void TinhNuocDi()
        {
            Point diemCan;
            Point toaDoMucTieu;
            QuanCo quanCoMucTieu;

            // Xét điểm cản (toaDo.X - 1, toaDo.Y)
            diemCan = new Point(toaDo.X - 1, toaDo.Y);
            if (NamTrongBanCo(diemCan) && !BanCo.CoQuanCoTaiDay(diemCan))
            {
                toaDoMucTieu = new Point(toaDo.X - 2, toaDo.Y - 1);
                if (NamTrongBanCo(toaDoMucTieu))
                {
                    if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                    {
                        danhSachDiemDich.Add(toaDoMucTieu);
                    }
                    else
                    {
                        quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                        if (quanCoMucTieu.Mau != this.Mau)
                        {
                            danhSachDiemDich.Add(toaDoMucTieu);
                        }
                    }
                }
                toaDoMucTieu = new Point(toaDo.X - 2, toaDo.Y + 1);
                if (NamTrongBanCo(toaDoMucTieu))
                {
                    if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                    {
                        danhSachDiemDich.Add(toaDoMucTieu);
                    }
                    else
                    {
                        quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                        if (quanCoMucTieu.Mau != this.Mau)
                        {
                            danhSachDiemDich.Add(toaDoMucTieu);
                        }
                    }
                }
            }

            // Xét điểm cản (toaDo.X + 1, toaDo.Y)
            diemCan = new Point(toaDo.X + 1, toaDo.Y);
            if (NamTrongBanCo(diemCan) && !BanCo.CoQuanCoTaiDay(diemCan))
            {
                toaDoMucTieu = new Point(toaDo.X + 2, toaDo.Y - 1);
                if (NamTrongBanCo(toaDoMucTieu))
                {
                    if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                    {
                        danhSachDiemDich.Add(toaDoMucTieu);
                    }
                    else
                    {
                        quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                        if (quanCoMucTieu.Mau != this.Mau)
                        {
                            danhSachDiemDich.Add(toaDoMucTieu);
                        }
                    }
                }
                toaDoMucTieu = new Point(toaDo.X + 2, toaDo.Y + 1);
                if (NamTrongBanCo(toaDoMucTieu))
                {
                    if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                    {
                        danhSachDiemDich.Add(toaDoMucTieu);
                    }
                    else
                    {
                        quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                        if (quanCoMucTieu.Mau != this.Mau)
                        {
                            danhSachDiemDich.Add(toaDoMucTieu);
                        }
                    }
                }
            }

            // Xét điểm cản (toaDo.X, toaDo.Y - 1)
            diemCan = new Point(toaDo.X, toaDo.Y - 1);
            if (NamTrongBanCo(diemCan) && !BanCo.CoQuanCoTaiDay(diemCan))
            {
                toaDoMucTieu = new Point(toaDo.X - 1, toaDo.Y - 2);
                if (NamTrongBanCo(toaDoMucTieu))
                {
                    if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                    {
                        danhSachDiemDich.Add(toaDoMucTieu);
                    }
                    else
                    {
                        quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                        if (quanCoMucTieu.Mau != this.Mau)
                        {
                            danhSachDiemDich.Add(toaDoMucTieu);
                        }
                    }
                }
                toaDoMucTieu = new Point(toaDo.X + 1, toaDo.Y - 2);
                if (NamTrongBanCo(toaDoMucTieu))
                {
                    if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                    {
                        danhSachDiemDich.Add(toaDoMucTieu);
                    }
                    else
                    {
                        quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                        if (quanCoMucTieu.Mau != this.Mau)
                        {
                            danhSachDiemDich.Add(toaDoMucTieu);
                        }
                    }
                }
            }

            // Xét điểm cản (toaDo.X, toaDo.Y + 1)
            diemCan = new Point(toaDo.X, toaDo.Y + 1);
            if (NamTrongBanCo(diemCan) && !BanCo.CoQuanCoTaiDay(diemCan))
            {
                toaDoMucTieu = new Point(toaDo.X - 1, toaDo.Y + 2);
                if (NamTrongBanCo(toaDoMucTieu))
                {
                    if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                    {
                        danhSachDiemDich.Add(toaDoMucTieu);
                    }
                    else
                    {
                        quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                        if (quanCoMucTieu.Mau != this.Mau)
                        {
                            danhSachDiemDich.Add(toaDoMucTieu);
                        }
                    }
                }
                toaDoMucTieu = new Point(toaDo.X + 1, toaDo.Y + 2);
                if (NamTrongBanCo(toaDoMucTieu))
                {
                    if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                    {
                        danhSachDiemDich.Add(toaDoMucTieu);
                    }
                    else
                    {
                        quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                        if (quanCoMucTieu.Mau != this.Mau)
                        {
                            danhSachDiemDich.Add(toaDoMucTieu);
                        }
                    }
                }
            }
        }
    }
}