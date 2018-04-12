using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCoTuong
{
    //Dung chung ben QuanCo
    public struct VITRI
    {
        float x, y;
    }
    public struct OCO //o co
    {
        public VITRI viTri;
        public int giaTri; //0 : k co co; 1: xanh, 2: do
    };


    public class BanCo
    {

        public OCO[,] viTri = new OCO[9, 10]; //tao mang o co


        public void KhoiTao( float x0, float y0, float khoangCach) //toa do goc 0, khoang cach cac o
        {
            //Dat vi tri, gia tri cua o
        }

       

        
    }
}
