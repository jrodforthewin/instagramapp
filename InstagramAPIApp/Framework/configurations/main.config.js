﻿/// <reference path="~/Scripts/angular.js" />
/// <reference path="modules.js" />
app.config(['$mdThemingProvider', function ($mdThemingProvider) {
    $mdThemingProvider
        .theme('default')
        .primaryPalette('green')
        .accentPalette('deep-orange')
        .warnPalette('red')
}]);