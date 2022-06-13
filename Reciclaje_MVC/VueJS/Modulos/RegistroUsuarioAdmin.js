(function () {
    'use strict';
    Vue.use(VeeValidate, {
        dictionary: {
            es: {
                custom: {
                    nombre: {
                        required: 'Debe ingresar su nombre.'
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
        el: '#appRegistroUsuarioAdmin',
        data: () => ({
            //usuario_sistema: JSON.parse(sessionStorage.currentUser),
            codigo_usuario: 0,
            nombre: '',
            apellido: '',
            celular: '',
            documento: '',
            correo: '',
            estado: 1,
            usuario: '',
            contrasenia: '',
            Perfil_Usuario: '',
            titulo_usuario_modal: '',

            error: 'aa',
            mensaje: 'bb',
            //estilos_css default
            estilo_titulo: 'bg-primary',
            estilo_texto: 'text-primary',
            texto_titulo: 'aca va tu titulo',
            texto_mensaje: 'aca va tu subtitulo',
            //listas
            listarUsuarios: [],
            ListarPerfiles:[],
            obtener_datos_usuario: [],
        }),

        created: function () {
            var vm = this;


        },
        mounted: function () {
            var vm = this;
            vm.Listar_Usuario();
            vm.Tabla_Cliente_Query_Mount_Reload();
            vm.Listar_Perfiles();
            //vm.metodo_notificacion('text-danger', 'bg-danger', 'titulo', 'hola mundo')
            //var toastElList = [].slice.call(document.querySelectorAll('.toast'))
            //var toastList = toastElList.map(function (toastEl) {

            //    return new bootstrap.Toast(toastEl, {
            //        animation: true,
            //        autohide: true,
            //        delay: 3000
            //    }).show();
            //})
        },

        methods:
        {
            Registrar_Usuario_Admin(evt) {
                var vm = this;


                vm.$validator.validateAll('formdatosusuario').then(function (result) {
                    if (result) {
                        (vm.estado) ? vm.estado = 1 : vm.estado = 0;
                        if (vm.codigo_usuario === 0 || vm.codigo_usuario === "") {
                            //Insertar
                            return axios.post('/Cliente/Registro_Usuario_Adm', {
                                nombre: vm.nombre,
                                apellido: vm.apellido,
                                celular: vm.celular,
                                numero_documento: vm.documento,
                                correo_electronico: vm.correo,
                                usuario: vm.usuario,
                                contrasenia: vm.contrasenia,
                                codigo_perfil_usuario: vm.Perfil_Usuario,

                            }).then(function (response) {
                                console.log(response.data);
                                var user = response.data;
                                if (user.resultado) {
                                    vm.limpiar_campos();
                                    vm.Listar_Usuario();
                                    vm.Tabla_Cliente_Query_Mount_Reload();

                                    $('#modalformulariousuario').modal("hide");
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
                            return axios.post('/Cliente/Actualizar_Usuario_Adm', {
                                nombre: vm.nombre,
                                apellido: vm.apellido,
                                celular: vm.celular,
                                numero_documento: vm.documento,
                                correo_electronico: vm.correo,
                                usuario: vm.usuario,
                                habilitado: vm.estado,
                                contrasenia: vm.contrasenia,
                                codigo_usuario: vm.codigo_usuario,
                                codigo_perfil_usuario: vm.Perfil_Usuario,

                            }).then(function (response) {
                                console.log(response.data);
                                var user = response.data;
                                if (user.resultado) {
                                    vm.limpiar_campos();
                                    vm.Listar_Usuario();
                                    vm.Tabla_Cliente_Query_Mount_Reload();

                                    $('#modalformulariousuario').modal("hide");
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

            Listar_Usuario() {

                var vm = this;

                return axios.post('/Cliente/Listar_Usuarios', {
                    params: {
                    }
                })
                    .then(function (response) {
                        vm.listarUsuarios = response.data;

                    })
                    .catch(function (error) {
                        console.log(error);
                    });
            },
            Listar_Perfiles() {

                var vm = this;

                return axios.post('/Cliente/Listar_Perfiles', {
                    params: {
                    }
                })
                    .then(function (response) {
                        vm.ListarPerfiles = response.data;

                    })
                    .catch(function (error) {
                        console.log(error);
                    });
            },
            agregar_datos_cliente(valor) {
                var vm = this;
                vm.limpiar_campos();
                vm.titulo_usuario_modal = 'Agregar Cliente';
                $('#modalformulariousuario').modal("show");

            },
            obtener_datos_cliente(datos) {

                var vm = this;
                vm.limpiar_campos();
                vm.titulo_usuario_modal = 'Editar Cliente';
                vm.codigo_usuario = datos.codigo_usuario;
                vm.nombre = datos.nombre;
                vm.apellido = datos.apellido;
                vm.celular = datos.celular;
                vm.documento = datos.numero_documento;
                vm.correo = datos.correo_electronico;           
                vm.Perfil_Usuario = (datos.codigo_perfil_usuario == 0) ? datos.codigo_perfil_usuario = "" : datos.codigo_perfil_usuario;
                vm.usuario = datos.usuario;
                vm.contrasenia = datos.contrasenia
                vm.estado = (datos.habilitado) ? datos.habilitado = 1 : datos.habilitado = 0;
                $('#modalformulariousuario').modal("show");

            },

            limpiar_campos() {
                var vm = this;
                vm.$validator.reset('formdatosusuario');
                vm.codigo_usuario = 0;
                vm.nombre = '';
                vm.apellido = '';
                vm.celular = '';
                vm.documento = '';
                vm.correo = '';
                vm.estado = 1;
                vm.usuario = '';
                vm.contrasenia = '';
                vm.Perfil_Usuario = '';
            },

            deshabilitar_datos_cliente(codigo_usuario) {
                var vm = this;
                //Actualizar
                return axios.post('/Cliente/Actualizar_Estado_Usuario_Adm', {

                    codigo_usuario: codigo_usuario

                }).then(function (response) {
                    console.log(response.data);
                    var user = response.data;
                    if (user.resultado) {
                        vm.Listar_Usuario();
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


