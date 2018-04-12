using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCoTuong
{
    public class QuanMa : QuanCo
    {
        public override void TinhOCoTheDi(OCO[,] viTri)
        {
            Point oTemp = new Point(-1, -1);
            OCO oCo = new OCO();
            if (XetToaDo(toaDo.X+1, toaDo.Y +0))  //+1 0
            {
                if (viTri[toaDo.X + 1, toaDo.Y].giaTri == 0)  //Khong bi chan
                {
                    
                    if (XetToaDo(toaDo.X + 2, toaDo.Y + 1))
                    {
                        oTemp = TinhNuoc(2, 1); //+2 +1
                        
                        oCo = viTri[toaDo.X + 2, toaDo.Y + 1];

                        AddList(oTemp, oCo);
                    }

                    if (XetToaDo(toaDo.X + 2, toaDo.Y - 1))
                    {
                        oTemp = TinhNuoc(2, -1); //+2 -1

                        oCo = viTri[toaDo.X + 2, toaDo.Y - 1];

                        AddList(oTemp, oCo);
                    }
                    
                }
            }
            if (XetToaDo(toaDo.X + 0, toaDo.Y + 1)) // 0 1
            {
                if (viTri[toaDo.X + 0, toaDo.Y+1].giaTri == 0)  //Khong bi chan
                {
                    if (XetToaDo(toaDo.X + 1, toaDo.Y + 2))
                    {
                        oTemp = TinhNuoc(1, 2); //+1 +2

                        oCo = viTri[toaDo.X + 1, toaDo.Y + 2];

                        AddList(oTemp, oCo);
                    }

                    if (XetToaDo(toaDo.X -1, toaDo.Y + 2))
                    {
                        oTemp = TinhNuoc(-1, 2); //-1 +2

                        oCo = viTri[toaDo.X -1, toaDo.Y + 2];

                        AddList(oTemp, oCo);
                    }
                }
            }
            if (XetToaDo(toaDo.X -1, toaDo.Y +0))  //-1 0
            {
                if (viTri[toaDo.X -1, toaDo.Y + 0].giaTri == 0)  //Khong bi chan
                {
                    if (XetToaDo(toaDo.X - 2, toaDo.Y + 1))
                    {
                        oTemp = TinhNuoc(-2, 1); //-2 +1

                        oCo = viTri[toaDo.X - 2, toaDo.Y + 1];

                        AddList(oTemp, oCo);
                    }

                    if (XetToaDo(toaDo.X - 2, toaDo.Y - 1))
                    {
                        oTemp = TinhNuoc(-2, -1); //-2 -1

                        oCo = viTri[toaDo.X - 2, toaDo.Y - 1];

                        AddList(oTemp, oCo);
                    }
    
                }
            }
            if (XetToaDo(toaDo.X +0, toaDo.Y -1))  //0 -1
            {
                if (viTri[toaDo.X +0, toaDo.Y -1].giaTri == 0)  //Khong bi chan
                {
                    if (XetToaDo(toaDo.X + 1, toaDo.Y -2))
                    {
                        oTemp = TinhNuoc(1,-2); //+1 -2

                        oCo = viTri[toaDo.X + 1, toaDo.Y -2];

                        AddList(oTemp, oCo);
                    }

                    if (XetToaDo(toaDo.X -1, toaDo.Y -2))
                    {
                        oTemp = TinhNuoc(-1, -2); //-1 -2

                        oCo = viTri[toaDo.X -1, toaDo.Y -2];

                        AddList(oTemp, oCo);
                    }             
                }
            }
            return;
        }
        
        
    
    }
}
