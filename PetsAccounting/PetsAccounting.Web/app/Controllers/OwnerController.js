(function () {
    var OwnerController = function ($scope, OwnerService) {
        $scope.pageNumber = 1;
        $scope.pageSize = 3;

        showOwners();

        $scope.pageChanged = function() {
            showOwners();
        };

        $scope.createOwner = function() {
            OwnerService
                .createOwner($scope.ownerName)
                .then(function() {
                    showOwners();
                });
        };

        $scope.deleteOwner = function(ownerId) {
            OwnerService
                .deleteOwner(ownerId)
                .then(function() {
                    showOwners();
                });
        };

        function showOwners() {
            OwnerService
                .getOwnersCount()
                .then(function (response) {
                    $scope.ownersTotalCount = response.data;
                });

            OwnerService
                .getOwners($scope.pageNumber, $scope.pageSize)
                .then(function(response) {
                    $scope.owners = response.data;
                });
        }
    };

    petsAccountingApp.controller("OwnerController", ["$scope", "OwnerService", OwnerController]);
}());