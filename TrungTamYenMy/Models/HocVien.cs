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
    
    public partial class HocVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HocVien()
        {
            this.KetQuaHocTaps = new HashSet<KetQuaHocTap>();
            this.LopHoc_HocVien = new HashSet<LopHoc_HocVien>();
            this.PhieuDiemDanhs = new HashSet<PhieuDiemDanh>();
        }
    
        public long MaHV { get; set; }
        public string TenHV { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string QueQuan { get; set; }
        public string SoDT { get; set; }
        public string Email { get; set; }
        public Nullable<long> MaLop { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<bool> TrangThai { get; set; }
    
        public virtual LopHoc LopHoc { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KetQuaHocTap> KetQuaHocTaps { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LopHoc_HocVien> LopHoc_HocVien { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuDiemDanh> PhieuDiemDanhs { get; set; }
    }
}
