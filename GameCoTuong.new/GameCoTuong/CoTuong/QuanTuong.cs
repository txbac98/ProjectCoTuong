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
            QuanCo quanCoMucTieu;
            Point toaDoMucTieu;

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
        #endregion
        public bool NamTrongCung(Point point)
        {
            if (this.mau == 1)
                if ((point.X >= 3 && point.X <= 5 && point.Y >= 0 && point.Y <= 2))
                    return true;
            if (this.mau == 2)
                if (point.X >= 3 && point.X <= 5 && point.Y >= 7 && point.Y <= 9)
                    return true;
            return false;
        }
    }
}