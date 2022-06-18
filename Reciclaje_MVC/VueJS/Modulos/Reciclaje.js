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
            vm.listar_Productos_Categorias();
            vm.Listar_Categoria();
            vm.tabla_jquery_reload_mount();
            vm.Listar_Reciclaje_Usuario();
            vm.tabla_jquery_reload_mount_reciclaje();
            vm.mostrar_puntos_reciclaje();


        },

        methods:
        {
            grabar_formulario_reciclaje(evt) {
                evt.preventDefault()
                var vm = this;

                vm.$validator.validateAll('formdatosreciclajeprocesar').then(function (result) {
                    if (result) {
                        (vm.estado) ? vm.estado = 1 : vm.estado = 0;

                        var objeto_reciclaje = {
                            codigo_usuario: vm.usuario.codigo_usuario,
                            ERegistro_Reciclaje_Detalle: vm.registro_detalle_gestion
                        };

                        if (vm.registro_detalle_gestion.length === 0) {
                            return alert("Agregar detalle del Reciclaje");
                        }
                        else {
                            return axios.post('/Reciclaje/guardar_reciclaje', {
                                //objeto_reciclaje: JSON.stringify(objeto_reciclaje)
                                codigo_usuario: vm.usuario.codigo_usuario,
                                valor_detalle: vm.registro_detalle_gestion
                            })
                                .then(function (response) {
                                    vm.Listar_Reciclaje_Usuario();
                                    vm.tabla_jquery_reload_mount_reciclaje();
                                    vm.mostrar_puntos_reciclaje();
                                    vm.registro_detalle_gestion = [];
                                    $('#modalformularioreciclaje').modal("hide");
                                    vm.bloquar_campo = false;
                                })
                                .catch(function (error) {
                                    console.log(error);
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

            insertar_actualizar_formulario_reciclaje_temp(evt) {
                evt.preventDefault()
                var vm = this;

                vm.$validator.validateAll('formdatosreciclajetemp').then(function (result) {
                    if (result) {
                        (vm.estado) ? vm.estado = 1 : vm.estado = 0;

                        if (vm.indexcodigo_registro_detalle === "") {
                            //Insertar
                            vm.registro_detalle_gestion.push({
                                codigo_categoria: vm.categoria,
                                descripcion_categoria: vm.obtener_valor_combobox("categoria", vm.categoria),
                                codigo_producto: vm.producto,
                                descripcion_producto: vm.obtener_valor_combobox("producto", vm.producto),
                                cantidad: 1
                            });

                            console.log(vm.registro_detalle_gestion)
                            vm.tabla_jquery_reload_mount();
                            vm.limpiar_campos();
                        } else {
                            vm.registro_detalle_gestion[vm.indexcodigo_registro_detalle].codigo_categoria = vm.categoria;
                            vm.registro_detalle_gestion[vm.indexcodigo_registro_detalle].descripcion_categoria = vm.obtener_valor_combobox("categoria", vm.categoria);
                            vm.registro_detalle_gestion[vm.indexcodigo_registro_detalle].codigo_producto = vm.producto;
                            vm.registro_detalle_gestion[vm.indexcodigo_registro_detalle].descripcion_producto = vm.obtener_valor_combobox("producto", vm.producto);
                            vm.registro_detalle_gestion[vm.indexcodigo_registro_detalle].cantidad = 1;
                            vm.tabla_jquery_reload_mount();
                            vm.limpiar_campos();
                            $('#modalformulariodatosreciclajetemp').modal("hide");
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

            listar_Productos_Categorias(valor) {

                var vm = this;
                if (!valor) {
                    vm.bloquar_campo = true;
                    vm.listarProductos = [];
                    vm.producto = '';
                } else {
                    return axios.post('/Reciclaje/Listar_Producto_Categoria', {
                        codigo_categoria: valor

                    })
                        .then(function (response) {
                            vm.producto = '';
                            vm.listarProductos = response.data;
                            vm.bloquar_campo = false;
                        })
                        .catch(function (error) {
                            console.log(error);
                        });
                }
            },

            Listar_Categoria() {

                var vm = this;

                return axios.post('/Producto/Listar_Categorias', {
                    params: {
                    }
                })
                    .then(function (response) {
                        vm.listarCategorias = response.data;

                    })
                    .catch(function (error) {
                        console.log(error);
                    });
            },

            Listar_Reciclaje_Usuario() {

                var vm = this;

                return axios.post('/Reciclaje/Listar_Reciclaje_Usuario', {
                    codigo_usuario: vm.usuario.codigo_usuario,
                })
                    .then(function (response) {
                        vm.ListarReciclajeUsuario = response.data;

                    })
                    .catch(function (error) {
                        console.log(error);
                    });
            },
            obtener_datos_cliente(datos, index) {

                var vm = this;

                vm.limpiar_campos();
                vm.titulo_producto_modal = 'Editar Reciclaje';
                vm.indexcodigo_registro_detalle = index;
                vm.categoria = datos.codigo_categoria;
                if (vm.categoria !== "") {
                    vm.listar_Productos_Categorias(vm.categoria).then(function () {
                        vm.producto = datos.codigo_producto;
                    });
                }
                vm.cantidad = 1;
                $('#modalformulariodatosreciclajetemp').modal("show");

            },

            cargar_datos_cliente_reciclaje(datos) {

                var vm = this;
                vm.titulo_detalle_reciclaje_modal = 'Detalle Reciclaje';
                if (datos.length !== "") {
                    vm.listar_todo_reciclaje_usuario(datos)
                }
                $('#modalformularioreciclajeprocesado').modal("show");

            },

            deshabilitar_datos_cliente(codigo_registro_reciclaje) {
                var vm = this;
                //Actualizar
                return axios.post('/Producto/Actualizar_Estado_Producto', {

                    codigo_registro_reciclaje: codigo_registro_reciclaje

                }).then(function (response) {
                    console.log(response.data);
                    var user = response.data;
                    if (user.resultado) {
                        vm.listar_Productos_Categorias();
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

            eliminar_datos_cliente(index) {
                var vm = this;

                vm.registro_detalle_gestion.splice(index, 1);
                vm.tabla_jquery_reload_mount();
                console.log(vm.detalleRequerimiento);
            },

            limpiar_campos() {
                var vm = this;
                vm.$validator.reset('formdatosreciclajetemp');
                vm.indexcodigo_registro_detalle = "";
                vm.categoria = "";
                vm.producto = "";
                vm.estado = 1;
            },

            agregar_datos_cliente(valor) {
                var vm = this;
                vm.limpiar_campos();
                vm.titulo_producto_modal = 'Agregar Reciclaje';
                $('#modalformulariodatosreciclajetemp').modal("show");

            },

            nuevo_reciclaje(valor) {
                var vm = this;
                vm.titulo_producto_modal = 'Reciclaje';
                $('#modalformularioreciclaje').modal("show");

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
            tabla_jquery_reload_mount() {
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


