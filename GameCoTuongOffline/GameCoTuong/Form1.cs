using GameCoTuong.CoTuong;
using GameCoTuong.ProgramConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BanCo.SetToDefault(lblPheDuocDanh, lblSoLuotDi, btnNewGame, btnUndo);
            BanCo.TaoDiemBanCo(ptbBanCo, DiemBanCo_Click);
            BanCo.TaoQuanCo(QuanCo_Click, ptbBanCo);
            BanCo.RefreshBanCo();
        }

        /* Khi click vào 1 RoundPictureBox quân cờ thì nó sẽ được chọn... */
        private void QuanCo_Click(object sender, EventArgs e)
        {
            BanCo.QuanCoDuocChon = sender as RoundPictureBox;
            BanCo.Highlight(ptbBanCo);
            BanCo.HienThiDiemDich();
            foreach (RoundPictureBox element in BanCo.Alive_RoundPictureBox) // Khi 1 quân cờ được chọn thì không thể click chọn 1 quân cờ khác ngay lập tức mà phải bỏ chọn nó trước
                element.Enabled = false;
        }

        /* Khi đang chọn 1 quân cờ (tức là đã click vào 1 quân cờ trước đó), click vào một điểm bất kì trên bàn cờ sẽ bỏ chọn quân cờ đó */
        private void ptbBanCo_Click(object sender, EventArgs e) // BẢN OFFLINE
        {
            if (BanCo.QuanCoDuocChon != null)
            {
                BanCo.Dehighlight();
                BanCo.AnDiemDich();
                BanCo.RefreshBanCo(); //*Offline*
                BanCo.QuanCoDuocChon = null;
            }
        }

        /* Những gì xảy ra khi click vào một RoundButton điểm bàn cờ để đi đến */
        private void DiemBanCo_Click(object sender, EventArgs e) // BẢN OFFLINE
        {
            if (BanCo.QuanCoDuocChon == null) return; // Dòng code chống lỗi lặp lại event ngoài ý muốn (chưa rõ nguyên nhân của lỗi này). Không được xóa!
            BanCo.Dehighlight(); // chọn nước đi...
            BanCo.AnDiemDich(); // ...thì đồng thời sẽ bỏ chọn quân cờ luôn

            Point departure = new Point(BanCo.QuanCoDuocChon.Quan_Co.ToaDo.X, BanCo.QuanCoDuocChon.Quan_Co.ToaDo.Y);
            Point destination = ThongSo.ToaDoDonViCuaDiem(((RoundButton)sender).Location); // Lấy tọa độ của RoundButton điểm bàn cờ (điểm đích)

            BanCo.LoaiBoQuanCo(destination, ptbBanCo); // Loại bỏ quân cờ ở điểm đích
            BanCo.QuanCoDuocChon.DiChuyen(destination); // Di chuyển quân cờ đến điểm đích

            if (BanCo.HaiTuongDoiMatNhau()) // nước đi không hợp lệ nếu sau nước đi 2 tướng đối mặt nhau => hoàn tác nước đi
            {
                MessageBox.Show("Tướng phe bạn sẽ đối mặt với tướng đối phương sau nước đi này. Hãy chọn một nước đi khác.", "Nước đi không hợp lệ");
                BanCo.QuanCoDuocChon.DiChuyen(departure);
                BanCo.QuanCoDuocChon = null;
                BanCo.TraLaiQuanCo(ptbBanCo, BanCo.QuanCoBiLoai);
                BanCo.RefreshBanCo();
                return;
            }
            if (BanCo.CoChieuTuong(BanCo.PheDoiPhuong())) // nước đi không hợp lệ nếu sau nước đi tướng phe di chuyển bị đối phương chiếu => hoàn tác nước đi
            {
                MessageBox.Show("Tướng phe bạn sẽ gặp nguy sau nước đi này. Hãy chọn một nước đi khác.", "Nước đi không hợp lệ");
                BanCo.QuanCoDuocChon.DiChuyen(departure);
                BanCo.QuanCoDuocChon = null;
                BanCo.TraLaiQuanCo(ptbBanCo, BanCo.QuanCoBiLoai);
                BanCo.RefreshBanCo();
                return;
            }
            if (BanCo.CoChieuTuong(BanCo.PheDuocDanh)) // nếu sau nước đi phe di chuyển chiếu tướng phe đối phương => thông báo cho người chơi
            {
                if (BanCo.PheDoiPhuong() == 1)
                    MessageBox.Show("Phe Xanh hãy đối phó với nước đi này từ phe Đỏ.", "Chiếu tướng!");
                else
                    MessageBox.Show("Phe Đỏ hãy đối phó với nước đi này từ phe Xanh.", "Chiếu tướng!");
            }
            BanCo.HienThiNuocDi(departure, destination, ptbBanCo);
            BanCo.LuuNuocDi(departure, destination);
            BanCo.DoiPhe(lblPheDuocDanh, lblSoLuotDi, btnNewGame, btnUndo); //*Offline*
        }

        // Event cho button 'New game'
        private void btnNewGame_Click(object sender, EventArgs e) // BẢN OFFLINE
        {
            DialogResult result = MessageBox.Show("Bạn muốn bỏ ván đấu này và bắt đầu một ván mới?", "Ván mới", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //Hàm xóa bàn cờ tách thành SetToDefault + XoaBanCo
                BanCo.SetToDefault(lblPheDuocDanh, lblSoLuotDi, btnNewGame, btnUndo);
                BanCo.XoaBanCo(ptbBanCo);
                BanCo.TaoDiemBanCo(ptbBanCo, DiemBanCo_Click);
                BanCo.TaoQuanCo(QuanCo_Click, ptbBanCo);
                BanCo.RefreshBanCo(); //*Offline*
            }
        }

        // Event cho button 'Undo'
        private void btnUndo_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Bạn muốn hoàn tác nước đi vừa rồi?", "Hoàn tác nước đi", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                btnUndo.Enabled = false;
                BanCo.Dehighlight();
                BanCo.AnDiemDich();
                BanCo.HoanTac(ptbBanCo);
                BanCo.DoiPhe(lblPheDuocDanh, lblSoLuotDi, btnNewGame);
                BanCo.HienThiNuocDiTruoc(ptbBanCo);
            }
        }
    }
}