using System.Runtime.Serialization;
using System.Xml.Serialization;
using System;

namespace DoAnCK
{
    [XmlInclude(typeof(HoaDonNhap))]
    [XmlInclude(typeof(HoaDonXuat))]
    [Serializable]
    public abstract class HoaDon : ISerializable
    {
        public string id_hoa_don { get; set; }
        public DateTime ngay_tao_don { get; set; }
        public QuanLyNhapXuat qlnx { get; set; }
        public NhanVien nv_lap { get; set; }
        public ulong tong_tien { get; set; }

        protected HoaDon() { }
        public HoaDon(QuanLyNhapXuat qlnx, string id_hoa_don, NhanVien nv_lap, ulong tong_tien)
        {
            this.ngay_tao_don = DateTime.Now;
            this.id_hoa_don = id_hoa_don;
            this.qlnx = qlnx;
            this.nv_lap = nv_lap;
            this.tong_tien = tong_tien;
        }

        public abstract string SetID();

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("id_hoa_don", id_hoa_don);
            info.AddValue("ngay_tao_don", ngay_tao_don);
            info.AddValue("qlnx", qlnx);
            info.AddValue("nv_lap", nv_lap);
            info.AddValue("tong_tien", tong_tien);
        }

        protected HoaDon(SerializationInfo info, StreamingContext context)
        {
            id_hoa_don = info.GetString("id_hoa_don");
            ngay_tao_don = (DateTime)info.GetValue("ngay_tao_don", typeof(DateTime));
            qlnx = (QuanLyNhapXuat)info.GetValue("qlnx", typeof(QuanLyNhapXuat));
            nv_lap = (NhanVien)info.GetValue("nv_lap", typeof(NhanVien));
            tong_tien = info.GetUInt64("tong_tien");
        }
    }

    [Serializable]
    public class HoaDonNhap : HoaDon
    {
        public NhaCungCap nha_cung_cap { get; set; }
        private HoaDonNhap() { }
        public HoaDonNhap(QuanLyNhapXuat qlnx, string id_hoa_don, NhanVien nv_lap, NhaCungCap nha_cung_cap, ulong tong_tien) : base(qlnx, id_hoa_don, nv_lap, tong_tien)
        {
            this.nha_cung_cap = nha_cung_cap;
            ngay_tao_don = DateTime.Now;
        }

        public override string SetID()
        {
            return "HDN";
        }


        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("nha_cung_cap", nha_cung_cap);
        }

        private HoaDonNhap(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            nha_cung_cap = (NhaCungCap)info.GetValue("nha_cung_cap", typeof(NhaCungCap));
        }
    }

    [Serializable]
    public class HoaDonXuat : HoaDon
    {
        public CuaHang cua_hang { get; set; }
        private HoaDonXuat() { }
        public HoaDonXuat(QuanLyNhapXuat qlnx, string id_hoa_don, NhanVien nv_lap, CuaHang cua_hang, ulong tong_tien) : base(qlnx, id_hoa_don, nv_lap, tong_tien)
        {
            ngay_tao_don = DateTime.Now;
            this.cua_hang = cua_hang;
        }

        public override string SetID()
        {
            return "HDX";
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("cua_hang", cua_hang);
        }

        private HoaDonXuat(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            cua_hang = (CuaHang)info.GetValue("cua_hang", typeof(CuaHang));
        }
    }
}