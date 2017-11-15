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
    public class NguoiDungController : BaseController
    {
        // GET: Admin/NguoiDung

        TrungTamYenMyEntities db = new TrungTamYenMyEntities();

       

        public ActionResult DsNguoiDung()
        {
            return View(db.Users.ToList());
        }

        

        [HttpGet]
        public ActionResult ThemNguoiDung()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult ThemNguoiDung(User user)
        {
            if (ModelState.IsValid)
            {
                //chèn dl vào bảng user
                db.Users.Add(user);

                //lưu vào databasse
                db.SaveChanges();
                return RedirectToAction("DsNguoiDung", "NguoiDung");

            }
            else
            {

            }
            return View();
        }

        [HttpGet]
        public ActionResult ChinhSua(long ID)
        {
            User nguoiDung = db.Users.SingleOrDefault(x => x.UserID == ID);
            if (nguoiDung == null)
            {
                return null;
            }

            return View(nguoiDung);
        }

        [HttpPost]
        public ActionResult ChinhSua(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("DsNguoiDung");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Xoa(long ID)
        {
            User user = db.Users.SingleOrDefault(x => x.UserID == ID);
            if (user==null)
            {
                return null;
            }
            return View(user);
        }

        [HttpPost,ActionName("Xoa")]
        public ActionResult XacNhanXoa(long ID)
        {
            User user = db.Users.SingleOrDefault(x => x.UserID == ID);
            if (user == null)
            {
                return null;
            }
            db.Users.Remove(user);
            db.SaveChanges();

            return RedirectToAction("DsNguoiDung");
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new Change().ChangeStatus(id);
            return Json(new { status = result });
        }


    }
}