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
            InitializeRoundButtons();
            TaoQuanCo();
            XepBanCo();
        }

        private void TaoQuanCo()
        {
            /* Tướng xanh */
            RoundPictureBox tuongXanh = new RoundPictureBox(ThongSo.ToaDoTuongXanh);
            roundPictureBoxList.Add(tuongXanh);

            /* Xe xanh */
            RoundPictureBox xeXanh1 = new RoundPictureBox(ThongSo.ToaDoXeXanh1);
            roundPictureBoxList.Add(xeXanh1);

            RoundPictureBox xeXanh2 = new RoundPictureBox(ThongSo.ToaDoXeXanh2);
            roundPictureBoxList.Add(xeXanh2);

            /* Mã xanh */
            RoundPictureBox maXanh1 = new RoundPictureBox(ThongSo.ToaDoMaXanh1);
            roundPictureBoxList.Add(maXanh1);

            RoundPictureBox maXanh2 = new RoundPictureBox(ThongSo.ToaDoMaXanh2);
            roundPictureBoxList.Add(maXanh2);

            /* Tịnh xanh */
            RoundPictureBox tinhXanh1 = new RoundPictureBox(ThongSo.ToaDoTinhXanh1);
            roundPictureBoxList.Add(tinhXanh1);

            RoundPictureBox tinhXanh2 = new RoundPictureBox(ThongSo.ToaDoTinhXanh2);
            roundPictureBoxList.Add(tinhXanh2);

            /* Sĩ xanh */
            RoundPictureBox siXanh1 = new RoundPictureBox(ThongSo.ToaDoSiXanh1);
            roundPictureBoxList.Add(siXanh1);

            RoundPictureBox siXanh2 = new RoundPictureBox(ThongSo.ToaDoSiXanh2);
            roundPictureBoxList.Add(siXanh2);

            /* Pháo xanh */
            RoundPictureBox phaoXanh1 = new RoundPictureBox(ThongSo.ToaDoPhaoXanh1);
            roundPictureBoxList.Add(phaoXanh1);

            RoundPictureBox phaoXanh2 = new RoundPictureBox(ThongSo.ToaDoPhaoXanh2);
            roundPictureBoxList.Add(phaoXanh2);

            /* Tốt xanh */
            RoundPictureBox totXanh1 = new RoundPictureBox(ThongSo.ToaDoTotXanh1);
            roundPictureBoxList.Add(totXanh1);

            RoundPictureBox totXanh2 = new RoundPictureBox(ThongSo.ToaDoTotXanh2);
            roundPictureBoxList.Add(totXanh2);

            RoundPictureBox totXanh3 = new RoundPictureBox(ThongSo.ToaDoTotXanh3);
            roundPictureBoxList.Add(totXanh3);

            RoundPictureBox totXanh4 = new RoundPictureBox(ThongSo.ToaDoTotXanh4);
            roundPictureBoxList.Add(totXanh4);

            RoundPictureBox totXanh5 = new RoundPictureBox(ThongSo.ToaDoTotXanh5);
            roundPictureBoxList.Add(totXanh5);

            /* Tướng đỏ */
            RoundPictureBox tuongDo = new RoundPictureBox(ThongSo.ToaDoTuongDo);
            roundPictureBoxList.Add(tuongDo);

            /* Xe đỏ */
            RoundPictureBox xeDo1 = new RoundPictureBox(ThongSo.ToaDoXeDo1);
            roundPictureBoxList.Add(xeDo1);

            RoundPictureBox xeDo2 = new RoundPictureBox(ThongSo.ToaDoXeDo2);
            roundPictureBoxList.Add(xeDo2);

            /* Mã đỏ */
            RoundPictureBox maDo1 = new RoundPictureBox(ThongSo.ToaDoMaDo1);
            roundPictureBoxList.Add(maDo1);

            RoundPictureBox maDo2 = new RoundPictureBox(ThongSo.ToaDoMaDo2);
            roundPictureBoxList.Add(maDo2);

            /* Tịnh đỏ */
            RoundPictureBox tinhDo1 = new RoundPictureBox(ThongSo.ToaDoTinhDo1);
            roundPictureBoxList.Add(tinhDo1);

            RoundPictureBox tinhDo2 = new RoundPictureBox(ThongSo.ToaDoTinhDo2);
            roundPictureBoxList.Add(tinhDo2);

            /* Sĩ đỏ */
            RoundPictureBox siDo1 = new RoundPictureBox(ThongSo.ToaDoSiDo1);
            roundPictureBoxList.Add(siDo1);

            RoundPictureBox siDo2 = new RoundPictureBox(ThongSo.ToaDoSiDo2);
            roundPictureBoxList.Add(siDo2);

            /* Pháo đỏ */
            RoundPictureBox phaoDo1 = new RoundPictureBox(ThongSo.ToaDoPhaoDo1);
            roundPictureBoxList.Add(phaoDo1);

            RoundPictureBox phaoDo2 = new RoundPictureBox(ThongSo.ToaDoPhaoDo2);
            roundPictureBoxList.Add(phaoDo2);

            /* Tốt đỏ */
            RoundPictureBox totDo1 = new RoundPictureBox(ThongSo.ToaDoTotDo1);
            roundPictureBoxList.Add(totDo1);

            RoundPictureBox totDo2 = new RoundPictureBox(ThongSo.ToaDoTotDo2);
            roundPictureBoxList.Add(totDo2);

            RoundPictureBox totDo3 = new RoundPictureBox(ThongSo.ToaDoTotDo3);
            roundPictureBoxList.Add(totDo3);

            RoundPictureBox totDo4 = new RoundPictureBox(ThongSo.ToaDoTotDo4);
            roundPictureBoxList.Add(totDo4);

            RoundPictureBox totDo5 = new RoundPictureBox(ThongSo.ToaDoTotDo5);
            roundPictureBoxList.Add(totDo5);

            foreach (RoundPictureBox element in roundPictureBoxList)
                element.Click += RoundPictureBox_Click;
        }

        private void XepBanCo()
        {
            foreach (RoundPictureBox element in roundPictureBoxList)
            {
                ptbBanCo.Controls.Add(element);
            }
        }

        private void XoaBanCo()
        {
            foreach (RoundPictureBox element in roundPictureBoxList)
            {
                ptbBanCo.Controls.Remove(element);
            }
        }

        private void LamMoiBanCo()
        {
            //XoaBanCo();
            //XepBanCo();
            foreach (RoundPictureBox element in roundPictureBoxList)
                element.Enabled = true;
        }

        private void InitializeRoundButtons()
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
            if (quanCoDuocChon.quanCo.DanhSachDiemDich.Count == 0)
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
                roundPictureBoxList.Remove(removed);
            }
        }

        private void RoundButton_Click(object sender, EventArgs e)
        {
            if (selectedCoordinate == ThongSo.ToaDoNULL) return; // The LEGENDARY GATEKEEPER
            Dehighlight();
            HideDestinations();
            RoundButton clickedRoundButton = sender as RoundButton;
            Point destination = ThongSo.ToaDoDonViCuaDiem(clickedRoundButton.Location);
            RoundPictureBox selected = roundPictureBoxList.Find(element => element.quanCo.ToaDo == selectedCoordinate);
            LoaiBoQuanCo(destination);
            selected.DiChuyen(destination);
            selectedCoordinate = ThongSo.ToaDoNULL;
            LamMoiBanCo();
        }
    }
}