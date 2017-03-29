(function() {
    var OwnerService = function ($http) {
        var host = "http://localhost:51263";
        var uri = host + "/api/owner";
        var service = {};

        service.getOwners = function (pageNumber, pageSize) {
            pageNumber = pageNumber || 1;
            pageSize = pageSize || 3;

            return $http.get(uri + "?pageNumber=" + pageNumber + "&pageSize=" + pageSize);
        };

        service.getOwnersCount = function() {
            return $http.get(uri + "/count");
        };

        service.createOwner = function (ownerName) {
            var owner = {
                Name: ownerName
            };

            return $http.post(uri, owner);
        };

        service.deleteOwner = function (ownerId) {
            return $http.delete(uri + "/" + ownerId);
        };

        return service;
    };

    petsAccountingApp.factory("OwnerService", ["$http", OwnerService]);
}());