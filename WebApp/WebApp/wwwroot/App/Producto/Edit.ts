namespace ProductoEdit {

    var Entity = $("#AppEdit").data("entity");

    var Formulario = new Vue(
        {
            data:
            {
                Formulario: "#FormEdit",
                Entity: Entity

            },

            mounted() {
                CreateValidator(this.Formulario)
            },

        }

    );

    Formulario.$mount("#AppEdit")



}