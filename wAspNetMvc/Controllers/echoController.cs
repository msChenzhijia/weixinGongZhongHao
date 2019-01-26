using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wxBase;

namespace wAspNetMvc.Controllers
{
    public class echoController : Controller
    {
        // GET: echo
        public ActionResult Index()
        {
            //参数说明:
            //echostr:随机字符串
            //signature:微信加密签名结合了token等等的参数
            //timestamp:时间戳
            //nonce:随机数
            String echoString = Request.QueryString["echoStr"];
            String signature = Request.QueryString["signature"];
            String timestamp = Request.QueryString["timestamp"];
            String noce = Request.QueryString["nonce"];
            LogService.Write("echoString:" + echoString);
            LogService.Write("signature:" + signature);
            LogService.Write("timestamp:" + timestamp);
            LogService.Write("noce:" + noce);
            //对token,timestamp,nonce进行加密,得到临时signature字符串
            String tmp_signature = weixinService.make_signature(timestamp, noce);
            LogService.Write("tmp_signature:" + tmp_signature);
            if (tmp_signature==signature&&!String.IsNullOrEmpty(echoString))
            {
                Response.Write(echoString);
                Response.End();
            }
            else
            {
                //Response.Write("Invalid request!");
                //Response.End();
                return View();
            }
            ViewBag.echoString = echoString;
            ViewBag.signature = signature;
            ViewBag.timestamp = timestamp;
            ViewBag.noce = noce;
            return View();
        }
        public ActionResult Create()
        {
            Response.Write(wxMenuService.Create(Server.MapPath("~/menu.txt")));
            return View();
        }
    }
};
