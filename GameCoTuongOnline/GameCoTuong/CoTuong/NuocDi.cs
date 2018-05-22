using GameCoTuong.ProgramConfig;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCoTuong.CoTuong
{
    public class NuocDi
    {
        public Point PrevGreyTargetDepartureLocation { get; set; }
        public Point PrevGreyTargetDestinationLocation { get; set; }
        public Point ToaDoDi { get; set; }
        public Point ToaDoDen { get; set; }
        public RoundPictureBox QuanCoDiChuyen { get; set; }
        public RoundPictureBox QuanCoBiLoai { get; set; }

        public NuocDi()
        {
            PrevGreyTargetDepartureLocation = ThongSo.ToaDoNULL;
            PrevGreyTargetDestinationLocation = ThongSo.ToaDoNULL;
            ToaDoDi = ThongSo.ToaDoNULL;
            ToaDoDen = ThongSo.ToaDoNULL;
            QuanCoDiChuyen = null;
            QuanCoBiLoai = null;
        }

        public void Clear()
        {
            PrevGreyTargetDepartureLocation = ThongSo.ToaDoNULL;
            PrevGreyTargetDestinationLocation = ThongSo.ToaDoNULL;
            ToaDoDi = ThongSo.ToaDoNULL;
            ToaDoDen = ThongSo.ToaDoNULL;
            QuanCoDiChuyen = null;
            QuanCoBiLoai = null;
        }
    }
}