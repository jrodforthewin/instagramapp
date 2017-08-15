/// <reference path="~/Scripts/angular.js" />
/// <reference path="modules.js" />
app.service('userService', function () {
    this.getMedia = function (x) {
        console.log(userBioAndMedia.UserMedia);
        return userBioAndMedia.UserMedia;
    },
        this.getBio = function (x) {
            return userBioAndMedia.UserBio
        }
});
app.service('followerService', function () {
    this.get = function (x) {
        console.log(followers);
        return followers;
    }
});