/// <reference path="~/Scripts/angular.js" />
/// <reference path="modules.js" />
acq.config(function ($mdThemingProvider) {
    $mdThemingProvider
        .theme('default')
        .primaryPalette('green')
        .accentPalette('deep-orange')
        .warnPalette('red').dark()
});