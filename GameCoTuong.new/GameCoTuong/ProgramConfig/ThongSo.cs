using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCoTuong.ProgramConfig
{
    public static class ThongSo
    {
        /*
        Class này chứa tất cả thông số về bàn cờ tướng, điểm bàn cờ, quân cờ và các hàm tính toán cần thiết.
        Chú thích:
        - Tọa độ đơn vị (TDDV) là tọa độ của bàn cờ tướng đơn vị trong đó các đường thẳng song song cách nhau 1 đơn vị.
        - Tọa độ bàn cờ (TDBC) là tọa độ của bàn cờ thực sự trên WinForm.
        - Gốc tọa độ trên bàn cờ của điểm bàn cờ và quân cờ KHÔNG trùng nhau, do đó TDBC của chúng cũng khác nhau. Nhưng chúng lại dùng chung TDDV.
        */

        #region Gốc tọa độ bàn cờ
        private static int gocDiemBanCoX = 44; // hoành độ gốc của điểm bàn cờ trên bàn cờ (góc trên bên trái)
        public static int GocDiemBanCoX { get { return gocDiemBanCoX; } }

        private static int gocDiemBanCoY = 42; // tung độ gốc của điểm bàn cờ trên bàn cờ (góc trên bên trái)
        public static int GocDiemBanCoY { get { return gocDiemBanCoY; } }

        private static int gocQuanCoX = 31; // hoành độ gốc của quân cờ trên bàn cờ (góc trên bên trái)
        public static int GocQuanCoX { get { return gocQuanCoX; } }

        private static int gocQuanCoY = 30; // tung độ gốc của quân cờ trên bàn cờ (góc trên bên trái)
        public static int GocQuanCoY { get { return gocQuanCoY; } }
        #endregion

        #region Khoảng cách
        private static int khoangCach = 61; // khoảng cách giữa các điểm bàn cờ & quân cờ
        public static int KhoangCach { get { return khoangCach; } }
        #endregion

        #region Kích thước quân cờ, điểm bàn cờ và bàn cờ
        /* Quân cờ (hình tròn) */
        private static int duongKinhQuanCo = 60; // đường kính của 1 quân cờ
        public static int DuongKinhQuanCo { get { return duongKinhQuanCo; } }

        /* Điểm bàn cờ (hình tròn) */
        private static int duongKinhDiem = 30; // đường kính của 1 điểm bàn cờ
        public static int DuongKinhDiem { get { return duongKinhDiem; } }

        /* Bàn cờ */
        private static Point toaDoBanCo = new Point(0, 0); // tọa độ của bàn cờ trong WinForm
        public static Point ToaDoBanCo { get { return toaDoBanCo; } }

        private static int chieuRongBanCo = 607; // chiều rộng của bàn cờ
        public static int ChieuRongBanCo { get { return chieuRongBanCo; } }

        private static int chieuCaoBanCo = 662; // chiều cao của bàn cờ
        public static int ChieuCaoBanCo { get { return chieuCaoBanCo; } }
        #endregion

        #region Tọa độ đơn vị ban đầu của tất cả quân cờ
        /* Tọa độ NULL - Tọa độ không thuộc bàn cờ */
        private static Point toaDoNULL = new Point(-1, -1);
        public static Point ToaDoNULL { get { return toaDoNULL; } }

        /* PHE XANH */

        /* Tướng Xanh */
        private static Point toaDoTuongXanh = new Point(4, 0);
        public static Point ToaDoTuongXanh { get { return toaDoTuongXanh; } }

        /* Xe Xanh */
        private static Point toaDoXeXanh1 = new Point(0, 0);
        public static Point ToaDoXeXanh1 { get { return toaDoXeXanh1; } }

        private static Point toaDoXeXanh2 = new Point(8, 0);
        public static Point ToaDoXeXanh2 { get { return toaDoXeXanh2; } }

        /* Mã Xanh */
        private static Point toaDoMaXanh1 = new Point(1, 0);
        public static Point ToaDoMaXanh1 { get { return toaDoMaXanh1; } }

        private static Point toaDoMaXanh2 = new Point(7, 0);
        public static Point ToaDoMaXanh2 { get { return toaDoMaXanh2; } }

        /* Tịnh Xanh */
        private static Point toaDoTinhXanh1 = new Point(2, 0);
        public static Point ToaDoTinhXanh1 { get { return toaDoTinhXanh1; } }

        private static Point toaDoTinhXanh2 = new Point(6, 0);
        public static Point ToaDoTinhXanh2 { get { return toaDoTinhXanh2; } }

        /* Sĩ Xanh */
        private static Point toaDoSiXanh1 = new Point(3, 0);
        public static Point ToaDoSiXanh1 { get { return toaDoSiXanh1; } }

        private static Point toaDoSiXanh2 = new Point(5, 0);
        public static Point ToaDoSiXanh2 { get { return toaDoSiXanh2; } }

        /* Pháo Xanh */
        private static Point toaDoPhaoXanh1 = new Point(1, 2);
        public static Point ToaDoPhaoXanh1 { get { return toaDoPhaoXanh1; } }

        private static Point toaDoPhaoXanh2 = new Point(7, 2);
        public static Point ToaDoPhaoXanh2 { get { return toaDoPhaoXanh2; } }

        /* Tốt Xanh */
        private static Point toaDoTotXanh1 = new Point(0, 3);
        public static Point ToaDoTotXanh1 { get { return toaDoTotXanh1; } }

        private static Point toaDoTotXanh2 = new Point(2, 3);
        public static Point ToaDoTotXanh2 { get { return toaDoTotXanh2; } }

        private static Point toaDoTotXanh3 = new Point(4, 3);
        public static Point ToaDoTotXanh3 { get { return toaDoTotXanh3; } }

        private static Point toaDoTotXanh4 = new Point(6, 3);
        public static Point ToaDoTotXanh4 { get { return toaDoTotXanh4; } }

        private static Point toaDoTotXanh5 = new Point(8, 3);
        public static Point ToaDoTotXanh5 { get { return toaDoTotXanh5; } }

        /* PHE ĐỎ */

        /* Tướng Đỏ */
        private static Point toaDoTuongDo = new Point(4, 9);
        public static Point ToaDoTuongDo { get { return toaDoTuongDo; } }

        /* Xe Đỏ */
        private static Point toaDoXeDo1 = new Point(0, 9);
        public static Point ToaDoXeDo1 { get { return toaDoXeDo1; } }

        private static Point toaDoXeDo2 = new Point(8, 9);
        public static Point ToaDoXeDo2 { get { return toaDoXeDo2; } }

        /* Mã Đỏ */
        private static Point toaDoMaDo1 = new Point(1, 9);
        public static Point ToaDoMaDo1 { get { return toaDoMaDo1; } }

        private static Point toaDoMaDo2 = new Point(7, 9);
        public static Point ToaDoMaDo2 { get { return toaDoMaDo2; } }

        /* Tịnh Đỏ */
        private static Point toaDoTinhDo1 = new Point(2, 9);
        public static Point ToaDoTinhDo1 { get { return toaDoTinhDo1; } }

        private static Point toaDoTinhDo2 = new Point(6, 9);
        public static Point ToaDoTinhDo2 { get { return toaDoTinhDo2; } }

        /* Sĩ Đỏ */
        private static Point toaDoSiDo1 = new Point(3, 9);
        public static Point ToaDoSiDo1 { get { return toaDoSiDo1; } }

        private static Point toaDoSiDo2 = new Point(5, 9);
        public static Point ToaDoSiDo2 { get { return toaDoSiDo2; } }

        /* Pháo Đỏ */
        private static Point toaDoPhaoDo1 = new Point(1, 7);
        public static Point ToaDoPhaoDo1 { get { return toaDoPhaoDo1; } }

        private static Point toaDoPhaoDo2 = new Point(7, 7);
        public static Point ToaDoPhaoDo2 { get { return toaDoPhaoDo2; } }

        /* Tốt Đỏ */
        private static Point toaDoTotDo1 = new Point(0, 6);
        public static Point ToaDoTotDo1 { get { return toaDoTotDo1; } }

        private static Point toaDoTotDo2 = new Point(2, 6);
        public static Point ToaDoTotDo2 { get { return toaDoTotDo2; } }

        private static Point toaDoTotDo3 = new Point(4, 6);
        public static Point ToaDoTotDo3 { get { return toaDoTotDo3; } }

        private static Point toaDoTotDo4 = new Point(6, 6);
        public static Point ToaDoTotDo4 { get { return toaDoTotDo4; } }

        private static Point toaDoTotDo5 = new Point(8, 6);
        public static Point ToaDoTotDo5 { get { return toaDoTotDo5; } }
        #endregion

        #region Hàm tính toán
        public static Point ToaDoBanCoCuaDiem(int x, int y) // hàm chuyển tọa độ đơn vị (TDDV) của điểm bàn cờ sang tọa độ bàn cờ (TDBC)
        {
            Point result = new Point(GocDiemBanCoX + x * KhoangCach, GocDiemBanCoY + y * KhoangCach);
            return result;
        }
        public static Point ToaDoBanCoCuaDiem(Point toaDoDonVi)
        {
            return ToaDoBanCoCuaDiem(toaDoDonVi.X, toaDoDonVi.Y);
        }

        public static Point ToaDoBanCoCuaQuanCo(int x, int y) // hàm chuyển TDDV của quân cờ sang TDBC
        {
            Point result = new Point(GocQuanCoX + x * KhoangCach, GocQuanCoY + y * KhoangCach);
            return result;
        }
        public static Point ToaDoBanCoCuaQuanCo(Point toaDoDonVi)
        {
            return ToaDoBanCoCuaQuanCo(toaDoDonVi.X, toaDoDonVi.Y);
        }

        public static Point ToaDoDonViCuaDiem(int X, int Y) // hàm chuyển TDBC của điểm bàn cờ sang TDDV
        {
            Point result = new Point((X - GocDiemBanCoX) / KhoangCach, (Y - GocDiemBanCoY) / KhoangCach);
            return result;
        }
        public static Point ToaDoDonViCuaDiem(Point toaDoBanCo)
        {
            return ToaDoDonViCuaDiem(toaDoBanCo.X, toaDoBanCo.Y);
        }

        public static Point ToaDoDonViCuaQuanCo(int X, int Y)  // hàm chuyển TDBC của quân cờ sang TDDV
        {
            Point result = new Point((X - GocQuanCoX) / KhoangCach, (Y - GocQuanCoY) / KhoangCach);
            return result;
        }
        public static Point ToaDoDonViCuaQuanCo(Point toaDoBanCo)
        {
            return ToaDoDonViCuaQuanCo(toaDoBanCo.X, toaDoBanCo.Y);
        }

        public static Point ToaDoDiemSangQuanCo(int X_DiemBanCo, int Y_DiemBanCo) // hàm chuyển TDBC của điểm bàn cờ sang TDBC của quân cờ
        {
            Point result = ToaDoBanCoCuaQuanCo(ToaDoDonViCuaDiem(X_DiemBanCo, Y_DiemBanCo));
            return result;
        }
        public static Point ToaDoDiemSangQuanCo(Point toaDoDiem)
        {
            return ToaDoDiemSangQuanCo(toaDoDiem.X, toaDoDiem.Y);
        }

        public static Point ToaDoQuanCoSangDiem(int X_QuanCo, int Y_QuanCo) // hàm chuyển TDBC của quân cờ sang TDBC của điểm bàn cờ
        {
            Point result = ToaDoBanCoCuaDiem(ToaDoDonViCuaQuanCo(X_QuanCo, Y_QuanCo));
            return result;
        }
        public static Point ToaDoQuanCoSangDiem(Point toaDoQuanCo)
        {
            return ToaDoQuanCoSangDiem(toaDoQuanCo.X, toaDoQuanCo.Y);
        }

        public static int MauQuanCo(Point toaDoBanDau) // xác định màu quân cờ dựa vào TDDV ban đầu của nó
        {
            if (toaDoBanDau == ToaDoTuongXanh || 
                toaDoBanDau == toaDoXeXanh1 || toaDoBanDau == toaDoXeXanh2 ||
                toaDoBanDau == toaDoMaXanh1 || toaDoBanDau == toaDoMaXanh2 ||
                toaDoBanDau == toaDoTinhXanh1 || toaDoBanDau == toaDoTinhXanh2 ||
                toaDoBanDau == toaDoSiXanh1 || toaDoBanDau == toaDoSiXanh2 ||
                toaDoBanDau == toaDoPhaoXanh1 || toaDoBanDau == toaDoPhaoXanh2 ||
                toaDoBanDau == ToaDoTotXanh1 ||
                toaDoBanDau == ToaDoTotXanh2 ||
                toaDoBanDau == ToaDoTotXanh3 ||
                toaDoBanDau == ToaDoTotXanh4 ||
                toaDoBanDau == ToaDoTotXanh5)
                return 1;
            return 2;
        }
        #endregion
    }
}