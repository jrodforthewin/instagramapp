using InstagramAPIApp.Models;
using InstaSharp;
using InstaSharp.Models.Responses;
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
        }

        public ActionResult Index()
        {
            
            return View();
        }

        public async Task<ActionResult> Bio()
        {
            //var bio = new Bio();
            var userBioAndMedia = new UserMediaAndBio();
            if (Session["InstaSharp.AuthInfo"] == null)
            {
                Redirect("Login");
            }
            else
            {
                userBioAndMedia.UserMedia = await GetMedia();
                userBioAndMedia.UserBio = await GetBio();
            }
            return View(userBioAndMedia);
        }

        public async Task<ActionResult> _MyBio()
        {
            var bio = new Bio();
            if (Session["InstaSharp.AuthInfo"] == null)
            {
                ViewBag.Message = "You are not logged in!";
                ViewBag.Username = "??";
            }
            else
            {
                //bio = await GetBio(bio);
            }

            return PartialView(bio);
        }

        private async Task<Bio> GetBio()
        {
            var auth = (OAuthResponse)Session["InstaSharp.AuthInfo"];
            var userEndpoint = new InstaSharp.Endpoints.Users(config, auth);
            var me = await userEndpoint.GetSelf();
            var bio = new Bio()
            {
                Bio = me.Data.Bio,
                Counts = me.Data.Counts,
                FullName = me.Data.FullName,
                Id = me.Data.Id,
                ProfilePicture = me.Data.ProfilePicture,
                Username = me.Data.Username,
                Website = me.Data.Website
            };
            return bio;
        }

        public async Task<ActionResult> _MyMedia()
        {
            var mediaList = new List<Media>();
            if (Session["InstaSharp.AuthInfo"] == null)
            {
                ViewBag.Message = "You are not logged in!";
                ViewBag.Username = "??";
            }
            else
            {
                //await GetMedia(mediaList);
            }

            return PartialView(mediaList);
        }

        private async Task<List<Media>> GetMedia()
        {
            var auth = (OAuthResponse)Session["InstaSharp.AuthInfo"];
            var userEndpoint = new InstaSharp.Endpoints.Users(config, auth);
            var myMedia = await userEndpoint.RecentSelf();
            var mediaList = new List<Media>();
            foreach (var media in myMedia.Data)
            {
                mediaList.Add(new Media()
                {
                    Id = media.Id,
                    Attribution = media.Attribution,
                    Caption = media.Caption,
                    Comments = media.Comments,
                    CreatedTime = media.CreatedTime,
                    Filter = media.Filter,
                    Images = media.Images,
                    Likes = media.Likes,
                    Link = media.Link,
                    Location = media.Location,
                    Tags = media.Tags,
                    Type = media.Type,
                    User = media.User,
                    UserHasLiked = media.UserHasLiked,
                    UsersInPhoto = media.UsersInPhoto,
                    Videos = media.Videos
                });
            }
            return mediaList;
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
            return RedirectToAction("Bio");
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Your login page.";
            var scopes = new List<OAuth.Scope>();
            scopes.Add(InstaSharp.OAuth.Scope.Likes);
            scopes.Add(InstaSharp.OAuth.Scope.Comments);

            var link = InstaSharp.OAuth.AuthLink(config.OAuthUri + "authorize", config.ClientId, config.RedirectUri, scopes, InstaSharp.OAuth.ResponseType.Code);

            return Redirect(link);
        }
    }
}