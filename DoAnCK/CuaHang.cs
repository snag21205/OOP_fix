using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

[Serializable]
public class CuaHang : ISerializable
{
    
    public string id_ch { get; set; } 
    public string ten_ch { get; set; } 
    public string sdt_ch { get; set; } 
    public string dia_chi_ch { get; set; } 
    private CuaHang() { } 

    
    public CuaHang(string id_ch, string ten_ch, string sdt_ch, string dia_chi_ch)
    {
        this.id_ch = id_ch;
        this.ten_ch = ten_ch;
        this.sdt_ch = sdt_ch;
        this.dia_chi_ch = dia_chi_ch;
    }

   
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("id_ch", id_ch); 
        info.AddValue("ten_ch", ten_ch); 
        info.AddValue("sdt_ch", sdt_ch); 
        info.AddValue("dia_chi_ch", dia_chi_ch); 
    }

    
    private CuaHang(SerializationInfo info, StreamingContext context)
    {
        id_ch = info.GetString("id_ch"); 
        ten_ch = info.GetString("ten_ch"); 
        dia_chi_ch = info.GetString("dia_chi_ch");
        sdt_ch = info.GetString("sdt_ch"); 
    }

    // Các phương thức truy cập (Getters)
    public string GetIdCh()
    {
        return id_ch;
    }

    public string GetTenCh()
    {
        return ten_ch;
    }

    public string GetSdtCh()
    {
        return sdt_ch;
    }

    public string GetDiaChiCh()
    {
        return dia_chi_ch;
    }
}


public class QuanLyNhapXuat
{
    public List<HangHoa> ds_hang_hoa = new List<HangHoa>();


    public void them_hh(HangHoa hh)
    {
        ds_hang_hoa.Add(hh);
    }

    public void xoa_hh(HangHoa hh)
    {
        ds_hang_hoa.Remove(hh);
    }

    public void tang_sl(HangHoa hh)
    {
        hh.so_luong++;
    }

    public void giam_sl(HangHoa hh)
    {
        if (hh.so_luong > 1)
        {
            hh.so_luong--;
        }
    }

    public void cap_nhat_sl(HangHoa hh, uint sl_moi)
    {
        hh.so_luong = sl_moi;
    }

    public bool ton_tai(HangHoa hh)
    {
        foreach (HangHoa hh_check in ds_hang_hoa)
        {
            if (hh_check.id == hh.id)
            {
                return true;
            }
        }
        return false;
    }

    public ulong tinh_tong_tien()
    {
        ulong tong_tien = 0;
        foreach (HangHoa hh in ds_hang_hoa)
        {
            tong_tien += hh.don_gia * hh.so_luong;
        }
        return tong_tien;
    }
}