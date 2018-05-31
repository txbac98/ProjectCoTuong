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
    public partial class KhoiDong : Form
    {
        public static DialogResult FormResult { get; private set; }

        public KhoiDong()
        {
            InitializeComponent();
        }

        private void btnOfflineMode_Click(object sender, EventArgs e)
        {
            btnOfflineMode.Enabled = false;
            btnPvpMode.Enabled = true;
            panel1.Enabled = true;
            panel2.Enabled = false;
        }

        private void btnPvpMode_Click(object sender, EventArgs e)
        {
            btnPvpMode.Enabled = false;
            btnOfflineMode.Enabled = true;
            panel2.Enabled = true;
            panel1.Enabled = false;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (radioNewGamePvp.Checked)
            {
                CoTuong.BanCo.PheTa = 2;
            }
            else if (radioConnectPvp.Checked)
            {
                CoTuong.BanCo.PheTa = 1;
            }
            if (tbPlayerName.Text != string.Empty)
                CoTuong.BanCo.Name = tbPlayerName.Text;
            else
            {
                if (radioNewGamePvp.Checked)
                    CoTuong.BanCo.Name = "PlayerRed";
                else if (radioConnectPvp.Checked)
                    CoTuong.BanCo.Name = "PlayerBlue";
            }
            FormResult = DialogResult.Yes;
            this.Close();
        }
    }
}