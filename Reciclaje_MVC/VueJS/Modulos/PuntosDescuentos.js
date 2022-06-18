(function () {
    'use strict';
    Vue.use(VeeValidate, {
        dictionary: {
            es: {
                custom: {
                    descripcion: {
                        required: 'Debe ingresar su descripcion.'
                    }
                }
            }
        }
    });

    VeeValidate.Validator.localize("es");
    Vue.config.productionTip = false;
    //    Vue.use(bootstrapVue);

    var app1 = new Vue({
        el: '#appRegistroUsuarioAdmin',
        data: () => ({
            usuario: JSON.parse(sessionStorage.currentUser),
            codigo_registro_reciclaje: 0,
            descripcion: '',
            categoria: '',
            precio: '',
            umd: '',
            stock: '',
            estado: 1,
            cantidad: '',
            producto: '',
            codigo_producto: 0,
            indexcodigo_registro_detalle: '',
            //bloqueo_campos
            bloquar_campo: true,
            //modal
            titulo_producto_modal: '',
            registro_detalle_gestion: [],
            registro_detalle_gestion_vista: [],
            titulo_detalle_reciclaje_modal: '',

            error: 'aa',
            mensaje: 'bb',
            //estilos_css default
            estilo_titulo: 'bg-primary',
            estilo_texto: 'text-primary',
            texto_titulo: 'aca va tu titulo',
            texto_mensaje: 'aca va tu subtitulo',
            //listas
            listarProductos: [],
            listarCategorias: [],
            obtener_datos_usuario: [],
            ListarReciclajeUsuario: [],
            listarEmpresaDescuentoReciclajeCantidad: [],
            puntaje_reciclaje: 0,
            EmpresaDescuentoReciclajeCantidad: '',
        }),

        created: function () {
            var vm = this;


        },
        mounted: function () {
            var vm = this;
            vm.Listar_Puntos_Usuario();
            vm.tabla_jquery_reload_mount_reciclaje();
            vm.mostrar_puntos_reciclaje();


        },

        methods:
        {

            Listar_Puntos_Usuario() {

                var vm = this;

                return axios.post('/PuntosDescuentos/Listar_Puntos_Usuario', {
                    codigo_usuario: vm.usuario.codigo_usuario,
                })
                    .then(function (response) {
                        vm.ListarReciclajeUsuario = response.data;

                    })
                    .catch(function (error) {
                        console.log(error);
                    });
            },
            cargar_datos_cliente_reciclaje(datos) {

                var vm = this;
                vm.titulo_detalle_reciclaje_modal = 'Detalle Reciclaje';
                if (datos.length !== "") {
                    vm.listar_todo_reciclaje_usuario(datos)
                }
                $('#modalformularioreciclajeprocesado').modal("show");

            },
            exportar_pdf_puntos_cliente(datos) {

                var vm = this;

                return axios.post('/Reciclaje/obtener_puntos_descuento_reciclaje', {
                    codigo_detalle: datos,

                })
                    .then(function (response) {
                        console.log(response);
                        vm.descargaPDF(response.data.base64, response.data.nombrepdf)
                        vm.mostrar_puntos_reciclaje();

                        $('#modalformulariocanjepuntos').modal("hide");
                        vm.bloquar_campo = false;
                    })
                    .catch(function (error) {
                        console.log(error);
                    });

            },
            metodo_notificacion(estilo_texto, estilo_titulo, texto_titulo, texto_mensaje) {
                const vm = this;
                vm.texto_titulo = texto_titulo;
                vm.texto_mensaje = texto_mensaje;
                vm.estilo_titulo = estilo_titulo;
                vm.estilo_texto = estilo_texto;
                var toastElList = [].slice.call(document.querySelectorAll('.toast'))
                var toastList = toastElList.map(function (toastEl) {

                    return new bootstrap.Toast(toastEl, {
                        animation: true,
                        autohide: true,
                        delay: 2500
                    }).show();
                })
            },
            obtener_valor_combobox(getElementById, objeto_vm) {

                let cmb_options = document.getElementById(getElementById);
                let texto = "";
                if (objeto_vm === "") {
                    texto === "";
                } else {
                    texto = cmb_options.options[cmb_options.selectedIndex].text;
                }
                return texto;
            },
            tabla_jquery_reload_mount_reciclaje() {
                $('#tabla_cliente_responsivos_reciclaje').DataTable().destroy();
                setTimeout(() => {
                    $("#tabla_cliente_responsivos_reciclaje").DataTable({
                        "language": {
                            "url": "//cdn.datatables.net/plug-ins/1.10.16/i18n/Spanish.json"
                        },
                        responsive: true,
                        pageLength: 5,
                        lengthMenu: [[5, 10, 25, 50, 100, -1], [5, 10, 25, 50, 100, 'Todos']],
                        "dom":
                            "<'row'" +
                            "<'col-sm-6 d-flex align-items-center justify-conten-start'l>" +
                            "<'col-sm-6 d-flex align-items-center justify-content-end'f>" +
                            ">" +

                            "<'table-responsive'tr>" +

                            "<'row'" +
                            "<'col-sm-12 col-md-5 d-flex align-items-center justify-content-center justify-content-md-start'i>" +
                            "<'col-sm-12 col-md-7 d-flex align-items-center justify-content-center justify-content-md-end'p>" +
                            ">"
                    })
                }, 270);
            },
            listar_todo_reciclaje_usuario(valor) {

                var vm = this;

                return axios.post('/Reciclaje/listar_todo_reciclaje_usuario', {
                    codigo_usuario: valor,
                })
                    .then(function (response) {
                        vm.registro_detalle_gestion_vista = response.data;

                    })
                    .catch(function (error) {
                        console.log(error);
                    });
            },
            canjear_puntos(valor) {
                var vm = this;
                vm.titulo_producto_modal = 'Nuevo Canje de Puntos';
                vm.Listar_Empresa_Descuento_Reciclaje_cantidad();
                $('#modalformulariocanjepuntos').modal("show");

            },
            mostrar_puntos_reciclaje() {

                var vm = this;

                return axios.post('/Reciclaje/Mostrar_Puntos_Reciclaje', {

                    codigo_usuario: vm.usuario.codigo_usuario,

                })
                    .then(function (response) {
                        vm.puntaje_reciclaje = response.data;

                    })
                    .catch(function (error) {
                        console.log(error);
                    });
            },
            Listar_Empresa_Descuento_Reciclaje_cantidad() {

                var vm = this;

                return axios.post('/Reciclaje/Listar_Empresa_Descuento_Reciclaje_cantidad', {
                    codigo_usuario: vm.usuario.codigo_usuario,

                })
                    .then(function (response) {
                        vm.listarEmpresaDescuentoReciclajeCantidad = response.data;

                    })
                    .catch(function (error) {
                        console.log(error);
                    });
            },
            grabar_puntos_cajeados_reciclaje(evt) {
                evt.preventDefault()
                var vm = this;

                vm.$validator.validateAll('formdatosreciclajeempresadescuento').then(function (result) {
                    if (result) {
                        (vm.estado) ? vm.estado = 1 : vm.estado = 0;

                        return axios.post('/Reciclaje/guardar_puntos_descuento_reciclaje', {
                            codigo_usuario: vm.usuario.codigo_usuario,
                            codigo_empresa_descuento: vm.EmpresaDescuentoReciclajeCantidad.codigo_empresa_descuento,
                            descripcion_empresa_descuento: vm.EmpresaDescuentoReciclajeCantidad.descripcion_empresa_descuento,
                            descuento_aplicado: vm.EmpresaDescuentoReciclajeCantidad.descuento,
                            puntos_canjeados: vm.EmpresaDescuentoReciclajeCantidad.stock,

                        })
                            .then(function (response) {
                                console.log(response);
                                vm.descargaPDF(response.data.base64, response.data.nombrepdf)
                                vm.mostrar_puntos_reciclaje();

                                $('#modalformulariocanjepuntos').modal("hide");
                                vm.bloquar_campo = false;
                            })
                            .catch(function (error) {
                                console.log(error);
                            });

                    };
                }).catch(function (error) {
                    console.log(error);
                    console.log(error.response.data.status);
                    console.log(error.response.data.message);
                    vm.error = error.response.data.status
                    vm.mensaje = error.response.data.message
                    //bootstrap.toast(document.querySelector('#errortoast')).show();
                    $('.toast').toast({ animation: true, autohide: true, delay: 3000 });
                    $('.toast').toast("show")

                });
            },
            descargaPDF(data, filename) {
                const linkSource = `data:application/pdf;base64,${data}`;
                const downloadLink = document.createElement('a');
                const fileName = filename + ".pdf"

                downloadLink.href = linkSource;
                downloadLink.download = fileName;
                downloadLink.click();
            },
            limpiar_campos_puntos_cajeados() {
                var vm = this;
                vm.$validator.reset('formdatosreciclajeempresadescuento');
                vm.EmpresaDescuentoReciclajeCantidad = "";
            },
        }
    });
})();


