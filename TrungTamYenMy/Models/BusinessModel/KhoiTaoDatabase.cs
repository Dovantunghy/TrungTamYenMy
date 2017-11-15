//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Web;
//using TrungTamYenMy_CodeFirst.Models.DataModel;

//namespace TrungTamYenMy_CodeFirst.Models.BusinessModel
//{
//    //kế thừa 1 lớp hệ thống, lớp này có tác dụng là nó sẽ dựa vào cái dbcontext mà chúng ta chỉ ra
//    //xem model có thay đổi hay không-nếu model thay đổi thì nó sẽ tự động xóa database đi tạo lại
//    public class KhoiTaoDatabase : DropCreateDatabaseIfModelChanges<TrungTamYenMyDbContext>
//    {
//        protected override void Seed(TrungTamYenMyDbContext context)
//        {
//            var admin = new User()
//            {
//                UserName = "tungAdmin",
//                Password = "e10adc3949ba59abbe56e057f20f883e",
//                Name = "Đỗ Văn Tùng",
//                Avatar = "/Assets/admin/IMG/admin.jpg",
//                Email = "Dovantunghy186@gmail.com",
//                Authorities = true,
//                Status = true
//            };
//            context.Users.Add(admin);

//            var user01 = new User()
//            {
//                UserName = "user01",
//                Password = "e10adc3949ba59abbe56e057f20f883e",
//                Name = "user01",
//                Avatar = "/Assets/admin/IMG/admin.jpg",
//                Email = "user01@gmail.com",
//                Authorities = false,
//                Status = true
//            };
//            context.Users.Add(user01);

//            context.SaveChanges();
//        }
//    }
//}