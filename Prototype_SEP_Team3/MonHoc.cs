//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prototype_SEP_Team3
{
    using System;
    using System.Collections.Generic;
    
    public partial class MonHoc
    {
        public MonHoc()
        {
            this.DeCuongChiTiets = new HashSet<DeCuongChiTiet>();
            this.DeCuongChiTiets1 = new HashSet<DeCuongChiTiet>();
            this.MonTienQuyets = new HashSet<MonTienQuyet>();
            this.MonTienQuyets1 = new HashSet<MonTienQuyet>();
        }
    
        public int Id { get; set; }
        public int ChuongTrinhDaoTao_Id { get; set; }
        public string TenMonHoc { get; set; }
        public string TenTiengAnh { get; set; }
        public int LoaiKienThuc { get; set; }
        public int SoTinChi { get; set; }
        public int HocKy { get; set; }
        public int GiangVienPhuTrach_Id { get; set; }
        public string NoiDungVanTat { get; set; }
        public int SoGioLyThuyet { get; set; }
        public int SoGioThucHanh { get; set; }
        public string Monhoc_Id { get; set; }
    
        public virtual ChuongTrinhDaoTao ChuongTrinhDaoTao { get; set; }
        public virtual ICollection<DeCuongChiTiet> DeCuongChiTiets { get; set; }
        public virtual ICollection<DeCuongChiTiet> DeCuongChiTiets1 { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
        public virtual ICollection<MonTienQuyet> MonTienQuyets { get; set; }
        public virtual ICollection<MonTienQuyet> MonTienQuyets1 { get; set; }
    }
}
