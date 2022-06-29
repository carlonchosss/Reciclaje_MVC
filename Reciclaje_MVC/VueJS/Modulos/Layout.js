(function () {
    'use strict';

    //Vue.use(VeeValidate, {
    //    locale: 'es',
    //    dictionary: {
    //        es: {
    //            custom: {
    //                passActual: {
    //                    required: 'Ingrese contraseña actual.',

    //                },
    //                passNueva: {
    //                    required: 'Ingrese contraseña nueva.',
    //                    alpha_dash: 'El campo puede contener caracteres alfanuméricos, así como guiones y guiones bajos.',
    //                    min: 'Mínimo 8 caracteres.',
    //                    max: 'Máximo 12 caracteres.'
    //                },
    //                passConfNueva: {
    //                    required: 'Ingrese confirmación de contraseña.',
    //                    confirmed: 'La contraseña nueva y la confirmación no coindicen.'
    //                },
    //            }
    //        }

    //    }

    //});
    //Vue.use(bootstrapVue);

    var app = new Vue({
        el: '#appLayout',
        data() {
            return {
                usuario_login: JSON.parse(sessionStorage.currentUser),
                //nombreUsuario: '',
                listaMenu: [],
                //mensaje: '',
                //passActual: '',
                //passNueva: '',
                //passConfNueva: '',
            }
        },
        created: function () {
            var vm = this;
            //if (sessionStorage["currentUser"] == null) {
            if (sessionStorage.length === 0) {
                return window.location.href = "/";
            } else {
                vm.usuario_login = JSON.parse(sessionStorage.currentUser);
                return vm.listarMenu();
            }
        },
        mounted: function () {
            var vm = this;
        },
        methods: {

            listarMenu() {

                var vm = this;
                const codigoPerfil = vm.usuario_login.codigo_perfil_usuario

                return axios.get('/Authentication/listar_menu_perfil', {
                    params: {
                        codigo_perfil: codigoPerfil
                    }
                })
                    .then(function (response) {

                        vm.listaMenu = response.data;
                        // vm.nombreUsuario = vm.usuario.descripcion_agente;

                        return vm.listaMenu;
                        //return $("#page-loader").addClass("d-none");
                    })
                    .catch(function (error) {
                        console.log(error);
                    });
            },

            cerrarSesion: function () {

                var vm = this;
                if (sessionStorage["currentUser"] !== null) {
                    debugger;
                    var codigoPerfil = vm.usuario.codigo_perfil_usuario;

                    sessionStorage.clear();
                    return window.location.href = "/";

                }
            },

            cambioClave: function () {


                var vm = this;
                vm.$validator.reset('formCambioClave');
                vm.passActual = '';
                vm.passNueva = '';
                vm.passConfNueva = '';
                return $('#modalCambioClave').modal("show");
            },

            cambiarClave: function () {

                var vm = this;
                debugger;
                console.log(vm.usuario.codigo_agente);
                console.log(vm.passActual);
                console.log(vm.passNueva);

                vm.$validator.validateAll('formCambioClave').then(function (result) {
                    debugger;
                    if (result) {
                        var params = {
                            codigo_agente: vm.usuario.codigo_agente,
                            pass_actual: vm.passActual,
                            pass_nueva: vm.passNueva

                        }

                        return axios({
                            method: 'post',
                            url: '/conexion/actualiza_password',
                            params: params
                        })
                            .then(function (response) {
                                var result = response.data;

                                if (result == "1") {

                                    vm.mensaje = "OK";
                                    //vm.$refs.modalCambioClave.hide();
                                    //vm.$refs.modalMensajeSistema.show();

                                    $.alert({
                                        icon: 'la la-info-circle',
                                        title: 'SCC',
                                        content: 'Contraseña actualizada satisfactoriamente.',
                                        typeAnimated: true,
                                        type: 'green',
                                    });
                                    $('#modalCambioClave').modal("hide");

                                } else {
                                    vm.mensaje = " No se ha podido cambiar la contraseña, revise los datos ingresados.";
                                    $("#alertValidacion").slideDown()
                                    setTimeout(function () {
                                        $("#alertValidacion").slideUp()
                                    }, 4000);
                                }
                            })
                            .catch(function (error) {
                                console.log(error);
                            });
                    };

                });

            },

        }

    });
})();