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
    
    public partial class TaiKhoan
    {
        public TaiKhoan()
        {
            this.ChuongTrinhDaoTaos = new HashSet<ChuongTrinhDaoTao>();
            this.DeCuongChiTiets = new HashSet<DeCuongChiTiet>();
            this.MonHocs = new HashSet<MonHoc>();
            this.PhanQuyenTaiKhoans = new HashSet<PhanQuyenTaiKhoan>();
        }
    
        public int Id { get; set; }
        public string Email { get; set; }
        public string Ten { get; set; }
        public string MatKhau { get; set; }
    
        public virtual ICollection<ChuongTrinhDaoTao> ChuongTrinhDaoTaos { get; set; }
        public virtual ICollection<DeCuongChiTiet> DeCuongChiTiets { get; set; }
        public virtual ICollection<MonHoc> MonHocs { get; set; }
        public virtual ICollection<PhanQuyenTaiKhoan> PhanQuyenTaiKhoans { get; set; }
    }
}
