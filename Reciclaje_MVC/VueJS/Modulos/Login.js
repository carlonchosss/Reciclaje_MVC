(function () {
    'use strict';
    Vue.use(VeeValidate, {
        dictionary: {
            es: {
                custom: {
                    usuario: {
                        required: 'Debe ingresar su usuario.'
                    },
                    contrasenia: {
                        required: 'Debe ingresar su contraseña.'
                    }
                }
            }
        }
    });

    VeeValidate.Validator.localize("es");
    Vue.config.productionTip = false;

    var app = new Vue({
        el: '#applogin',
        data: () => ({
            usuario: '',
            contrasenia: '',
            error: '',
            mensaje: '',
            //estilos_css default
            estilo_titulo: 'bg-primary',
            estilo_texto: 'text-primary',
            texto_titulo: 'aca va tu titulo',
            texto_mensaje: 'aca va tu subtitulo',
        }),

        created: function () {
            var vm = this;
        },
        mounted: function () {
            var vm = this;
        },

        methods: {
            iniciar_login() {
                //   evt.preventDefault()
                var vm = this;

                vm.$validator.validateAll('formdatosusuario').then(function (result) {
                    if (result) {

                        return axios.post('/Authentication/Usuario_por_Documento_Password', {
                            usuario: vm.usuario,
                            contrasenia: vm.contrasenia

                        }).then(function (response) {

                            console.log(response.data);
                            var user = response.data;

                            if (user.resultado) {
                                const serializedState = JSON.stringify(user.datos);
                                sessionStorage.setItem('currentUser', serializedState);
                                return window.location.href = "/Home";
                            } else {
                                console.log(user)
                                if (user.codigo_error === 0) {
                                    vm.metodo_notificacion('text-warning', 'bg-warning', user.errortitulo, user.mensaje)
                                } else {
                                    vm.metodo_notificacion('text-danger', 'bg-danger', user.errortitulo, user.mensaje)
                                }
                            }
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