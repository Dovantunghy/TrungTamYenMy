using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrungTamYenMy.Models
{
    [MetadataType(typeof(LopHoc.LopHocMetadata))]
    public partial class LopHoc
    {
        internal sealed class LopHocMetadata
        {
            [Display(Name = "Mã lớp học")]
            [Required(ErrorMessage = "{0} không được để trống")]
            public long MaLop { get; set; }

            [Display(Name = "Lớp")]
            public string Lop { get; set; }

            [Display(Name = "Tên lớp học")]
            [Required(ErrorMessage = "{0} không được để trống")]
            public string TenLop { get; set; }

            [Display(Name = "Tiêu đề meta")]
            public string MetatTitle { get; set; }

            [Display(Name = "Mô tả")]
            public string MoTa { get; set; }

            [Display(Name = "Hình ảnh")]
            public string HinhAnh { get; set; }

            [Display(Name = "Tên giáo viên dạy")]
            public string TenGiaoVienDay { get; set; }

            [Display(Name = "Thứ")]
            public string Thu { get; set; }

            [Display(Name = "Khung giờ học")]
            public string KhungGioHoc { get; set; }

            [Display(Name = "Số học viên")]
           
            [Required(ErrorMessage = "{0} không được để trống")]
            public Nullable<int> SoHV { get; set; }

            [Display(Name = "Ngày tạo")]
            public Nullable<System.DateTime> NgayTao { get; set; }

            [Display(Name = "Ngày bắt đầu")]
            public Nullable<System.DateTime> NgayBatDau { get; set; }

            [Display(Name = "Ngày kết thúc")]
            public Nullable<System.DateTime> NgayKetThuc { get; set; }

            [Display(Name = "Loại lớp")]
            public Nullable<long> MaLoaiLop { get; set; }

            [Display(Name = "Top Hot")]
            public Nullable<System.DateTime> TopHot { get; set; }

            [Display(Name = "Trạng thái")]
            public Nullable<bool> TrangThai { get; set; }

        }
    }
}