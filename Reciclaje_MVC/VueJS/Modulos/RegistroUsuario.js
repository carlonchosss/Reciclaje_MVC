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
        el: '#appregistro',
        data: () => ({
            //usuario_sistema: JSON.parse(sessionStorage.currentUser),
            codigo_usuario: 0,
            nombre: '',
            apellido: '',
            celular: '',
            documento: '',
            correo: '',
            usuario: '',
            contrasenia: '',
            error: 'aa',
            mensaje: 'bb',
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

        methods:
        {
            Registrar_Usuario(evt) {
                var vm = this;


                vm.$validator.validateAll('formdatosusuario').then(function (result) {
                    if (result) {
                        //Insertar
                        return axios.post('/Cliente/Registro_Usuario_Adm', {
                            nombre: vm.nombre,
                            apellido: vm.apellido,
                            celular: vm.celular,
                            numero_documento: vm.documento,
                            correo_electronico: vm.correo,
                            usuario: vm.usuario,
                            contrasenia: vm.contrasenia
                            // codigo_perfil_usuario: vm.perfil,

                        }).then(function (response) {
                            console.log(response.data);
                            var user = response.data;
                            if (user.resultado) {
                                vm.limpiar_campos();
                                vm.Listar_Usuario();
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

            limpiar_campos() {
                var vm = this;
                vm.$validator.reset('formdatosusuario');
                vm.codigo_usuario = 0;
                vm.nombre = '';
                vm.apellido = '';
                vm.celular = '';
                vm.documento = '';
                vm.correo = '';
                vm.perfil_usuario = '';
                vm.estado = 1;
                vm.usuario = '';
                vm.contrasenia = '';
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


