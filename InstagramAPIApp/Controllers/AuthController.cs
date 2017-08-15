using InstaSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace InstagramAPIApp.Controllers
{
    public class AuthController : Controller
    {
        string clientId, clientSecret, redirectUri, realtimeUri = "";

        InstagramConfig config = null;

        public AuthController()
        {
            clientId = ConfigurationManager.AppSettings["client_id"];
            clientSecret = ConfigurationManager.AppSettings["client_secret"];
            redirectUri = ConfigurationManager.AppSettings["redirect_uri"];
            realtimeUri = "";
            config = new InstagramConfig(clientId, clientSecret, redirectUri, realtimeUri);
            //https://www.instagram.com/developer/endpoints/relationships/
        }
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Oauth(string code)
        {
            // add this code to the auth object
            var auth = new OAuth(config);

            // now we have to call back to instagram and include the code they gave us
            // along with our client secret
            var oauthResponse = await auth.RequestToken(code);

            // both the client secret and the token are considered sensitive data, so we won't be
            // sending them back to the browser. we'll only store them temporarily.  If a user's session times
            // out, they will have to click on the authenticate button again - sorry bout yer luck.
            Session.Add("InstaSharp.AuthInfo", oauthResponse);

            // all done, lets redirect to the home controller which will send some intial data to the app
            return RedirectToAction("Bio","Bio");
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Your login page.";
            var scopes = new List<OAuth.Scope>();
            scopes.Add(InstaSharp.OAuth.Scope.Likes);
            scopes.Add(InstaSharp.OAuth.Scope.Comments);
            //scopes.Add(InstaSharp.OAuth.Scope.Basic);
            scopes.Add(InstaSharp.OAuth.Scope.Follower_List);
            scopes.Add(InstaSharp.OAuth.Scope.Public_Content);
            scopes.Add(InstaSharp.OAuth.Scope.Relationships);

            var link = InstaSharp.OAuth.AuthLink(config.OAuthUri + "authorize", config.ClientId, config.RedirectUri, scopes, InstaSharp.OAuth.ResponseType.Code);
            return Redirect(link);
        }
    }
}