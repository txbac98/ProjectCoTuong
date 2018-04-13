using GameCoTuong.CoTuong;
using GameCoTuong.ProgramConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GameCoTuong
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TaoDiemBanCo();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void TaoDiemBanCo()
        {
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    Button diemMoi = new RoundButton();
                    ptbBanCo.Controls.Add(diemMoi);
                    diemMoi.Text = "";
                    diemMoi.Height = ThongSo.DuongKinhDiem;
                    diemMoi.Width = 30;
                    diemMoi.BackColor = Color.Yellow;
                    diemMoi.Location = ThongSo.ToaDoBanCo(x, y);
                    diemMoi.Visible = true;
                }
            }
        }
    }
}