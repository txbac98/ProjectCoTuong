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
        public void TinhOCoTheDi()
        {
            Point oTemp = new Point(-1, -1);

            if (XetToaDo(toaDo.X+1, toaDo.Y +0))  //+1 0
            {
                if (viTri[toaDo.X + 1, toaDo.Y].giaTri == 0)  //Khong bi chan
                {
                    oTemp = TinhNuoc(2, 1); //+2 +1
                    AddList(oTemp, listO);

                    oTemp = TinhNuoc(2, -1); //+2 -1

                    AddList(oTemp, listO);
                }
            }
            if (XetToaDo(toaDo.X + 0, toaDo.Y + 1)) // 0 1
            {
                if (viTri[toaDo.X + 0, toaDo.Y+1].giaTri == 0)  //Khong bi chan
                {
                    oTemp = TinhNuoc(1, 2); //+1 +2

                    AddList(oTemp, listO);

                    oTemp = TinhNuoc(-1, 2); //-1 +2

                    AddList(oTemp, listO);
                }
            }
            if (XetToaDo(toaDo.X -1, toaDo.Y +0))  //-1 0
            {
                if (viTri[toaDo.X -1, toaDo.Y + 0].giaTri == 0)  //Khong bi chan
                {
                    oTemp = TinhNuoc(-2, 1); //-2 +1

                    AddList(oTemp, listO);

                    oTemp = TinhNuoc(-2, -1); //-2 -1

                    AddList(oTemp, listO);
                }
            }
            if (XetToaDo(toaDo.X +0, toaDo.Y -1))  //0 -1
            {
                if (viTri[toaDo.X +0, toaDo.Y -1].giaTri == 0)  //Khong bi chan
                {
                    oTemp = TinhNuoc(1, -2); //+1 -2

                    AddList(oTemp, listO);

                    oTemp = TinhNuoc(-1, -2); //-1 -2

                    AddList(oTemp, listO);
                }
            }
            return;
        }
        
        
    
    }
}
