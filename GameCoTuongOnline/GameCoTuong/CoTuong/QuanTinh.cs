using GameCoTuong.ProgramConfig;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCoTuong.CoTuong
{
    public class QuanTinh : QuanCo
    {
        public QuanTinh() { }

        public QuanTinh(Point toaDoBanDau)
        {
            toaDo = toaDoBanDau;
            danhSachDiemDich = new List<Point>();
            if (BanCo.MauPheTa == 2)
                mau = ThongSoPheDo.MauQuanCo(toaDoBanDau);
            else if (BanCo.MauPheTa == 1)
                mau = ThongSoPheXanh.MauQuanCo(toaDoBanDau);
            BanCo.Alive_QuanCo.Add(this);
        }

        public override void TinhNuocDi()
        {

            Point diemCan;
            Point toaDoMucTieu;
            QuanCo quanCoMucTieu;

            // Xét điểm cản (toaDo.X - 1, toaDo.Y - 1)
            diemCan = new Point(toaDo.X - 1, toaDo.Y - 1);
            if (NamTrongNuaBanCo(diemCan) && !BanCo.CoQuanCoTaiDay(diemCan))
            {
                toaDoMucTieu = new Point(toaDo.X - 2, toaDo.Y - 2);
                if (NamTrongNuaBanCo(toaDoMucTieu))
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

            // Xét điểm cản (toaDo.X - 1, toaDo.Y + 1)
            diemCan = new Point(toaDo.X - 1, toaDo.Y + 1);
            if (NamTrongNuaBanCo(diemCan) && !BanCo.CoQuanCoTaiDay(diemCan))
            {
                toaDoMucTieu = new Point(toaDo.X - 2, toaDo.Y + 2);
                if (NamTrongNuaBanCo(toaDoMucTieu))
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

            // Xét điểm cản (toaDo.X + 1, toaDo.Y - 1)
            diemCan = new Point(toaDo.X + 1, toaDo.Y - 1);
            if (NamTrongNuaBanCo(diemCan) && !BanCo.CoQuanCoTaiDay(diemCan))
            {
                toaDoMucTieu = new Point(toaDo.X + 2, toaDo.Y - 2);
                if (NamTrongNuaBanCo(toaDoMucTieu))
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

            // Xét điểm cản (toaDo.X + 1, toaDo.Y + 1)
            diemCan = new Point(toaDo.X + 1, toaDo.Y + 1);
            if (NamTrongNuaBanCo(diemCan) && !BanCo.CoQuanCoTaiDay(diemCan))
            {
                toaDoMucTieu = new Point(toaDo.X + 2, toaDo.Y + 2);
                if (NamTrongNuaBanCo(toaDoMucTieu))
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

        private bool NamTrongNuaBanCo(Point diem)
        {
            if (diem.X < 0 || diem.X > 8)
                return false;
            if (BanCo.MauPheTa == 2)
            {
                if (this.Mau == 1)
                {
                    if (diem.Y < 0 || diem.Y > 4)
                        return false;
                }
                else if (this.Mau == 2)
                {
                    if (diem.Y < 5 || diem.Y > 9)
                        return false;
                }
            }
            else if (BanCo.MauPheTa == 1)
            {
                if (this.Mau == 2)
                {
                    if (diem.Y < 0 || diem.Y > 4)
                        return false;
                }
                else if (this.Mau == 1)
                {
                    if (diem.Y < 5 || diem.Y > 9)
                        return false;
                }
            }
            return true;
        }
    }
}