require.config({
    baseUrl: '../../system',
    urlArgs: 'v=1.0',

    waitSeconds: 100,
    paths: {
        "angular-notify" : "requires/angular-notify",
        "jquery-confirm" :"requires/jquery-confirm.min",
        "jquery" : "requires/jquery.min",
        "angular-route":"requires/angular-route.min",
        "angular-cookies" : "requires/angular-cookies.min",
        "ocLazyLoad" : "requires/ocLazyLoad.min",
        "angular": "requires/angular.min",
        "app" : "app",
        "flash": "app-services/flash.service",
        "userlocal-storage":"app-services/user.service.local-storage",
        "user":"app-services/user.service",
        "authentication": "app-services/authentication.service",
        "application" : "app-services/application.service",
        "profile" : "app-services/profile.service",
        "dashboard" : "app-services/dashboard.service",
        "cusmod" : "app-services/module.service",
        "page" : "app-services/page.service",
        "role" : "app-services/role.service",
        "lemoras" :"app-services/lemoras.service",
        "message" : "app-services/message.service",
        "settings": "app-services/settings.service",
        "businesslogic": "app-services/businesslogic.service",
        "command": "app-services/command.service",
        "company": "app-services/company.service",
        "microservice" : "app-services/microservice.service",
	"menu" : "app-services/menu.service",
	"language" : "app-services/language.service",
	"template" : "app-services/template.service",

        "login":"modules/login/login.controller",
        "logout":"modules/logout/logout.controller"
    },
    shim: {
        "angular-notify": { deps:["angular"], exports: "angular-notif" },
        "jquery-confirm": { deps: ["jquery"], exports: "jquery-confirm" },
        "jquery": { exports: "jquery" },
        "angular-route": { deps: ["angular"], exports: "angular-route" },
        "angular-cookies": { deps: ["angular"], exports: "angular-cookies" },
        "ocLazyLoad": { deps: ["angular"], exports: "ocLazyLoad" },
        "angular": { deps: ["jquery"], exports: "angular" },
        "app": { deps: ["angular", "angular-route", "angular-cookies", "ocLazyLoad", 'angular-notify'], exports: "app" },
        "flash": { deps: ["app"], exports: "flash" },
        "userlocal-storage": { deps: ["app"], exports: "userlocal-storage" },
        "user": { deps: ["app"], exports: "user" },
        "authentication": { deps: ["app"],exports: "authentication" },
        "application": { deps: ["app"], exports: "application" },
        "profile": { deps: ["app"], exports: "profile" },
        "dashboard": { deps: ["app"], exports: "dashboard" },
        "cusmod": { deps: ["app"], exports: "cusmod" },
        "page": { deps: ["app"],exports: "page" },
        "role": { deps: ["app"], exports: "role" },
        "businesslogic": { deps: ["app"], exports: "businesslogic" },
        "command": { deps: ["app"], exports: "command" },
        "company": { deps: ["app"], exports: "company" },
        "microservice": { deps: ["app"], exports: "microservice" },
	"menu": { deps: ["app"], exports: "menu" },
	"language": { deps: ["app"], exports: "language" },
	"template": { deps: ["app"], exports: "template" },
        "lemoras": { deps: ["app"], exports: "lemoras" },
        "message": { deps: ["app"], exports: "message" },
        "settings": { deps: ["app"],exports: "settings" },
        "logout": { deps: ["app", "jquery-confirm"], exports: "logout" },
        "login": { deps: ["authentication", "flash", "app"], exports: "login" }
    },
    deps: ["app"]
});

require(
    [
        'login', 'logout',
        "jquery-confirm",
        "jquery",
        "angular-route",
        "angular-cookies",
        "ocLazyLoad",
        "angular",
        "app",
        "flash",
        "userlocal-storage",
        "user",
        "authentication",
        "application",
        "profile",
        "dashboard",
        "cusmod",
        "company",
        "page",
        "role",
        "lemoras",
        "message",
        "settings",
        "businesslogic",
        "command",
        "microservice",
	"menu",
	"language",
	"template"
    ],
    function () {
        angular.bootstrap(document, ['app']);
    });

