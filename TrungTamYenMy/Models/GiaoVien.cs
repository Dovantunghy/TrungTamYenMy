//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrungTamYenMy.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class GiaoVien
    {
        public long MaGV { get; set; }
        public string TenGV { get; set; }
        public string Anh { get; set; }
        public string ThongTin { get; set; }
        public string MoTa { get; set; }
        public string GioiThieu { get; set; }
        public string QueQuan { get; set; }
        public Nullable<int> SoNamCongTac { get; set; }
        public string NoiCongTac { get; set; }
        public string SoDT { get; set; }
        public string Email { get; set; }
        public Nullable<int> Luong { get; set; }
        public Nullable<long> MaLop { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Nullable<bool> TrangThai { get; set; }
    
        public virtual LopHoc LopHoc { get; set; }
    }
}
