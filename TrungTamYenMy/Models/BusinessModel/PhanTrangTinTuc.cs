using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrungTamYenMy.Models.BusinessModel
{
    public class PhanTrangTinTuc
    {
        TrungTamYenMyEntities db=new TrungTamYenMyEntities();
        public List<TinTuc> ListTinTuc(ref int totalRecord,int page = 1,int pageSize=4)
        {
            totalRecord = db.TinTucs.Count();
            var model = db.TinTucs.Where(x=>x.TrangThai==true).OrderBy(x => x.MaTinTuc).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            //var model = db.TinTucs.Take(pageSize).ToList();
            return model;
        }


        public List<TinTuc> ListTinTuc1(ref int totalRecord, int page = 1, int pageSize = 12)
        {
            totalRecord = db.TinTucs.Count();
            var model = db.TinTucs.Where(x => x.TrangThai == true).OrderBy(x => x.MaTinTuc).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            //var model = db.TinTucs.Take(pageSize).ToList();
            return model;
        }
    }
}