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
        #region global properties in 'Form1'

        RoundButton[,] diemBanCo = new RoundButton[9, 10];
        List<RoundPictureBox> roundPictureBoxList = new List<RoundPictureBox>();
        Point selectedCoordinate = ThongSo.ToaDoNULL;

        #endregion

        private void Form1_Load(object sender, EventArgs e) { }

        public Form1()
        {
            InitializeComponent();
            InitializeRoundButton();
            TaoQuanCo();
            XepBanCo();
        }

        private void InitializeRoundButton()
        {
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    diemBanCo[x, y] = new RoundButton()
                    {
                        Text = "",
                        Width = ThongSo.DuongKinhDiem,
                        Height = ThongSo.DuongKinhDiem,
                        BackColor = Color.Yellow,
                        Location = ThongSo.ToaDoBanCoCuaDiem(x, y),
                        Visible = false
                    };
                    ptbBanCo.Controls.Add(diemBanCo[x, y]);
                }
            }
        }

        private void TaoQuanCo()
        {
            /* Tướng xanh */
            RoundPictureBox tuongXanh = new RoundPictureBox(ThongSo.ToaDoTuongXanh);
            tuongXanh.Image = GameCoTuong.Properties.Resources.TuongXanh;
            roundPictureBoxList.Add(tuongXanh);

            /* Xe xanh */
            RoundPictureBox xeXanh1 = new RoundPictureBox(ThongSo.ToaDoXeXanh1);
            xeXanh1.Image = GameCoTuong.Properties.Resources.XeXanh;
            roundPictureBoxList.Add(xeXanh1);

            RoundPictureBox xeXanh2 = new RoundPictureBox(ThongSo.ToaDoXeXanh2);
            xeXanh2.Image = GameCoTuong.Properties.Resources.XeXanh;
            roundPictureBoxList.Add(xeXanh2);

            /* Mã xanh */
            RoundPictureBox maXanh1 = new RoundPictureBox(ThongSo.ToaDoMaXanh1);
            maXanh1.Image = GameCoTuong.Properties.Resources.MaXanh;
            roundPictureBoxList.Add(maXanh1);

            RoundPictureBox maXanh2 = new RoundPictureBox(ThongSo.ToaDoMaXanh2);
            maXanh2.Image = GameCoTuong.Properties.Resources.MaXanh;
            roundPictureBoxList.Add(maXanh2);

            /* Tịnh xanh */
            RoundPictureBox tinhXanh1 = new RoundPictureBox(ThongSo.ToaDoTinhXanh1);
            tinhXanh1.Image = GameCoTuong.Properties.Resources.TinhXanh;
            roundPictureBoxList.Add(tinhXanh1);

            RoundPictureBox tinhXanh2 = new RoundPictureBox(ThongSo.ToaDoTinhXanh2);
            tinhXanh2.Image = GameCoTuong.Properties.Resources.TinhXanh;
            roundPictureBoxList.Add(tinhXanh2);

            /* Sĩ xanh */
            RoundPictureBox siXanh1 = new RoundPictureBox(ThongSo.ToaDoSiXanh1);
            siXanh1.Image = GameCoTuong.Properties.Resources.SiXanh;
            roundPictureBoxList.Add(siXanh1);

            RoundPictureBox siXanh2 = new RoundPictureBox(ThongSo.ToaDoSiXanh2);
            siXanh2.Image = GameCoTuong.Properties.Resources.SiXanh;
            roundPictureBoxList.Add(siXanh2);

            /* Pháo xanh */
            RoundPictureBox phaoXanh1 = new RoundPictureBox(ThongSo.ToaDoPhaoXanh1);
            phaoXanh1.Image = GameCoTuong.Properties.Resources.PhaoXanh;
            roundPictureBoxList.Add(phaoXanh1);

            RoundPictureBox phaoXanh2 = new RoundPictureBox(ThongSo.ToaDoPhaoXanh2);
            phaoXanh2.Image = GameCoTuong.Properties.Resources.PhaoXanh;
            roundPictureBoxList.Add(phaoXanh2);

            /* Tốt xanh */
            RoundPictureBox totXanh1 = new RoundPictureBox(ThongSo.ToaDoTotXanh1);
            totXanh1.Image = GameCoTuong.Properties.Resources.TotXanh;
            roundPictureBoxList.Add(totXanh1);

            RoundPictureBox totXanh2 = new RoundPictureBox(ThongSo.ToaDoTotXanh2);
            totXanh2.Image = GameCoTuong.Properties.Resources.TotXanh;
            roundPictureBoxList.Add(totXanh2);

            RoundPictureBox totXanh3 = new RoundPictureBox(ThongSo.ToaDoTotXanh3);
            totXanh3.Image = GameCoTuong.Properties.Resources.TotXanh;
            roundPictureBoxList.Add(totXanh3);

            RoundPictureBox totXanh4 = new RoundPictureBox(ThongSo.ToaDoTotXanh4);
            totXanh4.Image = GameCoTuong.Properties.Resources.TotXanh;
            roundPictureBoxList.Add(totXanh4);

            RoundPictureBox totXanh5 = new RoundPictureBox(ThongSo.ToaDoTotXanh5);
            totXanh5.Image = GameCoTuong.Properties.Resources.TotXanh;
            roundPictureBoxList.Add(totXanh5);

            /* Tướng đỏ */
            RoundPictureBox tuongDo = new RoundPictureBox(ThongSo.ToaDoTuongDo);
            tuongDo.Image = GameCoTuong.Properties.Resources.TuongDo;
            roundPictureBoxList.Add(tuongDo);

            /* Xe đỏ */
            RoundPictureBox xeDo1 = new RoundPictureBox(ThongSo.ToaDoXeDo1);
            xeDo1.Image = GameCoTuong.Properties.Resources.XeDo;
            roundPictureBoxList.Add(xeDo1);

            RoundPictureBox xeDo2 = new RoundPictureBox(ThongSo.ToaDoXeDo2);
            xeDo2.Image = GameCoTuong.Properties.Resources.XeDo;
            roundPictureBoxList.Add(xeDo2);

            /* Mã đỏ */
            RoundPictureBox maDo1 = new RoundPictureBox(ThongSo.ToaDoMaDo1);
            maDo1.Image = GameCoTuong.Properties.Resources.MaDo;
            roundPictureBoxList.Add(maDo1);

            RoundPictureBox maDo2 = new RoundPictureBox(ThongSo.ToaDoMaDo2);
            maDo2.Image = GameCoTuong.Properties.Resources.MaDo;
            roundPictureBoxList.Add(maDo2);

            /* Tịnh đỏ */
            RoundPictureBox tinhDo1 = new RoundPictureBox(ThongSo.ToaDoTinhDo1);
            tinhDo1.Image = GameCoTuong.Properties.Resources.TinhDo;
            roundPictureBoxList.Add(tinhDo1);

            RoundPictureBox tinhDo2 = new RoundPictureBox(ThongSo.ToaDoTinhDo2);
            tinhDo2.Image = GameCoTuong.Properties.Resources.TinhDo;
            roundPictureBoxList.Add(tinhDo2);

            /* Sĩ đỏ */
            RoundPictureBox siDo1 = new RoundPictureBox(ThongSo.ToaDoSiDo1);
            siDo1.Image = GameCoTuong.Properties.Resources.SiDo;
            roundPictureBoxList.Add(siDo1);

            RoundPictureBox siDo2 = new RoundPictureBox(ThongSo.ToaDoSiDo2);
            siDo2.Image = GameCoTuong.Properties.Resources.SiDo;
            roundPictureBoxList.Add(siDo2);

            /* Pháo đỏ */
            RoundPictureBox phaoDo1 = new RoundPictureBox(ThongSo.ToaDoPhaoDo1);
            phaoDo1.Image = GameCoTuong.Properties.Resources.PhaoDo;
            roundPictureBoxList.Add(phaoDo1);

            RoundPictureBox phaoDo2 = new RoundPictureBox(ThongSo.ToaDoPhaoDo2);
            phaoDo2.Image = GameCoTuong.Properties.Resources.PhaoDo;
            roundPictureBoxList.Add(phaoDo2);

            /* Tốt đỏ */
            RoundPictureBox totDo1 = new RoundPictureBox(ThongSo.ToaDoTotDo1);
            totDo1.Image = GameCoTuong.Properties.Resources.TotDo;
            roundPictureBoxList.Add(totDo1);

            RoundPictureBox totDo2 = new RoundPictureBox(ThongSo.ToaDoTotDo2);
            totDo2.Image = GameCoTuong.Properties.Resources.TotDo;
            roundPictureBoxList.Add(totDo2);

            RoundPictureBox totDo3 = new RoundPictureBox(ThongSo.ToaDoTotDo3);
            totDo3.Image = GameCoTuong.Properties.Resources.TotDo;
            roundPictureBoxList.Add(totDo3);

            RoundPictureBox totDo4 = new RoundPictureBox(ThongSo.ToaDoTotDo4);
            totDo4.Image = GameCoTuong.Properties.Resources.TotDo;
            roundPictureBoxList.Add(totDo4);

            RoundPictureBox totDo5 = new RoundPictureBox(ThongSo.ToaDoTotDo5);
            totDo5.Image = GameCoTuong.Properties.Resources.TotDo;
            roundPictureBoxList.Add(totDo5);

            foreach (RoundPictureBox element in roundPictureBoxList)
                element.Click += RoundPictureBox_Click;
        }

        private void XepBanCo()
        {
            foreach (RoundPictureBox element in roundPictureBoxList)
                ptbBanCo.Controls.Add(element);
        }

        private void XoaBanCo()
        {
            foreach (Control item in ptbBanCo.Controls)
                ptbBanCo.Controls.Remove(item);
            roundPictureBoxList.Clear();
        }

        private void LamMoiBanCo()
        {
            foreach (RoundPictureBox element in roundPictureBoxList)
                element.Enabled = true;
        }

        private void Highlight(RoundPictureBox highlighted)
        {
            if (highlighted.quanCo.Mau == 1)
                highlighted.BackColor = Color.LightBlue;
            else if (highlighted.quanCo.Mau == 2)
                highlighted.BackColor = Color.LightPink;
        }

        private void Dehighlight()
        {
            foreach (RoundPictureBox element in roundPictureBoxList)
            {
                if (element.quanCo.Mau == 1)
                    element.BackColor = Color.DarkBlue;
                else if (element.quanCo.Mau == 2)
                    element.BackColor = Color.DarkRed;
            }
        }

        private void ShowDestinations(RoundPictureBox quanCoDuocChon) // Vẽ các điểm đích của quân cờ đang được chọn
        {
            if (quanCoDuocChon.quanCo.DanhSachDiemDich.Count != 0)
                quanCoDuocChon.quanCo.DanhSachDiemDich.Clear();
            quanCoDuocChon.quanCo.TinhNuocDi();
            foreach (Point element in quanCoDuocChon.quanCo.DanhSachDiemDich)
            {
                diemBanCo[element.X, element.Y].Visible = true;
                diemBanCo[element.X, element.Y].BringToFront();
                diemBanCo[element.X, element.Y].Click += RoundButton_Click;
            }
        }

        private void HideDestinations()
        {
            foreach (RoundButton element in diemBanCo)
                element.Visible = false;
        }

        private void RoundPictureBox_Click(object sender, EventArgs e)
        {
            RoundPictureBox selected = sender as RoundPictureBox;
            Highlight(selected);
            ShowDestinations(selected);
            selectedCoordinate = selected.quanCo.ToaDo;
            foreach (RoundPictureBox element in roundPictureBoxList)
                element.Enabled = false;
        }

        private void ptbBanCo_Click(object sender, EventArgs e)
        {
            Dehighlight();
            HideDestinations();
            selectedCoordinate = ThongSo.ToaDoNULL;
            foreach (RoundPictureBox element in roundPictureBoxList)
                element.Enabled = true;
        }

        private bool CoQuanCo(Point toaDo)
        {
            foreach (RoundPictureBox element in roundPictureBoxList)
            {
                Point toaDoQuanCoDangXet = ThongSo.ToaDoDonViCuaQuanCo(element.Location);
                if (toaDoQuanCoDangXet == toaDo)
                    return true;
            }
            return false;
        }

        private void LoaiBoQuanCo(Point toaDo)
        {
            RoundPictureBox removed = roundPictureBoxList.Find(element => element.quanCo.ToaDo == toaDo);
            if (removed != null)
            {
                ptbBanCo.Controls.Remove(removed);
                //if (removed.quanCo.Mau == 1)
                //    panel2.Controls.Add(removed);
                //else if (removed.quanCo.Mau == 2)
                //    panel1.Controls.Add(removed);
                roundPictureBoxList.Remove(removed);
            }
        }

        private void RoundButton_Click(object sender, EventArgs e)
        {
            if (selectedCoordinate == ThongSo.ToaDoNULL) return; // THE LEGENDARY GATEKEEPER
            Dehighlight();
            HideDestinations();
            RoundButton clickedRoundButton = sender as RoundButton;
            Point destination = ThongSo.ToaDoDonViCuaDiem(clickedRoundButton.Location);
            RoundPictureBox selected = roundPictureBoxList.Find(element => element.quanCo.ToaDo == selectedCoordinate);
            LoaiBoQuanCo(destination);
            selected.DiChuyen(destination);
            foreach (RoundPictureBox element in roundPictureBoxList)
                element.Enabled = true;
            selectedCoordinate = ThongSo.ToaDoNULL;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XoaBanCo();
            InitializeRoundButton();
            TaoQuanCo();
            XepBanCo();
        }
    }
}