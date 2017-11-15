using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrungTamYenMy.Models;
using TrungTamYenMy.Models.BusinessModel;

namespace TrungTamYenMy.Models.BusinessModel
{

    public class LienHeHp
    {
        TrungTamYenMyEntities db=new TrungTamYenMyEntities();

        public LienHe LayThongTin()
        {
            return db.LienHes.Single(x => x.TrangThai == true);
        }

        public long InsertFeedBack(FeedBack fb)
        {
            db.FeedBacks.Add(fb);
            db.SaveChanges();
            return fb.MaFeedBack;
        }

    }
}