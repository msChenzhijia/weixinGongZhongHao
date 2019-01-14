using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wxBase;

namespace wAspNetMvc.Areas.Areas.Controllers
{
    public class HomeController : Controller
    {
        // GET: Areas/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult get_access_token()
        {
            Response.Write("access_token:" + weixinService.Access_token);
            return View();
        }
        public ActionResult getcallbackip()
        {
            String ipList = weixinService.GetCallbackip();
            return View(ipList);
        }
    }
}