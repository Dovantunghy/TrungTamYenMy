using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrungTamYenMy.Models.BusinessModel
{
    public class UserDao
    {
        TrungTamYenMyEntities db=new TrungTamYenMyEntities();
        public long InsertForFacebook(User entity)
        {
            var user = db.Users.SingleOrDefault(x => x.UserName == entity.UserName);
            if (user == null)
            {
                db.Users.Add(entity);
                db.SaveChanges();
                return entity.UserID;
            }
            else
            {
                return user.UserID;
            }

        }

        public List<string> GetListCredential(string userName)
        {
            var user = db.Users.Single(x => x.UserName == userName);
            var data = (from a in db.NhomNguoiDung_Quyen
                        join b in db.NhomNguoiDungs on a.MaNhomNguoiDung equals b.MaNhomNguoiDung
                        join c in db.Quyens on a.MaQuyen equals c.MaQuyen
                        where b.MaNhomNguoiDung == user.MaNhomNguoiDung
                        select new
                        {
                            maQuyen = a.MaQuyen,
                            maNhomNguoiDung = a.MaNhomNguoiDung
                        }).AsEnumerable().Select(x => new NhomNguoiDung_Quyen()
                        {
                            MaQuyen = x.maQuyen,
                            MaNhomNguoiDung = x.maNhomNguoiDung
                        });
            return data.Select(x => x.MaQuyen).ToList();

        }

        public int DangNhap(string userName, string passWord, bool isLoginAdmin = false)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (isLoginAdmin == true)
                {
                    if (result.MaNhomNguoiDung == CommonConstants.ADMIN_GROUP || result.MaNhomNguoiDung == CommonConstants.MOD_GROUP)
                    {
                        if (result.Status == false)
                        {
                            return -1;
                        }
                        else
                        {
                            if (result.Password == passWord)
                                return 1;
                            else
                                return -2;
                        }
                    }
                    else
                    {
                        return -3;
                    }
                }
                else
                {
                    if (result.Status == false)
                    {
                        return -1;
                    }
                    else
                    {
                        if (result.Password == passWord)
                            return 1;
                        else
                            return -2;
                    }
                }
            }
        }

    }
}