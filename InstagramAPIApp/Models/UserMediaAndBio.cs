using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstagramAPIApp.Models
{
    public class UserMediaAndBio
    {
        public Bio UserBio { get; set; }
        public List<Media> UserMedia { get; set; }
    }
}