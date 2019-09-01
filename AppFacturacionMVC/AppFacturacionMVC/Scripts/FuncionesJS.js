(function ($) {
    $(document).ready(function () {
        $('ul.dropdown-menu [data-toggle=dropdown]').on('click', function (event) {
            event.preventDefault();
            event.stopPropagation();
            $(this).parent().siblings().removeClass('open');
            $(this).parent().toggleClass('open');
        });
        i = 1;
        total = 0;
        $(".datepicker").datepicker();

        $("#agregar").click(function () {
            subtotal = $("#cantidad").val() * $("#precio").val()
            $("table").append('<tr><th scope="' + "row" + '">' + (i++)
                + '</th><td>' + $("#producto").val() + '</td><td>' + $("#cantidad").val()
                + '</td><td>' + "$" + subtotal + '</td></tr >');
            total += subtotal;
            $("#totalFactura").text("El total comprado es: $" + total);
        });

        //Busqueda de cliente
        var a = $("#BuscarCliente").val();

        $.getJSON('/Catalogos/Cliente/BuscaCliente', { search: a }, function (result) {
            var data_arr = result.map(function (val) {
                return val.IdCliente+" -"+val.Nombre+" "+val.Apellido+" "+val.Telefono
            });
            autoCliente(data_arr);
        });
        
        function autoCliente(data_arr) {

            $("#BuscarCliente").autocomplete({
                source: data_arr,
                minLength: 1
            });
        }
        

        //Buscar Producto
        var p = $("#producto").val();
        var precio = 0;
        $.getJSON('/Catalogos/Producto/BuscaProducto', { search: p }, function (resultP) {
            var data_arrP = resultP.map(function (val) {                
                return val.IdProducto + "- " + val.NombreProducto + " " + val.Precio
            });
            autoProducto(data_arrP);
        });


        //Cargar precio
        $("#producto").on("autocompletechange ", function () {
            var dato = $("#producto").val().split(" ");            
            $(".precio").val(dato[2]);
        });


        function autoProducto(data_arrP) {
            
            $("#producto").autocomplete({
                source: data_arrP,
                minLength: 1                
            });

        }

        //Facturar
        $("#facturar").click(function () {
            $.getJSON(
                "/Procesos/Factura/AbrirFactura", // Controller/View   
                { //Passing data  
                    idFactura: $("#NumeroFactura").val(),
                    formaPago: $("#formaPago").val(),
                    fecha: $("#pick").val(),
                    idCliente: ($("#BuscarCliente").val().split(" "))[0]

                }, function (data) {
                    
                    if (data.res == 1) {
                        alert("Se Aperturo una nueva factura");
                    } else {
                        alert("No pudo aperturarse la factura");
                    }
                }

            );
        });

    });
}) (jQuery);