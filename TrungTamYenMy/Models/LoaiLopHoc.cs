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
    
    public partial class LoaiLopHoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiLopHoc()
        {
            this.LopHocs = new HashSet<LopHoc>();
        }
    
        public long MaLoaiLop { get; set; }
        public string TenLoaiLop { get; set; }
        public string MetaTitle { get; set; }
        public Nullable<long> ParentID { get; set; }
        public Nullable<int> ThuTuHienThi { get; set; }
        public string CeoTitle { get; set; }
        public Nullable<System.DateTime> NgayTao { get; set; }
        public string TaoBoi { get; set; }
        public Nullable<bool> TrangThai { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LopHoc> LopHocs { get; set; }
    }
}
