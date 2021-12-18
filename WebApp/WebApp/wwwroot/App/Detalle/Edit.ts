namespace DetalleEdit {
    var Entity = $("#AppEdit").data("entity");
    var Formulario = new Vue(
        {
            data:
            {
                Formulario: "#FormEdit",
                Entity: Entity
            },

            methods: {
                Save() {
                    if (BValidateData(this.Formulario)) {
                        Loading.fire("Guardando");
                        App.AxiosProvider.DetalleGuardar(this.Entity).then(data => {
                            Loading.close();
                            if (data.CodeError == 0) {
                                Toast.fire({ title: "Se guardo correctamente", icon: "success" })
                                    .then(() => window.location.href = "Detalle/Grid");
                            }
                            else {
                                Toast.fire({ title: data.MsgError, icon: "error" })
                            }
                        });
                    }
                    else {
                        Toast.fire({ title: "Por favor complete los campos requeridos" });
                    }
                }
            },
            mounted() {
                CreateValidator(this.Formulario)
            }
        }
    );
    Formulario.$mount("#AppEdit")
}