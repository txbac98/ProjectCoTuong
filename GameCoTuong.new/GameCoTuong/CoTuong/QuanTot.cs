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
            QuanCo quanCoMucTieu;
            Point toaDoMucTieu = new Point(-1, -1);

            if (mau == 1)
                toaDoMucTieu = new Point(toaDo.X, toaDo.Y + 1);
            else if (mau == 2)
                toaDoMucTieu = new Point(toaDo.X, toaDo.Y - 1);

            if (KiemTraToaDo(toaDoMucTieu))
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

                if (mau == 1)
                {
                    if (KiemTraToaDo(toaDoMucTieu))
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
                if (mau == 2)
                {
                    if (KiemTraToaDo(toaDoMucTieu))
                    {
                        toaDoMucTieu = new Point(toaDo.X, toaDo.Y - 1);
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
                if (KiemTraToaDo(toaDoMucTieu))
                {
                    toaDoMucTieu = new Point(toaDo.X - 1, toaDo.Y);
                    if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                        danhSachDiemDich.Add(toaDoMucTieu);
                    else
                    {
                        quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                        if (quanCoMucTieu.Mau != this.Mau)
                            danhSachDiemDich.Add(toaDoMucTieu);
                    }
                }
                if (KiemTraToaDo(toaDoMucTieu))
                {
                    toaDoMucTieu = new Point(toaDo.X + 1, toaDo.Y);
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

        #endregion
        bool KiemTraToaDo(Point point)
        {
            if (point.X < 0 || point.X > 8 || point.Y < 0 || point.Y > 9)
                return false;
            return true;
        }       
        bool QuaSong()
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