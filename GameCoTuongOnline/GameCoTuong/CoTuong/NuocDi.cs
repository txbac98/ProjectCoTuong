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
        public Point ToaDoDi { get; set; }
        public Point ToaDoDen { get; set; }
        public RoundPictureBox QuanCoDiChuyen { get; set; }
        public RoundPictureBox QuanCoBiLoai { get; set; }

        public NuocDi()
        {
            ToaDoDi = ThongSo.ToaDoNULL;
            ToaDoDen = ThongSo.ToaDoNULL;
            QuanCoDiChuyen = null;
            QuanCoBiLoai = null;
        }

        public NuocDi(Point departure, Point destination, RoundPictureBox moving, RoundPictureBox eliminated)
        {
            ToaDoDi = new Point(departure.X, departure.Y);
            ToaDoDen = new Point(destination.X, destination.Y);
            QuanCoDiChuyen = moving;
            QuanCoBiLoai = eliminated;
        }
    }
}