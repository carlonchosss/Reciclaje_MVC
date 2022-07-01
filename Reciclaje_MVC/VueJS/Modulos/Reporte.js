(function () {
    'use strict';
    Vue.use(VeeValidate, {
        dictionary: {
            es: {
                custom: {
                    descripcion: {
                        required: 'Debe ingresar su descripcion.'
                    },
                    fecha_inicio_reporte: {
                        required: 'Debe seleccionar una fecha inicio.'
                    },
                    fecha_fin_reporte: {
                        required: 'Debe seleccionar una fecha fin.'
                    },
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
            fecha_inicio_reporte: '',
            fecha_fin_reporte: '',
            reciclaje: '',
            EmpresaDescuentoReciclaje: '',

            CategoriaReciclaje: '',
            ProductoReciclaje: '',
            TipoReporteMateriales: '',

            error: 'aa',
            mensaje: 'bb',
            //estilos_css default
            estilo_titulo: 'bg-primary',
            estilo_texto: 'text-primary',
            texto_titulo: 'aca va tu titulo',
            texto_mensaje: 'aca va tu subtitulo',
            //listas
            listarEmpresaDescuentoReciclaje: [],
            ListarReporteUsuario: [],
            listarCategorias: [],
            listarProductos: [],
        }),

        created: function () {
            var vm = this;

        },
        mounted: function () {
            var vm = this;
            vm.tabla_jquery_reload_mount_reciclaje();
            vm.Listar_Empresa_Descuento();
            vm.listar_Productos_Categorias();
            vm.Listar_Categoria();

            $("#fecha_inicio_reporte").flatpickr({
                dateFormat: "d/m/Y",
                altFormat: "YYYYmmdd",
                "locale": "es",
            });
            $("#fecha_fin_reporte").flatpickr({
                dateFormat: "d/m/Y",
                altFormat: "YYYYmmdd",
                "locale": "es",
            });


        },

        methods:
        {
            Listar_Empresa_Descuento() {

                var vm = this;

                return axios.post('/Reciclaje/Listar_Empresa_Descuento', {
                })
                    .then(function (response) {
                        vm.listarEmpresaDescuentoReciclaje = response.data;

                    })
                    .catch(function (error) {
                        console.log(error);
                    });
            },
            Obtener_Reporte_Empresa_Descuento(evt) {

                evt.preventDefault()
                var vm = this;

                vm.$validator.validateAll('formdatosreporte').then(function (result) {
                    if (result) {
                        const fecha_inicio_reporte1 = vm.fecha_inicio_reporte.split("/").reverse().join("");
                        const fecha_fin_reporte1 = vm.fecha_fin_reporte.split("/").reverse().join("");
                        return axios.post('/Reporte/Obtener_Reporte_Empresa_Descuento', {
                            fecha_inicio_reporte: fecha_inicio_reporte1,
                            fecha_fin_reporte: fecha_fin_reporte1,
                            codigo_empresa_descuento: vm.EmpresaDescuentoReciclaje,

                        })
                            .then(function (response) {
                                vm.ListarReporteUsuario = response.data;
                                vm.tabla_jquery_reload_mount_reciclaje();
                                console.log(vm.ListarReporteUsuario);
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
            Exportar_Obtener_Reporte_Empresa_Descuento(evt) {

                evt.preventDefault()
                var vm = this;

                vm.$validator.validateAll('formdatosreporte').then(function (result) {
                    if (result) {
                        const fecha_inicio_reporte1 = vm.fecha_inicio_reporte.split("/").reverse().join("");
                        const fecha_fin_reporte1 = vm.fecha_fin_reporte.split("/").reverse().join("");
                        return axios.post('/Reporte/Exportar_Obtener_Reporte_Empresa_Descuento', {
                            fecha_inicio_reporte: fecha_inicio_reporte1,
                            fecha_fin_reporte: fecha_fin_reporte1,
                            codigo_empresa_descuento: vm.EmpresaDescuentoReciclaje,

                        })
                            .then(function (response) {
                                vm.descargaPDF(response.data.base64, response.data.nombrepdf)
                                vm.tabla_jquery_reload_mount_reciclaje();
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
            Obtener_Reporte_Categoria_Materiales(evt) {

                evt.preventDefault()
                var vm = this;

                vm.$validator.validateAll('formdatosreporte').then(function (result) {
                    if (result) {
                        const fecha_inicio_reporte1 = vm.fecha_inicio_reporte.split("/").reverse().join("");
                        const fecha_fin_reporte1 = vm.fecha_fin_reporte.split("/").reverse().join("");
                        return axios.post('/Reporte/Obtener_Reporte_Categoria_Materiales', {
                            fecha_inicio_reporte: fecha_inicio_reporte1,
                            fecha_fin_reporte: fecha_fin_reporte1,
                            codigo_categoria: vm.CategoriaReciclaje,
                            codigo_producto: vm.ProductoReciclaje,
                            tipo_reporte: vm.TipoReporteMateriales,

                        })
                            .then(function (response) {
                                vm.ListarReporteUsuario = response.data;
                                vm.tabla_jquery_reload_mount_reciclaje();
                                console.log(vm.ListarReporteUsuario);
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
            Exportar_Obtener_Reporte_Categoria_Materiales(evt) {

                evt.preventDefault()
                var vm = this;

                vm.$validator.validateAll('formdatosreporte').then(function (result) {
                    if (result) {
                        const fecha_inicio_reporte1 = vm.fecha_inicio_reporte.split("/").reverse().join("");
                        const fecha_fin_reporte1 = vm.fecha_fin_reporte.split("/").reverse().join("");
                        return axios.post('/Reporte/Exportar_Obtener_Reporte_Categoria_Materiales', {
                            fecha_inicio_reporte: fecha_inicio_reporte1,
                            fecha_fin_reporte: fecha_fin_reporte1,
                            codigo_categoria: vm.CategoriaReciclaje,
                            codigo_producto: vm.ProductoReciclaje,
                            tipo_reporte: vm.TipoReporteMateriales,

                        })
                            .then(function (response) {
                                vm.descargaPDF(response.data.base64, response.data.nombrepdf)
                                vm.tabla_jquery_reload_mount_reciclaje();
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

            //por borrar
            limpiar_campos() {
                var vm = this;
                vm.$validator.reset('formdatosreciclajetemp');
                vm.indexcodigo_registro_detalle = "";
                vm.categoria = "";
                vm.producto = "";
                vm.estado = 1;
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
            descargaPDF(data, filename) {
                const linkSource = `data:application/pdf;base64,${data}`;
                const downloadLink = document.createElement('a');
                const fileName = filename + ".pdf"

                downloadLink.href = linkSource;
                downloadLink.download = fileName;
                downloadLink.click();
            },
        }
    });
})();


