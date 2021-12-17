"use strict";
var ProductoEdit;
(function (ProductoEdit) {
    var Entity = $("#AppEdit").data("entity");
    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit",
            Entity: Entity
        },
        mounted: function () {
            CreateValidator(this.Formulario);
        },
    });
    Formulario.$mount("#AppEdit");
})(ProductoEdit || (ProductoEdit = {}));
//# sourceMappingURL=Edit.js.map