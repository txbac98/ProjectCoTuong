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

        #region Gốc tọa độ bàn cờ & khoảng cách
        public static int GocDiemBanCoX { get { return 44; } } // hoành độ gốc của điểm bàn cờ trên bàn cờ (góc trên bên trái)

        public static int GocDiemBanCoY { get { return 42; } } // tung độ gốc của điểm bàn cờ trên bàn cờ (góc trên bên trái)

        public static int GocQuanCoX { get { return 31; } } // hoành độ gốc của quân cờ trên bàn cờ (góc trên bên trái)

        public static int GocQuanCoY { get { return 30; } } // tung độ gốc của quân cờ trên bàn cờ (góc trên bên trái)
        
        public static int KhoangCach { get { return 61; } } // khoảng cách giữa các điểm bàn cờ & quân cờ
        #endregion

        #region Kích thước quân cờ, điểm bàn cờ và bàn cờ
        /* Quân cờ (hình tròn) */
        public static int DuongKinhQuanCo { get { return 56; } } // đường kính của 1 quân cờ

        /* Điểm bàn cờ (hình tròn) */
        public static int DuongKinhDiem { get { return 30; } } // đường kính của 1 điểm bàn cờ

        /* Bàn cờ */
        public static Point ToaDoBanCo { get { return new Point(0, 0); } } // tọa độ của bàn cờ trong WinForm

        public static int ChieuRongBanCo { get { return 607; } } // chiều rộng của bàn cờ

        public static int ChieuCaoBanCo { get { return 662; } } // chiều cao của bàn cờ
        #endregion

        #region Tọa độ đơn vị ban đầu của tất cả quân cờ
        /* Tọa độ NULL - Tọa độ không thuộc bàn cờ */
        public static Point ToaDoNULL { get { return new Point(-1, -1); } }

        /* PHE XANH */

        /* Tướng Xanh */
        public static Point ToaDoTuongXanh { get { return new Point(4, 0); } }

        /* Xe Xanh */
        public static Point ToaDoXeXanh1 { get { return new Point(0, 0); } }

        public static Point ToaDoXeXanh2 { get { return new Point(8, 0); } }

        /* Mã Xanh */
        public static Point ToaDoMaXanh1 { get { return new Point(1, 0); } }

        public static Point ToaDoMaXanh2 { get { return new Point(7, 0); } }

        /* Tịnh Xanh */
        public static Point ToaDoTinhXanh1 { get { return new Point(2, 0); } }

        public static Point ToaDoTinhXanh2 { get { return new Point(6, 0); } }

        /* Sĩ Xanh */
        public static Point ToaDoSiXanh1 { get { return new Point(3, 0); } }

        public static Point ToaDoSiXanh2 { get { return new Point(5, 0); } }

        /* Pháo Xanh */
        public static Point ToaDoPhaoXanh1 { get { return new Point(1, 2); } }

        public static Point ToaDoPhaoXanh2 { get { return new Point(7, 2); } }

        /* Tốt Xanh */
        public static Point ToaDoTotXanh1 { get { return new Point(0, 3); } }

        public static Point ToaDoTotXanh2 { get { return new Point(2, 3); } }

        public static Point ToaDoTotXanh3 { get { return new Point(4, 3); } }

        public static Point ToaDoTotXanh4 { get { return new Point(6, 3); } }

        public static Point ToaDoTotXanh5 { get { return new Point(8, 3); } }

        /* PHE ĐỎ */

        /* Tướng Đỏ */
        public static Point ToaDoTuongDo { get { return new Point(4, 9); } }

        /* Xe Đỏ */
        public static Point ToaDoXeDo1 { get { return new Point(8, 9); } }

        public static Point ToaDoXeDo2 { get { return new Point(0, 9); } }

        /* Mã Đỏ */
        public static Point ToaDoMaDo1 { get { return new Point(7, 9); } }

        public static Point ToaDoMaDo2 { get { return new Point(1, 9); } }

        /* Tịnh Đỏ */
        public static Point ToaDoTinhDo1 { get { return new Point(6, 9); } }

        public static Point ToaDoTinhDo2 { get { return new Point(2, 9); } }

        /* Sĩ Đỏ */
        public static Point ToaDoSiDo1 { get { return new Point(5, 9); } }

        public static Point ToaDoSiDo2 { get { return new Point(3, 9); } }

        /* Pháo Đỏ */
        public static Point ToaDoPhaoDo1 { get { return new Point(7, 7); } }

        public static Point ToaDoPhaoDo2 { get { return new Point(1, 7); } }

        /* Tốt Đỏ */
        public static Point ToaDoTotDo1 { get { return new Point(8, 6); } }

        public static Point ToaDoTotDo2 { get { return new Point(6, 6); } }

        public static Point ToaDoTotDo3 { get { return new Point(4, 6); } }

        public static Point ToaDoTotDo4 { get { return new Point(2, 6); } }

        public static Point ToaDoTotDo5 { get { return new Point(0, 6); } }
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
                toaDoBanDau == ToaDoXeXanh1 || toaDoBanDau == ToaDoXeXanh2 ||
                toaDoBanDau == ToaDoMaXanh1 || toaDoBanDau == ToaDoMaXanh2 ||
                toaDoBanDau == ToaDoTinhXanh1 || toaDoBanDau == ToaDoTinhXanh2 ||
                toaDoBanDau == ToaDoSiXanh1 || toaDoBanDau == ToaDoSiXanh2 ||
                toaDoBanDau == ToaDoPhaoXanh1 || toaDoBanDau == ToaDoPhaoXanh2 ||
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