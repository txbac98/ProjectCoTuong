﻿using GameCoTuong.CoTuong;
using GameCoTuong.LAN;
using GameCoTuong.ProgramConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GameCoTuong.LAN.SocketData;

namespace GameCoTuong
{

    public partial class Form1 : Form
    {
        private SocketManager socketManager;
        bool sound;
        System.Media.SoundPlayer player;

        //Camera
        private static Bitmap screenBitmap;
        private static Graphics screenGraphics;

        //Chat
        public static int soKT = 30, doDai = 50;

        public Form1()
        {
            InitializeComponent();
            PlayMusic();
        }
        public void PlayMusic()
        {
            player = new System.Media.SoundPlayer(Properties.Resources.Nhac3);
            player.Play();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblName.Text = BanCo.Name;
            txbIP.Enabled = (BanCo.PheTa == 1) ? true : false;
            btnLAN.Text = (BanCo.PheTa == 2) ? "Tạo phòng" : "Kết nối";

            BanCo.PtbBanCo = ptbBanCo;
            BanCo.LblPheDuocDanh = lblPheDuocDanh;
            BanCo.LblSoLuotDi = lblSoLuotDi;
            BanCo.BtnNewGame = btnNewGame;
            BanCo.BtnUndo = btnUndo;
            BanCo.BtnSurrender = btnSurrender;
            BanCo.TimerRemainingTime = timerRemainingTime;
            BanCo.LblRemainingTime = lblRemainingTime;
            BanCo.LblOpponentRemainingTime = lblOpponentRemainingTime;
            BanCo.BtnReady = btnReady;
            socketManager = new SocketManager();

            BanCo.SetToDefault();
            BanCo.TaoDiemBanCo(DiemBanCo_Click);
            BanCo.TaoQuanCo(QuanCo_Click);
            BanCo.RefreshBanCo();
        }

        /* Khi click vào 1 RoundPictureBox quân cờ thì nó sẽ được chọn... */
        private void QuanCo_Click(object sender, EventArgs e)
        {
            BanCo.QuanCoDuocChon = sender as RoundPictureBox;
            BanCo.Highlight(ptbBanCo);
            BanCo.HienThiDiemDich();
            BanCo.DisableBanCo(); // Vô hiệu hóa những quân cờ khác
        }

        /* Khi đang chọn 1 quân cờ (tức là đã click vào 1 quân cờ trước đó), click vào một điểm bất kì trên bàn cờ sẽ bỏ chọn quân cờ đó */
        private void ptbBanCo_Click(object sender, EventArgs e) // BẢN OFFLINE
        {
            if (BanCo.QuanCoDuocChon != null)
            {
                BanCo.Dehighlight();
                BanCo.AnDiemDich();
                BanCo.RefreshBanCo();
                BanCo.QuanCoDuocChon = null;
            }
        }

        /* Những gì xảy ra khi click vào một RoundButton điểm bàn cờ để đi đến */
        private void DiemBanCo_Click(object sender, EventArgs e) // BẢN OFFLINE
        {
            if (BanCo.QuanCoDuocChon == null) return; // Dòng code chống lỗi lặp lại event ngoài ý muốn (chưa rõ nguyên nhân của lỗi này). Không được xóa!
            BanCo.Dehighlight(); // chọn nước đi...
            BanCo.AnDiemDich(); // ...thì đồng thời sẽ bỏ chọn quân cờ luôn
            try
            {
                socketManager.Send(new SocketData((int)SocketCommand.TEST_CONNECTION));
            }
            catch
            {
                MessageBox.Show("Chưa kết nối hoặc đã mất kết nối với đối thủ.");
                BanCo.RefreshBanCo();
                BanCo.QuanCoDuocChon = null;
                return;
            }

            if (BanCo.TaDanh(BanCo.QuanCoDuocChon.Quan_Co.ToaDo, ThongSo.ToaDoDonViCuaDiem(((RoundButton)sender).Location)))
            {
                timerRemainingTime.Stop();
                socketManager.Send(new SocketData((int)SocketCommand.SEND_MOVE, string.Empty,
                    new Point(8 - BanCo.ToaDoDiTruoc.X, 9 - BanCo.ToaDoDiTruoc.Y), new Point(8 - BanCo.ToaDoDenTruoc.X, 9 - BanCo.ToaDoDenTruoc.Y)));
            }
            Listen();
        }

