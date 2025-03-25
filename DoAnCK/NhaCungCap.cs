using System;
using System.Runtime.Serialization;

[Serializable]
public class NhaCungCap : ISerializable
{
    public string id_ncc { get; set; }
    public string ten_ncc { get; set; }
    public string sdt_ncc { get; set; }
    public string dia_chi_ncc { get; set; }

    private NhaCungCap() { }
    public NhaCungCap(string id_ncc, string ten_ncc, string sdt_ncc, string dia_chi_ncc)
    {
        this.id_ncc = id_ncc;
        this.ten_ncc = ten_ncc;
        this.sdt_ncc = sdt_ncc;
        this.dia_chi_ncc = dia_chi_ncc;
    }
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("id_ncc", id_ncc);
        info.AddValue("ten_ncc", ten_ncc);
        info.AddValue("sdt_ncc", sdt_ncc);
        info.AddValue("dia_chi_ncc", dia_chi_ncc);
    }

    private NhaCungCap(SerializationInfo info, StreamingContext context)
    {
        id_ncc = info.GetString("id_ncc");
        ten_ncc = info.GetString("ten_ncc");
        dia_chi_ncc = info.GetString("dia_chi_ncc");
        sdt_ncc = info.GetString("sdt_ncc");
    }
}