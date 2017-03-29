(function () {
    var PetController = function ($scope, $routeParams, $window, PetService) {
        var ownerId = $routeParams.ownerId;

        $scope.pageNumber = 1;
        $scope.pageSize = 3;

        showPets();

        $scope.pageChanged = function () {
            showPets();
        };

        $scope.createPet = function () {
            PetService
                .createPet(ownerId, $scope.petName)
                .then(function () {
                    $scope.petName = "";
                    showPets();
                });
        };

        $scope.deletePet = function (petId) {
            PetService
                .deletePet(petId)
                .then(function () {
                    showPets();
                });
        };

        $scope.back = function () {
            $window.history.back();
        };

        function showPets() {
            PetService
                .getPetsCount(ownerId)
                .then(function (response) {
                    $scope.petsTotalCount = response.data;
                });

            PetService
                .getPets(ownerId, $scope.pageNumber, $scope.pageSize)
                .then(function (response) {
                    $scope.pets = response.data;
                });
        }
    };

    petsAccountingApp.controller("PetController", ["$scope", "$routeParams", "$window", "PetService", PetController]);
}());