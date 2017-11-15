using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Facebook;
using TrungTamYenMy.Models;
using TrungTamYenMy.Models.BusinessModel;

namespace TrungTamYenMy.Areas.Admin.Controllers
{
    public class DangNhapController : Controller
    {
        TrungTamYenMyEntities db = new TrungTamYenMyEntities();

        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }
        // GET: Admin/DangNhap
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult DangKy(User user)
        {
            if (ModelState.IsValid)
            {
                //chèn dl vào bảng user
                db.Users.Add(user);

                //lưu vào databasse
                db.SaveChanges();

                return RedirectToAction("DangNhap", "DangNhap");
            }
            else
            {

            }
            return View();
        }

        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(User model, string UserName, string Password)
        {
            {
                if (ModelState.IsValid)
                {
                    var dao = new UserDao();
                    var result = dao.DangNhap(model.UserName, Common.Md5Hash(model.Password), true);
                    if (result == 1)
                    {
                        var user = db.Users.SingleOrDefault(x => x.UserName == UserName);
                        var userSession = new UserLogin();
                        userSession.UserName = user.UserName;
                        userSession.UserID = user.UserID;
                        userSession.MaNhomNguoiDung = user.MaNhomNguoiDung;
                        var listCredentials = dao.GetListCredential(model.UserName);

                        Session.Add(CommonConstants.SESSION_CREDENTIALS, listCredentials);
                        Session.Add(CommonConstants.USER_SESSION, userSession);

                        Session["Name"] = user.Name;
                        Session["Avatar"] = user.Avatar;

                        return RedirectToAction("Index", "Home");
                    }
                    else if (result == 0)
                    {
                        ViewBag.ThongBao="Tài khoản không tồn tại.";
                    }
                    else if (result == -1)
                    {
                        ViewBag.ThongBao="Tài khoản đang bị khoá.";
                    }
                    else if (result == -2)
                    {
                        ViewBag.ThongBao= "Mật khẩu không đúng.";
                    }
                    else if (result == -3)
                    {
                        ViewBag.ThongBao= "Tài khoản của bạn không có quyền đăng nhập.";
                    }
                    else
                    {
                        ViewBag.ThongBao= "đăng nhập không đúng.";
                    }
                }
                return View();
            }
        }

        [AllowAnonymous]
        public ActionResult DangNhapFacebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email",
            });

            return Redirect(loginUrl.AbsoluteUri);
        }

        public ActionResult FacebookCallback(string codes)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                code = codes
            });


            var accessToken = result.access_token;
            if (!string.IsNullOrEmpty(accessToken))
            {
                fb.AccessToken = accessToken;
                // Get the user's information, like email, first name, middle name etc
                dynamic me = fb.Get("me?fields=first_name,middle_name,last_name,id,email");
                string email = me.email;
                string userName = me.email;
                string firstname = me.first_name;
                string middlename = me.middle_name;
                string lastname = me.last_name;

                var user = new User();
                user.Email = email;
                user.UserName = email;
                user.Status = true;
                user.Name = firstname + " " + middlename + " " + lastname;
                user.CreatedDate = DateTime.Now;
                var resultInsert = new UserDao().InsertForFacebook(user);
                if (resultInsert > 0)
                {
                    Session["UserID"] = user.UserID;
                    Session["UserName"] = user.UserName;
                    Session["Name"] = user.Name;
                    Session["Avatar"] = user.Avatar;
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult DangXuat()
        {
            Session["UserID"] = null;
            Session["UserName"] = null;
            Session["Name"] = null;
            Session["Avatar"] = null;
            return RedirectToAction("DangNhap");
        }

    }
}