        // Event cho button 'New game'
        private void btnNewGame_Click(object sender, EventArgs e) // BẢN OFFLINE
        {
            DialogResult result = MessageBox.Show("Bạn muốn xin hòa với đối thủ và bắt đầu một ván mới?", "Cầu hòa", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                btnNewGame.Enabled = false;
                socketManager.Send(new SocketData((int)SocketCommand.ASK_NEW_GAME));
            }
        }

        // Event cho button 'Undo'
        private void btnUndo_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn xin đi lại nước đi vừa rồi?", "Xin đi lại", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (btnUndo.Enabled == true)
                {
                    btnUndo.Enabled = false;
                    socketManager.Send(new SocketData((int)SocketCommand.ASK_UNDO));
                }
                else
                {
                    MessageBox.Show("Bạn không còn quyền xin đi lại. Đối phương đã đánh trước khi bạn gửi yêu cầu.", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void btnSurrender_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn thực sự muốn xin hàng đối phương? Bạn sẽ thua ván cờ này.", "Xin hàng", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                btnSurrender.Enabled = false;
                TakeAPicture();
                socketManager.Send(new SocketData((int)SocketCommand.SURRENDER));
                lblOpponentScore.Text = (int.Parse(lblOpponentScore.Text) + 1).ToString();
                BanCo.SetToDefault();
                BanCo.XoaBanCo();
                BanCo.TaoDiemBanCo(DiemBanCo_Click);
                BanCo.TaoQuanCo(QuanCo_Click);
                BanCo.RefreshBanCo();
                MessageBox.Show("Bạn đã thua ván cờ này. Bắt đầu ván mới.", "Kết thúc ván cờ", MessageBoxButtons.OK);
                if (MessageBox.Show("Bạn có muốn lưu hình ảnh gần nhất ván cờ vừa rồi?", "Lưu hình ảnh", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SavePicture();
                }
            }
        }

        private void btnLAN_Click(object sender, EventArgs e)
        {
            btnLAN.Enabled = false;
            socketManager.IP = txbIP.Text;

            if (!socketManager.ConnectToServer())
            {
                socketManager.isServer = true;
                socketManager.CreateServer();
            }
            else
            {
                socketManager.isServer = false;
                Listen();
            }
        }

        private void Listen()
        {
            Thread listenThread = new Thread(() =>
            {
                try
                {
                    SocketData receivedData = (SocketData)socketManager.Receive();
                    ProcessSocketData(receivedData);
                }
                catch { }
            })
            {
                IsBackground = true
            };
            listenThread.Start();
        }

        private void ProcessSocketData(SocketData data)
        {
            switch (data.Command)
            {
                case (int)SocketCommand.SEND_MOVE:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        timerRemainingTime.Start();
                        BanCo.DoiPhuongDanh(data.DepartureLocation, data.DestinationLocation);
                    }));
                    break;
                case (int)SocketCommand.NOTIFY:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        this.Enabled = false;
                        MessageBox.Show(data.Message, "Thông báo", MessageBoxButtons.OK);
                        this.Enabled = true;
                    }));
                    break;
                case (int)SocketCommand.ASK_NEW_GAME:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        this.Enabled = false;
                        timerRemainingTime.Stop();
                        DialogResult resultNewGame = MessageBox.Show("Đối phương xin hòa và bắt đầu một ván mới. Bạn có có đồng ý không?", "Cầu hòa", MessageBoxButtons.YesNo);
                        if (resultNewGame == DialogResult.Yes)
                        {
                            TakeAPicture();
                            socketManager.Send(new SocketData((int)SocketCommand.ACCEPT_NEW_GAME));
                            BanCo.SetToDefault();
                            BanCo.XoaBanCo();
                            BanCo.TaoDiemBanCo(DiemBanCo_Click);
                            BanCo.TaoQuanCo(QuanCo_Click);
                            BanCo.RefreshBanCo();
                            if (MessageBox.Show("Bạn có muốn lưu hình ảnh gần nhất ván cờ vừa rồi?", "Lưu hình ảnh", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                SavePicture();
                            }
                        }
                        else if (resultNewGame == DialogResult.No)
                        {
                            socketManager.Send(new SocketData((int)SocketCommand.NOTIFY, "Đối phương không đồng ý hòa ván này. Ván đấu sẽ tiếp tục."));
                            if (BanCo.PheDuocDanh == BanCo.PheTa)
                                timerRemainingTime.Start();
                        }
                        this.Enabled = true;
                    }));
                    break;
                case (int)SocketCommand.ACCEPT_NEW_GAME:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        this.Enabled = false;
                        TakeAPicture();
                        BanCo.SetToDefault();
                        BanCo.XoaBanCo();
                        BanCo.TaoDiemBanCo(DiemBanCo_Click);
                        BanCo.TaoQuanCo(QuanCo_Click);
                        BanCo.RefreshBanCo();
                        MessageBox.Show("Đối phương đã đồng ý hòa ván này. Bắt đầu ván mới.", "Kết thúc ván cờ", MessageBoxButtons.OK);
                        if (MessageBox.Show("Bạn có muốn lưu hình ảnh gần nhất ván cờ vừa rồi?", "Lưu hình ảnh", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            SavePicture();
                        }
                        this.Enabled = true;
                    }));
                    break;
                case (int)SocketCommand.ASK_UNDO:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        this.Enabled = false;
                        timerRemainingTime.Stop();
                        DialogResult resultUndo = MessageBox.Show("Đối phương xin đi lại nước vừa rồi. Bạn có có đồng ý không?", "Xin đi lại", MessageBoxButtons.YesNo);
                        if (resultUndo == DialogResult.Yes)
                        {
                            socketManager.Send(new SocketData((int)SocketCommand.ACCEPT_UNDO));
                            BanCo.Dehighlight();
                            BanCo.AnDiemDich();
                            BanCo.HoanTac();
                        }
                        else if (resultUndo == DialogResult.No)
                        {
                            socketManager.Send(new SocketData((int)SocketCommand.NOTIFY, "Đối phương không đồng ý cho bạn đi lại."));
                            timerRemainingTime.Start();
                        }
                        this.Enabled = true;
                    }));
                    break;
                case (int)SocketCommand.ACCEPT_UNDO:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        this.Enabled = false;
                        BanCo.Dehighlight();
                        BanCo.AnDiemDich();
                        BanCo.HoanTac();
                        MessageBox.Show("Đối phương đã đồng ý cho bạn đi lại.", "Thông báo", MessageBoxButtons.OK);
                        timerRemainingTime.Start();
                        this.Enabled = true;
                    }));
                    break;
                case (int)SocketCommand.SURRENDER:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        this.Enabled = false;
                        TakeAPicture();
                        lblScore.Text = (int.Parse(lblScore.Text) + 1).ToString();
                        BanCo.SetToDefault();
                        BanCo.XoaBanCo();
                        BanCo.TaoDiemBanCo(DiemBanCo_Click);
                        BanCo.TaoQuanCo(QuanCo_Click);
                        BanCo.RefreshBanCo();
                        MessageBox.Show("Đối phương đã xin hàng. Bạn đã thắng ván cờ này! Bắt đầu ván mới.", "Kết thúc ván cờ", MessageBoxButtons.OK);
                        if (MessageBox.Show("Bạn có muốn lưu hình ảnh gần nhất ván cờ vừa rồi?", "Lưu hình ảnh", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            SavePicture();
                        }
                        this.Enabled = true;
                    }));
                    break;
                case (int)SocketCommand.EXIT:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        this.Enabled = false;
                        TakeAPicture();
                        BanCo.SetToDefault();
                        BanCo.XoaBanCo();
                        BanCo.TaoDiemBanCo(DiemBanCo_Click);
                        BanCo.TaoQuanCo(QuanCo_Click);
                        BanCo.RefreshBanCo();
                        MessageBox.Show("Đối phương đã tự thoát game.", "Kết thúc ván cờ", MessageBoxButtons.OK);
                        if (MessageBox.Show("Bạn có muốn lưu hình ảnh gần nhất ván cờ vừa rồi?", "Lưu hình ảnh", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            SavePicture();
                        }
                        this.Enabled = true;
                    }));
                    break;
                case (int)SocketCommand.CHAT_MESSAGE:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        //listView1.Items.Add(new ListViewItem() { Text = data.Message });
                        //txtMessage.Text += data.Message + "\r\n";
                        ThemTinNhanNhan(data.Message);
                    }));
                    break;
                case (int)SocketCommand.TEST_CONNECTION:
                    //do nothing
                    break;
                case (int)SocketCommand.OUT_OF_TIME:
                    this.Enabled = false;
                    lblScore.Text = (int.Parse(lblScore.Text) + 1).ToString();
                    BanCo.SetToDefault();
                    BanCo.XoaBanCo();
                    BanCo.TaoDiemBanCo(DiemBanCo_Click);
                    BanCo.TaoQuanCo(QuanCo_Click);
                    BanCo.RefreshBanCo();
                    MessageBox.Show("Đối phương đã hết thời gian. Bạn đã thắng ván cờ này! Bắt đầu ván mới.", "Kết thúc ván cờ", MessageBoxButtons.OK);
                    this.Enabled = true;
                    break;
                case (int)SocketCommand.READY:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        BanCo.OpponentName = data.Message;
                        lblOpponentName.Text = BanCo.OpponentName;
                        BanCo.WritePheDuocDanh(lblPheDuocDanh);
                        lblPheDuocDanh.Visible = true;
                        ptbBanCo.Enabled = true;
                        if (BanCo.PheTa == 1)
                            socketManager.Send(new SocketData((int)SocketCommand.READY, BanCo.Name));
                        else if (BanCo.PheTa == 2)
                            timerRemainingTime.Start();
                    }));
                    break;
                case (int)SocketCommand.OPPONENT_TICK:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        lblOpponentRemainingTime.Text = data.Message;
                    }));
                    break;
            }
            Listen();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            txbIP.Text = socketManager.GetLocalIPv4(NetworkInterfaceType.Wireless80211);
            if (string.IsNullOrEmpty(txbIP.Text))
            {
                txbIP.Text = socketManager.GetLocalIPv4(NetworkInterfaceType.Ethernet);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn thoát game?", "Thoát game", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else if (result == DialogResult.Yes)
            {
                try
                {
                    socketManager.Send(new SocketData((int)SocketCommand.EXIT));
                }
                catch { }
            }
        }

        #region Chat
        public static int TimDauCach(string s, int soKyTu)
        {
            for (int i = soKyTu; i > 0; i--)
            {
                if (s[i] == ' ') return i;
            }
            return soKyTu;
        }
        public static string LayDoanSau(string s, int soKyTu)
        {
            string s1 = "";
            for (int i = soKyTu; i < s.Length; i++)
            {
                s1 += s[i];
            }
            return s1;
        }
        public static string ThemCachTruoc(string s, int doDai)
        {
            while (s.Length < doDai)
            {
                s = s.Insert(0, " ");
            }
            return s;
        }
        public static string ThemCachSau(string s, int so)
        {
            while (s.Length < so)
            {
                s = s.Insert(s.Length, " ");
            }
            return s;
        }

        public void ThemTinNhanNhan(string s)
        {
            while (s.Length > soKT)
            {
                string s1 = "";
                int viTriDauCach = TimDauCach(s, soKT);
                for (int i = 0; i < viTriDauCach; i++)
                {
                    s1 += s[i];
                }
                s1 = s1.Trim();
                lsvMessage.Items.Add(new ListViewItem() { Text = s1 });
                lsvMessage.Items[lsvMessage.Items.Count - 1].ForeColor = Color.Blue;

                s = LayDoanSau(s, soKT);
            }
            if (s.Length < soKT)
            {
                s = s.Trim();
                lsvMessage.Items.Add(new ListViewItem() { Text = s });
                lsvMessage.Items[lsvMessage.Items.Count - 1].ForeColor = Color.Blue;

            }
        }
        public void ThemTinNhanGui(string s)
        {
            if (s.Length < soKT)
            {
                s = s.Trim();
                s = ThemCachTruoc(s, doDai);
                lsvMessage.Items.Add(new ListViewItem() { Text = s });
            }
            else
            {
                while (s.Length > soKT)
                {
                    string s1 = "";
                    int viTriDauCach = TimDauCach(s, soKT);
                    for (int i = 0; i < viTriDauCach; i++)
                    {
                        s1 += s[i];
                    }
                    s1 = s1.Trim();
                    s1 = ThemCachSau(s1, soKT);
                    s1 = ThemCachTruoc(s1, doDai);
                    lsvMessage.Items.Add(new ListViewItem() { Text = s1 });

                    s = LayDoanSau(s, soKT);
                }
                if (s.Length < soKT)
                {
                    s = s.Trim();
                    s = ThemCachSau(s, soKT);
                    s = ThemCachTruoc(s, doDai);
                    lsvMessage.Items.Add(new ListViewItem() { Text = s });
                }
            }
        }
        #endregion


        private void btnGui_Click(object sender, EventArgs e)
        {
            if (txtChat.Text != string.Empty)
            {
                ThemTinNhanGui(txtChat.Text);
                try
                {
                    socketManager.Send(new SocketData((int)SocketCommand.CHAT_MESSAGE, txtChat.Text));
                }
                catch
                {
                    lsvMessage.Items.Add(new ListViewItem() { Text = "Lỗi kết nối. Không thể gửi tin nhắn.", ForeColor = Color.Red });
                }
                txtChat.Clear();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtChat.Focused && e.KeyCode == Keys.Enter)
            {
                btnGui_Click(sender, e);
            }
        }

        private void timerRemainingTime_Tick(object sender, EventArgs e)
        {
            BanCo.RemainingTime--;
            lblRemainingTime.Text = BanCo.SecondsToTime(BanCo.RemainingTime);
            socketManager.Send(new SocketData((int)SocketCommand.OPPONENT_TICK, lblRemainingTime.Text));
            if (BanCo.RemainingTime < 60)
                lblRemainingTime.ForeColor = Color.Red;
            else
                lblRemainingTime.ForeColor = Color.DarkGreen;
            if (BanCo.RemainingTime == 0)
            {
                timerRemainingTime.Stop();
                socketManager.Send(new SocketData((int)SocketCommand.OUT_OF_TIME));
                lblOpponentScore.Text = (int.Parse(lblOpponentScore.Text) + 1).ToString();
                BanCo.SetToDefault();
                BanCo.XoaBanCo();
                BanCo.TaoDiemBanCo(DiemBanCo_Click);
                BanCo.TaoQuanCo(QuanCo_Click);
                BanCo.RefreshBanCo();
                MessageBox.Show("Hết thời gian! Bạn đã thua ván cờ này. Bắt đầu ván mới.", "Kết thúc ván cờ", MessageBoxButtons.OK);
            }
        }

        private void btnReady_Click(object sender, EventArgs e)
        {
            btnReady.Enabled = false;
            try
            {
                socketManager.Send(new SocketData((int)SocketCommand.READY, BanCo.Name));
                Listen();
            }
            catch
            {
                MessageBox.Show("Chưa kết nối hoặc đã mất kết nối với đối thủ.");
                btnReady.Enabled = true;
            }
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