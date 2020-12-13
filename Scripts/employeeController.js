var app = angular.module('myApp', []);
app.controller("employeeController", function employeeController($scope, $http, $window) {
    $scope.dvStudent = false; 
    //Muestra los datos
    $http({
        method: 'GET',
        url: '/api/employees/'
    }).then(function (response) {
        $scope.Employees = response.data;
    }, function (error) {
            $scope.error = "Ha ocurrido un error";
            alert("Ha ocurrido un error");
            console.log(error);
    });

    //Permite agregar un registro 
    $scope.AddEmployee = function (employee) {
        $http({
            method: 'POST',
            url: '/api/employees/',
            data: employee
        }).then(function (response) {
            alert("Registro agregado de forma exitosa!!");
            $window.location.href='/EmployeesViews/Index';
            console.log(response);
        }, function (error) {
                $scope.error = "Ha ocurrido un error al agregar el registro " + error;
                alert("Ha ocurrido un error");
        });
    }

    // Muestra el formulario 
    $scope.AddNew= function () {
        $scope.Action = "Add";
        $scope.dvEmployee = true;
    } 
   
    //Permite actualizar un registro 
    $scope.UpdateEmployee = function (employee) {
        $http({
            method: 'POST',
            url: '/api/UpdateEmployee/',
            data:  employee 
        }).then(function (response) {
            alert("Registro actualizado de forma exitosa!!");
            $window.location.href = '/EmployeesViews/Index';
            console.log(response);
        }, function (error) {
            $scope.error = "Ha ocurrido un error al actualizar el registro " + error;
            alert("Ha ocurrido un error");
        });
    }

    //Permite actualizar un registro 
    $scope.DeleteEmployee = function (employee) {
        $http({
            method: 'POST',
            url: '/api/DeleteEmployee/',
            data: employee
        }).then(function (response) {
            alert("Registro eliminado de forma exitosa!!");
            $window.location.href = '/EmployeesViews/Index';
            console.log(response);
        }, function (error) {
            $scope.error = "Ha ocurrido un error al eliminar el registro " + error;
            alert("Ha ocurrido un error");
        });
    }
   
  
});
