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
            //usuario_sistema: JSON.parse(sessionStorage.currentUser),
            codigo_empresa_descuento: 0,
            descripcion: '',
            descuento: '',
            cantidad: '',
            estado: 1,

            titulo_categoria_modal: '',

            error: 'aa',
            mensaje: 'bb',
            //estilos_css default
            estilo_titulo: 'bg-primary',
            estilo_texto: 'text-primary',
            texto_titulo: 'aca va tu titulo',
            texto_mensaje: 'aca va tu subtitulo',
            //listas
            listarempresadescuento: [],
            obtener_datos_usuario: [],
        }),

        created: function () {
            var vm = this;


        },
        mounted: function () {
            var vm = this;
            vm.Listar_Empresa_Descuento();
            vm.Tabla_Cliente_Query_Mount_Reload();
        },

        methods:
        {
            insertar_actualizar_formulario_consumidor(evt) {
                evt.preventDefault()
                var vm = this;

                vm.$validator.validateAll('formdatosempresadescuento').then(function (result) {
                    if (result) {
                        (vm.estado) ? vm.estado = 1 : vm.estado = 0;
                        if (vm.codigo_empresa_descuento === 0 || vm.codigo_empresa_descuento === "") {
                            //Insertar
                            return axios.post('/Reciclaje/Registro_Empresa_Descuento', {
                                descripcion_empresa_descuento: vm.descripcion,
                                descuento: vm.descuento,
                                stock: vm.cantidad,
                                // codigo_perfil_usuario: vm.perfil,
                            }).then(function (response) {
                                console.log(response.data);
                                var user = response.data;
                                if (user.resultado) {
                                    vm.limpiar_campos();
                                    vm.Listar_Empresa_Descuento();
                                    vm.Tabla_Cliente_Query_Mount_Reload();

                                    $('#modalformularioempresadescuento').modal("hide");

                                    vm.metodo_notificacion('text-success', 'bg-success', user.titulo, user.mensaje)
                                } else {
                                    console.log(user)
                                    if (user.codigo_error === 0) {
                                        vm.metodo_notificacion('text-warning', 'bg-warning', user.errortitulo, user.mensaje)
                                    } else {
                                        vm.metodo_notificacion('text-danger', 'bg-danger', user.errortitulo, user.mensaje)
                                    }
                                }
                            });
                        } else {
                            //Actualizar
                            return axios.post('/Reciclaje/Actualizar_Empresa_Descuento', {
                                descripcion_empresa_descuento: vm.descripcion,
                                descuento: vm.descuento,
                                stock: vm.cantidad,
                                codigo_empresa_descuento: vm.codigo_empresa_descuento,
                                habilitado: vm.estado
                                // codigo_perfil_usuario: vm.perfil,

                            }).then(function (response) {
                                console.log(response.data);
                                var user = response.data;
                                if (user.resultado) {
                                    vm.limpiar_campos();
                                    vm.Listar_Empresa_Descuento();
                                    vm.Tabla_Cliente_Query_Mount_Reload();

                                    $('#modalformularioempresadescuento').modal("hide");

                                    vm.metodo_notificacion('text-success', 'bg-success', user.titulo, user.mensaje)
                                } else {
                                    console.log(user)
                                    if (user.codigo_error === 0) {
                                        vm.metodo_notificacion('text-warning', 'bg-warning', user.errortitulo, user.mensaje)
                                    } else {
                                        vm.metodo_notificacion('text-danger', 'bg-danger', user.errortitulo, user.mensaje)
                                    }
                                }
                            });

                        }
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

            Listar_Empresa_Descuento() {

                var vm = this;

                return axios.post('/Reciclaje/Listar_Empresa_Descuento', {
                    params: {
                    }
                })
                    .then(function (response) {
                        vm.listarempresadescuento = response.data;

                    })
                    .catch(function (error) {
                        console.log(error);
                    });
            },

            obtener_datos_cliente(datos) {

                var vm = this;

                vm.limpiar_campos();
                vm.titulo_categoria_modal = 'Editar Empresa';

                vm.codigo_empresa_descuento = datos.codigo_empresa_descuento;
                vm.descripcion = datos.descripcion_empresa_descuento;
                vm.descuento = datos.descuento;
                vm.cantidad = datos.stock;

                vm.estado = (datos.habilitado) ? datos.habilitado = 1 : datos.habilitado = 0;
                $('#modalformularioempresadescuento').modal("show");

            },

            deshabilitar_datos_cliente(codigo_empresa_descuento) {
                var vm = this;
                //Actualizar
                return axios.post('/Reciclaje/Actualizar_Estado_Empresa_Descuento', {

                    codigo_empresa_descuento: codigo_empresa_descuento

                }).then(function (response) {
                    console.log(response.data);
                    var user = response.data;
                    if (user.resultado) {
                        vm.Listar_Empresa_Descuento();
                        vm.Tabla_Cliente_Query_Mount_Reload();

                        vm.metodo_notificacion('text-success', 'bg-success', user.titulo, user.mensaje)
                    } else {
                        console.log(user)
                        if (user.codigo_error === 0) {
                            vm.metodo_notificacion('text-warning', 'bg-warning', user.errortitulo, user.mensaje)
                        } else {
                            vm.metodo_notificacion('text-danger', 'bg-danger', user.errortitulo, user.mensaje)
                        }
                    }
                });
            },

            limpiar_campos() {
                var vm = this;
                vm.$validator.reset('formdatosempresadescuento');
                vm.codigo_empresa_descuento = 0;
                vm.descripcion = '';
                vm.descuento = '';
                vm.cantidad = '';
                vm.estado = 1;
            },

            agregar_datos_cliente(valor) {
                var vm = this;
                vm.limpiar_campos();
                vm.titulo_categoria_modal = 'Agregar Empresa';
                $('#modalformularioempresadescuento').modal("show");

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

            Tabla_Cliente_Query_Mount_Reload() {
                $('#tabla_cliente_responsivo').DataTable().destroy();
                setTimeout(() => {
                    $("#tabla_cliente_responsivo").DataTable({
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
        },
    });
})();


