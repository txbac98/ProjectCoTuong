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
    public class BanCo
    {
        #region attributes
        /* Thuộc tính dùng cho đối tượng QuanCo */
        public static List<QuanCo> alive = new List<QuanCo>();
        public static QuanTuong tuongXanh;
        public static QuanTuong tuongDo;

        /* Thuộc tính dùng cho đối tượng RoundPictureBox */
        public static RoundButton[,] diemBanCo = new RoundButton[9, 10]; // Mảng 2 chiều chứa 90 điểm bàn cờ
        public static List<RoundPictureBox> danhSachQuanCo = new List<RoundPictureBox>(); // List chứa tất cả các quân cờ còn sống
        public static RoundPictureBox quanCoBiLoai = null; // quân cờ vừa bị loại ở nước đi trước đó, nếu di chuyển thành công thì quanCoBiLoai không cần dùng đến => gán lại về null
        public static Point toaDoDuocChon = ThongSo.ToaDoNULL; // Tọa độ của quân cờ đang được chọn (được click vào), khi không có quân cờ nào đang được chọn thì bằng (-1, -1)
        public static int pheDuocDanh = 2; // Phe hiện tại đang được đánh (1 - Xanh, 2 - Đỏ). Phe Đỏ được đánh đầu tiên
        public static int soLuotDi = 0; // Số lượt đã đi từ đầu ván cờ
        public static PictureBox yellowSquareTarget = new PictureBox()
        {
            Width = 58,
            Height = 58,
            BackColor = Color.Transparent,
            Image = GameCoTuong.Properties.Resources.yellow_square_target,
            Location = new Point(863, 698)
        };
        public static PictureBox greySquareTarget_Depart = new PictureBox()
        {
            Width = 36,
            Height = 36,
            BackColor = Color.Transparent,
            Image = GameCoTuong.Properties.Resources.grey_square_target_depart,
            Location = new Point(863, 698)
        };
        public static PictureBox greySquareTarget_Dest = new PictureBox()
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
            return alive.Find(element => element.ToaDo == toaDo) != null;
        }
        public static QuanCo GetQuanCo(Point toaDo)
        {
            return alive.Find(element => element.ToaDo == toaDo);
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
        public static void TaoQuanCo(EventHandler QuanCo_Click)
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
        public static void XepBanCo(PictureBox ptbBanCo)
        {
            foreach (RoundPictureBox element in danhSachQuanCo)
                ptbBanCo.Controls.Add(element);
        }
        public static void RefreshBanCo()
        {
            foreach (RoundPictureBox element in danhSachQuanCo)
            {
                if (element.quanCo.Mau == pheDuocDanh)
                    element.Enabled = true;
                else element.Enabled = false;
                element.BringToFront();
            }
        }
        /*Dat ban co ve trang thai ban dau*/
        public static void SetToDefault(Label label2,Label label3, Button button1)
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
        public static void XoaBanCo(PictureBox ptbBanCo)
        {           
            ptbBanCo.Controls.Clear();
            tuongXanh = null;
            tuongDo = null;
            alive.Clear();
            danhSachQuanCo.Clear();
        }
        /* Tính toán và hiển thị tất cả điểm đích của quân cờ được chọn */
        public static void HienThiDiemDich(RoundPictureBox quanCoDuocChon, EventHandler DiemBanCo_Click) // Vẽ các điểm đích của quân cờ đang được chọn
        {
            if (quanCoDuocChon.quanCo.danhSachDiemDich.Count != 0)
                quanCoDuocChon.quanCo.danhSachDiemDich.Clear();
            quanCoDuocChon.quanCo.TinhNuocDi();
            foreach (Point element in quanCoDuocChon.quanCo.danhSachDiemDich)
            {
                QuanCo target = alive.Find(element1 => element1.Mau != quanCoDuocChon.quanCo.Mau && element1.ToaDo == element);
                if (target != null)
                    diemBanCo[element.X, element.Y].BackColor = Color.Red;
                diemBanCo[element.X, element.Y].Visible = true;
                diemBanCo[element.X, element.Y].BringToFront();
                diemBanCo[element.X, element.Y].Click += DiemBanCo_Click;
            }
        }
        /* Ẩn tất cả các điểm đích đang hiển thị trên bàn cờ */
        public static void AnDiemDich()
        {
            foreach (RoundButton element in diemBanCo)
            {
                element.Visible = false;
                element.BackColor = Color.Yellow;
            }
        }   
        /* Trả lại quân cờ vừa bị loại khỏi bàn cờ */
        public static void TraLaiQuanCo(PictureBox ptbBanCo)
        {
            if (quanCoBiLoai != null)
            {
                alive.Add(quanCoBiLoai.quanCo);
                danhSachQuanCo.Add(quanCoBiLoai);
                ptbBanCo.Controls.Add(quanCoBiLoai);
                quanCoBiLoai = null;
            }
            RefreshBanCo();
        }  
        public static void QuayLai(RoundPictureBox pieceToTakeBack, Point previousLocation)
        {
            pieceToTakeBack.DenViTri(previousLocation);
            toaDoDuocChon = ThongSo.ToaDoNULL;
        }
        public static bool HaiTuongDoiMatNhau()
        {
            if (tuongXanh.ToaDo.X == tuongDo.ToaDo.X) // nếu 2 tướng cùng hoành độ (thẳng hàng) ...
            {
                int X = tuongXanh.ToaDo.X;
                Point diemGiuaHaiTuong;
                for (int Y = tuongXanh.ToaDo.Y + 1; Y < tuongDo.ToaDo.Y; Y++) // ... thì xét xem giữa 2 tướng có quân cờ nào không
                {
                    diemGiuaHaiTuong = new Point(X, Y);
                    if (CoQuanCoTaiDay(diemGiuaHaiTuong))
                        return false; // nếu có 1 quân cờ ở giữa 2 tướng thì 2 tướng không đối mặt nhau
                }
                return true; // nếu không có quân cờ nào ở giữa 2 tướng thì 2 tướng đối mặt nhau
            }
            return false; // nếu 2 tướng không cùng hoành độ thì 2 tướng không đối mặt nhau
        }

        public static void LoaiBoQuanCo(Point toaDo, PictureBox ptbBanCo)
        {
            quanCoBiLoai = danhSachQuanCo.Find(element => element.quanCo.Mau != pheDuocDanh && element.quanCo.ToaDo == toaDo);
            if (quanCoBiLoai != null)
            {
                ptbBanCo.Controls.Remove(quanCoBiLoai);
                danhSachQuanCo.Remove(quanCoBiLoai);
                alive.Remove(quanCoBiLoai.quanCo);
            }
        }
        public static void DiChuyen(RoundPictureBox pieceToMove, Point destination)
        {

            pieceToMove.DenViTri(destination);
        }
        public static int PheDoiPhuong()
        {
            if (pheDuocDanh == 1) return 2;
            return 1;
        }
        /* Đổi phe sau mỗi nước đi */
        public static void DoiPhe(Label label3, Label label2, Button button1)
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
            if (soLuotDi != 0 && !button1.Enabled)
                button1.Enabled = true;
            RefreshBanCo();
        }
        public static bool ChieuTuong(int pheChieuTuong)
        {
            foreach (QuanCo element in alive)
            {
                if (element.Mau == pheChieuTuong)
                {
                    if (element.danhSachDiemDich.Count != 0)
                        element.danhSachDiemDich.Clear();
                    element.TinhNuocDi();
                    QuanCo target;
                    foreach (Point element1 in element.danhSachDiemDich)
                    {
                        target = alive.Find(element2 => element2.Mau != pheChieuTuong && element2.ToaDo == element1);
                        if (target != null)
                        {
                            if (target == tuongXanh || target == tuongDo)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public static void Highlight(RoundPictureBox selected, PictureBox ptbBanCo)
        {
            yellowSquareTarget.Location = new Point(selected.Location.X - 1, selected.Location.Y - 1);
            yellowSquareTarget.Parent = ptbBanCo;
        }

        public static void Dehighlight()
        {
            yellowSquareTarget.Parent = null;
            yellowSquareTarget.Location = new Point(863, 698);
        }

        public static void ShowTheMove(Point departure, Point destination, PictureBox ptbBanCo)
        {
            greySquareTarget_Depart.Location = new Point(ThongSo.ToaDoBanCoCuaQuanCo(departure).X + 10, ThongSo.ToaDoBanCoCuaQuanCo(departure).Y + 10);
            greySquareTarget_Dest.Location = new Point(ThongSo.ToaDoBanCoCuaQuanCo(destination).X - 1, ThongSo.ToaDoBanCoCuaQuanCo(destination).Y - 1);
            if (soLuotDi == 0)
            {
                greySquareTarget_Depart.Parent = ptbBanCo;
                greySquareTarget_Dest.Parent = ptbBanCo;
            }
        }
        #endregion
    }
}