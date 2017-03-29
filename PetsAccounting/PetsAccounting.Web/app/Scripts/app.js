var petsAccountingApp = angular.module("petsAccountingApp", ["ngRoute", "ui.bootstrap", "ngAnimate", "ngSanitize"]);

petsAccountingApp.config(["$locationProvider", function($locationProvider) {
    $locationProvider.hashPrefix("");
}]);

petsAccountingApp.config(function ($routeProvider) {
    $routeProvider
        .when("/",
        {
            templateUrl: "app/Views/Owner/Index.html",
            controller: "OwnerController"
        })
        .when("/owner/:ownerId/pets",
        {
            templateUrl: "app/Views/Pet/Pets.html",
            controller: "PetController"
        })
        .otherwise(
        {
            templateUrl: "/",
            controller: "OwnerController"
        });
});



