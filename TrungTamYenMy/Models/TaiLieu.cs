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
    
    public partial class TaiLieu
    {
        public long MaTaiLieu { get; set; }
        public string TenTaiLieu { get; set; }
        public string MoTa { get; set; }
        public Nullable<long> MaLop { get; set; }
        public Nullable<bool> TrangThai { get; set; }
    
        public virtual LopHoc LopHoc { get; set; }
    }
}
