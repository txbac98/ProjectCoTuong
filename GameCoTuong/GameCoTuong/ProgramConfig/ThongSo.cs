using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCoTuong.ProgramConfig
{
    public class ThongSo // Lớp Thông số
    {
        /* Class này chứa tất cả thông số về bàn cờ tướng, điểm bàn cờ, các quân cờ và các hàm tính toán cần thiết */

        #region Gốc tọa độ & Khoảng cách
        private static int gocBanCoX = 44; // hoành độ gốc của bàn cờ (góc trên bên trái)
        public static int GocBanCoX { get { return gocBanCoX; } }

        private static int gocBanCoY = 42; // tung độ gốc của bàn cờ (góc trên bên trái)
        public static int GocBanCoY { get { return gocBanCoY; } }

        private static int khoangCachGiuaCacDiem = 61; // khoảng cách giữa các điểm bàn cờ
        public static int KhoangCachGiuaCacDiem { get { return khoangCachGiuaCacDiem; } }
        #endregion

        #region Quân cờ và Điểm bàn cờ
        /* Quân cờ là hình tròn */
        private static int duongKinhQuanCo = 60; // đường kính của 1 quân cờ
        public static int DuongKinhQuanCo { get { return duongKinhQuanCo; } }

        /* Điểm bàn cờ là hình tròn */
        private static int duongKinhDiem = 30; // đường kính của 1 điểm bàn cờ
        public static int DuongKinhDiem { get { return duongKinhDiem; } }
        #endregion

        #region Hàm tính toán
        public static Point ToaDoBanCo(int x, int y) // hàm chuyển tọa độ đơn vị (TĐĐV - mỗi đường thẳng cách nhau 1 đơn vị) sang tọa độ bàn cờ
        {
            Point result = new Point(GocBanCoX + x * KhoangCachGiuaCacDiem, GocBanCoY + y * KhoangCachGiuaCacDiem);
            return result;
        }
        #endregion
    }
}