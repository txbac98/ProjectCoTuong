using GameCoTuong.ChatLan;
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
        private static string playerName;
        public KhoiDong()
        {
            InitializeComponent();
        }

        public static string PlayerName
        { get => playerName; set => playerName = value; }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button1.Enabled = true;
            panel2.Visible = true;
            panel1.Visible = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                label2.Enabled = false;
                textBox2.Enabled = false;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                label2.Enabled = true;
                textBox2.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}