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
        public override void TinhOCoTheDi(OCO[,] viTri)
        {
            Point oTemp = new Point(-1, -1);
            for (int i = 0; i < 9; i++)
            {
                if (i != toaDo.X)
                {
                    oTemp.X = i;
                    oTemp.Y = toaDo.Y;
                    AddList(oTemp);
                }
                for (int j = 0; j < 10; j++)
                {
                    if (j != toaDo.Y)
                    {
                        oTemp.X = toaDo.X;
                        oTemp.Y = j;
                        AddList(oTemp);
                    }
                }
            }
        }
    }
}