var app = angular.module('foodTracker', []);

app.factory('endpointUrlRetriever', ['$http', 
  function($http){
    return function(endpointContainer){
    
      $http
        .get("http://localhost:50000/api/Endpoints")
    	  .success(function(data, status, headers, config) {
      	  // this callback will be called asynchronously
      	  // when the response is available
          console.log("loading the endpoint container");
          endpointContainer = data;
      	})
      	.error(function(data, status, headers, config) {
      	  // called asynchronously if an error occurs
      	  // or server returns response with an error status.
          console.log("failure loading the endpoint container");
          endpointContainer = {};
      	});
    };
}]);

// app.factory('foodRequestor', function($http){
//   return function(endpointUrl){
//     $http({
//       method: 'GET', 
//       url: endpointUrl
//     })
//     .success(function(data, status, headers, config) {
//       // this callback will be called asynchronously
//       // when the response is available
//       return data;

//     })
//     .error(function(data, status, headers, config) {
//       // called asynchronously if an error occurs
//       // or server returns response with an error status.
//       return {};
//     });
//   };
// });

app.controller('FoodTrackerCtrl', ['$scope', 'endpointUrlRetriever', 
  function($scope, endpointUrlRetriever){
    $scope.version = "1.0.0.0";
    //$scope.endpoints = {};
    $scope.loadEndpoints = function(){
      console.log("loadEndpoints");
      endpointUrlRetriever($scope.endpoints);
    };

}]);

app.controller('FoodCtrl', ['$scope', '$http',  
  function($scope, $http) {
    var endpoints = {};

    $http.get("http://localhost:50000/api/Endpoints")
      .success(function(data, status){
        endpoints = data;
      })
      .error(function(data, status){
        endpoints = {};
      });

    //$scope.FoodList = foodRequestor(endpointUrl);
}]);