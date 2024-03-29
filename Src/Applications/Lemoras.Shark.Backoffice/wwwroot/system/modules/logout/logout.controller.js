﻿(function () {
    'use strict';

    angular
        .module('app')
        .controller('LogoutController', LogoutController);

    LogoutController.$inject = ['$scope', 'ProfileService'];
    function LogoutController($scope, ProfileService) {
        var vm = this;

        var logout = function () {
            ProfileService.Logout();
        };

        askQuestion($scope.config.module.logout.label,
            $scope.config.module.logout.caption,
            $scope.config.module.logout.btnLogout,
            $scope.config.module.logout.btnCancel, logout);
    };

})();