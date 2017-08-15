using InstagramAPIApp.Models;
using InstaSharp;
using InstaSharp.Models.Responses;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace InstagramAPIApp.Controllers
{
    public class HomeController : Controller
    {
        string clientId, clientSecret, redirectUri, realtimeUri = "";

        InstagramConfig config = null;

        public HomeController()
        {
            clientId = ConfigurationManager.AppSettings["client_id"];
            clientSecret = ConfigurationManager.AppSettings["client_secret"];
            redirectUri = ConfigurationManager.AppSettings["redirect_uri"];
            realtimeUri = "";
            config = new InstagramConfig(clientId, clientSecret, redirectUri, realtimeUri);
            //https://www.instagram.com/developer/endpoints/relationships/
        }

        public ActionResult Index()
        {
            
            return View();
        }
       

        [Authorize()]
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

        
    }
}