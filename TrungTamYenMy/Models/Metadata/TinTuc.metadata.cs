using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrungTamYenMy.Models
{
    [MetadataType(typeof(TinTuc.TinTucMetadata))]
    public partial class TinTuc
    {
        internal sealed class TinTucMetadata
        {
            [Display(Name = "Mã tin tức")]
            [Required(ErrorMessage = "{0} không được để trống")]
            public long MaTinTuc { get; set; }

            [Display(Name = "Tiêu đề")]
            [Required(ErrorMessage = "{0} không được để trống")]
            public string TieuDe { get; set; }

            [Display(Name = "Tiêu đề meta")]
            public string MetaTitle { get; set; }

            [Display(Name = "Mô tả")]
            public string Mota { get; set; }

            [Display(Name = "Hình ảnh")]
            public string HinhAnh { get; set; }

            [Display(Name = "Nội dung")]
            public string NoiDung { get; set; }

            [Display(Name = "Người viết")]
            public string NguoiViet { get; set; }

            [Display(Name = "Người đăng")]
            public string NguoiDang { get; set; }

            [Display(Name = "Ngày đăng")]
            public Nullable<System.DateTime> NgayDang { get; set; }


            [Display(Name = "Loại tin")]
            public Nullable<long> MaLoaiTin { get; set; }

            [Display(Name = "Bài mới")]
            public Nullable<System.DateTime> TopHot { get; set; }

            [Display(Name = "Số lượt xem")]
            public Nullable<int> SoLuotXem { get; set; }

            [Display(Name = "Trạng thái")]
            public Nullable<bool> TrangThai { get; set; }

        }
    }
}