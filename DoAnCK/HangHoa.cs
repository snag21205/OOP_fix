using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;


[XmlInclude(typeof(DienTu))]
[XmlInclude(typeof(GiaDung))]
[XmlInclude(typeof(ThoiTrang))]
[Serializable]
public abstract class HangHoa : ISerializable, ICloneable
{
    public string id { get; set; }
    public string ten_hang { get; set; }
    public uint so_luong { get; set; }
    public ulong don_gia { get; set; }
    public string img { get; set; }

    protected HangHoa() { }

    public HangHoa(string id, string ten_hang, uint so_luong, ulong don_gia, string img)
    {
        this.id = id;
        this.ten_hang = ten_hang;
        this.so_luong = so_luong;
        this.don_gia = don_gia;
        this.img = img;
    }

    public object Clone()
    {
        HangHoa clone = (HangHoa)this.MemberwiseClone();
        clone.id = this.id;
        clone.ten_hang = this.ten_hang;
        clone.don_gia = this.don_gia;
        return clone;
    }


    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("id", id);
        info.AddValue("ten_hang", ten_hang);
        info.AddValue("so_luong", so_luong);
        info.AddValue("don_gia", don_gia);
        info.AddValue("img", img);
    }

    protected HangHoa(SerializationInfo info, StreamingContext context)
    {
        id = info.GetString("id");
        ten_hang = info.GetString("ten_hang");
        so_luong = info.GetUInt32("so_luong");
        don_gia = info.GetUInt64("don_gia");
        img = info.GetString("img");
    }
}

[Serializable]
public class DienTu : HangHoa
{
    private DienTu() { }

    public DienTu(string id, string ten_hang, uint so_luong, ulong don_gia, string img) : base(id, ten_hang, so_luong, don_gia, img)
    {

    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);
    }

    private DienTu(SerializationInfo info, StreamingContext context) : base(info, context)
    {

    }
}

[Serializable]
public class GiaDung : HangHoa
{
    private GiaDung() { }

    public GiaDung(string id, string ten_hang, uint so_luong, ulong don_gia, string img) : base(id, ten_hang, so_luong, don_gia, img)
    {

    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);
    }

    private GiaDung(SerializationInfo info, StreamingContext context) : base(info, context)
    {

    }
}

[Serializable]
public class ThoiTrang : HangHoa
{
    private ThoiTrang() { }

    public ThoiTrang(string id, string ten_hang, uint so_luong, ulong don_gia, string img) : base(id, ten_hang, so_luong, don_gia, img)
    {

    }


    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);
    }

    private ThoiTrang(SerializationInfo info, StreamingContext context) : base(info, context)
    {

    }
}