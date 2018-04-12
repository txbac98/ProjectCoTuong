using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameCoTuong.CoTuong
{
    class QuanSy : QuanCo
    {
        public override void TinhOCoTheDi(OCO[,] viTri)
        {
            Point oTemp = new Point(-1, -1);
            OCO oCo = new OCO();

            if (viTri[toaDo.X + 1, toaDo.Y + 1].giaTri != mau) 
            // Kiểm tra xem có khác màu không, nếu khác màu là ô trống hoặc đối phương
            {
                if (XetToaDo(toaDo.X + 1, toaDo.Y + 1))
                {
                    oTemp = TinhNuoc(1, 1);
                    oCo = viTri[toaDo.X + 1, toaDo.Y + 1];
                    AddList(oTemp, oCo);
                }
            }
            if (viTri[toaDo.X + 1, toaDo.Y - 1].giaTri != mau)
            // Kiểm tra xem có khác màu không, nếu khác màu là ô trống hoặc đối phương
            {
                if (XetToaDo(toaDo.X + 1, toaDo.Y - 1))
                {
                    oTemp = TinhNuoc(1, -1);
                    oCo = viTri[toaDo.X + 1, toaDo.Y - 1];
                    AddList(oTemp, oCo);
                }
            }
            if (viTri[toaDo.X - 1, toaDo.Y + 1].giaTri != mau)
            // Kiểm tra xem có khác màu không, nếu khác màu là ô trống hoặc đối phương
            {
                if (XetToaDo(toaDo.X - 1, toaDo.Y + 1))
                {
                    oTemp = TinhNuoc(-1, +1);
                    oCo = viTri[toaDo.X - 1, toaDo.Y + 1];
                    AddList(oTemp, oCo);
                }
            }
            if (viTri[toaDo.X - 1, toaDo.Y - 1].giaTri != mau)
            // Kiểm tra xem có khác màu không, nếu khác màu là ô trống hoặc đối phương
            {
                if (XetToaDo(toaDo.X - 1, toaDo.Y - 1))
                {
                    oTemp = TinhNuoc(-1, -1);
                    oCo = viTri[toaDo.X - 1, toaDo.Y - 1];
                    AddList(oTemp, oCo);
                }
            }
        }
        public override bool XetToaDo(int X, int Y)
        {
            if (mau == 2)
            {
                if (toaDo.X >= 3 && toaDo.X <= 5 && toaDo.Y >= 7 && toaDo.Y <= 9) // Sy mau do nam trong o
                    return true;
            }
            else if(mau == 1)
            {
                if ((toaDo.X >= 3 && toaDo.X <= 5 && toaDo.Y >= 0 && toaDo.Y <= 2)) // Sy mau xanh nam trong o
                    return true;
            }
            return false;
        }
    }
}
