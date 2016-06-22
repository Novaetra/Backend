(function() {
    var app = angular.module('app');

    var controllerId = 'backend.views.users.create';
    app.controller(controllerId,
    [
        '$scope', '$location', 'abp.services.backend.user',
        function($scope, $location, userService) {
            var vm = this;
            vm.localize = abp.localization.localize;

            vm.user = {
                displayName: '',
                email: '',
                password: ''
            }

            vm.createUser = function() {
                abp.ui.setBusy(
                    null,
                    userService.createUser(vm.user)
                    .success(function() {
                        abp.notify.info(abp.utils.formatString(vm.localize("UserCreatedMessage"), vm.user.displayName));
                    })
                );
            };
        }
    ]);
})();