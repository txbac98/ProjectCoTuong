using GameCoTuong.ProgramConfig;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCoTuong.CoTuong
{
    public static class BanCo
    {
        #region
        public static int MauPheTa { get; set; } = 1; // màu của phe ta (phe xuất phát ở nửa dưới bàn cờ)

        public static NuocDi NuocDiTruocDo { get; private set; } = new NuocDi();

        /* Thuộc tính liên quan đến đối tượng QuanCo (quân cờ trừu tượng) */

        public static List<QuanCo> Alive_QuanCo { get; private set; } = new List<QuanCo>();

        public static QuanTuong TuongXanh { get; set; } = null;

        public static QuanTuong TuongDo { get; set; } = null;

        /* Thuộc tính liên quan đến đối tượng RoundButton (thể hiện điểm bàn cờ) */

        public static RoundButton[,] DiemBanCo { get; private set; } = new RoundButton[9, 10]; // Mảng 2 chiều chứa 90 điểm bàn cờ

        /* Thuộc tính liên quan đến đối tượng RoundPictureBox (thể hiện quân cờ trực quan) */

        public static List<RoundPictureBox> Alive_RoundPictureBox { get; private set; } = new List<RoundPictureBox>(); // List chứa tất cả các quân cờ còn sống

        public static RoundPictureBox QuanCoDuocChon { get; set; } = null; // quân cờ đang được chọn (được click vào)

        public static RoundPictureBox QuanCoBiLoai { get; set; } = null; // quân cờ vừa bị loại ở nước đi trước đó, nếu di chuyển thành công thì quanCoBiLoai không cần dùng đến => gán lại về null

        public static int PheDuocDanh { get; private set; } = 2; // Phe hiện tại đang được đánh (1 - Xanh, 2 - Đỏ). Phe Đỏ được đánh đầu tiên

        public static int SoLuotDi { get; private set; } = 0; // Số lượt đã đi từ đầu ván cờ

        public static PictureBox YellowSquareTarget { get; private set; } = new PictureBox()
        {
            Width = 58,
            Height = 58,
            BackColor = Color.Transparent,
            Image = GameCoTuong.Properties.Resources.yellow_square_target,
            Location = new Point(863, 698)
        };
        public static PictureBox greySquareTarget_Depart { get; private set; } = new PictureBox()
        {
            Width = 36,
            Height = 36,
            BackColor = Color.Transparent,
            Image = GameCoTuong.Properties.Resources.grey_square_target_depart,
            Location = new Point(863, 698)
        };
        public static PictureBox greySquareTarget_Dest { get; private set; } = new PictureBox()
        {
            Width = 58,
            Height = 58,
            BackColor = Color.Transparent,
            Image = GameCoTuong.Properties.Resources.grey_square_target_dest,
            Location = new Point(863, 698)
        };

        #endregion

        #region methods
        /* Phương thức dùng cho đối tượng QuanCo */

        public static bool CoQuanCoTaiDay(Point toaDo) // kiểm tra xem có quân cờ nào tại điểm cho trước hay không
        {
            return Alive_QuanCo.Find(element => element.ToaDo == toaDo) != null;
        }

        public static QuanCo GetQuanCo(Point toaDo) // tìm quân cờ tại điểm cho trước
        {
            return Alive_QuanCo.Find(element => element.ToaDo == toaDo);
        }

        /* Phương thức dùng cho đối tượng RoundPictureBox */
        /* Tạo 90 RoundButton điểm bàn cờ nhưng chưa hiển thị.
         Khi click vào 1 RoundPictureBox quân cờ thì những điểm bàn cờ ở những tọa độ trong danh sách điểm đích của quân đó sẽ hiện ra */
        public static void TaoDiemBanCo(PictureBox ptbBanCo)
        {
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    DiemBanCo[x, y] = new RoundButton()
                    {
                        Text = "",
                        Width = ThongSo.DuongKinhDiem,
                        Height = ThongSo.DuongKinhDiem,
                        BackColor = Color.Yellow,
                        Location = ThongSo.ToaDoBanCoCuaDiem(x, y),
                        Visible = false // Ẩn điểm bàn cờ sau khi khởi tạo
                    };
                    ptbBanCo.Controls.Add(DiemBanCo[x, y]);
                }
            }
        }

        /* Tạo 32 RoundPictureBox quân cờ và đưa chúng vào danh sách các quân cờ để quản lý */
        public static void TaoQuanCo(EventHandler QuanCo_Click, PictureBox ptbBanCo)
        {
            if (MauPheTa == 2)
            {
                /* Tướng xanh */
                RoundPictureBox tuongXanh = new RoundPictureBox(ThongSoPheDo.ToaDoTuongXanh);
                tuongXanh.Image = GameCoTuong.Properties.Resources.TuongXanh;
                Alive_RoundPictureBox.Add(tuongXanh);

                /* Xe xanh */
                RoundPictureBox xeXanh1 = new RoundPictureBox(ThongSoPheDo.ToaDoXeXanh1);
                xeXanh1.Image = GameCoTuong.Properties.Resources.XeXanh;
                Alive_RoundPictureBox.Add(xeXanh1);

                RoundPictureBox xeXanh2 = new RoundPictureBox(ThongSoPheDo.ToaDoXeXanh2);
                xeXanh2.Image = GameCoTuong.Properties.Resources.XeXanh;
                Alive_RoundPictureBox.Add(xeXanh2);

                /* Mã xanh */
                RoundPictureBox maXanh1 = new RoundPictureBox(ThongSoPheDo.ToaDoMaXanh1);
                maXanh1.Image = GameCoTuong.Properties.Resources.MaXanh;
                Alive_RoundPictureBox.Add(maXanh1);

                RoundPictureBox maXanh2 = new RoundPictureBox(ThongSoPheDo.ToaDoMaXanh2);
                maXanh2.Image = GameCoTuong.Properties.Resources.MaXanh;
                Alive_RoundPictureBox.Add(maXanh2);

                /* Tịnh xanh */
                RoundPictureBox tinhXanh1 = new RoundPictureBox(ThongSoPheDo.ToaDoTinhXanh1);
                tinhXanh1.Image = GameCoTuong.Properties.Resources.TinhXanh;
                Alive_RoundPictureBox.Add(tinhXanh1);

                RoundPictureBox tinhXanh2 = new RoundPictureBox(ThongSoPheDo.ToaDoTinhXanh2);
                tinhXanh2.Image = GameCoTuong.Properties.Resources.TinhXanh;
                Alive_RoundPictureBox.Add(tinhXanh2);

                /* Sĩ xanh */
                RoundPictureBox siXanh1 = new RoundPictureBox(ThongSoPheDo.ToaDoSiXanh1);
                siXanh1.Image = GameCoTuong.Properties.Resources.SiXanh;
                Alive_RoundPictureBox.Add(siXanh1);

                RoundPictureBox siXanh2 = new RoundPictureBox(ThongSoPheDo.ToaDoSiXanh2);
                siXanh2.Image = GameCoTuong.Properties.Resources.SiXanh;
                Alive_RoundPictureBox.Add(siXanh2);

                /* Pháo xanh */
                RoundPictureBox phaoXanh1 = new RoundPictureBox(ThongSoPheDo.ToaDoPhaoXanh1);
                phaoXanh1.Image = GameCoTuong.Properties.Resources.PhaoXanh;
                Alive_RoundPictureBox.Add(phaoXanh1);

                RoundPictureBox phaoXanh2 = new RoundPictureBox(ThongSoPheDo.ToaDoPhaoXanh2);
                phaoXanh2.Image = GameCoTuong.Properties.Resources.PhaoXanh;
                Alive_RoundPictureBox.Add(phaoXanh2);

                /* Tốt xanh */
                RoundPictureBox totXanh1 = new RoundPictureBox(ThongSoPheDo.ToaDoTotXanh1);
                totXanh1.Image = GameCoTuong.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totXanh1);

                RoundPictureBox totXanh2 = new RoundPictureBox(ThongSoPheDo.ToaDoTotXanh2);
                totXanh2.Image = GameCoTuong.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totXanh2);

                RoundPictureBox totXanh3 = new RoundPictureBox(ThongSoPheDo.ToaDoTotXanh3);
                totXanh3.Image = GameCoTuong.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totXanh3);

                RoundPictureBox totXanh4 = new RoundPictureBox(ThongSoPheDo.ToaDoTotXanh4);
                totXanh4.Image = GameCoTuong.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totXanh4);

                RoundPictureBox totXanh5 = new RoundPictureBox(ThongSoPheDo.ToaDoTotXanh5);
                totXanh5.Image = GameCoTuong.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totXanh5);

                /* Tướng đỏ */
                RoundPictureBox tuongDo = new RoundPictureBox(ThongSoPheDo.ToaDoTuongDo);
                tuongDo.Image = GameCoTuong.Properties.Resources.TuongDo;
                Alive_RoundPictureBox.Add(tuongDo);

                /* Xe đỏ */
                RoundPictureBox xeDo1 = new RoundPictureBox(ThongSoPheDo.ToaDoXeDo1);
                xeDo1.Image = GameCoTuong.Properties.Resources.XeDo;
                Alive_RoundPictureBox.Add(xeDo1);

                RoundPictureBox xeDo2 = new RoundPictureBox(ThongSoPheDo.ToaDoXeDo2);
                xeDo2.Image = GameCoTuong.Properties.Resources.XeDo;
                Alive_RoundPictureBox.Add(xeDo2);

                /* Mã đỏ */
                RoundPictureBox maDo1 = new RoundPictureBox(ThongSoPheDo.ToaDoMaDo1);
                maDo1.Image = GameCoTuong.Properties.Resources.MaDo;
                Alive_RoundPictureBox.Add(maDo1);

                RoundPictureBox maDo2 = new RoundPictureBox(ThongSoPheDo.ToaDoMaDo2);
                maDo2.Image = GameCoTuong.Properties.Resources.MaDo;
                Alive_RoundPictureBox.Add(maDo2);

                /* Tịnh đỏ */
                RoundPictureBox tinhDo1 = new RoundPictureBox(ThongSoPheDo.ToaDoTinhDo1);
                tinhDo1.Image = GameCoTuong.Properties.Resources.TinhDo;
                Alive_RoundPictureBox.Add(tinhDo1);

                RoundPictureBox tinhDo2 = new RoundPictureBox(ThongSoPheDo.ToaDoTinhDo2);
                tinhDo2.Image = GameCoTuong.Properties.Resources.TinhDo;
                Alive_RoundPictureBox.Add(tinhDo2);

                /* Sĩ đỏ */
                RoundPictureBox siDo1 = new RoundPictureBox(ThongSoPheDo.ToaDoSiDo1);
                siDo1.Image = GameCoTuong.Properties.Resources.SiDo;
                Alive_RoundPictureBox.Add(siDo1);

                RoundPictureBox siDo2 = new RoundPictureBox(ThongSoPheDo.ToaDoSiDo2);
                siDo2.Image = GameCoTuong.Properties.Resources.SiDo;
                Alive_RoundPictureBox.Add(siDo2);

                /* Pháo đỏ */
                RoundPictureBox phaoDo1 = new RoundPictureBox(ThongSoPheDo.ToaDoPhaoDo1);
                phaoDo1.Image = GameCoTuong.Properties.Resources.PhaoDo;
                Alive_RoundPictureBox.Add(phaoDo1);

                RoundPictureBox phaoDo2 = new RoundPictureBox(ThongSoPheDo.ToaDoPhaoDo2);
                phaoDo2.Image = GameCoTuong.Properties.Resources.PhaoDo;
                Alive_RoundPictureBox.Add(phaoDo2);

                /* Tốt đỏ */
                RoundPictureBox totDo1 = new RoundPictureBox(ThongSoPheDo.ToaDoTotDo1);
                totDo1.Image = GameCoTuong.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totDo1);

                RoundPictureBox totDo2 = new RoundPictureBox(ThongSoPheDo.ToaDoTotDo2);
                totDo2.Image = GameCoTuong.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totDo2);

                RoundPictureBox totDo3 = new RoundPictureBox(ThongSoPheDo.ToaDoTotDo3);
                totDo3.Image = GameCoTuong.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totDo3);

                RoundPictureBox totDo4 = new RoundPictureBox(ThongSoPheDo.ToaDoTotDo4);
                totDo4.Image = GameCoTuong.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totDo4);

                RoundPictureBox totDo5 = new RoundPictureBox(ThongSoPheDo.ToaDoTotDo5);
                totDo5.Image = GameCoTuong.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totDo5);
            }
            else if (MauPheTa == 1)
            {
                /* Tướng xanh */
                RoundPictureBox tuongXanh = new RoundPictureBox(ThongSoPheXanh.ToaDoTuongXanh);
                tuongXanh.Image = GameCoTuong.Properties.Resources.TuongXanh;
                Alive_RoundPictureBox.Add(tuongXanh);

                /* Xe xanh */
                RoundPictureBox xeXanh1 = new RoundPictureBox(ThongSoPheXanh.ToaDoXeXanh1);
                xeXanh1.Image = GameCoTuong.Properties.Resources.XeXanh;
                Alive_RoundPictureBox.Add(xeXanh1);

                RoundPictureBox xeXanh2 = new RoundPictureBox(ThongSoPheXanh.ToaDoXeXanh2);
                xeXanh2.Image = GameCoTuong.Properties.Resources.XeXanh;
                Alive_RoundPictureBox.Add(xeXanh2);

                /* Mã xanh */
                RoundPictureBox maXanh1 = new RoundPictureBox(ThongSoPheXanh.ToaDoMaXanh1);
                maXanh1.Image = GameCoTuong.Properties.Resources.MaXanh;
                Alive_RoundPictureBox.Add(maXanh1);

                RoundPictureBox maXanh2 = new RoundPictureBox(ThongSoPheXanh.ToaDoMaXanh2);
                maXanh2.Image = GameCoTuong.Properties.Resources.MaXanh;
                Alive_RoundPictureBox.Add(maXanh2);

                /* Tịnh xanh */
                RoundPictureBox tinhXanh1 = new RoundPictureBox(ThongSoPheXanh.ToaDoTinhXanh1);
                tinhXanh1.Image = GameCoTuong.Properties.Resources.TinhXanh;
                Alive_RoundPictureBox.Add(tinhXanh1);

                RoundPictureBox tinhXanh2 = new RoundPictureBox(ThongSoPheXanh.ToaDoTinhXanh2);
                tinhXanh2.Image = GameCoTuong.Properties.Resources.TinhXanh;
                Alive_RoundPictureBox.Add(tinhXanh2);

                /* Sĩ xanh */
                RoundPictureBox siXanh1 = new RoundPictureBox(ThongSoPheXanh.ToaDoSiXanh1);
                siXanh1.Image = GameCoTuong.Properties.Resources.SiXanh;
                Alive_RoundPictureBox.Add(siXanh1);

                RoundPictureBox siXanh2 = new RoundPictureBox(ThongSoPheXanh.ToaDoSiXanh2);
                siXanh2.Image = GameCoTuong.Properties.Resources.SiXanh;
                Alive_RoundPictureBox.Add(siXanh2);

                /* Pháo xanh */
                RoundPictureBox phaoXanh1 = new RoundPictureBox(ThongSoPheXanh.ToaDoPhaoXanh1);
                phaoXanh1.Image = GameCoTuong.Properties.Resources.PhaoXanh;
                Alive_RoundPictureBox.Add(phaoXanh1);

                RoundPictureBox phaoXanh2 = new RoundPictureBox(ThongSoPheXanh.ToaDoPhaoXanh2);
                phaoXanh2.Image = GameCoTuong.Properties.Resources.PhaoXanh;
                Alive_RoundPictureBox.Add(phaoXanh2);

                /* Tốt xanh */
                RoundPictureBox totXanh1 = new RoundPictureBox(ThongSoPheXanh.ToaDoTotXanh1);
                totXanh1.Image = GameCoTuong.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totXanh1);

                RoundPictureBox totXanh2 = new RoundPictureBox(ThongSoPheXanh.ToaDoTotXanh2);
                totXanh2.Image = GameCoTuong.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totXanh2);

                RoundPictureBox totXanh3 = new RoundPictureBox(ThongSoPheXanh.ToaDoTotXanh3);
                totXanh3.Image = GameCoTuong.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totXanh3);

                RoundPictureBox totXanh4 = new RoundPictureBox(ThongSoPheXanh.ToaDoTotXanh4);
                totXanh4.Image = GameCoTuong.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totXanh4);

                RoundPictureBox totXanh5 = new RoundPictureBox(ThongSoPheXanh.ToaDoTotXanh5);
                totXanh5.Image = GameCoTuong.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totXanh5);

                /* Tướng đỏ */
                RoundPictureBox tuongDo = new RoundPictureBox(ThongSoPheXanh.ToaDoTuongDo);
                tuongDo.Image = GameCoTuong.Properties.Resources.TuongDo;
                Alive_RoundPictureBox.Add(tuongDo);

                /* Xe đỏ */
                RoundPictureBox xeDo1 = new RoundPictureBox(ThongSoPheXanh.ToaDoXeDo1);
                xeDo1.Image = GameCoTuong.Properties.Resources.XeDo;
                Alive_RoundPictureBox.Add(xeDo1);

                RoundPictureBox xeDo2 = new RoundPictureBox(ThongSoPheXanh.ToaDoXeDo2);
                xeDo2.Image = GameCoTuong.Properties.Resources.XeDo;
                Alive_RoundPictureBox.Add(xeDo2);

                /* Mã đỏ */
                RoundPictureBox maDo1 = new RoundPictureBox(ThongSoPheXanh.ToaDoMaDo1);
                maDo1.Image = GameCoTuong.Properties.Resources.MaDo;
                Alive_RoundPictureBox.Add(maDo1);

                RoundPictureBox maDo2 = new RoundPictureBox(ThongSoPheXanh.ToaDoMaDo2);
                maDo2.Image = GameCoTuong.Properties.Resources.MaDo;
                Alive_RoundPictureBox.Add(maDo2);

                /* Tịnh đỏ */
                RoundPictureBox tinhDo1 = new RoundPictureBox(ThongSoPheXanh.ToaDoTinhDo1);
                tinhDo1.Image = GameCoTuong.Properties.Resources.TinhDo;
                Alive_RoundPictureBox.Add(tinhDo1);

                RoundPictureBox tinhDo2 = new RoundPictureBox(ThongSoPheXanh.ToaDoTinhDo2);
                tinhDo2.Image = GameCoTuong.Properties.Resources.TinhDo;
                Alive_RoundPictureBox.Add(tinhDo2);

                /* Sĩ đỏ */
                RoundPictureBox siDo1 = new RoundPictureBox(ThongSoPheXanh.ToaDoSiDo1);
                siDo1.Image = GameCoTuong.Properties.Resources.SiDo;
                Alive_RoundPictureBox.Add(siDo1);

                RoundPictureBox siDo2 = new RoundPictureBox(ThongSoPheXanh.ToaDoSiDo2);
                siDo2.Image = GameCoTuong.Properties.Resources.SiDo;
                Alive_RoundPictureBox.Add(siDo2);

                /* Pháo đỏ */
                RoundPictureBox phaoDo1 = new RoundPictureBox(ThongSoPheXanh.ToaDoPhaoDo1);
                phaoDo1.Image = GameCoTuong.Properties.Resources.PhaoDo;
                Alive_RoundPictureBox.Add(phaoDo1);

                RoundPictureBox phaoDo2 = new RoundPictureBox(ThongSoPheXanh.ToaDoPhaoDo2);
                phaoDo2.Image = GameCoTuong.Properties.Resources.PhaoDo;
                Alive_RoundPictureBox.Add(phaoDo2);

                /* Tốt đỏ */
                RoundPictureBox totDo1 = new RoundPictureBox(ThongSoPheXanh.ToaDoTotDo1);
                totDo1.Image = GameCoTuong.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totDo1);

                RoundPictureBox totDo2 = new RoundPictureBox(ThongSoPheXanh.ToaDoTotDo2);
                totDo2.Image = GameCoTuong.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totDo2);

                RoundPictureBox totDo3 = new RoundPictureBox(ThongSoPheXanh.ToaDoTotDo3);
                totDo3.Image = GameCoTuong.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totDo3);

                RoundPictureBox totDo4 = new RoundPictureBox(ThongSoPheXanh.ToaDoTotDo4);
                totDo4.Image = GameCoTuong.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totDo4);

                RoundPictureBox totDo5 = new RoundPictureBox(ThongSoPheXanh.ToaDoTotDo5);
                totDo5.Image = GameCoTuong.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totDo5);
            }
            foreach (RoundPictureBox element in Alive_RoundPictureBox) // Gắn cho mỗi RoundPictureBox quân cờ 1 sự kiện click và xếp nó lên bàn cờ
            {
                element.Click += QuanCo_Click;
                ptbBanCo.Controls.Add(element);
            }
        }

        public static void RefreshBanCo() // BẢN OFFLINE
        {
            foreach (RoundPictureBox element in Alive_RoundPictureBox)
            {
                if (element.quanCo.Mau == PheDuocDanh)
                    element.Enabled = true;
                else element.Enabled = false;
                element.BringToFront();
            }
        }
        /*Dat ban co ve trang thai ban dau*/
        public static void SetToDefault(Label label2, Label label3, Button button1)
        {
            QuanCoBiLoai = null;
            QuanCoDuocChon = null;

            PheDuocDanh = 2;
            label2.Text = "Phe Đỏ được đi đầu tiên";
            label2.ForeColor = Color.DarkRed;
            SoLuotDi = 0;
            label3.Text = SoLuotDi.ToString();
            button1.Enabled = false;
        }

        /* Xóa các RoundPictureBox quân cờ khỏi bàn cờ và danh sách quân cờ */
        public static void XoaBanCo(PictureBox ptbBanCo)
        {
            ptbBanCo.Controls.Clear();
            TuongXanh = null;
            TuongDo = null;
            Alive_QuanCo.Clear();
            Alive_RoundPictureBox.Clear();
        }

        public static void Highlight(PictureBox ptbBanCo)
        {
            YellowSquareTarget.Location = new Point(QuanCoDuocChon.Location.X - 1, QuanCoDuocChon.Location.Y - 1);
            YellowSquareTarget.Parent = ptbBanCo;
        }

        public static void Dehighlight()
        {
            YellowSquareTarget.Parent = null;
            YellowSquareTarget.Location = new Point(863, 698);
        }

        /* Tính toán và hiển thị tất cả điểm đích của quân cờ được chọn */
        public static void HienThiDiemDich(EventHandler DiemBanCo_Click) // Vẽ các điểm đích của quân cờ đang được chọn
        {
            QuanCoDuocChon.quanCo.danhSachDiemDich.Clear();
            QuanCoDuocChon.quanCo.TinhNuocDi();
            foreach (Point element in QuanCoDuocChon.quanCo.danhSachDiemDich)
            {
                QuanCo target = Alive_QuanCo.Find(element1 => element1.Mau != QuanCoDuocChon.quanCo.Mau && element1.ToaDo == element);
                if (target != null)
                    DiemBanCo[element.X, element.Y].BackColor = Color.Red;
                DiemBanCo[element.X, element.Y].Click += DiemBanCo_Click;
                DiemBanCo[element.X, element.Y].Visible = true;
                DiemBanCo[element.X, element.Y].BringToFront();
            }
        }
        /* Ẩn tất cả các điểm đích đang hiển thị trên bàn cờ */
        public static void AnDiemDich()
        {
            foreach (RoundButton element in DiemBanCo)
            {
                element.Visible = false;
                element.BackColor = Color.Yellow;
            }
        }

        public static void LoaiBoQuanCo(Point viTri, PictureBox ptbBanCo)
        {
            QuanCoBiLoai = Alive_RoundPictureBox.Find(element => element.quanCo.Mau != PheDuocDanh && element.quanCo.ToaDo == viTri);
            if (QuanCoBiLoai != null)
            {
                ptbBanCo.Controls.Remove(QuanCoBiLoai);
                Alive_RoundPictureBox.Remove(QuanCoBiLoai);
                Alive_QuanCo.Remove(QuanCoBiLoai.quanCo);
            }
        }

        /* Trả lại quân cờ vừa bị loại khỏi bàn cờ */
        public static void TraLaiQuanCo(PictureBox ptbBanCo)
        {
            if (QuanCoBiLoai != null)
            {
                Alive_QuanCo.Add(QuanCoBiLoai.quanCo);
                Alive_RoundPictureBox.Add(QuanCoBiLoai);
                ptbBanCo.Controls.Add(QuanCoBiLoai);
                QuanCoBiLoai = null;
            }
            RefreshBanCo();
        }

        public static void DiChuyen(Point destination)
        {
            QuanCoDuocChon.DenViTri(destination);
        }
        public static int PheDoiPhuong()
        {
            if (PheDuocDanh == 1)
                return 2;
            return 1;
        }

        public static bool HaiTuongDoiMatNhau()
        {
            if (TuongXanh.ToaDo.X == TuongDo.ToaDo.X) // nếu 2 tướng cùng hoành độ (thẳng hàng) ...
            {
                int X = TuongXanh.ToaDo.X;
                Point diemGiuaHaiTuong;
                if (MauPheTa == 2)
                {
                    for (int Y = TuongXanh.ToaDo.Y + 1; Y < TuongDo.ToaDo.Y; Y++) // ... thì xét xem giữa 2 tướng có quân cờ nào không
                    {
                        diemGiuaHaiTuong = new Point(X, Y);
                        if (CoQuanCoTaiDay(diemGiuaHaiTuong))
                            return false; // nếu có 1 quân cờ ở giữa 2 tướng thì 2 tướng không đối mặt nhau
                    }
                    return true; // nếu không có quân cờ nào ở giữa 2 tướng thì 2 tướng đối mặt nhau
                }
                else if (MauPheTa == 1)
                {
                    for (int Y = TuongXanh.ToaDo.Y - 1; Y > TuongDo.ToaDo.Y; Y--) // ... thì xét xem giữa 2 tướng có quân cờ nào không
                    {
                        diemGiuaHaiTuong = new Point(X, Y);
                        if (CoQuanCoTaiDay(diemGiuaHaiTuong))
                            return false; // nếu có 1 quân cờ ở giữa 2 tướng thì 2 tướng không đối mặt nhau
                    }
                    return true;
                }
            }
            return false; // nếu 2 tướng không cùng hoành độ thì 2 tướng không đối mặt nhau
        }

        public static bool ChieuTuong(int pheChieuTuong)
        {
            foreach (QuanCo element in Alive_QuanCo)
            {
                if (element.Mau == pheChieuTuong)
                {
                    element.danhSachDiemDich.Clear();
                    element.TinhNuocDi();
                    foreach (Point element1 in element.danhSachDiemDich)
                    {
                        QuanCo target = Alive_QuanCo.Find(element2 => element2.Mau != pheChieuTuong && element2.ToaDo == element1);
                        if (target != null && (target == TuongXanh || target == TuongDo))
                            return true;
                    }
                }
            }
            return false;
        }

        /* Đổi phe sau mỗi nước đi */
        public static void DoiPhe(Label label3, Label label2, Button button1) // BẢN OFFLINE
        {
            QuanCoBiLoai = null;
            QuanCoDuocChon = null;
            PheDuocDanh = PheDoiPhuong();
            if (PheDuocDanh == 2)
            {
                label2.ForeColor = Color.DarkRed;
                label2.Text = "Lượt đi của phe Đỏ";
            }
            else
            {
                label2.ForeColor = Color.DarkBlue;
                label2.Text = "Lượt đi của phe Xanh";
            }
            SoLuotDi++;
            label3.Text = SoLuotDi.ToString();
            if (SoLuotDi != 0 && !button1.Enabled)
                button1.Enabled = true;
            RefreshBanCo(); //*Offline*
        }

        public static void HienThiNuocDi(Point departure, Point destination, PictureBox ptbBanCo)
        {
            greySquareTarget_Depart.Location = new Point(ThongSo.ToaDoBanCoCuaQuanCo(departure).X + 10, ThongSo.ToaDoBanCoCuaQuanCo(departure).Y + 10);
            greySquareTarget_Dest.Location = new Point(ThongSo.ToaDoBanCoCuaQuanCo(destination).X - 1, ThongSo.ToaDoBanCoCuaQuanCo(destination).Y - 1);
            if (SoLuotDi == 0)
            {
                greySquareTarget_Depart.Parent = ptbBanCo;
                greySquareTarget_Dest.Parent = ptbBanCo;
            }
        }

        public static void LuuNuocDi(Point departure, Point destination)
        {
            NuocDiTruocDo.ToaDoDi = new Point(departure.X, departure.Y);
            NuocDiTruocDo.ToaDoDen = new Point(destination.X, destination.Y);
            NuocDiTruocDo.QuanCoDiChuyen = QuanCoDuocChon;
            NuocDiTruocDo.QuanCoBiLoai = QuanCoBiLoai;
        }
        #endregion
    }
}