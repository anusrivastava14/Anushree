using Anushree.DAL;
using Anushree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Anushree.Controllers
{
    public class HomeController : Controller
    {
        DataAccess DB = new DataAccess();
        private int procid;
        stu model = new stu();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult student()
        {
            if(Request.QueryString["sid"]!=null)
            {
                model.uid = Convert.ToInt32(Request.QueryString["sid"].ToString());
                model= DB.reach(3, model).ToList().FirstOrDefault();
                ViewBag.ButtonName = "update";

            }
            else
            {
                ViewBag.ButtonName = "submit";
            }
            var list1 = DB.reach(4,model).ToList();
            if(list1.Count > 0)
            {
                ViewBag.list = list1;
            }
            else
            {
                ViewBag.list = null;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult student(stu model,string Command)
        {
            if(Command== "submit")
            {
                procid = 1;
            }
            else if(Command== "update")
            {
                procid = 2;
            }
            var list = DB.reach(procid, model).ToList();
            if (list.Count > 0)
            {
                if (list[0].msg == "success")
                {
                    TempData["msg"] = "1";
                }
                else if(list[0].msg=="exsists")
                {
                    TempData["msg"] = "2";
                }
                else if (list[0].msg == "update")
                {
                    TempData["msg"] = "3";
                }
                else 
                {
                    TempData["msg"] = "4";
                }
                ViewBag.list = list;
            }
           
            else
            {
                ViewBag.list = null;
            }
            return RedirectToAction("student","Home");
        }
        public ActionResult Edit(int id)
        {
            return RedirectToAction("student",new { sid=id});
        }
        public JsonResult Delete(int sid)
        {
            model.uid = sid;
            var data = DB.reach(5, model).ToList();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}