using GameCoTuong.CoTuong;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCoTuong.ProgramConfig
{
    public class RoundPictureBox : PictureBox
    {
        #region attributes
        public QuanCo quanCo;
        public QuanCo QuanCo { get { return quanCo; } }

        private string tenQuanCo;
        public string TenQuanCo { get { return tenQuanCo; } }
        #endregion

        #region methods
        public RoundPictureBox()
        {
            quanCo = new QuanCo();
            tenQuanCo = "";
            this.BackColor = Color.DarkGray;
        }

        public RoundPictureBox(Point toaDoBanDau)
        {
            tenQuanCo = "";
            if (toaDoBanDau == ThongSoPheDo.ToaDoNULL)
            {
                quanCo = new QuanCo(toaDoBanDau);
                tenQuanCo += "NULL";
            }
            else if (toaDoBanDau == ThongSoPheDo.ToaDoTuongXanh || toaDoBanDau == ThongSoPheDo.ToaDoTuongDo)
            {
                quanCo = new QuanTuong(toaDoBanDau);
                tenQuanCo += "Tuong";
            }
            else if (toaDoBanDau == ThongSoPheDo.ToaDoXeXanh1 || toaDoBanDau == ThongSoPheDo.ToaDoXeXanh2 || toaDoBanDau == ThongSoPheDo.ToaDoXeDo1 || toaDoBanDau == ThongSoPheDo.ToaDoXeDo2)
            {
                quanCo = new QuanXe(toaDoBanDau);
                tenQuanCo += "Xe";
            }
            else if (toaDoBanDau == ThongSoPheDo.ToaDoMaXanh1 || toaDoBanDau == ThongSoPheDo.ToaDoMaXanh2 || toaDoBanDau == ThongSoPheDo.ToaDoMaDo1 || toaDoBanDau == ThongSoPheDo.ToaDoMaDo2)
            {
                quanCo = new QuanMa(toaDoBanDau);
                tenQuanCo += "Ma";
            }
            else if (toaDoBanDau == ThongSoPheDo.ToaDoTinhXanh1 || toaDoBanDau == ThongSoPheDo.ToaDoTinhXanh2 || toaDoBanDau == ThongSoPheDo.ToaDoTinhDo1 || toaDoBanDau == ThongSoPheDo.ToaDoTinhDo2)
            {
                quanCo = new QuanTinh(toaDoBanDau);
                tenQuanCo += "Tinh";
            }
            else if (toaDoBanDau == ThongSoPheDo.ToaDoSiXanh1 || toaDoBanDau == ThongSoPheDo.ToaDoSiXanh2 || toaDoBanDau == ThongSoPheDo.ToaDoSiDo1 || toaDoBanDau == ThongSoPheDo.ToaDoSiDo2)
            {
                quanCo = new QuanSi(toaDoBanDau);
                tenQuanCo += "Si";
            }
            else if (toaDoBanDau == ThongSoPheDo.ToaDoPhaoXanh1 || toaDoBanDau == ThongSoPheDo.ToaDoPhaoXanh2 || toaDoBanDau == ThongSoPheDo.ToaDoPhaoDo1 || toaDoBanDau == ThongSoPheDo.ToaDoPhaoDo2)
            {
                quanCo = new QuanPhao(toaDoBanDau);
                tenQuanCo += "Phao";
            }
            else
            {
                quanCo = new QuanTot(toaDoBanDau);
                tenQuanCo += "Tot";
            }

            if (quanCo.Mau == 1)
            {
                BackColor = Color.DarkBlue;
                tenQuanCo += " Xanh";
            }
            else if (quanCo.Mau == 2)
            {
                BackColor = Color.DarkRed;
                tenQuanCo += " Do";
            }

            Height = ThongSo.DuongKinhQuanCo;
            Width = ThongSo.DuongKinhQuanCo;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Location = ThongSo.ToaDoBanCoCuaQuanCo(toaDoBanDau);
        }

        public bool Equals(RoundPictureBox quanCoSoSanh)
        {
            return (this.quanCo.Equals(quanCoSoSanh.quanCo)) && (this.TenQuanCo == quanCoSoSanh.TenQuanCo);
        }

        public void DenViTri(Point location)
        {
            quanCo.MoveTo(location);
            Location = ThongSo.ToaDoBanCoCuaQuanCo(location);
        }

        public void ThayDoiDuongKinh(int value)
        {
            this.Width = value;
            this.Height = value;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            using (var gp = new GraphicsPath())
            {
                gp.AddEllipse(new Rectangle(0, 0, this.Width - 1, this.Height - 1));
                this.Region = new Region(gp);
            }
        }
        #endregion
    }
}