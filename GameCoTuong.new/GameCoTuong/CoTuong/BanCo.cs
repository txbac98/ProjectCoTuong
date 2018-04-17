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
        #region properties

        public static List<QuanCo> alive = new List<QuanCo>();

        #endregion

        #region methods

        public static bool CoQuanCoTaiDay(Point toaDo) // kiểm tra xem có quân cờ nào tại điểm cho trước hay không
        {
            foreach (QuanCo element in alive)
            {
                if (element.ToaDo == toaDo)
                    return true;
            }
            return false;
        }

        public static QuanCo GetQuanCo(Point toaDo)
        {
            return alive.Find(element => element.ToaDo == toaDo);
        }

        #endregion
    }
}