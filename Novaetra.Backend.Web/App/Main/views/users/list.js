(function () {
    var app = angular.module('app');

    var controllerId = 'backend.views.users.list';
    app.controller(controllerId, [
        '$scope', 'abp.services.backend.user',
        function ($scope, userService) {
            var vm = this;

            vm.users = [];

            // Refresh users on search text change
            $scope.$watch('searchString', function (value) {
                if (value)
                    vm.refreshUsers();
            });

            vm.refreshUsers = function () {
                abp.ui.setBusy( //Set whole page busy until getTasks complete
                    null,
                    userService.getUsers({ //Call application service method directly from javascript
                        searchString: $scope.searchString
                    }).success(function (data) {
                        vm.users = data.users;
                    })
                );
            };

            vm.getUserCountText = function () {
                return vm.users.length;
            };
        }
    ]);
})();