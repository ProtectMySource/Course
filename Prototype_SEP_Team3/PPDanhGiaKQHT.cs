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
    
    public partial class PPDanhGiaKQHT
    {
        public int Id { get; set; }
        public int DeCuongChiTiet_Id { get; set; }
        public string LoaiNoiDung { get; set; }
        public string SoLanDanhGia { get; set; }
        public string TrongSo { get; set; }
        public string HinhThucDanhGia { get; set; }
    
        public virtual DeCuongChiTiet DeCuongChiTiet { get; set; }
    }
}