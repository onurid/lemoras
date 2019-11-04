(function () {
    'use strict';

    angular
        .module('app')
        .controller('LoginController', LoginController);

    LoginController.$inject = ['$location', 'AuthenticationService', 'FlashService'];
    function LoginController($location, AuthenticationService, FlashService) {
        var vm = this;

        vm.login = login;
        vm.loginWithApp = loginWithApp;

        vm.selectedApplication = null;

        vm.allApplication = [];

        (function initController() {
            // reset login status
            AuthenticationService.ClearCredentials();

        })();

        function login() {
            vm.dataLoading = true;
            AuthenticationService.Login(vm.username, vm.password, function (response) {
                if (response.success) {
                    AuthenticationService.SetCredentials(vm.username, vm.password, response.data.token);
                    if (response.data.configData == undefined) {
                        document.getElementById("preLoginForm").style.display = "none";
                        document.getElementById("loginForm").style.display = "";
                        loadAllApplication();
                    }
                    else {
                        FlashService.WriteLocal(response.data.configData);
                        var template = window.localStorage.getItem("template");
                        window.location.href = '../../templates/' + template + '/index.html'  //$location.path('/load');
                    }
                } else {
                    FlashService.Error(response.data.message, $location);
                    vm.dataLoading = false;
                }
            });
        };

        function loginWithApp() {
            vm.dataLoading = true;

            var applicationId = vm.selectedApplication.id;

            AuthenticationService.GetConfig(applicationId, function (response) {
                if (response.success) {
                    FlashService.WriteLocal(response.data);
                    var template = window.localStorage.getItem("template");
                    window.location.href = '../../templates/' + template + '/index.html'  //$location.path('/load');
                    //uygulama seçilmeden kapandıysa tekrar girildiğinde config boş ise ama global de credentials var ise uygulama seçe yönlendir veya token var ise 
                    //burada config set edilmesin sunucudanda config gelmesin
                } else {
                    FlashService.Error(response.data.message, $location);
                    vm.dataLoading = false;
                }
            });
        };

        function loadAllApplication() {
            AuthenticationService.GetUserApp(function (response) {
                vm.allApplication = response;
            });
        }
    }

})();
