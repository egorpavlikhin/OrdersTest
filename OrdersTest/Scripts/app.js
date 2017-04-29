var app = angular.module('angularTable', ['angularUtils.directives.dirPagination']);
app.controller('listdata',function($http){
    var vm = this;
    vm.procurements = []; //declare an empty array
    vm.pageno = 1; // initialize page no to 1
    vm.total_count = 0;
    vm.itemsPerPage = 10; //this could be a dynamic value from a drop down
    vm.getData = function(pageno){ // This would fetch the data on page change.
        //In practice this should be in a factory.
        vm.users = [];  $http.get("/procurement/list/{itemsPerPage}/{pagenumber}").success(function(response){ 
            //ajax request to fetch data into vm.data
            vm.users = response.data;  // data to be displayed on current page.
            vm.total_count = response.total_count; // total data count.
        });
    };
    vm.getData(vm.pageno); // Call the function to fetch initial data on page load.
});