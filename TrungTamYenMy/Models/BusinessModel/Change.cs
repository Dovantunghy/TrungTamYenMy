using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrungTamYenMy.Models.BusinessModel
{
    public class Change
    {
        private TrungTamYenMyEntities db = null;

        public Change()
        {
            db = new TrungTamYenMyEntities();
        }
        public bool ChangeStatus(long id)
        {
            var user = db.Users.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();

            return user.Status;
        }
    }
}