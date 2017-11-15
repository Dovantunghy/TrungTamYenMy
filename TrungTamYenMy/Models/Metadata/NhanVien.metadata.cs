using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrungTamYenMy.Models
{
    [MetadataType(typeof(NhanVien.NhanVienMetadata))]
    public partial class NhanVien
    {
        internal sealed class NhanVienMetadata
        {
            [Display(Name = "Mã nhân viên")]
            [Required(ErrorMessage = "{0} không được để trống")]
            public long MaNV { get; set; }

            [Display(Name = "Tên nhân viên")]
            [Required(ErrorMessage = "{0} không được để trống")]
            public string TenNV { get; set; }

            [Display(Name = "Ngày sinh")]
            public Nullable<System.DateTime> NgaySinh { get; set; }

            [Display(Name = "Quê quán")]
            public string QueQuan { get; set; }

            [Display(Name = "Số điện thoại")]
            public string SoDT { get; set; }

            
            public string Email { get; set; }

            [Display(Name = "Lương")]

            public string Luong { get; set; }

            public string UserName { get; set; }
            public string Password { get; set; }

            [Display(Name = "Chức vụ")]
            public string ChucVu { get; set; }
        }
        
    }
}