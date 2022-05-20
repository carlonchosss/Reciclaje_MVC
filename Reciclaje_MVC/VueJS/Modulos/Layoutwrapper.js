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
        el: '#appLayout_wrapper',
        data() {
            return {
                usuario_login: JSON.parse(sessionStorage.currentUser),
                //nombreUsuario: '',
            }
        },
        created: function () {
            var vm = this;
            if (sessionStorage.length === 0) {
                return window.location.href = "/";
            }
        },
        mounted: function () {
            var vm = this;
        },
        methods: {

            cerrarSesion: function () {

                var vm = this;
                if (sessionStorage["currentUser"] !== null) {
                    debugger;

                    sessionStorage.clear();
                    return window.location.href = "/";

                }
            },

        }

    });
})();