using System;
using System.Windows.Forms;

namespace DoAnCK
{
    public partial class FormHoaDon : System.Windows.Forms.Form
    {
        KhoHang kho = new KhoHang();
        private bool isnhap;

        private int index;

        public FormHoaDon(bool isnhap)
        {
            InitializeComponent();
            kho.LoadData();
            this.isnhap = isnhap;
        }

        #region Event
        private void HoaDon_load(object sender, EventArgs e)
        {
            try
            {
                if (isnhap)
                {
                    label1.Text = "Danh sách hoá đơn nhập";
                    DanhSachHoaDon_dgv.Columns["idnccch_hd"].HeaderText = "ID nhà cung cấp";
                    foreach (HoaDonNhap hdn in kho.ds_hoa_don_nhap)
                    {
                        DanhSachHoaDon_dgv.Rows.Add(hdn.id_hoa_don, hdn.ngay_tao_don, hdn.nv_lap.id_nv, hdn.nha_cung_cap.id_ncc, hdn.tong_tien);
                    }
                    DanhSachHoaDon_dgv.Enabled = DanhSachHoaDon_dgv.Rows.Count > 0;
                }
                else
                {
                    label1.Text = "Danh sách hoá đơn xuất";
                    DanhSachHoaDon_dgv.Columns["idnccch_hd"].HeaderText = "ID cửa hàng";
                    foreach (HoaDonXuat hdx in kho.ds_hoa_don_xuat)
                    {
                        DanhSachHoaDon_dgv.Rows.Add(hdx.id_hoa_don, hdx.ngay_tao_don, hdx.nv_lap.id_nv, hdx.cua_hang.id_ch, hdx.tong_tien);
                    }
                    DanhSachHoaDon_dgv.Enabled = DanhSachHoaDon_dgv.Rows.Count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DanhSachHoaDon_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                index = DanhSachHoaDon_dgv.CurrentCell.RowIndex;
                if (isnhap)
                {
                    HoaDonNhap hdn = kho.ds_hoa_don_nhap[index];
                    FormPhieuHoaDon formHoaDon = new FormPhieuHoaDon();
                    formHoaDon.hd_lbl.Text = "Hoá Đơn Nhập";
                    formHoaDon.ngaylap_lbl.Text = "Ngày lập: " + DateTime.Now.ToString();
                    formHoaDon.idnv_lbl.Text = "ID nhân viên lập: " + hdn.nv_lap.id_nv;
                    formHoaDon.idhd_lbl.Text = "ID hoá đơn: " + hdn.id_hoa_don;
                    formHoaDon.idncc_ch_lbl.Text = "ID nhà cung cấp: " + hdn.nha_cung_cap.id_ncc;
                    formHoaDon.them_dshh(hdn.qlnx);
                    formHoaDon.Show();
                }
                else
                {
                    HoaDonXuat hdx = kho.ds_hoa_don_xuat[index];
                    FormPhieuHoaDon formHoaDon = new FormPhieuHoaDon();
                    formHoaDon.hd_lbl.Text = "Hoá Đơn Xuất";
                    formHoaDon.ngaylap_lbl.Text = "Ngày lập: " + DateTime.Now.ToString();
                    formHoaDon.idnv_lbl.Text = "ID nhân viên lập: " + hdx.nv_lap.id_nv;
                    formHoaDon.idhd_lbl.Text = "ID hoá đơn: " + hdx.id_hoa_don;
                    formHoaDon.idncc_ch_lbl.Text = "ID cửa hàng: " + hdx.cua_hang.id_ch;
                    formHoaDon.them_dshh(hdx.qlnx);
                    formHoaDon.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
