﻿using GameCoTuong.CoTuong;
using GameCoTuong.ProgramConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCoTuong
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new KhoiDong());
            if (KhoiDong.FormResult == DialogResult.Yes)
                Application.Run(new Form1());
        }
    }
}