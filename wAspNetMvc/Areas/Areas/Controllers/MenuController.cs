using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wxBase;
using wxBase.Model;

namespace wAspNetMvc.Areas.Areas.Controllers
{
    public class MenuController : Controller
    {
        // GET: Areas/Menu
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            Response.Write(wxMenuService.Create(Server.MapPath("~/menu.txt")));
            return View();
        }
        public ActionResult Get()
        {
            Response.Write(wxMenuService.Get());
            return View();
        }
        public ActionResult delete()
        {
            wxResult wxResult = JSONHepler.JsonToObject<wxResult>(wxMenuService.delete());
            if (wxResult.errorcode=="0")
            {
                Response.Write("操作成功");
            }
            else
            {
                Response.Write("操作失败"+wxResult.errmsg);
            }
            return View();
        }
        public ActionResult addcomditional()
        {
            Response.Write(wxMenuService.addConditional(Server.MapPath("~/menu01.txt")));
            return View();
        }
        public ActionResult delconditional()
        {
            Response.Write(wxMenuService.deleconditional("408825572"));
            return View();
        }
        public ActionResult trymatch()
        {
            Response.Write(wxMenuService.trymatch("xxxxxxxx"));
            return View();
        }
    }
}