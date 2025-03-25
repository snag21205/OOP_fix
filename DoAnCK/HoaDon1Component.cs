using System;
using System.Windows.Forms;

namespace DoAnCK
{
    public partial class HoaDon1Component : UserControl
    {
        private FormPhieuHoaDon HoaDon;
        public HangHoa hh;
        public HoaDon1Component(FormPhieuHoaDon HoaDon)
        {
            InitializeComponent();
            this.HoaDon = HoaDon;
        }
        public void SetProductInfo(HangHoa hh)
        {
            id_bhdx.Text = hh.id.ToString();
            sp_bhdx.Text = hh.ten_hang;
            sl_bhdx.Text = hh.so_luong.ToString();
            tt_bhdx.Text = String.Format("{0:N0}", hh.don_gia * hh.so_luong);
        }
    }
}
