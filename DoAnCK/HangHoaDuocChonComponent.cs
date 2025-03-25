using System;
using System.Windows.Forms;

namespace DoAnCK
{
    public partial class HangHoaDuocChonComponent : UserControl
    {
        public HangHoaDuocChonComponent(FormNhapXuat NhapXuat)
        {
            InitializeComponent();
            this.NhapXuat = NhapXuat;
        }
        private FormNhapXuat NhapXuat;
        public HangHoa hh;

        public void SetProductInfo()
        {
            id_lbl.Text = hh.id.ToString();
            ten_lbl.Text = hh.ten_hang;
            soluong_tb.Text = hh.so_luong.ToString();
            thanhtien_lbl.Text = String.Format("{0:N0}",hh.don_gia * hh.so_luong);
        }

        #region Event
        private void xoa_btn_Click(object sender, EventArgs e)
        {
            NhapXuat.xoa_hh_lo(this);
        }

        private void soluong_tb_TextChanged(object sender, EventArgs e)
        {
            if (soluong_tb.Text != "")
            {
                hh.so_luong = Convert.ToUInt32(soluong_tb.Text);
                soluong_tb.Text = hh.so_luong.ToString();
                thanhtien_lbl.Text = String.Format("{0:N0}", hh.don_gia * hh.so_luong);
                NhapXuat.nhap_sl(this);
            }
        }

        private void soluong_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
       
        #endregion

        
    }
}
