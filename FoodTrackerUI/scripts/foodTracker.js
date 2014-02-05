var app = angular.module('foodTracker', []);

app.factory('endpointUrlRetriever', ['$http', 
  function($http){
    return {
      getEndpointsAsync: function(successCallback, errorCallback){
        $http
          .get("http://localhost:50000/api/Endpoints")
          .success(successCallback)
          .error(errorCallback);
      }
    };
}]);

app.factory('endpointRequestor', ['$http', 
  function($http){
    return {
      getEndpointDataAsync: function(endpointUrl, successCallback, errorCallback){
        $http
          .get(endpointUrl)
          .success(successCallback)
          .error(errorCallback);
        }
    };
}]);

app.controller('FoodTrackerCtrl', ['$scope', 'endpointUrlRetriever', 'endpointRequestor', 
  function($scope, endpointUrlRetriever, endpointRequestor){
    // set the function to get the list of endpoints
    $scope.loadEndpoints = function(){
      endpointUrlRetriever.getEndpointsAsync(
      function(data, status, headers, config) {
        console.log("success loading the endpoint container");
        $scope.endpoints = data;
      },
      function(data, status, headers, config) {
        console.log("error loading the endpoint container");
        $scope.endpoints = {};
      }
    )};

    $scope.getDataFromEndpoint = function(endpoint){
      console.log("Calling getDataFromEndpoint for " + endpoint);
      endpointRequestor.getEndpointDataAsync(
        endpoint.URL,
        function(data, status, headers, config) {
          console.log("success loading the endpoint data");
          $scope.endpointData = data;
        },
        function(data, status, headers, config) {
          console.log("error loading the endpoint data");
          $scope.endpointData = {};
        }
    )};

}]);

