using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCoTuong.CoTuong
{
    public class QuanMa : QuanCo
    {
        public override void TinhOCoTheDi(OCO[,] viTri)
        {
            Point oTemp = new Point(-1, -1);
            //Xet o chan (1,0)
            if (XetToaDo(toaDo.X + 1, toaDo.Y + 0))  //+1 0
            {
                if (viTri[toaDo.X + 1, toaDo.Y].giaTri == 0)  //Khong bi chan
                {

                    if (XetToaDo(toaDo.X + 2, toaDo.Y + 1)) //+2 +1
                    {
                        if (viTri[toaDo.X + 2, toaDo.Y + 1].giaTri != mau)
                        {
                            oTemp = TinhNuoc(2, 1);
                            AddList(oTemp);
                        }

                    }

                    if (XetToaDo(toaDo.X + 2, toaDo.Y - 1)) //+2 -1
                    {

                        if (viTri[toaDo.X + 2, toaDo.Y - 1].giaTri != mau)
                        {
                            oTemp = TinhNuoc(2, -1);
                            AddList(oTemp);
                        }

                    }

                }
            }
            //Xet o chan (0,1)
            if (XetToaDo(toaDo.X + 0, toaDo.Y + 1)) // 0 1
            {
                if (viTri[toaDo.X + 0, toaDo.Y + 1].giaTri == 0)  //Khong bi chan
                {

                    if (XetToaDo(toaDo.X + 1, toaDo.Y + 2)) //+1 +2
                    {
                        if (viTri[toaDo.X + 1, toaDo.Y + 2].giaTri != mau)
                        {
                            oTemp = TinhNuoc(1, 2);
                            AddList(oTemp);
                        }
                    }


                    if (XetToaDo(toaDo.X - 1, toaDo.Y + 2))  //-1 +2
                    {
                        if (viTri[toaDo.X - 1, toaDo.Y + 2].giaTri != mau)
                        {
                            oTemp = TinhNuoc(-1, 2);
                            AddList(oTemp);
                        }

                    }
                }
            }
            //Xet o chan (-1,0)
            if (XetToaDo(toaDo.X - 1, toaDo.Y + 0))  //-1 0
            {
                if (viTri[toaDo.X - 1, toaDo.Y + 0].giaTri == 0)  //Khong bi chan
                {

                    if (XetToaDo(toaDo.X - 2, toaDo.Y + 1)) //-2 +1
                    {
                        if (viTri[toaDo.X - 2, toaDo.Y + 1].giaTri != mau)
                        {
                            oTemp = TinhNuoc(-2, 1);

                            AddList(oTemp);
                        }

                    }

                    if (XetToaDo(toaDo.X - 2, toaDo.Y - 1)) //-2 -1
                    {
                        if (viTri[toaDo.X - 2, toaDo.Y - 1].giaTri != mau)
                        {
                            oTemp = TinhNuoc(-2, -1);

                            AddList(oTemp);
                        }

                    }

                }
            }
            //Xet o chan (0,-1)
            if (XetToaDo(toaDo.X + 0, toaDo.Y - 1))  //0 -1
            {
                if (viTri[toaDo.X + 0, toaDo.Y - 1].giaTri == 0)  //Khong bi chan
                {

                    if (XetToaDo(toaDo.X + 1, toaDo.Y - 2))  //+1 -2
                    {
                        if (viTri[toaDo.X + 1, toaDo.Y - 2].giaTri != mau)
                        {
                            oTemp = TinhNuoc(1, -2);

                            AddList(oTemp);
                        }

                    }

                    if (XetToaDo(toaDo.X - 1, toaDo.Y - 2))   //-1 -2
                    {
                        if (viTri[toaDo.X - 1, toaDo.Y - 2].giaTri != mau)
                        {
                            oTemp = TinhNuoc(-1, -2);

                            AddList(oTemp);
                        }

                    }
                }
            }
            return;
        }
    }
}