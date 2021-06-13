using ScreeningReports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScreeningReports.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogInAction(ScreeningReports.Models.User userModel)
        {
            using(ScreeningReportDatabaseEntities1 db=new ScreeningReportDatabaseEntities1())
            {
                var userDetails = db.Users.Where(x => x.UserName == userModel.UserName && x.Password == userModel.Password).FirstOrDefault();

                if(userDetails==null)
                {
                    userModel.LogInErrorMessage = "User Name or Password is incorrect. Please check and re-enter";
                    return View("LogIn", userModel);
                }
                else
                {
                    return View("ReportCheck");
                    if (userDetails.TestResult==null && userDetails.ResultDate==null)
                    {
                        userModel.LogInErrorMessage = userDetails.FirstName+userModel.LastName+" results are not available yet.";
                        return View("LogIn", userModel);
                    }
                    else
                    {
                        //ViewBag.Message = userModel;
                        //return View("LogInAction", userDetails);
                        
                    }
                    
                }
            }
            return View();
        }

        public ActionResult UserPassport(ScreeningReports.Models.User Model)
        {
            using (ScreeningReportDatabaseEntities1 db = new ScreeningReportDatabaseEntities1())
            {
                var user = db.Users.Where(x => x.PassportNo==Model.PassportNo).FirstOrDefault();

                if(user==null)
                {
                    Model.PassportErrorMessage = "Details about the given passport number is unavailable";
                    return View("ReportCheck", Model);
                }
                else
                {
                    if (user.TestResult == null && user.ResultDate == null)
                    {
                        Model.PassportErrorMessage = user.FirstName + user.LastName + " results are not available yet.";
                        return View("ReportCheck", Model);
                    }
                    else
                    {
                        return View("LogInAction", user);
                    }
                    
                }

            }

        }
    }
}