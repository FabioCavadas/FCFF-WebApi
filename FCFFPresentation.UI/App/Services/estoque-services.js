//$http -> objeto utilizado para executar serviços REST
app.service('$estoqueServices',
    function ($http) {

        //variável para armazenar a URL base da API..
        var urlBase = "http://localhost:50059/api/estoque";

        //objeto para armazemar as funções que irão 
        //fazer chamadas aos serviços da API..
        var services = {}; //JSON vazio..

        services.cadastrar = function (model) {
            return $http.post(urlBase + "/cadastrar", model);
        };

        services.atualizar = function (model) {
            return $http.put(urlBase + "/atualizar", model);
        };

        services.excluir = function (id) {
            return $http.delete(urlBase + "/excluir?id=" + id);
        };

        services.consultar = function () {
            return $http.get(urlBase + "/consultar");
        };

        services.obter = function (id) {
            return $http.get(urlBase + "/obter?id=" + id);
        };

        return services; //retornando..
    });
