using System;
using System.Runtime.Serialization;

[Serializable]
public class NhanVien : ISerializable
{
    public string id_nv { get; set; }
    public string ten_nv { get; set; }
    public uint tuoi { get; set; }
    public bool gioi_tinh { get; set; }
    public string dia_chi_nv { get; set; }
    public string username { get; set; }
    public string password { get; set; }

    public NhanVien() { }
    public NhanVien(string id_nv, string ten_nv, uint tuoi, bool gioi_tinh, string dia_chi_nv, string username, string password)
    {
        this.id_nv = id_nv;
        this.ten_nv = ten_nv;
        this.tuoi = tuoi;
        this.gioi_tinh = gioi_tinh;
        this.dia_chi_nv = dia_chi_nv;
        this.username = username;
        this.password = password;
    }


    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("id_nv", id_nv);
        info.AddValue("ten_nv", ten_nv);
        info.AddValue("tuoi", tuoi);
        info.AddValue("gioi_tinh", gioi_tinh);
        info.AddValue("dia_chi_nv", dia_chi_nv);
        info.AddValue("username", username);
        info.AddValue("password", password);
    }

    private NhanVien(SerializationInfo info, StreamingContext context)
    {
        id_nv = info.GetString("id_nv");
        ten_nv = info.GetString("ten_nv");
        tuoi = info.GetUInt32("tuoi");
        gioi_tinh = info.GetBoolean("gioi_tinh");
        dia_chi_nv = info.GetString("dia_chi_nv");
        username = info.GetString("username");
        password = info.GetString("password");
    }
}