using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

//namespace phải đúng
namespace TrungTamYenMy.Models
{

    [MetadataType(typeof(HocVien.HocVienMetadata))]
    public partial class HocVien
    {
        internal sealed class HocVienMetadata
        {
            [Display(Name = "Mã học viên")]
            [Required(ErrorMessage = "{0} không được để trống")]
            public long MaHV { get; set; }

            [Display(Name = "Tên học viên")]
            [Required(ErrorMessage = "{0} không được để trống")]
            public string TenHV { get; set; }

            [Display(Name = "Ngày sinh")]
            public Nullable<System.DateTime> NgaySinh { get; set; }

            [Display(Name = "Giới tính")]
            public string GioiTinh { get; set; }

            [Display(Name = "Quê quán")]
            public string QueQuan { get; set; }

            [Display(Name = "Số điện thoại")]
            public string SoDT { get; set; }

            [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail không đúng định dạng")]
            public string Email { get; set; }

            [Display(Name = "Mã lớp")]
            public Nullable<long> MaLop { get; set; }

            [Required(ErrorMessage = "{0} không được để trống")]
            
            public string UserName { get; set; }

            [Required(ErrorMessage = "{0} không được để trống")]
            public string Password { get; set; }

            [Display(Name = "Trạng thái")]
            public Nullable<bool> TrangThai { get; set; }
        }
    }
}