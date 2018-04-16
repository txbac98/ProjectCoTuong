using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GameCoTuong.ProgramConfig;

namespace GameCoTuong.CoTuong
{
    class QuanSi : QuanCo
    {
        #region Code by Viet Anh
        public QuanSi() { }
        public QuanSi(Point toaDoBanDau)
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

            if (mau == 1)
            {
                if (toaDo == new Point(3, 0) || toaDo == new Point(5, 0) || toaDo == new Point(3, 2) || toaDo == new Point(5, 2))
                {
                    toaDoMucTieu = new Point(4, 1);
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
                else if (toaDo == new Point(4, 1))
                {
                    toaDoMucTieu = new Point(3, 0);
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

                    toaDoMucTieu = new Point(5, 0);
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

                    toaDoMucTieu = new Point(3, 2);
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

                    toaDoMucTieu = new Point(5, 2);
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
            else if (mau == 2)
            {
                if (toaDo == new Point(3, 9) || toaDo == new Point(5, 9) || toaDo == new Point(3, 7) || toaDo == new Point(5, 7))
                {
                    toaDoMucTieu = new Point(4, 8);
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
                else if (toaDo == new Point(4, 8))
                {
                    toaDoMucTieu = new Point(3, 9);//
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

                    toaDoMucTieu = new Point(5, 9);//
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

                    toaDoMucTieu = new Point(3, 7);//
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

                    toaDoMucTieu = new Point(5, 7);//
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
        #endregion

        public override void TinhOCoTheDi(OCO[,] viTri)
        {
            Point oTemp = new Point(-1, -1);
            if (XetToaDo(toaDo.X + 1, toaDo.Y + 1))
            //Kiem tra có tồn tại không
            {
                if (viTri[toaDo.X + 1, toaDo.Y + 1].giaTri != mau)
                // Kiểm tra xem có khác màu không, nếu khác màu là ô trống hoặc đối phương
                {

                    oTemp = TinhNuoc(1, 1);
                    AddList(oTemp);

                }
            }
            if (XetToaDo(toaDo.X + 1, toaDo.Y - 1))
            {
                if (viTri[toaDo.X + 1, toaDo.Y - 1].giaTri != mau)
                // Kiểm tra xem có khác màu không, nếu khác màu là ô trống hoặc đối phương
                {

                    oTemp = TinhNuoc(1, -1);
                    AddList(oTemp);
                }
            }
            if (XetToaDo(toaDo.X - 1, toaDo.Y + 1))
            {
                if (viTri[toaDo.X - 1, toaDo.Y + 1].giaTri != mau)
                // Kiểm tra xem có khác màu không, nếu khác màu là ô trống hoặc đối phương
                {

                    oTemp = TinhNuoc(-1, +1);
                    AddList(oTemp);
                }
            }
            if (XetToaDo(toaDo.X - 1, toaDo.Y - 1))
            {
                if (viTri[toaDo.X - 1, toaDo.Y - 1].giaTri != mau)
                // Kiểm tra xem có khác màu không, nếu khác màu là ô trống hoặc đối phương
                {
                    oTemp = TinhNuoc(-1, -1);
                    AddList(oTemp);
                }
            }
        }

        public override bool XetToaDo(int X, int Y)
        {
            //Chung
            if (X < 0 || X > 8)
            {
                return false;
            }
            if (Y < 0 || Y > 9)
            {
                return false;
            }

            if (mau == 2)
            {
                if (toaDo.X >= 3 && toaDo.X <= 5 && toaDo.Y >= 7 && toaDo.Y <= 9) // Sy mau do nam trong o
                    return true;
            }
            else if (mau == 1)
            {
                if ((toaDo.X >= 3 && toaDo.X <= 5 && toaDo.Y >= 0 && toaDo.Y <= 2)) // Sy mau xanh nam trong o
                    return true;
            }
            return false;
        }
    }
}