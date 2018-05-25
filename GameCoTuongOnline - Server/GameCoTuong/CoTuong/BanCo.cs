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
        #region properties
        public static int PheTa { get; set; } = 2; // màu của phe ta (phe xuất phát ở nửa dưới bàn cờ)

        public static Color MauPheDo { get { return Color.DarkRed; } }

        public static Color MauPheXanh { get { return Color.DarkBlue; } }

        public static NuocDi NuocDiTruoc { get; set; } = new NuocDi(); ///*

        /* Thuộc tính liên quan đến đối tượng QuanCo (quân cờ trừu tượng) */

        public static List<QuanCo> Alive_QuanCo { get; set; } = new List<QuanCo>(); ///*

        public static QuanTuong TuongXanh { get; set; } = null;

        public static QuanTuong TuongDo { get; set; } = null;

        /* Thuộc tính liên quan đến đối tượng RoundButton (thể hiện điểm bàn cờ) */

        public static RoundButton[,] DiemBanCo { get; set; } = new RoundButton[9, 10]; ///* // Mảng 2 chiều chứa 90 điểm bàn cờ

        /* Thuộc tính liên quan đến đối tượng RoundPictureBox (thể hiện quân cờ trực quan) */

        public static List<RoundPictureBox> Alive_RoundPictureBox { get; set; } = new List<RoundPictureBox>(); ///* // List chứa tất cả các quân cờ còn sống

        public static RoundPictureBox QuanCoDuocChon { get; set; } // quân cờ đang được chọn (được click vào)

        public static RoundPictureBox QuanCoBiLoai { get; set; } // quân cờ vừa bị loại ở nước đi trước đó, nếu di chuyển thành công thì quanCoBiLoai không cần dùng đến => gán lại về null

        public static int PheDuocDanh { get; private set; } // Phe hiện tại đang được đánh (1 - Xanh, 2 - Đỏ). Phe Đỏ được đánh đầu tiên

        public static int SoLuotDi { get; private set; } // Số lượt đã đi từ đầu ván cờ

        public static PictureBox PtbBanCo { get; set; }
        public static Label LblPheDuocDanh { get; set; }
        public static Label LblSoLuotDi { get; set; }
        public static Button BtnNewGame { get; set; }
        public static Button BtnUndo { get; set; }

        public static PictureBox YellowTarget { get; set; } = new PictureBox() ///*
        {
            Width = 58,
            Height = 58,
            BackColor = Color.Transparent,
            Image = GameCoTuong.Properties.Resources.yellow_square_target,
            Location = ThongSo.ToaDoNULL
        };
        public static PictureBox GreyTargetDeparture { get; set; } = new PictureBox() ///*
        {
            Width = 36,
            Height = 36,
            BackColor = Color.Transparent,
            Image = GameCoTuong.Properties.Resources.grey_square_target_depart,
            Location = ThongSo.ToaDoNULL
        };
        public static PictureBox GreyTargetDestination { get; set; } = new PictureBox() ///*
        {
            Width = 58,
            Height = 58,
            BackColor = Color.Transparent,
            Image = GameCoTuong.Properties.Resources.grey_square_target_dest,
            Location = ThongSo.ToaDoNULL
        };

        #endregion

        #region methods
        /* Phương thức dùng cho đối tượng QuanCo */

        public static bool CoQuanCoTaiDay(Point viTri) // kiểm tra xem có quân cờ nào tại điểm cho trước hay không
        {
            return Alive_QuanCo.Find(element => element.ToaDo == viTri) != null;
        }

        public static QuanCo GetQuanCo(Point viTri) // tìm quân cờ tại điểm cho trước
        {
            return Alive_QuanCo.Find(element => element.ToaDo == viTri);
        }


        /* Phương thức dùng cho đối tượng RoundPictureBox */
        /* Tạo 90 RoundButton điểm bàn cờ nhưng chưa hiển thị.
         Khi click vào 1 RoundPictureBox quân cờ thì những điểm bàn cờ ở những tọa độ trong danh sách điểm đích của quân đó sẽ hiện ra */
        public static void TaoDiemBanCo(PictureBox ptbBanCo, EventHandler DiemBanCo_Click)
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
                    DiemBanCo[x, y].Click += DiemBanCo_Click;
                    ptbBanCo.Controls.Add(DiemBanCo[x, y]);
                }
            }
        }

        /* Tạo 32 RoundPictureBox quân cờ và đưa chúng vào danh sách các quân cờ để quản lý */
        public static void TaoQuanCo(EventHandler QuanCo_Click, PictureBox ptbBanCo)
        {
            if (PheTa == 2)
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
            else if (PheTa == 1)
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

        public static void RefreshBanCo()
        {
            if (PheDuocDanh == PheTa)
            {
                foreach (RoundPictureBox element in Alive_RoundPictureBox)
                {
                    if (element.Quan_Co.Mau == PheTa)
                    {
                        element.Enabled = true;
                        element.BringToFront();
                    }
                    else
                    {
                        element.Enabled = false;
                    }
                    element.BringToFront();
                }
            }
            else
            {
                foreach (RoundPictureBox element in Alive_RoundPictureBox)
                {
                    element.Enabled = false;
                    element.BringToFront();
                }
            }
        }

        public static void WritePheDuocDanh(Label lblPheDuocDanh)
        {
            if (PheDuocDanh == 2)
            {
                lblPheDuocDanh.ForeColor = MauPheDo;
                lblPheDuocDanh.Text = "Lượt đi của phe Đỏ";
            }
            else
            {
                lblPheDuocDanh.ForeColor = MauPheXanh;
                lblPheDuocDanh.Text = "Lượt đi của phe Xanh";
            }
        }

        /*Dat ban co ve trang thai ban dau*/
        public static void SetToDefault(Label lblPheDuocDanh, Label lblSoLuotDi, Button btnNewGame, Button btnUndo)
        {
            QuanCoBiLoai = null;
            QuanCoDuocChon = null;
            PheDuocDanh = 2;
            SoLuotDi = 0;

            WritePheDuocDanh(lblPheDuocDanh);
            lblSoLuotDi.Text = SoLuotDi.ToString();
            btnNewGame.Enabled = false;
            btnUndo.Enabled = false;
        }

        /* Xóa các RoundPictureBox quân cờ khỏi bàn cờ và danh sách quân cờ */
        public static void XoaBanCo(PictureBox ptbBanCo)
        {
            ptbBanCo.Controls.Clear();
            TuongXanh = null;
            TuongDo = null;
            Alive_QuanCo.Clear();
            Alive_RoundPictureBox.Clear();
            NuocDiTruoc.Clear();
        }

        public static void Highlight(PictureBox ptbBanCo)
        {
            YellowTarget.Location = new Point(QuanCoDuocChon.Location.X - 1, QuanCoDuocChon.Location.Y - 1);
            YellowTarget.Parent = ptbBanCo;
        }

        public static void Dehighlight()
        {
            YellowTarget.Parent = null;
        }

        /* Tính toán và hiển thị tất cả điểm đích của quân cờ được chọn */
        public static void HienThiDiemDich() // Vẽ các điểm đích của quân cờ đang được chọn
        {
            QuanCoDuocChon.Quan_Co.DanhSachDiemDich.Clear();
            QuanCoDuocChon.Quan_Co.TinhNuocDi();
            foreach (Point element in QuanCoDuocChon.Quan_Co.DanhSachDiemDich)
            {
                QuanCo target = Alive_QuanCo.Find(element1 => element1.Mau != QuanCoDuocChon.Quan_Co.Mau && element1.ToaDo == element);
                if (target != null)
                    DiemBanCo[element.X, element.Y].BackColor = Color.Red;
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
            QuanCoBiLoai = Alive_RoundPictureBox.Find(element => element.Quan_Co.Mau != PheDuocDanh && element.Quan_Co.ToaDo == viTri);
            if (QuanCoBiLoai != null)
            {
                ptbBanCo.Controls.Remove(QuanCoBiLoai);
                Alive_RoundPictureBox.Remove(QuanCoBiLoai);
                Alive_QuanCo.Remove(QuanCoBiLoai.Quan_Co);
            }
        }

        public static void LoaiBoQuanCo(RoundPictureBox QuanCoBiLoai, PictureBox ptbBanCo)
        {
            if (QuanCoBiLoai != null)
            {
                ptbBanCo.Controls.Remove(QuanCoBiLoai);
                Alive_RoundPictureBox.Remove(QuanCoBiLoai);
                Alive_QuanCo.Remove(QuanCoBiLoai.Quan_Co);
            }
        }

        /* Trả lại một quân cờ bị loại khỏi bàn cờ */
        public static void TraLaiQuanCo(RoundPictureBox quanCoCanTraLai, PictureBox ptbBanCo)
        {
            if (quanCoCanTraLai != null)
            {
                Alive_QuanCo.Add(quanCoCanTraLai.Quan_Co);
                Alive_RoundPictureBox.Add(quanCoCanTraLai);
                ptbBanCo.Controls.Add(quanCoCanTraLai);
            }
        }

        public static int PheDoiPhuong(int phe)
        {
            if (phe == 1)
                return 2;
            return 1;
        }

        public static bool HaiTuongDoiMatNhau()
        {
            if (TuongXanh.ToaDo.X == TuongDo.ToaDo.X) // nếu 2 tướng cùng hoành độ (thẳng hàng) ...
            {
                int X = TuongXanh.ToaDo.X;
                if (PheTa == 2)
                {
                    for (int Y = TuongXanh.ToaDo.Y + 1; Y < TuongDo.ToaDo.Y; Y++) // ... thì xét xem giữa 2 tướng có quân cờ nào không
                    {
                        Point diemGiuaHaiTuong = new Point(X, Y);
                        if (CoQuanCoTaiDay(diemGiuaHaiTuong))
                            return false; // nếu có 1 quân cờ ở giữa 2 tướng thì 2 tướng không đối mặt nhau
                    }
                    return true; // nếu không có quân cờ nào ở giữa 2 tướng thì 2 tướng đối mặt nhau
                }
                else if (PheTa == 1)
                {
                    for (int Y = TuongXanh.ToaDo.Y - 1; Y > TuongDo.ToaDo.Y; Y--) // ... thì xét xem giữa 2 tướng có quân cờ nào không
                    {
                        Point diemGiuaHaiTuong = new Point(X, Y);
                        if (CoQuanCoTaiDay(diemGiuaHaiTuong))
                            return false; // nếu có 1 quân cờ ở giữa 2 tướng thì 2 tướng không đối mặt nhau
                    }
                    return true;
                }
            }
            return false; // nếu 2 tướng không cùng hoành độ thì 2 tướng không đối mặt nhau
        }

        public static bool CoChieuTuong(int pheChieuTuong)
        {
            foreach (QuanCo element in Alive_QuanCo)
            {
                if (element.Mau == pheChieuTuong)
                {
                    element.DanhSachDiemDich.Clear();
                    element.TinhNuocDi();
                    foreach (Point element1 in element.DanhSachDiemDich)
                    {
                        QuanCo target = Alive_QuanCo.Find(element2 => element2.Mau != pheChieuTuong && element2.ToaDo == element1);
                        if (target != null && (target == TuongXanh || target == TuongDo))
                            return true;
                    }
                }
            }
            return false;
        }

        /* Đổi phe sau mỗi nước đi thành công */
        public static void DoiPhe()
        {
            QuanCoDuocChon = null;
            QuanCoBiLoai = null;
            PheDuocDanh = PheDoiPhuong(PheDuocDanh);
            SoLuotDi++;

            WritePheDuocDanh(LblPheDuocDanh);
            LblSoLuotDi.Text = SoLuotDi.ToString();
            if (SoLuotDi != 0)
            {
                BtnNewGame.Enabled = true;
                BtnUndo.Enabled = true;
            }
            else
            {
                BtnNewGame.Enabled = false;
                BtnUndo.Enabled = false;
            }
            RefreshBanCo();
        }

        /* Đổi phe cho sự kiện undo */
        public static void DoiPhe(Label lblPheDuocDanh, Label lblSoLuotDi, Button btnNewGame)
        {
            QuanCoBiLoai = null;
            QuanCoDuocChon = null;
            PheDuocDanh = PheDoiPhuong(PheDuocDanh);
            SoLuotDi--;

            WritePheDuocDanh(lblPheDuocDanh);
            lblSoLuotDi.Text = SoLuotDi.ToString();
            if (SoLuotDi != 0)
            {
                btnNewGame.Enabled = true;
            }
            else
            {
                btnNewGame.Enabled = false;
            }
        }

        /* Hiển thị nước đi sau mỗi nước đi thành công */
        public static void HienThiNuocDi(Point departure, Point destination, PictureBox ptbBanCo)
        {
            NuocDiTruoc.PrevGreyTargetDepartureLocation = GreyTargetDeparture.Location;
            NuocDiTruoc.PrevGreyTargetDestinationLocation = GreyTargetDestination.Location;
            GreyTargetDeparture.Location = new Point(ThongSo.ToaDoBanCoCuaQuanCo(departure).X + 10, ThongSo.ToaDoBanCoCuaQuanCo(departure).Y + 10);
            GreyTargetDestination.Location = new Point(ThongSo.ToaDoBanCoCuaQuanCo(destination).X - 1, ThongSo.ToaDoBanCoCuaQuanCo(destination).Y - 1);
            if (SoLuotDi == 0)
            {
                GreyTargetDeparture.Parent = ptbBanCo;
                GreyTargetDestination.Parent = ptbBanCo;
            }
        }

        /* Hiển thị nước đi cho sự kiện undo */
        public static void HienThiNuocDiTruoc(PictureBox ptbBanCo)
        {
            GreyTargetDeparture.Location = NuocDiTruoc.PrevGreyTargetDepartureLocation;
            GreyTargetDestination.Location = NuocDiTruoc.PrevGreyTargetDestinationLocation;
            if (SoLuotDi == 0)
            {
                GreyTargetDeparture.Parent = null;
                GreyTargetDestination.Parent = null;
            }
        }

        public static void LuuNuocDi(Point departure, Point destination)
        {
            NuocDiTruoc.ToaDoDi = new Point(departure.X, departure.Y);
            NuocDiTruoc.ToaDoDen = new Point(destination.X, destination.Y);
            NuocDiTruoc.QuanCoDiChuyen = QuanCoDuocChon;
            NuocDiTruoc.QuanCoBiLoai = QuanCoBiLoai;
        }

        public static void HoanTac(PictureBox ptbBanCo)
        {
            NuocDiTruoc.QuanCoDiChuyen.DiChuyen(NuocDiTruoc.ToaDoDi);
            TraLaiQuanCo(NuocDiTruoc.QuanCoBiLoai, ptbBanCo);
        }

        public static bool TaDanh(Point departure, Point destination)
        {
            LoaiBoQuanCo(destination, PtbBanCo); // Loại bỏ quân cờ ở điểm đích
            QuanCoDuocChon.DiChuyen(destination); // Di chuyển quân cờ đến điểm đích

            if (HaiTuongDoiMatNhau()) // nước đi không hợp lệ nếu sau nước đi 2 tướng đối mặt nhau => hoàn tác nước đi
            {
                MessageBox.Show("Tướng phe bạn sẽ đối mặt với tướng đối phương sau nước đi này. Hãy chọn một nước đi khác.", "Nước đi không hợp lệ");
                QuanCoDuocChon.DiChuyen(departure);
                TraLaiQuanCo(QuanCoBiLoai, PtbBanCo);
                QuanCoDuocChon = null;
                QuanCoBiLoai = null;
                RefreshBanCo();
                return false;
            }
            if (CoChieuTuong(PheDoiPhuong(PheTa))) // nước đi không hợp lệ nếu sau nước đi tướng phe di chuyển bị đối phương chiếu => hoàn tác nước đi
            {
                MessageBox.Show("Tướng phe bạn sẽ gặp nguy sau nước đi này. Hãy chọn một nước đi khác.", "Nước đi không hợp lệ");
                QuanCoDuocChon.DiChuyen(departure);
                TraLaiQuanCo(QuanCoBiLoai, PtbBanCo);
                QuanCoDuocChon = null;
                QuanCoBiLoai = null;
                RefreshBanCo();
                return false;
            }
            HienThiNuocDi(departure, destination, PtbBanCo);
            LuuNuocDi(departure, destination);
            DoiPhe();
            return true;
        }

        public static void DoiPhuongDanh(Point departure, Point destination)
        {
            QuanCoDuocChon = Alive_RoundPictureBox.Find(element => element.Quan_Co.ToaDo == departure);
            LoaiBoQuanCo(destination, PtbBanCo);
            QuanCoDuocChon.DiChuyen(destination);
            HienThiNuocDi(departure, destination, PtbBanCo);
            LuuNuocDi(departure, destination);
            DoiPhe();
            if (CoChieuTuong(PheDoiPhuong(PheTa))) // nếu sau nước đi phe di chuyển chiếu tướng phe đối phương => thông báo cho người chơi
            {
                MessageBox.Show("Bạn bị chiếu tướng!");
            }
        }

        public static void DisableBanCo()
        {
            foreach (RoundPictureBox element in Alive_RoundPictureBox)
            {
                element.Enabled = false;
            }
        }
        #endregion
    }
}