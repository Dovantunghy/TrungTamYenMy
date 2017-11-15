using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;

namespace TrungTamYenMy.Models
{
    [MetadataType(typeof(GiaoVien.GiaoVienMetadata))]
    public partial class GiaoVien
    {
        internal sealed class GiaoVienMetadata
        {
            [Display(Name = "Mã giáo viên")]
            [Required(ErrorMessage = "{0} không được để trống")]
            public long MaGV { get; set; }

            [Display(Name = "Tên giáo viên")]
            [Required(ErrorMessage = "{0} không được để trống")]
            public string TenGV { get; set; }

            [Display(Name = "Ảnh")]
            public string Anh { get; set; }

            [Display(Name = "Thông tin")]
            public string ThongTin { get; set; }

            [Display(Name = "Quê quán")]
            public string QueQuan { get; set; }

            [Display(Name = "Số năm công tác")]
            public Nullable<int> SoNamCongTac { get; set; }

            [Display(Name = "Nơi công tác")]
            public string NoiCongTac { get; set; }

            [Display(Name = "Số điện thoại")]
            public string SoDT { get; set; }

            public string Email { get; set; }

            [Display(Name = "Lương")]
            public Nullable<int> Luong { get; set; }

            [Display(Name = "Mã lớp")]
            public Nullable<long> MaLop { get; set; }

            [Required(ErrorMessage = "{0} không được để trống")]
           
            public string Username { get; set; }

            [Required(ErrorMessage = "{0} không được để trống")]
            public string Password { get; set; }

            [Display(Name = "Trạng thái")]
            public Nullable<bool> TrangThai { get; set; }
        }
    }
}