using GameCoTuong.ProgramConfig;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCoTuong.CoTuong
{
    public static class BanCo
    {
        #region attributes

        public static List<QuanCo> alive = new List<QuanCo>();
        public static QuanTuong tuongXanh;
        public static QuanTuong tuongDo;

        #endregion

        #region methods

        public static bool CoQuanCoTaiDay(Point toaDo) // kiểm tra xem có quân cờ nào tại điểm cho trước hay không
        {
            return alive.Find(element => element.ToaDo == toaDo) != null;
        }

        public static QuanCo GetQuanCo(Point toaDo)
        {
            return alive.Find(element => element.ToaDo == toaDo);
        }

        #endregion
    }
}