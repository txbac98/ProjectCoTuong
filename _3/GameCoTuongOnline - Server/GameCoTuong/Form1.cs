using GameCoTuong.CoTuong;
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
using static GameCoTuong.ProgramConfig.SocketData;

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
            BanCo.SetToDefault(lblPheDuocDanh, lblSoLuotDi, btnNewGame, btnUndo);
            BanCo.TaoDiemBanCo(ptbBanCo, DiemBanCo_Click);
            BanCo.TaoQuanCo(QuanCo_Click, ptbBanCo);
            BanCo.RefreshBanCo();
            BanCo.PtbBanCo = ptbBanCo;
            BanCo.LblPheDuocDanh = lblPheDuocDanh;
            BanCo.LblSoLuotDi = lblSoLuotDi;
            BanCo.BtnNewGame = btnNewGame;
            BanCo.BtnUndo = btnUndo;
            socketManager = new SocketManager();
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

            if (BanCo.TaDanh(BanCo.QuanCoDuocChon.Quan_Co.ToaDo, ThongSo.ToaDoDonViCuaDiem(((RoundButton)sender).Location)))
            {
                socketManager.Send(new SocketData((int)SocketCommand.SEND_MOVE, string.Empty,
                    new Point(8 - BanCo.ToaDoDiTruoc.X, 9 - BanCo.ToaDoDiTruoc.Y), new Point(8 - BanCo.ToaDoDenTruoc.X, 9 - BanCo.ToaDoDenTruoc.Y)));
                Listen();
            }
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
                BanCo.RefreshBanCo();
            }
        }

        // Event cho button 'Undo'
        private void btnUndo_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Bạn muốn xin đi lại nước đi vừa rồi?", "Xin đi lại", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                btnUndo.Enabled = false;
                socketManager.Send(new SocketData((int)SocketCommand.ASK_UNDO, string.Empty));
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
                        BanCo.DoiPhuongDanh(data.DepartureLocation, data.DestinationLocation);
                    }));
                    break;
                case (int)SocketCommand.NOTIFY:
                    MessageBox.Show(data.Message);
                    break;
                case (int)SocketCommand.ASK_NEW_GAME:

                    break;
                case (int)SocketCommand.ACCEPT_NEW_GAME:

                    break;
                case (int)SocketCommand.ASK_UNDO:
                    DialogResult result = MessageBox.Show("Đối phương xin đi lại nước vừa rồi. Bạn có có đồng ý không?", "Hoàn tác nước đi", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        socketManager.Send(new SocketData((int)SocketCommand.ACCEPT_UNDO, string.Empty));
                        this.Invoke((MethodInvoker)(() =>
                        {
                            BanCo.Dehighlight();
                            BanCo.AnDiemDich();
                            BanCo.HoanTac();
                        }));
                    }
                    else if (result == DialogResult.No)
                    {
                        socketManager.Send(new SocketData((int)SocketCommand.NOTIFY, "Đối phương không đồng ý cho bạn đi lại."));
                    }
                    break;
                case (int)SocketCommand.ACCEPT_UNDO:
                    MessageBox.Show("Đối phương đã đồng ý cho bạn đi lại.");
                    this.Invoke((MethodInvoker)(() =>
                    {
                        BanCo.Dehighlight();
                        BanCo.AnDiemDich();
                        BanCo.HoanTac();
                    }));
                    break;
                case (int)SocketCommand.SURRENDER:
                    MessageBox.Show("Đối phương đã xin hàng. Bạn đã thắng ván cờ này.", "Kết thúc ván cờ");

                    break;
                case (int)SocketCommand.EXIT:

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
    }
}