﻿using CoTuongOffline.CoTuong;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CoTuongOffline
{
    public partial class CoTuongOffline : Form
    {
        bool sound;
        System.Media.SoundPlayer player;

        //Camera
        private static Bitmap screenBitmap;
        private static Graphics screenGraphics;

        public CoTuongOffline()
        {
            InitializeComponent();
            PlayMusic();
        }

        public void PlayMusic()
        {
            player = new System.Media.SoundPlayer(Properties.Resources.Nhac3);
            player.PlayLooping();
        }

        private void CoTuongOffline_Load(object sender, EventArgs e)
        {

            BanCo.SetToDefault(lblPheDuocDanh, lblSoLuotDi, btnNewGame, btnUndo);
            BanCo.TaoDiemBanCo(ptbBanCo, DiemBanCo_Click);
            BanCo.TaoQuanCo(QuanCo_Click, ptbBanCo);
            BanCo.RefreshBanCo();
        }
        /* Khi click vào 1 RoundPictureBox quân cờ thì nó sẽ được chọn... */
        private void QuanCo_Click(object sender, EventArgs e)
        {
            BanCo.QuanCoDuocChon = sender as ProgramConfig.RoundPictureBox;
            BanCo.Highlight(ptbBanCo);
            BanCo.HienThiDiemDich();
            foreach (ProgramConfig.RoundPictureBox element in BanCo.Alive_RoundPictureBox) // Khi 1 quân cờ được chọn thì không thể click chọn 1 quân cờ khác ngay lập tức mà phải bỏ chọn nó trước
                element.Enabled = false;
        }

        private void ptbBanCo_Click(object sender, EventArgs e)
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
            Point destination = ProgramConfig.ThongSo.ToaDoDonViCuaDiem(((ProgramConfig.RoundButton)sender).Location); // Lấy tọa độ của RoundButton điểm bàn cờ (điểm đích)

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

        private void btnNewGame_Click(object sender, EventArgs e)
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

        private void ptbLuatChoi_Click(object sender, EventArgs e)
        {
            LuatChoi.Form1 luatChoi = new LuatChoi.Form1();
            luatChoi.Show();
        }

        private void ptrHelp_Click(object sender, EventArgs e)
        {
            LuatChoi.Form1 luatChoi = new LuatChoi.Form1();
            luatChoi.Show();
        }

        private void ptrSound_Click(object sender, EventArgs e)
        {
            if (sound)
            {

                ptrSound.Image = Properties.Resources.SoundOff;
                player.Stop();
            }
            else
            {
                ptrSound.Image = Properties.Resources.SoundOn;
                PlayMusic();
            }
            sound = !sound;
        }
        private void TakeAPicture()
        {
            // Chụp ảnh
            screenBitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                            Screen.PrimaryScreen.Bounds.Height,
                                            PixelFormat.Format32bppArgb);
            Thread.Sleep(500);
            screenGraphics = Graphics.FromImage(screenBitmap);
            screenGraphics.CopyFromScreen(this.Location.X, this.Location.Y,
                                    0, 0, this.Size, CopyPixelOperation.SourceCopy);
        }

        private void SavePicture()
        {
            // Lưu ảnh đã chụp
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "PNG Files (.png)|*.png|All Files (*.*)|*.*";
            saveDialog.FilterIndex = 1;
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                screenBitmap.Save(saveDialog.FileName, ImageFormat.Png);
                MessageBox.Show("Đã lưu ảnh '" + saveDialog.FileName + "' !!", "Thành công");
            }
        }
        private void ptrCamera_Click(object sender, EventArgs e)
        {
            TakeAPicture();
            SavePicture();
        }
    }
}
