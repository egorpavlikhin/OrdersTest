angular.module("ordersTest", []);
var app = angular.module('ordersTest', ['angularUtils.directives.dirPagination']);

app.filter('ctime', function () {
    return function (jsonDate) {

        var date = new Date(parseInt(jsonDate.substr(6)));
        return date;
    };
});

app.controller('listProcurements', function ($scope, $http){
    $scope.procurements = []; 
    $scope.pageno = 1; 
    $scope.total_count = 0;
    $scope.itemsPerPage = 20; 

    getResultsPage(1);

    $scope.pagination = {
        current: 1
    };

    $scope.pageChanged = function (newPage) {
        getResultsPage(newPage);
    };
    
    $scope.saveAdd = function () {
        $http.post('/api/procurement/create', $scope.form).then(function (response) {
            $scope.procurements.unshift(response.data);
            $scope.procurements.pop();
            $(".modal").modal("hide");
            $scope.form = {};
        });
    };
    $scope.edit = function(id) {
        $http.get('/api/procurement/' + id).then(function(response) {
            console.log(response);
            $scope.form = response.data;
        });
    };
    $scope.saveEdit = function () {
        $http.put('/api/procurement/' + $scope.form.Id, $scope.form).then(function (response) {
            angular.extend($scope.procurements,
            apiModifyTable($scope.procurements, response.data.Id, response.data));
            $(".modal").modal("hide");
            $scope.form = {};
        });
    };

    function getResultsPage(pageNumber) {
        $http.get('/api/procurement/' + $scope.itemsPerPage + '/' + pageNumber)
            .then(function (result) {
                $scope.procurements = result.data.Items;
                $scope.total_count = result.data.Count;
            });
    }
});
function apiModifyTable(originalData, id, response) {
    for (key in originalData) {
        if (originalData[key].Id === id) {
            originalData.splice(key, 1);
            originalData.splice(key, 0, response);
            break;
        }
    }
    return originalData;
}