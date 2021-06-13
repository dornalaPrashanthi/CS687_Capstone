using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScreeningReports.Models;

namespace ScreeningReports.Controllers
{
    public class ScreeningCenterController : Controller
    {
        // GET: ScreeningCenter
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ScreeningCenter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SCreenLogIn(ScreeningReports.Models.ScreeningCenter SCUser)
        {
            using (ScreeningReportDatabaseEntities1 db = new ScreeningReportDatabaseEntities1())
            {
                var SCuserDetails = db.ScreeningCenters.Where(x => x.userName == SCUser.userName && x.password == SCUser.password).FirstOrDefault();

                if (SCuserDetails == null)
                {
                    SCUser.SCenterLogInErrorMessage = "User Name or Password is incorrect. Please check and re-enter";
                    return View("ScreeningCenter", SCUser);
                }
                else
                {
                    return View("SCUpdate");
                }
                return View();
            }
        }

        public ActionResult SCUserPassport(ScreeningReports.Models.User Model)
        {
            using (ScreeningReportDatabaseEntities1 db = new ScreeningReportDatabaseEntities1())
            {
                var user = db.Users.Where(x => x.PassportNo == Model.PassportNo).FirstOrDefault();

                if (user == null)
                {
                    Model.SCPassportErrorMessage = "Given passport number is not available. Please check and enter again";
                    return View("SCUpdate", Model);
                }
                else
                {
                    if (user.TestResult != null && user.ResultDate != null)
                    {
                        Model.SCResultError = user.FirstName + user.LastName + " results are already updated.";
                        return View("SCUpdate", Model);
                    }
                    else
                    {
                        var result = Edit(Model);
                        return View("UpdateActionView", Model);
                    }

                }

            }

        }

        public int Edit(User Model)
        {
            using (ScreeningReportDatabaseEntities1 db = new ScreeningReportDatabaseEntities1())
            {
                //db.Entry(user).State = EntityState.Modified;
                var userDetails = db.Users.Where(x => x.PassportNo == Model.PassportNo).FirstOrDefault();
                userDetails.TestResult = Model.TestResult;
                userDetails.ResultDate = DateTime.Now;
                var result = db.SaveChanges();
                return (result);
            }
        }
    }
}