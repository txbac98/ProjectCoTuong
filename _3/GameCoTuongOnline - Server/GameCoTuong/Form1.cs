using GameCoTuong.CoTuong;
using GameCoTuong.LAN;
using GameCoTuong.ProgramConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
                socketManager.Send(new SocketData((int)SocketCommand.SURRENDER));
                BanCo.SetToDefault();
                BanCo.XoaBanCo();
                BanCo.TaoDiemBanCo(DiemBanCo_Click);
                BanCo.TaoQuanCo(QuanCo_Click);
                BanCo.RefreshBanCo();
                MessageBox.Show("Bạn đã thua ván cờ này. Bắt đầu ván mới.", "Kết thúc ván cờ", MessageBoxButtons.OK);
            }
        }

        private void btnLAN_Click(object sender, EventArgs e)
        {
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
                            socketManager.Send(new SocketData((int)SocketCommand.ACCEPT_NEW_GAME));
                            BanCo.SetToDefault();
                            BanCo.XoaBanCo();
                            BanCo.TaoDiemBanCo(DiemBanCo_Click);
                            BanCo.TaoQuanCo(QuanCo_Click);
                            BanCo.RefreshBanCo();
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
                        BanCo.SetToDefault();
                        BanCo.XoaBanCo();
                        BanCo.TaoDiemBanCo(DiemBanCo_Click);
                        BanCo.TaoQuanCo(QuanCo_Click);
                        BanCo.RefreshBanCo();
                        MessageBox.Show("Đối phương đã đồng ý hòa ván này. Bắt đầu ván mới.", "Kết thúc ván cờ", MessageBoxButtons.OK);
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
                        BanCo.SetToDefault();
                        BanCo.XoaBanCo();
                        BanCo.TaoDiemBanCo(DiemBanCo_Click);
                        BanCo.TaoQuanCo(QuanCo_Click);
                        BanCo.RefreshBanCo();
                        MessageBox.Show("Đối phương đã xin hàng. Bạn đã thắng ván cờ này! Bắt đầu ván mới.", "Kết thúc ván cờ", MessageBoxButtons.OK);
                        this.Enabled = true;
                    }));
                    break;
                case (int)SocketCommand.EXIT:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        this.Enabled = false;
                        BanCo.SetToDefault();
                        BanCo.XoaBanCo();
                        BanCo.TaoDiemBanCo(DiemBanCo_Click);
                        BanCo.TaoQuanCo(QuanCo_Click);
                        BanCo.RefreshBanCo();
                        MessageBox.Show("Đối phương đã tự thoát game.", "Kết thúc ván cờ", MessageBoxButtons.OK);
                        this.Enabled = true;
                    }));
                    break;
                case (int)SocketCommand.CHAT_MESSAGE:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        //listView1.Items.Add(new ListViewItem() { Text = data.Message });
                        //txtMessage.Text += data.Message + "\r\n";
                        ReceiveMessage(data.Message);
                    }));
                    break;
                case (int)SocketCommand.TEST_CONNECTION:
                    //do nothing
                    break;
                case (int)SocketCommand.OUT_OF_TIME:
                    this.Enabled = false;
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
                        ptbBanCo.Enabled = true;
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

        private int NextWordLength(string str, int start)
        {
            for (int i = start; i < str.Length; i++)
                if (str[i] == ' ')
                    return i - start;
            return -1;
        }
        private int NextWord(string str, int start, ref string message)
        {
            for (int i = start ; i < str.Length; i++)
            {
                if (str[i] == ' ') 
                {
                    message += str.Substring(start, i - start) + " ";
                    return i+1;
                }
                if( i == str.Length - 1)
                {
                    message += str.Substring(start, str.Length - start);
                    return i;
                }
            }
            return -1;
        }
        private int CountOfWord(string str)
        {
            int count = 1;
            for (int i = 0; i < str.Length; i++)
                if (str[i] == ' ')
                    count++;
            return count;
        }

        private void InsertBlank(ref string str)
        {
            while(str.Length <45)
                str = str.Insert(0, " ");
        }
        private void ReceiveMessage(string text)
        {

            int i = 0;
            int start = 0;
            string message = "";
            while (i != CountOfWord(text))
            {
                start = NextWord(text, start, ref message);
                if (message.Length + NextWordLength(text, start) > 30)
                {
                    txtMessage.Text += message + "\r\n";
                    message = "";
                }
                i++;
            }
            if (i == CountOfWord(text) && message.Length < 30)
            {
                txtMessage.Text += message + "\r\n";
            }

        }
        private void SendMessage(string text)
        {

            int i = 0;
            int start = 0;
            string message = "";
            string blank = "                ";
            while (i != CountOfWord(text))
            {
                start = NextWord(text, start, ref message);
                if (message.Length + NextWordLength(text, start) > 30)
                {
                    txtMessage.Text += blank + message + "\r\n";
                    message = "";
                }
                i++;
            }
            if (i == CountOfWord(text) && message.Length < 30)
            {
                if (text.Length < 30)
                {
                    InsertBlank(ref message);
                    txtMessage.Text += message + "\r\n";
                }
                else txtMessage.Text += blank + message + "\r\n";
            }
        }
   
        private void btnGui_Click(object sender, EventArgs e)
        {
            if (chatTextBox.Text != string.Empty)
            {
                txtMessage.ReadOnly = true;
                SendMessage(chatTextBox.Text);

                try
                {
                    socketManager.Send(new SocketData((int)SocketCommand.CHAT_MESSAGE, "Opponent: " + chatTextBox.Text));
                }
                catch
                {
                    //listView1.Items.Add(new ListViewItem() { Text = "Lỗi kết nối. Không thể gửi tin nhắn.", ForeColor = Color.Red });
                }
                chatTextBox.Clear();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (chatTextBox.Focused && e.KeyCode == Keys.Enter)
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
                socketManager.Send(new SocketData((int)SocketCommand.READY));
            }
            catch
            {
                MessageBox.Show("Chưa kết nối hoặc đã mất kết nối với đối thủ.");
                btnReady.Enabled = true;
                return;
            }
            ptbBanCo.Enabled = true;
            timerRemainingTime.Start();
        }
    }
}