// Created by Hakuryuu (dev@hakuryuu.net)
// 04/2022
// 
// Main View, click on the Dogecoint image will instantly close the Program.

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

namespace kekw
{
    public partial class Form1 : Form
    {
        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0002;
        private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private bool exit = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A critical error occured, please check your internet connection...","CRITICAL ERROR 0x00829348", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Form1 form = new Form1();
            //form.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BG_MAIN _bm = new BG_MAIN(true);
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
            lblTime.Text = $"00:{BG_MAIN.TIME}";
            timer1.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                exit = true;
                Environment.Exit(0);
                BG_MAIN.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BG_MAIN.TIME--;
            lblTime.Text = $"00:{BG_MAIN.TIME}";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
            BG_MAIN.Close();
        }
    }
}
