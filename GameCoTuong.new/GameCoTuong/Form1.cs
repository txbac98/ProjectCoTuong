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
        #region global variables in 'Form1'

        RoundButton[,] diemBanCo = new RoundButton[9, 10]; // Mảng 2 chiều chứa 90 điểm bàn cờ
        List<RoundPictureBox> danhSachQuanCo = new List<RoundPictureBox>(); // List chứa tất cả các quân cờ còn sống
        RoundPictureBox quanCoBiLoai = null; // quân cờ vừa bị loại ở nước đi trước đó, nếu di chuyển thành công thì quanCoBiLoai không cần dùng đến => gán lại về null
        Point toaDoDuocChon = ThongSo.ToaDoNULL; // Tọa độ của quân cờ đang được chọn (được click vào), khi không có quân cờ nào đang được chọn thì bằng (-1, -1)
        int pheDuocDanh = 2; // Phe hiện tại đang được đánh (1 - Xanh, 2 - Đỏ). Phe Đỏ được đánh đầu tiên
        int soLuotDi = 0; // Số lượt đã đi từ đầu ván cờ

        #endregion

        private void Form1_Load(object sender, EventArgs e) { }

        public Form1()
        {
            InitializeComponent();
            TaoDiemBanCo();
            TaoQuanCo();
            XepBanCo();
            RefreshBanCo();
        }

        /* Tạo 90 RoundButton điểm bàn cờ nhưng chưa hiển thị.
         * Khi click vào 1 RoundPictureBox quân cờ thì những điểm bàn cờ ở những tọa độ trong danh sách điểm đích của quân đó sẽ hiện ra */
        private void TaoDiemBanCo()
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
                        Visible = false // Ẩn điểm bàn cờ sau khi khởi tạo
                    };
                    ptbBanCo.Controls.Add(diemBanCo[x, y]);
                }
            }
        }

        /* Tạo 32 RoundPictureBox quân cờ và đưa chúng vào danh sách các quân cờ để quản lý */
        private void TaoQuanCo()
        {
            /* Tướng xanh */
            RoundPictureBox tuongXanh = new RoundPictureBox(ThongSo.ToaDoTuongXanh);
            tuongXanh.Image = GameCoTuong.Properties.Resources.TuongXanh;
            danhSachQuanCo.Add(tuongXanh);

            /* Xe xanh */
            RoundPictureBox xeXanh1 = new RoundPictureBox(ThongSo.ToaDoXeXanh1);
            xeXanh1.Image = GameCoTuong.Properties.Resources.XeXanh;
            danhSachQuanCo.Add(xeXanh1);

            RoundPictureBox xeXanh2 = new RoundPictureBox(ThongSo.ToaDoXeXanh2);
            xeXanh2.Image = GameCoTuong.Properties.Resources.XeXanh;
            danhSachQuanCo.Add(xeXanh2);

            /* Mã xanh */
            RoundPictureBox maXanh1 = new RoundPictureBox(ThongSo.ToaDoMaXanh1);
            maXanh1.Image = GameCoTuong.Properties.Resources.MaXanh;
            danhSachQuanCo.Add(maXanh1);

            RoundPictureBox maXanh2 = new RoundPictureBox(ThongSo.ToaDoMaXanh2);
            maXanh2.Image = GameCoTuong.Properties.Resources.MaXanh;
            danhSachQuanCo.Add(maXanh2);

            /* Tịnh xanh */
            RoundPictureBox tinhXanh1 = new RoundPictureBox(ThongSo.ToaDoTinhXanh1);
            tinhXanh1.Image = GameCoTuong.Properties.Resources.TinhXanh;
            danhSachQuanCo.Add(tinhXanh1);

            RoundPictureBox tinhXanh2 = new RoundPictureBox(ThongSo.ToaDoTinhXanh2);
            tinhXanh2.Image = GameCoTuong.Properties.Resources.TinhXanh;
            danhSachQuanCo.Add(tinhXanh2);

            /* Sĩ xanh */
            RoundPictureBox siXanh1 = new RoundPictureBox(ThongSo.ToaDoSiXanh1);
            siXanh1.Image = GameCoTuong.Properties.Resources.SiXanh;
            danhSachQuanCo.Add(siXanh1);

            RoundPictureBox siXanh2 = new RoundPictureBox(ThongSo.ToaDoSiXanh2);
            siXanh2.Image = GameCoTuong.Properties.Resources.SiXanh;
            danhSachQuanCo.Add(siXanh2);

            /* Pháo xanh */
            RoundPictureBox phaoXanh1 = new RoundPictureBox(ThongSo.ToaDoPhaoXanh1);
            phaoXanh1.Image = GameCoTuong.Properties.Resources.PhaoXanh;
            danhSachQuanCo.Add(phaoXanh1);

            RoundPictureBox phaoXanh2 = new RoundPictureBox(ThongSo.ToaDoPhaoXanh2);
            phaoXanh2.Image = GameCoTuong.Properties.Resources.PhaoXanh;
            danhSachQuanCo.Add(phaoXanh2);

            /* Tốt xanh */
            RoundPictureBox totXanh1 = new RoundPictureBox(ThongSo.ToaDoTotXanh1);
            totXanh1.Image = GameCoTuong.Properties.Resources.TotXanh;
            danhSachQuanCo.Add(totXanh1);

            RoundPictureBox totXanh2 = new RoundPictureBox(ThongSo.ToaDoTotXanh2);
            totXanh2.Image = GameCoTuong.Properties.Resources.TotXanh;
            danhSachQuanCo.Add(totXanh2);

            RoundPictureBox totXanh3 = new RoundPictureBox(ThongSo.ToaDoTotXanh3);
            totXanh3.Image = GameCoTuong.Properties.Resources.TotXanh;
            danhSachQuanCo.Add(totXanh3);

            RoundPictureBox totXanh4 = new RoundPictureBox(ThongSo.ToaDoTotXanh4);
            totXanh4.Image = GameCoTuong.Properties.Resources.TotXanh;
            danhSachQuanCo.Add(totXanh4);

            RoundPictureBox totXanh5 = new RoundPictureBox(ThongSo.ToaDoTotXanh5);
            totXanh5.Image = GameCoTuong.Properties.Resources.TotXanh;
            danhSachQuanCo.Add(totXanh5);

            /* Tướng đỏ */
            RoundPictureBox tuongDo = new RoundPictureBox(ThongSo.ToaDoTuongDo);
            tuongDo.Image = GameCoTuong.Properties.Resources.TuongDo;
            danhSachQuanCo.Add(tuongDo);

            /* Xe đỏ */
            RoundPictureBox xeDo1 = new RoundPictureBox(ThongSo.ToaDoXeDo1);
            xeDo1.Image = GameCoTuong.Properties.Resources.XeDo;
            danhSachQuanCo.Add(xeDo1);

            RoundPictureBox xeDo2 = new RoundPictureBox(ThongSo.ToaDoXeDo2);
            xeDo2.Image = GameCoTuong.Properties.Resources.XeDo;
            danhSachQuanCo.Add(xeDo2);

            /* Mã đỏ */
            RoundPictureBox maDo1 = new RoundPictureBox(ThongSo.ToaDoMaDo1);
            maDo1.Image = GameCoTuong.Properties.Resources.MaDo;
            danhSachQuanCo.Add(maDo1);

            RoundPictureBox maDo2 = new RoundPictureBox(ThongSo.ToaDoMaDo2);
            maDo2.Image = GameCoTuong.Properties.Resources.MaDo;
            danhSachQuanCo.Add(maDo2);

            /* Tịnh đỏ */
            RoundPictureBox tinhDo1 = new RoundPictureBox(ThongSo.ToaDoTinhDo1);
            tinhDo1.Image = GameCoTuong.Properties.Resources.TinhDo;
            danhSachQuanCo.Add(tinhDo1);

            RoundPictureBox tinhDo2 = new RoundPictureBox(ThongSo.ToaDoTinhDo2);
            tinhDo2.Image = GameCoTuong.Properties.Resources.TinhDo;
            danhSachQuanCo.Add(tinhDo2);

            /* Sĩ đỏ */
            RoundPictureBox siDo1 = new RoundPictureBox(ThongSo.ToaDoSiDo1);
            siDo1.Image = GameCoTuong.Properties.Resources.SiDo;
            danhSachQuanCo.Add(siDo1);

            RoundPictureBox siDo2 = new RoundPictureBox(ThongSo.ToaDoSiDo2);
            siDo2.Image = GameCoTuong.Properties.Resources.SiDo;
            danhSachQuanCo.Add(siDo2);

            /* Pháo đỏ */
            RoundPictureBox phaoDo1 = new RoundPictureBox(ThongSo.ToaDoPhaoDo1);
            phaoDo1.Image = GameCoTuong.Properties.Resources.PhaoDo;
            danhSachQuanCo.Add(phaoDo1);

            RoundPictureBox phaoDo2 = new RoundPictureBox(ThongSo.ToaDoPhaoDo2);
            phaoDo2.Image = GameCoTuong.Properties.Resources.PhaoDo;
            danhSachQuanCo.Add(phaoDo2);

            /* Tốt đỏ */
            RoundPictureBox totDo1 = new RoundPictureBox(ThongSo.ToaDoTotDo1);
            totDo1.Image = GameCoTuong.Properties.Resources.TotDo;
            danhSachQuanCo.Add(totDo1);

            RoundPictureBox totDo2 = new RoundPictureBox(ThongSo.ToaDoTotDo2);
            totDo2.Image = GameCoTuong.Properties.Resources.TotDo;
            danhSachQuanCo.Add(totDo2);

            RoundPictureBox totDo3 = new RoundPictureBox(ThongSo.ToaDoTotDo3);
            totDo3.Image = GameCoTuong.Properties.Resources.TotDo;
            danhSachQuanCo.Add(totDo3);

            RoundPictureBox totDo4 = new RoundPictureBox(ThongSo.ToaDoTotDo4);
            totDo4.Image = GameCoTuong.Properties.Resources.TotDo;
            danhSachQuanCo.Add(totDo4);

            RoundPictureBox totDo5 = new RoundPictureBox(ThongSo.ToaDoTotDo5);
            totDo5.Image = GameCoTuong.Properties.Resources.TotDo;
            danhSachQuanCo.Add(totDo5);

            foreach (RoundPictureBox element in danhSachQuanCo) // Gắn cho mỗi RoundPictureBox quân cờ 1 sự kiện click
                element.Click += QuanCo_Click;
        }

        /* Đưa các RoundPictureBox quân cờ từ danh sách quân cờ vào bàn cờ */
        private void XepBanCo()
        {
            foreach (RoundPictureBox element in danhSachQuanCo)
                ptbBanCo.Controls.Add(element);
        }

        /* Làm cho các RoundPictureBox quân cờ trên bàn cờ có thể click dễ dàng được sau mỗi nước đi */
        private void RefreshBanCo()
        {
            foreach (RoundPictureBox element in danhSachQuanCo)
            {
                if (element.quanCo.Mau == pheDuocDanh)
                    element.Enabled = true;
                else element.Enabled = false;
            }
        }

        private void SetToDefault()
        {
            quanCoBiLoai = null;
            toaDoDuocChon = ThongSo.ToaDoNULL;

            pheDuocDanh = 2;
            label2.Text = "Phe Đỏ được đi đầu tiên";
            label2.ForeColor = Color.DarkRed;

            soLuotDi = 0;
            label3.Text = soLuotDi.ToString();
            button1.Enabled = false;
        }

        /* Xóa các RoundPictureBox quân cờ khỏi bàn cờ và danh sách quân cờ */
        private void XoaBanCo()
        {
            SetToDefault();
            ptbBanCo.Controls.Clear();
            BanCo.tuongXanh = null;
            BanCo.tuongDo = null;
            BanCo.alive.Clear();
            danhSachQuanCo.Clear();
        }

        /* Hai hàm tiếp theo là 2 hàm không quan trọng lắm */
        /* Đổi màu nền (BackColor) của RoundPictureBox quân cờ được click vào tùy vào màu quân cờ */
        private void Highlight(RoundPictureBox highlighted) { }

        /* Trả lại BackColor nguyên thủy cho tất cả RoundPictureBox quân cờ */
        private void Dehighlight() { }

        /* Tính toán và hiển thị tất cả điểm đích của quân cờ được chọn */
        private void HienThiDiemDich(RoundPictureBox quanCoDuocChon) // Vẽ các điểm đích của quân cờ đang được chọn
        {
            if (quanCoDuocChon.quanCo.danhSachDiemDich.Count != 0)
                quanCoDuocChon.quanCo.danhSachDiemDich.Clear();
            quanCoDuocChon.quanCo.TinhNuocDi();
            foreach (Point element in quanCoDuocChon.quanCo.danhSachDiemDich)
            {
                QuanCo target = BanCo.alive.Find(element1 => element1.Mau != quanCoDuocChon.quanCo.Mau && element1.ToaDo == element);
                if (target != null)
                    diemBanCo[element.X, element.Y].BackColor = Color.Red;
                diemBanCo[element.X, element.Y].Visible = true;
                diemBanCo[element.X, element.Y].BringToFront();
                diemBanCo[element.X, element.Y].Click += DiemBanCo_Click;
            }
        }

        /* Ẩn tất cả các điểm đích đang hiển thị trên bàn cờ */
        private void AnDiemDich()
        {
            foreach (RoundButton element in diemBanCo)
            {
                element.Visible = false;
                element.BackColor = Color.Yellow;
            }
        }

        /* Loại bỏ quân cờ tại điểm đích */
        private void LoaiBoQuanCo(Point toaDo)
        {
            quanCoBiLoai = danhSachQuanCo.Find(element => element.quanCo.Mau != pheDuocDanh && element.quanCo.ToaDo == toaDo);
            if (quanCoBiLoai != null)
            {
                ptbBanCo.Controls.Remove(quanCoBiLoai);
                danhSachQuanCo.Remove(quanCoBiLoai);
                BanCo.alive.Remove(quanCoBiLoai.quanCo);
            }
        }

        /* Trả lại quân cờ vừa bị loại khỏi bàn cờ */
        private void TraLaiQuanCo()
        {
            if (quanCoBiLoai != null)
            {
                BanCo.alive.Add(quanCoBiLoai.quanCo);
                danhSachQuanCo.Add(quanCoBiLoai);
                ptbBanCo.Controls.Add(quanCoBiLoai);
                quanCoBiLoai = null;
            }
        }

        /* Di chuyển 'pieceToMove' với destination là tọa độ đích đến */
        private void DiChuyen(RoundPictureBox pieceToMove, Point destination)
        {
            LoaiBoQuanCo(destination);
            pieceToMove.DenViTri(destination);
        }

        /* Hoàn tác lại nước đi trước đó của 'pieceToTakeBack' với previousLocation là tọa độ trước khi di chuyển của pieceToTakeBack */
        private void QuayLai(RoundPictureBox pieceToTakeBack, Point previousLocation)
        {
            pieceToTakeBack.DenViTri(previousLocation);
            TraLaiQuanCo();
            toaDoDuocChon = ThongSo.ToaDoNULL;
            RefreshBanCo();
        }

        /* Kiểm tra xem 2 tướng có đối mặt nhau không */
        private bool HaiTuongDoiMatNhau()
        {
            if (BanCo.tuongXanh.ToaDo.X == BanCo.tuongDo.ToaDo.X) // nếu 2 tướng cùng hoành độ (thẳng hàng) ...
            {
                int X = BanCo.tuongXanh.ToaDo.X;
                Point diemGiuaHaiTuong;
                for (int Y = BanCo.tuongXanh.ToaDo.Y + 1; Y < BanCo.tuongDo.ToaDo.Y; Y++) // ... thì xét xem giữa 2 tướng có quân cờ nào không
                {
                    diemGiuaHaiTuong = new Point(X, Y);
                    if (BanCo.CoQuanCoTaiDay(diemGiuaHaiTuong))
                        return false; // nếu có 1 quân cờ ở giữa 2 tướng thì 2 tướng không đối mặt nhau
                }
                return true; // nếu không có quân cờ nào ở giữa 2 tướng thì 2 tướng đối mặt nhau
            }
            return false; // nếu 2 tướng không cùng hoành độ thì 2 tướng không đối mặt nhau
        }

        /* Kiểm tra 1 phe ('pheChieuTuong') có đang chiếu tướng phe còn lại hay không */
        private bool ChieuTuong(int pheChieuTuong)
        {
            foreach (QuanCo element in BanCo.alive)
            {
                if (element.Mau == pheChieuTuong)
                {
                    if (element.danhSachDiemDich.Count != 0)
                        element.danhSachDiemDich.Clear();
                    element.TinhNuocDi();
                    QuanCo target;
                    foreach (Point element1 in element.danhSachDiemDich)
                    {
                        target = BanCo.alive.Find(element2 => element2.Mau != pheChieuTuong && element2.ToaDo == element1);
                        if (target != null)
                        {
                            if (target == BanCo.tuongXanh || target == BanCo.tuongDo)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        /* Tìm phe đối phương */
        private int PheDoiPhuong()
        {
            if (pheDuocDanh == 1) return 2;
            return 1;
        }

        /* Đổi phe sau mỗi nước đi */
        private void DoiPhe()
        {
            quanCoBiLoai = null;
            toaDoDuocChon = ThongSo.ToaDoNULL;
            soLuotDi++;
            label3.Text = soLuotDi.ToString();
            if (pheDuocDanh == 1)
            {
                pheDuocDanh = 2;
                label2.ForeColor = Color.DarkRed;
                label2.Text = "Lượt đi của phe Đỏ";
            }
            else
            {
                pheDuocDanh = 1;
                label2.ForeColor = Color.DarkBlue;
                label2.Text = "Lượt đi của phe Xanh";
            }
            RefreshBanCo();

            if (soLuotDi != 0 && !button1.Enabled)
                button1.Enabled = true;
        }

        /* Khi click vào 1 RoundPictureBox quân cờ thì nó sẽ được chọn... */
        private void QuanCo_Click(object sender, EventArgs e)
        {
            RoundPictureBox selected = sender as RoundPictureBox;
            Highlight(selected);
            HienThiDiemDich(selected);
            toaDoDuocChon = selected.quanCo.ToaDo; // Lấy tọa độ của quân cờ được chọn
            foreach (RoundPictureBox element in danhSachQuanCo) // Khi 1 quân cờ được chọn thì không thể click chọn 1 quân cờ khác ngay lập tức mà phải bỏ chọn nó trước
                element.Enabled = false;
        }

        /* Khi đang chọn 1 quân cờ (tức là đã click vào 1 quân cờ trước đó), click vào một điểm bất kì trên bàn cờ sẽ bỏ chọn quân cờ đó */
        private void ptbBanCo_Click(object sender, EventArgs e)
        {
            Dehighlight();
            AnDiemDich();
            RefreshBanCo();
            toaDoDuocChon = ThongSo.ToaDoNULL;
        }

        /* Những gì xảy ra khi click vào một RoundButton điểm bàn cờ để đi đến */
        private void DiemBanCo_Click(object sender, EventArgs e)
        {
            if (toaDoDuocChon == ThongSo.ToaDoNULL)  // THE LEGENDARY GATEKEEPER from evil bugs
                return; // Dòng code chống lỗi lặp lại event (chưa rõ nguyên nhân của lỗi này)

            Dehighlight(); // Khi click vào 1 điểm đích để đi tới
            AnDiemDich(); // thì đồng thời sẽ bỏ chọn quân cờ luôn
            RoundButton clickedRoundButton = sender as RoundButton;
            Point destination = ThongSo.ToaDoDonViCuaDiem(clickedRoundButton.Location); // Lấy tọa độ của RoundButton điểm bàn cờ (điểm đích)
            RoundPictureBox selected = danhSachQuanCo.Find(element => element.quanCo.ToaDo == toaDoDuocChon); // Tìm ra RoundPictureBox quân cờ trong danh sách quân cờ

            DiChuyen(selected, destination); // Di chuyển quân cờ đến điểm đích

            if (HaiTuongDoiMatNhau()) // nước đi không hợp lệ nếu sau nước đi 2 tướng đối mặt nhau => hoàn tác nước đi
            {
                MessageBox.Show("NƯỚC ĐI KHÔNG HỢP LỆ!\nTướng phe bạn sẽ đối mặt với tướng đối phương sau nước đi này. Hãy chọn một nước đi khác.");
                QuayLai(selected, toaDoDuocChon);
                return;
            }

            if (ChieuTuong(PheDoiPhuong())) // nước đi không hợp lệ nếu sau nước đi tướng phe di chuyển bị đối phương chiếu => hoàn tác nước đi
            {
                MessageBox.Show("NƯỚC ĐI KHÔNG ỔN TÍ NÀO!\nTướng phe bạn sẽ gặp nguy sau nước đi này. Hãy chọn một nước đi khác.");
                QuayLai(selected, toaDoDuocChon);
                return;
            }

            if (ChieuTuong(pheDuocDanh)) // nếu sau nước đi phe di chuyển chiếu tướng phe đối phương => thông báo cho người chơi
            {
                if (PheDoiPhuong() == 1)
                    MessageBox.Show("Phe Đỏ CHIẾU TƯỚNG! Phe Xanh hãy đối phó.");
                else
                    MessageBox.Show("Phe Xanh CHIẾU TƯỚNG! Phe Đỏ hãy đối phó.");
            }
            DoiPhe();
        }

        //private void roundPictureBox1_Click(object sender, EventArgs e)
        //{
        //    if (soLuotDi != 0)
        //    {

        //    }
        //}

        /* Event của nút 'Restart game'- nhưng chưa làm được chức năng này */
        private void button1_Click(object sender, EventArgs e)
        {
            XoaBanCo();
            TaoDiemBanCo();
            TaoQuanCo();
            XepBanCo();
            RefreshBanCo();
        }
    }
}