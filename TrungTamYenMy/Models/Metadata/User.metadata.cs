using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//2 thư viện thiết kế class metadata
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TrungTamYenMy.Models
{
    [MetadataTypeAttribute(typeof(UserMetadata))]
    public partial class User
    {
        //lớp chỉ dùng cho class này và không cho phép kế thừa "sealed"
        internal sealed class UserMetadata
        {
            public long UserID { get; set; }
            [Display(Name = "Tên tài khoản")]
            [Required(ErrorMessage = "{0} không được để trống")]
            public string UserName { get; set; }

            [Display(Name = "Mật khẩu")]
            [Required(ErrorMessage = "{0} không được để trống")]
            public string Password { get; set; }
            [Display(Name = "Họ tên")]
            public string Name { get; set; }

            [Display(Name = "Nhóm người dùng")]
            public string MaNhomNguoiDung { get; set; }

            [Display(Name = "Ảnh")]
            public string Avatar { get; set; }

            [Display(Name = "Địa chỉ")]
            public string Address { get; set; }
            [Display(Name = "Ngày sinh")]
            public Nullable<System.DateTime> Birthday { get; set; }
            [Display(Name = "Giới tính")]
            public string Gender { get; set; }
            public string Email { get; set; }
            [Display(Name = "Số điện thoại")]
            public string Phone { get; set; }

            [Display(Name = "Ngày tạo")]
            public Nullable<System.DateTime> CreatedDate { get; set; }

            [Display(Name = "Người tạo")]
            public string CreatedBy { get; set; }

            [Display(Name = "Ngày thay đổi")]
            public Nullable<System.DateTime> ModifiedDate { get; set; }


            [Display(Name = "Người chỉnh sửa")]
            public string ModifiedBy { get; set; }

            [Display(Name = "Trạng thái")]
            public bool Status { get; set; }
        }
    }
}