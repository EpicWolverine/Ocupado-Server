var app = angular.module('ocupado',[]);

app.config(function () {
    
});

app.controller('MainController', ['$scope', 'bathrooms', function ($scope, bathrooms) {
    $scope.bathrooms = [];
    bathrooms.success(function (data) {
        $scope.bathrooms = data;
    });
}]);

app.factory('bathrooms', ['$http', function ($http) {
    return $http.get('./api/BathroomInfo/Bathrooms')
              .success(function (data) {
                  return data;
              })
              .error(function (err) {
                  return err;
              });
}]);