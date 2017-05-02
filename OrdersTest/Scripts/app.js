angular.module("ordersTest", []);
var app = angular.module('ordersTest', ['angularUtils.directives.dirPagination']);
app.filter('ctime', function () {
    return function (jsonDate) {

        var date = new Date(parseInt(jsonDate.substr(6)));
        return date;
    };
});
app.controller('listProcurements', function ($scope, $http){
    $scope.procurements = []; //declare an empty array
    $scope.pageno = 1; // initialize page no to 1
    $scope.total_count = 0;
    $scope.itemsPerPage = 20; //this could be a dynamic value from a drop down

    getResultsPage(1);

    $scope.pagination = {
        current: 1
    };

    $scope.pageChanged = function (newPage) {
        getResultsPage(newPage);
    };

    $scope.saveAdd = function () {
        $http.post('/api/procurement/create', $scope.form).then(function (response) {
            $scope.procurements.push(response.data);
            $(".modal").modal("hide");
        });
    };
    $scope.edit = function(id) {
        $http.get('/api/procurement/' + id).then(function(response) {
            console.log(response);
            $scope.form = response.data;
        });
    };
    $scope.saveEdit = function() {
        $http.put('/api/procurement/' + $scope.form.id, $scope.form).then(function (response) {
            $(".modal").modal("hide");
            $scope.procurements = apiModifyTable($scope.data, response.data.id, response.data);
        });
    };

    function getResultsPage(pageNumber) {
        // this is just an example, in reality this stuff should be in a service
        $http.get('/api/procurement/' + $scope.itemsPerPage + '/' + pageNumber)
            .then(function (result) {
                $scope.procurements = result.data.Items;
                $scope.total_count = result.data.Count;
            });
    }
});
function apiModifyTable(originalData, id, response) {
    angular.forEach(originalData, function (item, key) {
        if (item.id == id) {
            originalData[key] = response;
        }
    });
    return originalData;
}