using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCoTuong.CoTuong
{
        //Dung chung ben QuanCo
    public struct VITRI
    {
        float x, y;
    }
    public struct OCO //o co
    {
        public VITRI ToaDo;
        public int giaTri; //0 : k co co; 1: xanh, 2: do
    };


    public class BanCo
    {

        public OCO[,] viTri = new OCO[9, 10]; //tao mang o co


        public void KhoiTao( float x0, float y0, float khoangCach) //toa do goc 0, khoang cach cac o
        {
            //Dat vi tri, gia tri cua o
        }

        public void CapNhat(Point toaDoTruoc, Point toaDoSau)  //Goi ham luc di chuyen
        {
            viTri[toaDoSau.X, toaDoSau.Y].giaTri = viTri[toaDoTruoc.X, toaDoTruoc.Y].giaTri;
            viTri[toaDoTruoc.X, toaDoTruoc.Y].giaTri = 0;
        }

        
    }
}