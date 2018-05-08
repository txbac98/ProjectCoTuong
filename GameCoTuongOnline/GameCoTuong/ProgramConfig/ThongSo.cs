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
        private static int duongKinhQuanCo = 56; // đường kính của 1 quân cờ
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

        #endregion
    }
}