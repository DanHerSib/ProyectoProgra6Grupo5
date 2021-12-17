"use strict";
var App;
(function (App) {
    var AxiosProvider;
    (function (AxiosProvider) {
        AxiosProvider.ProductoEliminar = function (id) { return axios.delete("Producto/Grid?handler=Eliminar&id=" + id).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.ProductoGuardar = function (entity) { return axios.post("Producto/Edit", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.PedidoEliminar = function (id) { return axios.delete("Pedido/Grid?handler=Eliminar&id=" + id).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.PedidoGuardar = function (entity) { return axios.post("Pedido/Edit", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.ClienteEliminar = function (id) { return axios.delete("Cliente/Grid?handler=Eliminar&id=" + id).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.ClienteGuardar = function (entity) { return axios.post("Cliente/Edit", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
    })(AxiosProvider = App.AxiosProvider || (App.AxiosProvider = {}));
})(App || (App = {}));
//# sourceMappingURL=AxiosProvider.js.map