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
        $http.post('procurement/create', $scope.form).then(function(data) {
            $scope.procurements.push(data);
            $(".modal").modal("hide");
        });
    };
    $scope.edit = function(id) {
        $http.get('procurement/' + id).then(function(data) {
            console.log(data);
            $scope.form = data;
        });
    };
    $scope.saveEdit = function() {
        $http.put('procurement/' + $scope.form.id, $scope.form).then(function(data) {
            $(".modal").modal("hide");
            $scope.procurements = apiModifyTable($scope.data, data.id, data);
        });
    };

    function getResultsPage(pageNumber) {
        // this is just an example, in reality this stuff should be in a service
        $http.get('/procurement/list/?pageNumber=' + pageNumber + '&itemsPerPage=' + $scope.itemsPerPage)
            .then(function (result) {
                $scope.procurements = result.data.Items;
                $scope.total_count = result.data.Count;
            });
    }
});