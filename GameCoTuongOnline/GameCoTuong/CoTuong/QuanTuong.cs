using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GameCoTuong.ProgramConfig;

namespace GameCoTuong.CoTuong
{
    public class QuanTuong : QuanCo
    {
        public QuanTuong() { }

        public QuanTuong(Point toaDoBanDau)
        {
            toaDo = toaDoBanDau;
            danhSachDiemDich = new List<Point>();
            if (BanCo.mauPheTa == 2)
                mau = ThongSoPheDo.MauQuanCo(toaDoBanDau);
            else if (BanCo.mauPheTa == 1)
                mau = ThongSoPheXanh.MauQuanCo(toaDoBanDau);
            BanCo.alive_QuanCo.Add(this);
            if (Mau == 1)
                BanCo.tuongXanh = this;
            else if (Mau == 2)
                BanCo.tuongDo = this;
        }

        public override void TinhNuocDi()
        {
            Point toaDoMucTieu;
            QuanCo quanCoMucTieu;

            toaDoMucTieu = new Point(toaDo.X + 1, toaDo.Y);
            if (NamTrongCung(toaDoMucTieu))
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

            toaDoMucTieu = new Point(toaDo.X - 1, toaDo.Y);
            if (NamTrongCung(toaDoMucTieu))
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

            toaDoMucTieu = new Point(toaDo.X, toaDo.Y + 1);
            if (NamTrongCung(toaDoMucTieu))
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

            toaDoMucTieu = new Point(toaDo.X, toaDo.Y - 1);
            if (NamTrongCung(toaDoMucTieu))
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

        private bool NamTrongCung(Point point)
        {
            if (BanCo.mauPheTa == 2)
            {
                if (Mau == 1)
                    if ((point.X >= 3 && point.X <= 5 && point.Y >= 0 && point.Y <= 2))
                        return true;
                if (Mau == 2)
                    if (point.X >= 3 && point.X <= 5 && point.Y >= 7 && point.Y <= 9)
                        return true;
            }
            else if (BanCo.mauPheTa == 1)
            {
                if (Mau == 2)
                    if ((point.X >= 3 && point.X <= 5 && point.Y >= 0 && point.Y <= 2))
                        return true;
                if (Mau == 1)
                    if (point.X >= 3 && point.X <= 5 && point.Y >= 7 && point.Y <= 9)
                        return true;
            }
            return false;
        }
    }
}