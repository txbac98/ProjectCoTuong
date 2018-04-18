using GameCoTuong.ProgramConfig;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCoTuong.CoTuong
{
    public class QuanTot : QuanCo
    {
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
            Point toaDoMucTieu = new Point(-1, -1);
            QuanCo quanCoMucTieu;

            if (Mau == 1)
                toaDoMucTieu = new Point(toaDo.X, toaDo.Y + 1);
            else if (Mau == 2)
                toaDoMucTieu = new Point(toaDo.X, toaDo.Y - 1);

            if (NamTrongBanCo(toaDoMucTieu))
            {
                if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                    danhSachDiemDich.Add(toaDoMucTieu);
                else
                {
                    quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                    if (quanCoMucTieu.Mau != this.Mau)
                        danhSachDiemDich.Add(toaDoMucTieu);
                }
            }
            if (QuaSong())
            {
                if (Mau == 1)
                {
                    if (NamTrongBanCo(toaDoMucTieu))
                    {
                        toaDoMucTieu = new Point(toaDo.X, toaDo.Y + 1);
                        if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                            danhSachDiemDich.Add(toaDoMucTieu);
                        else
                        {
                            quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                                danhSachDiemDich.Add(toaDoMucTieu);
                        }
                    }
                }
                if (Mau == 2)
                {
                    toaDoMucTieu = new Point(toaDo.X, toaDo.Y - 1);
                    if (NamTrongBanCo(toaDoMucTieu))
                    {
                        if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                            danhSachDiemDich.Add(toaDoMucTieu);
                        else
                        {
                            quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                                danhSachDiemDich.Add(toaDoMucTieu);
                        }
                    }
                }
                toaDoMucTieu = new Point(toaDo.X - 1, toaDo.Y);
                if (NamTrongBanCo(toaDoMucTieu))
                {
                    if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                        danhSachDiemDich.Add(toaDoMucTieu);
                    else
                    {
                        quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                        if (quanCoMucTieu.Mau != this.Mau)
                            danhSachDiemDich.Add(toaDoMucTieu);
                    }
                }
                toaDoMucTieu = new Point(toaDo.X + 1, toaDo.Y);
                if (NamTrongBanCo(toaDoMucTieu))
                {
                    if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                        danhSachDiemDich.Add(toaDoMucTieu);
                    else
                    {
                        quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                        if (quanCoMucTieu.Mau != this.Mau)
                            danhSachDiemDich.Add(toaDoMucTieu);
                    }
                }
            }
        }

        private bool QuaSong()
        {
            if (Mau == 1) //xanh
            {
                if (toaDo.Y > 4) return true;
            }
            else if (Mau == 2) //Do
            {
                if (toaDo.Y < 5) return true;
            }
            return false;
        }
    }
}