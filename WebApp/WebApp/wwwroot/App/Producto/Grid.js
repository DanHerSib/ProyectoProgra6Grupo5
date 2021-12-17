"use strict";
var ProductoGrid;
(function (ProductoGrid) {
    if (MensajeApp != "") {
        Toast.fire({
            icon: "success", title: MensajeApp
        });
    }
    function OnClickEliminar(id) {
        ComfirmAlert("Desea eliminar el registro?", "Eliminar", "warning", "#3085d6", "d33")
            .then(function (result) {
            if (result.isConfirmed) {
                window.location.href = "Producto/Grid?handler=Eliminar&id=" + id;
            }
        });
    }
    ProductoGrid.OnClickEliminar = OnClickEliminar;
    $("#GridView").DataTable();
})(ProductoGrid || (ProductoGrid = {}));
//# sourceMappingURL=Grid.js.map