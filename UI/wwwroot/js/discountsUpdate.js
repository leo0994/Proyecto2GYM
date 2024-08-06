$(document).ready(function () { 
    var urlParams = new URLSearchParams(window.location.search); // funcion nativa del javascript que saca los parametros de la URL
    console.log(urlParams.get('id')); // saca el parametro ID

    const apiUrlModify = API_URL_BASE + "/Coupons/Update" // put de la modificacion
    const apiUrlbyId = API_URL_BASE + "/Coupons/GetById/" + urlParams.get('id') // traer by ID
    

    $.ajax({
        url: apiUrlbyId,
        method: "GET",
        hasContent: true,
        //data: JSON.stringify(typeUser), para el post 
        contentType: "application/json;charset=utf-8",
        dataType: "json",
    })
        .done((result) => { // "result es el json de response del servicio ya sea base de datos o de la Api"
            console.log(result); // json de la base de datos desde la consola
            $('#id').val(result.id)
            $('#name').val(result.couponsName)
            $('#Quantity').val(result.numbersCoupons)
            $('#ExpirationDate').val(result.expirationDate)
            $('#Percentaje').val(result.percentaje)

        }).fail((response) => {
            console.log(response.responseText)
            Swal.fire({
                title: "Coupons Update",
                text: "There is an error",
                icon: "error",
            })
        });
 
    $("#btnUpdateCoupon").click(function () {
        //alert ("click en el boton")

        var id = $('#id').val()
        var name = $('#name').val()
        var Quantity = $('#Quantity').val()
        var ExpirationDate = $('#ExpirationDate').val()
        var Percentaje = $('#Percentaje').val()
        
        const apiUrlGet = API_URL_BASE_NORMAL + "/Discounts/GetAll"

        $.ajax({
            url: apiUrlModify,
            method: "PUT",
            hasContent: true,
            data: JSON.stringify({ 'id': id, 'couponsName': name, 'numbersCoupons': Quantity, 'expirationDate': ExpirationDate, 'percentaje': Percentaje}), //para el post 
            contentType: "application/json;charset=utf-8",
            dataType: "json",
        })
            .done((result) => { // "result es el json de response del servicio ya sea base de datos o de la Api"
                console.log(result); // json de la base de datos desde la consola
                Swal.fire({
                    title: "Coupon",
                    text: "Coupon was modify sucessfully",
                    icon: "success",
                }).then(function () {
                    window.location.href = apiUrlGet;
                }
                ); 
            }).fail((response) => {
                console.log(response.responseText)
                Swal.fire({
                    title: "Coupon",
                    text: "There is an error",
                    icon: "error",
                })
            });

    });

});











