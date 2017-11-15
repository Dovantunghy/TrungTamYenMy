using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrungTamYenMy.Models;

namespace TrungTamYenMy.Areas.Admin.Controllers
{
    public class LopHoc123Controller : BaseController
    {
        public ActionResult Index(string name)
        {
            TrungTamYenMyEntities db = new TrungTamYenMyEntities();
            List<LopHoc> lstLopHoc = new List<LopHoc>();
            if (name == null)
            {
                lstLopHoc = db.LopHocs.ToList();
            }
            else
            {
                lstLopHoc = db.LopHocs.Where(x => x.TenLop.Contains(name)).ToList();
            }

            return View(lstLopHoc);
        }
        //GET: LopHoc/Add
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        //POST: LopHoc/Add
        public ActionResult Add(LopHoc tb)
        {
            using (TrungTamYenMyEntities db = new TrungTamYenMyEntities())
            {
                db.LopHocs.Add(tb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        // POST: LopHoc/Search
        [HttpPost]
        public ActionResult Search(string LopHocname)
        {
            return RedirectToAction("Index", new { LopHocname = LopHocname });
        }
        // GET: LopHoc/Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            TrungTamYenMyEntities db = new TrungTamYenMyEntities();
            LopHoc rep = db.LopHocs.FirstOrDefault(x => x.MaLop == id);
            if (rep != null)
            {
                return View(rep);
            }

            return RedirectToAction("Index");
        }

        // POST: LopHoc /Edit

        [HttpPost]
        public ActionResult Edit(LopHoc re)
        {
            TrungTamYenMyEntities db = new TrungTamYenMyEntities();
            LopHoc LopHoc = db.LopHocs.FirstOrDefault(x => x.MaLop == re.MaLop);
            if (LopHoc != null)
            {

                LopHoc.TenLop = re.TenLop;
                LopHoc.SoHV = re.SoHV;
                LopHoc.SoHV = re.SoHV;
                db.SaveChanges();
            }
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        //POST: /LopHoc/Delete
        public ActionResult Delete(int id)
        {
            using (TrungTamYenMyEntities db = new TrungTamYenMyEntities())
            {
                LopHoc rep = db.LopHocs.SingleOrDefault(x => x.MaLop == id);
                if (rep != null)
                {
                    db.LopHocs.Remove(rep);
                    db.SaveChanges();
                }
                return RedirectToAction("DsLopHoc", "LopHoc");
            }
        }
    }
}