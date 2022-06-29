(function () {
    'use strict';
    Vue.use(VeeValidate, {
        dictionary: {
            es: {
                custom: {
                    Descripcion_Modulo: {
                        required: 'Debe ingresar Descripcion Rol'
                    },
                    contrasenia: {
                        required: 'Debe ingresar su contraseña.'
                    },
                    celular: {
                        required: 'Debe ingresar su celular.'
                    },
                    documento: {
                        required: 'Debe ingresar su documento.'
                    }
                }
            }
        }
    });

    VeeValidate.Validator.localize("es");
    Vue.config.productionTip = false;
    //    Vue.use(bootstrapVue);

    var app1 = new Vue({
        el: '#appModulo',
        data: () => ({
            descripcion_modulo: '',
            descripcion_url: '',
            codigo_menu: 0,
            titulo_modal_modulo: '',
            titulo_modal_sub_modulo: '',
            estado: 1,
            parentesco_menu: '',
            //usuario_sistema: JSON.parse(sessionStorage.currentUser),
            nombre: '',
            apellido: '',
            celular: '',
            documento: '',
            correo: '',
            usuario: '',
            contrasenia: '',
            Perfil_Usuario: '',

            error: 'aa',
            mensaje: 'bb',
            //estilos_css default
            estilo_titulo: 'bg-primary',
            estilo_texto: 'text-primary',
            texto_titulo: 'aca va tu titulo',
            texto_mensaje: 'aca va tu subtitulo',
            //listas
            ListarMenuWeb: [],
            ListarMenuWebParentesco: [],

            obtener_datos_usuario: [],
        }),
        created: function () {
            var vm = this;
        },
        mounted: function () {
            var vm = this;
            vm.Todo_Listar_Menu_Web();
            vm.Tabla_Cliente_Query_Mount_Reload();
            vm.Sub_Modulo_Tabla_Cliente_Query_Mount_Reload();
            vm.Listar_Menu_Web_Parentesco();
        },
        methods:
        {
            guardar_datos_modal_modulo(evt) {
                var vm = this;

                vm.$validator.validateAll('form_modal_datos_modulo').then(function (result) {
                    if (result) {
                        (vm.estado) ? vm.estado = 1 : vm.estado = 0;
                        (vm.parentesco_menu=='') ? vm.parentesco_menu = 0 : vm.parentesco_menu;

                        if (vm.codigo_menu === 0 || vm.codigo_menu === "") {
                            //Insertar
                            return axios.post('/Cliente/Registro_Modulo', {
                                descripcion: vm.descripcion_modulo,
                                url: vm.descripcion_url,
                                codigo_padre: vm.parentesco_menu,

                            }).then(function (response) {
                                console.log(response.data);
                                var user = response.data;
                                if (user.resultado) {
                                    vm.limpiar_campos();
                                    vm.Todo_Listar_Menu_Web();
                                    vm.Tabla_Cliente_Query_Mount_Reload();

                                    $('#modal_formulario_modulo').modal("hide");
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
                            return axios.post('/Cliente/Actualizar_Modulo', {
                                descripcion: vm.descripcion_modulo,
                                url: vm.descripcion_url,
                                habilitado: vm.estado,
                                codigo_menu: vm.codigo_menu,
                                codigo_padre: vm.parentesco_menu,

                            }).then(function (response) {
                                console.log(response.data);
                                var user = response.data;
                                if (user.resultado) {
                                    vm.limpiar_campos();
                                    vm.Todo_Listar_Menu_Web();
                                    vm.Tabla_Cliente_Query_Mount_Reload();

                                    $('#modal_formulario_modulo').modal("hide");
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
            Todo_Listar_Menu_Web() {

                var vm = this;

                return axios.post('/Cliente/Todo_Listar_Menu_Web', {
                    params: {
                    }
                })
                    .then(function (response) {
                        vm.ListarMenuWeb = response.data;

                    })
                    .catch(function (error) {
                        console.log(error);
                    });
            },
            Listar_Menu_Web_Parentesco() {

                var vm = this;

                return axios.post('/Cliente/Listar_Menu_Web_Parentesco', {
                    params: {
                    }
                })
                    .then(function (response) {
                        vm.ListarMenuWebParentesco = response.data;

                    })
                    .catch(function (error) {
                        console.log(error);
                    });
            },

            agregar_datos_cliente(valor) {
                var vm = this;
                vm.limpiar_campos();
                vm.titulo_modal_modulo = 'Agregar Modulo';
                $('#modal_formulario_modulo').modal("show");

            },
            agregar_datos_cliente_sub_modulo(valor) {
                var vm = this;
                vm.limpiar_campos();
                vm.titulo_modal_sub_modulo = 'Agregar Sub Modulo';
                $('#modal_formulario_sub_modulo').modal("show");

            },
            obtener_datos_cliente(datos) {
                var vm = this;

                return axios.post('/Cliente/Obtener_Modulo', {
                    codigo_menu: datos.codigo_menu
                }).then(function (response) {
                    console.log(response.data);
                    var user = response.data;
                    if (user) {
                        (user.codigo_padre == 0) ? user.codigo_padre = '' : user.codigo_padre;

                        vm.limpiar_campos();
                        vm.titulo_modal_modulo = 'Editar Modulo';

                        vm.codigo_menu = user.codigo_menu;
                        vm.descripcion_modulo = user.descripcion;
                        vm.descripcion_url = user.url;
                        vm.parentesco_menu = user.codigo_padre;

                        vm.estado = (user.habilitado) ? user.habilitado = 1 : user.habilitado = 0;
                        $('#modal_formulario_modulo').modal("show");
                    } else {
                        console.log(user)
                        $('#modal_formulario_modulo').modal("hide");
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
                vm.$validator.reset('form_modal_datos_modulo');
                vm.codigo_menu = 0;
                vm.descripcion_modulo = '';
                vm.estado = 1;
                vm.parentesco_menu = '';
                vm.descripcion_url = '';
            },
            deshabilitar_datos_cliente(codigo_menu) {
                var vm = this;
                //Actualizar
                return axios.post('/Cliente/Actualizar_Modulo_Estado', {

                    codigo_menu: codigo_menu,

                }).then(function (response) {
                    console.log(response.data);
                    var user = response.data;
                    if (user.resultado) {
                        vm.Todo_Listar_Menu_Web();
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
            Sub_Modulo_Tabla_Cliente_Query_Mount_Reload() {
                $('#tabla_cliente_responsivo_sub_modulo').DataTable().destroy();
                setTimeout(() => {
                    $("#tabla_cliente_responsivo_sub_modulo").DataTable({
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
            }
        }
    });
})();


