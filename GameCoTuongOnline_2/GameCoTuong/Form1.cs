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
            BanCo.TaoDiemBanCo(ptbBanCo);
            BanCo.TaoQuanCo(QuanCo_Click, ptbBanCo);
            BanCo.RefreshBanCo();
            BanCo.PtbBanCo = ptbBanCo;

            CheckForIllegalCrossThreadCalls = false;
            if (BanCo.mauPheTa == 2)
            {
                ChatLan.Server.ListView = listView1;
                ChatLan.Server.TextBox = textBox1;
                ChatLan.Server.Connect();
            }
            else
            {
                ChatLan.Client.ListView = listView1;
                ChatLan.Client.TextBox = textBox1;
                ChatLan.Client.Connect();
                BanCo.Disable();
            }
        }

        /* Khi click vào 1 RoundPictureBox quân cờ thì nó sẽ được chọn... */
        private void QuanCo_Click(object sender, EventArgs e)
        {
            RoundPictureBox selected = sender as RoundPictureBox;
            BanCo.Highlight(selected, ptbBanCo);
            BanCo.HienThiDiemDich(selected, DiemBanCo_Click);
            BanCo.toaDoDuocChon = selected.quanCo.ToaDo; // Lấy tọa độ của quân cờ được chọn
            BanCo.ToaDoTruoc = selected.quanCo.ToaDo;
            BanCo.Disable(); //khi 1 quân cờ được chọn thì không thể chọn các quân cờ khác

        }

        /* Khi đang chọn 1 quân cờ (tức là đã click vào 1 quân cờ trước đó), click vào một điểm bất kì trên bàn cờ sẽ bỏ chọn quân cờ đó */
        private void ptbBanCo_Click(object sender, EventArgs e)
        {
            BanCo.Dehighlight();
            BanCo.AnDiemDich();
            if(BanCo.DaDanh==false)
                BanCo.RefreshBanCo();
            BanCo.toaDoDuocChon = ThongSo.ToaDoNULL;
        }

        /* Những gì xảy ra khi click vào một RoundButton điểm bàn cờ để đi đến */
        private void DiemBanCo_Click(object sender, EventArgs e)
        {
            if (BanCo.toaDoDuocChon == ThongSo.ToaDoNULL)  // THE LEGENDARY GATEKEEPER from evil bugs
                return; // Dòng code chống lỗi lặp lại event (chưa rõ nguyên nhân của lỗi này)

            BanCo.Dehighlight(); // chọn nước đi
            BanCo.AnDiemDich(); // thì đồng thời sẽ bỏ chọn quân cờ luôn
            RoundButton clickedRoundButton = sender as RoundButton;
            Point destination = ThongSo.ToaDoDonViCuaDiem(clickedRoundButton.Location); // Lấy tọa độ của RoundButton điểm bàn cờ (điểm đích)
            RoundPictureBox selected = BanCo.alive_RoundPictureBox.Find(element => element.quanCo.ToaDo == BanCo.toaDoDuocChon); // Tìm ra RoundPictureBox quân cờ trong danh sách quân cờ

            //Hàm di chuyển cũ tách thành LoaiBoQuanCo + DiChuyen
            BanCo.LoaiBoQuanCo(destination, ptbBanCo);
            BanCo.DiChuyen(selected, destination); // Di chuyển quân cờ đến điểm đích
            BanCo.ToaDoSau = destination;
            BanCo.DaDanh = true;
            BanCo.Disable();
            if (BanCo.HaiTuongDoiMatNhau()) // nước đi không hợp lệ nếu sau nước đi 2 tướng đối mặt nhau => hoàn tác nước đi
            {
                MessageBox.Show("Tướng phe bạn sẽ đối mặt với tướng đối phương sau nước đi này. Hãy chọn một nước đi khác.", "Nước đi không hợp lệ");
                BanCo.QuayLai(selected, BanCo.toaDoDuocChon);
                BanCo.TraLaiQuanCo(ptbBanCo);
                return;
            }

            if (BanCo.ChieuTuong(BanCo.PheDoiPhuong())) // nước đi không hợp lệ nếu sau nước đi tướng phe di chuyển bị đối phương chiếu => hoàn tác nước đi
            {
                MessageBox.Show("Tướng phe bạn sẽ gặp nguy sau nước đi này. Hãy chọn một nước đi khác.", "Nước đi không hợp lệ");
                BanCo.QuayLai(selected, BanCo.toaDoDuocChon);
                BanCo.TraLaiQuanCo(ptbBanCo);
                return;
            }

            BanCo.ShowTheMove(BanCo.toaDoDuocChon, destination, ptbBanCo);
            if (BanCo.mauPheTa == 2)
            {
                foreach (Socket item in ChatLan.Server.ClientList)
                {
                    ChatLan.Server.Send(item);
                }
            }
            else
            {
                ChatLan.Client.Send();
            }
           
            BanCo.DoiPhe(label3, label2, button1, ptbBanCo);
        }

        // Event cho button New game
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn bỏ ván đấu này và bắt đầu một ván mới?", "Ván mới", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //Hàm xóa bàn cờ tách thành SetToDefault + XoaBanCo
                BanCo.SetToDefault(label2, label3, button1);
                BanCo.XoaBanCo(ptbBanCo);
                BanCo.TaoDiemBanCo(ptbBanCo);
                BanCo.TaoQuanCo(QuanCo_Click, ptbBanCo);
                BanCo.RefreshBanCo();
            }
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            if (BanCo.mauPheTa == 2)
            {
                foreach (Socket item in ChatLan.Server.ClientList)
                {
                    ChatLan.Server.Send(item);
                }
                ChatLan.Server.AddMessage(ChatLan.Server.TextBox.Text);
            }
            else
            {
                ChatLan.Client.Send();
                ChatLan.Client.AddMessage(ChatLan.Client.TextBox.Text);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox1.Focused && e.KeyCode == Keys.Enter)
            {
                btnGui_Click(sender, e);
            }
        }
    }
}