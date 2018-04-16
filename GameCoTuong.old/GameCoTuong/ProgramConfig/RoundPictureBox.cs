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
    class RoundPictureBox : PictureBox
    {
        #region properties
        public QuanCo quanCo;
        public QuanCo QuanCo { get { return quanCo; } }

        private string tenQuanCo;
        public string TenQuanCo { get { return tenQuanCo; } }
        
        public static RoundPictureBox quanCoNULL = new RoundPictureBox(ThongSo.ToaDoNULL);
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
            if (toaDoBanDau == ThongSo.ToaDoNULL)
            {
                quanCo = new QuanCo(toaDoBanDau);
                tenQuanCo += "NULL";
            }
            else if (toaDoBanDau == ThongSo.ToaDoTuongXanh || toaDoBanDau == ThongSo.ToaDoTuongDo)
            {
                quanCo = new QuanTuong(toaDoBanDau);
                tenQuanCo += "Tuong";
            }
            else if (toaDoBanDau == ThongSo.ToaDoXeXanh1 || toaDoBanDau == ThongSo.ToaDoXeXanh2 || toaDoBanDau == ThongSo.ToaDoXeDo1 || toaDoBanDau == ThongSo.ToaDoXeDo2)
            {
                quanCo = new QuanXe(toaDoBanDau);
                tenQuanCo += "Xe";
            }
            else if (toaDoBanDau == ThongSo.ToaDoMaXanh1 || toaDoBanDau == ThongSo.ToaDoMaXanh2 || toaDoBanDau == ThongSo.ToaDoMaDo1 || toaDoBanDau == ThongSo.ToaDoMaDo2)
            {
                quanCo = new QuanMa(toaDoBanDau);
                tenQuanCo += "Ma";
            }
            else if (toaDoBanDau == ThongSo.ToaDoTinhXanh1 || toaDoBanDau == ThongSo.ToaDoTinhXanh2 || toaDoBanDau == ThongSo.ToaDoTinhDo1 || toaDoBanDau == ThongSo.ToaDoTinhDo2)
            {
                quanCo = new QuanTinh(toaDoBanDau);
                tenQuanCo += "Tinh";
            }
            else if (toaDoBanDau == ThongSo.ToaDoSiXanh1 || toaDoBanDau == ThongSo.ToaDoSiXanh2 || toaDoBanDau == ThongSo.ToaDoSiDo1 || toaDoBanDau == ThongSo.ToaDoSiDo2)
            {
                quanCo = new QuanSi(toaDoBanDau);
                tenQuanCo += "Si";
            }
            else if (toaDoBanDau == ThongSo.ToaDoPhaoXanh1 || toaDoBanDau == ThongSo.ToaDoPhaoXanh2 || toaDoBanDau == ThongSo.ToaDoPhaoDo1 || toaDoBanDau == ThongSo.ToaDoPhaoDo2)
            {
                quanCo = new QuanPhao(toaDoBanDau);
                tenQuanCo += "Phao";
            }
            else
            {
                quanCo = new QuanTot(toaDoBanDau);
                tenQuanCo += "Tot";
            }
            Height = ThongSo.DuongKinhQuanCo;
            Width = ThongSo.DuongKinhQuanCo;
            Location = ThongSo.ToaDoBanCoCuaQuanCo(toaDoBanDau);
            if (quanCo.Mau == 1)
            {
                BackColor = Color.DarkBlue;
                tenQuanCo += "Xanh";
            }
            else if (quanCo.Mau == 2)
            {
                BackColor = Color.DarkRed;
                tenQuanCo += "Do";
            }
            //Image = Image.FromFile(Application.StartupPath + "\\Resources\\---.png");
        }

        public bool Equals(RoundPictureBox quanCoSoSanh)
        {
            return (this.quanCo.Equals(quanCoSoSanh.quanCo)) && (this.TenQuanCo == quanCoSoSanh.TenQuanCo);
        }

        public void DiChuyen(Point destination)
        {
            quanCo.Move(destination);
            Location = ThongSo.ToaDoBanCoCuaQuanCo(destination);
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