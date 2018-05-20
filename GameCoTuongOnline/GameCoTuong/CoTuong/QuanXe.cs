using GameCoTuong.ProgramConfig;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCoTuong.CoTuong
{
    public class QuanXe : QuanCo
    {
        public QuanXe() { }

        public QuanXe(Point toaDoBanDau)
        {
            toaDo = toaDoBanDau;
            danhSachDiemDich = new List<Point>();
            if (BanCo.mauPheTa == 2)
                mau = ThongSoPheDo.MauQuanCo(toaDoBanDau);
            else if (BanCo.mauPheTa == 1)
                mau = ThongSoPheXanh.MauQuanCo(toaDoBanDau);
            BanCo.alive.Add(this);
        }

        public override void TinhNuocDi()
        {
            Point toaDoMucTieu;
            QuanCo quanCoMucTieu;

            /* Xét nhánh các điểm đích BÊN TRÁI quân xe */
            for (int x = toaDo.X - 1; x >= 0; x--)
            {
                toaDoMucTieu = new Point(x, toaDo.Y);
                if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                    danhSachDiemDich.Add(toaDoMucTieu);
                else
                {
                    quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                    if (quanCoMucTieu.Mau != this.Mau)
                        danhSachDiemDich.Add(toaDoMucTieu);
                    break;
                }
            }

            /* Xét nhánh các điểm đích BÊN PHẢI quân xe */
            for (int x = toaDo.X + 1; x < 9; x++)
            {
                toaDoMucTieu = new Point(x, toaDo.Y);
                if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                    danhSachDiemDich.Add(toaDoMucTieu);
                else
                {
                    quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                    if (quanCoMucTieu.Mau != this.Mau)
                        danhSachDiemDich.Add(toaDoMucTieu);
                    break;
                }
            }

            /* Xét nhánh các điểm đích BÊN TRÊN quân xe */
            for (int y = toaDo.Y - 1; y >= 0; y--)
            {
                toaDoMucTieu = new Point(toaDo.X, y);
                if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                    danhSachDiemDich.Add(toaDoMucTieu);
                else
                {
                    quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                    if (quanCoMucTieu.Mau != this.Mau)
                        danhSachDiemDich.Add(toaDoMucTieu);
                    break;
                }
            }

            /* Xét nhánh các điểm đích BÊN DƯỚI quân xe */
            for (int y = toaDo.Y + 1; y < 10; y++)
            {
                toaDoMucTieu = new Point(toaDo.X, y);
                if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                    danhSachDiemDich.Add(toaDoMucTieu);
                else
                {
                    quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                    if (quanCoMucTieu.Mau != this.Mau)
                        danhSachDiemDich.Add(toaDoMucTieu);
                    break;
                }
            }
        }
    }
}