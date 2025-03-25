﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoAnCK
{
    public partial class HangHoaNhapXuatComponent : UserControl
    {
        public HangHoaNhapXuatComponent(FormNhapXuat NhapHang)
        {
            InitializeComponent();
            this.NhapHang = NhapHang;
        }
        private FormNhapXuat NhapHang;
        public HangHoa hh;
        public void SetProductInfo(HangHoa hh)
        {
            ten_lbl.Text = hh.ten_hang;
            dongia_lbl.Text = String.Format("{0:N0}", hh.don_gia);
            soluong_lbl.Text = "SL: " + hh.so_luong.ToString();
            if (hh.img != null)
            {
                hanghoa_img.ImageLocation = hh.img;
            }
            else
            {
                hanghoa_img.ImageLocation = "Resources/default.jpg";
            }
        }

        #region Event
        private void Mouse_Enter(object sender, EventArgs e)
        {
            guna2GradientPanel1.FillColor = Color.Gray;

        }
        private void Mouse_Leave(object sender, EventArgs e)
        {
            guna2GradientPanel1.FillColor = Color.FromArgb(192, 255, 192);
        }

        private void Mouse_Click(object sender, EventArgs e)
        {
            NhapHang.them_hh_lo(hh);
        }
        #endregion

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
