using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrungTamYenMy.Models;
using TrungTamYenMy.Models.BusinessModel;


namespace TrungTamYenMy.Controllers
{
    public class HomeController : Controller
    {
        TrungTamYenMyEntities db=new TrungTamYenMyEntities();
        // GET: Home
        [OutputCache(Duration = 3600 * 24)]
        public ActionResult Index()
        {
            var TinMoi = db.TinTucs.Take(4).ToList();
            return View(TinMoi);
        }


        [OutputCache(Duration = 3600*24)]
        public ActionResult LienHe()
        {
            var lienHe = new LienHeHp().LayThongTin();
            return View(lienHe);
        }

        [HttpPost]
        public JsonResult Send(string name, string email,string sdt,string diachi,string content)
        {
            var feedback=new FeedBack();
            feedback.HoTen = name;
            feedback.Email = email;
            feedback.SoDT = sdt;
            feedback.DiaChi = diachi;
            feedback.TinNhan = content;

            var id=new LienHeHp().InsertFeedBack(feedback);
            if (id > 0)
            {
                return Json(new
                {
                    TrangThai = true
                });
                //send mail
            }

            else
                return Json(new
                {
                    TrangThai = false
                });
        }
    }
}