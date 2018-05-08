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
            if (toaDoBanDau == PheDo.ToaDoNULL)
            {
                quanCo = new QuanCo(toaDoBanDau);
                tenQuanCo += "NULL";
            }
            else if (toaDoBanDau == PheDo.ToaDoTuongXanh || toaDoBanDau == PheDo.ToaDoTuongDo)
            {
                quanCo = new QuanTuong(toaDoBanDau);
                tenQuanCo += "Tuong";
            }
            else if (toaDoBanDau == PheDo.ToaDoXeXanh1 || toaDoBanDau == PheDo.ToaDoXeXanh2 || toaDoBanDau == PheDo.ToaDoXeDo1 || toaDoBanDau == PheDo.ToaDoXeDo2)
            {
                quanCo = new QuanXe(toaDoBanDau);
                tenQuanCo += "Xe";
            }
            else if (toaDoBanDau == PheDo.ToaDoMaXanh1 || toaDoBanDau == PheDo.ToaDoMaXanh2 || toaDoBanDau == PheDo.ToaDoMaDo1 || toaDoBanDau == PheDo.ToaDoMaDo2)
            {
                quanCo = new QuanMa(toaDoBanDau);
                tenQuanCo += "Ma";
            }
            else if (toaDoBanDau == PheDo.ToaDoTinhXanh1 || toaDoBanDau == PheDo.ToaDoTinhXanh2 || toaDoBanDau == PheDo.ToaDoTinhDo1 || toaDoBanDau == PheDo.ToaDoTinhDo2)
            {
                quanCo = new QuanTinh(toaDoBanDau);
                tenQuanCo += "Tinh";
            }
            else if (toaDoBanDau == PheDo.ToaDoSiXanh1 || toaDoBanDau == PheDo.ToaDoSiXanh2 || toaDoBanDau == PheDo.ToaDoSiDo1 || toaDoBanDau == PheDo.ToaDoSiDo2)
            {
                quanCo = new QuanSi(toaDoBanDau);
                tenQuanCo += "Si";
            }
            else if (toaDoBanDau == PheDo.ToaDoPhaoXanh1 || toaDoBanDau == PheDo.ToaDoPhaoXanh2 || toaDoBanDau == PheDo.ToaDoPhaoDo1 || toaDoBanDau == PheDo.ToaDoPhaoDo2)
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