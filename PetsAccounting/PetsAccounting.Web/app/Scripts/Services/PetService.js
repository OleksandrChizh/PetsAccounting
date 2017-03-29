(function () {
    var PetService = function ($http) {
        var host = "http://localhost:51263";
        var uri;
        var service = {};

        service.getPets = function (ownerId, pageNumber, pageSize) {
            uri = getUri(ownerId);
            pageNumber = pageNumber || 1;
            pageSize = pageSize || 3;

            return $http.get(uri + "?pageNumber=" + pageNumber + "&pageSize=" + pageSize);
        };

        service.getPetsCount = function (ownerId) {
            uri = getUri(ownerId);

            return $http.get(uri + "/count");
        };

        service.createPet = function (ownerId, ownerName) {
            var owner = {
                Name: ownerName
            };

            uri = getUri(ownerId);

            return $http.post(uri, owner);
        };

        service.deletePet = function (petId) {
            uri = host + "/api/pet/" + petId;

            return $http.delete(uri);
        };

        return service;

        function getUri(ownerId) {
            return host + "/api/owner/" + ownerId + "/pet";
        }
    };

    petsAccountingApp.factory("PetService", ["$http", PetService]);
}());