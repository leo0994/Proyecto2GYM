$(document).ready(function () {
    getUser();
    getAllPaymentsMethods();
    getEnrollmentAmount();
    getToDayDate();
    
});

function getUser() {
    var urlParams = new URLSearchParams(window.location.search); // funcion nativa del javascript que saca los parametros de la URL
    console.log(urlParams.get('id')); // saca el parametro ID
    $('#userId').val(urlParams.get('id'));

    const apiUrlGetUser = API_URL_BASE + "/User/RetrieveById" // traer el user

    $.ajax({
        url: apiUrlGetUser+"?id="+urlParams.get('id'),
        method: "GET",
        hasContent: true,   
        //data: JSON.stringify(typeUser), para el post 
        contentType: "application/json;charset=utf-8",
        dataType: "json",
    })
        .done((result) => { // "result es el json de response del servicio ya sea base de datos o de la Api"
            console.log(result); // json de la base de datos desde la consola
            $('#email').val(result.email)
            $('#name').val(result.name)
        }).fail((response) => {
            console.log(response.responseText)
            Swal.fire({
                title: "User ID",
                text: "User ID incorrect",
                icon: "error",
            })
        });
}


function getAllPaymentsMethods() {

    const apiUrlGetPaymentMethods = API_URL_BASE + "/PaymentMethod" // traer el payment 

    $.ajax({
        url: apiUrlGetPaymentMethods,
        method: "GET",
        hasContent: true,
        //data: JSON.stringify(typeUser), para el post 
        contentType: "application/json;charset=utf-8",
        dataType: "json",
    })
        .done((result) => { // "result es el json de response del servicio ya sea base de datos o de la Api"
            console.log(result); // json de la base de datos desde la consola
            //$('#PaymentMethod').append("<option value=‘0’>Seleccione una opción</option>");
            $('#PaymentMethod').append(new Option('Select your Payment Method',0));
            for (var i = 0; i < result.length; i++) {
                $('#PaymentMethod').append(new Option(result[i]['name'],result[i]['id'] ));
                //$('#PaymentMethod').append("<option value='" + result[i]['id'] + "' > " + result[i]['name']+"</option > ");
            }
        }).fail((response) => {
            console.log(response.responseText)
            Swal.fire({
                title: "Payment Method",
                text: "There is an error",
                icon: "error",
            })
        });
}

function getEnrollmentAmount() {

    const apiUrlEnrollmentAmount = API_URL_BASE + "/Enrollment/RetrieveById/1" // traer el payment 

    $.ajax({
        url: apiUrlEnrollmentAmount,
        method: "GET",
        hasContent: true,
        //data: JSON.stringify(typeUser), para el post 
        contentType: "application/json;charset=utf-8",
        dataType: "json",
    })
        .done((result) => { // "result es el json de response del servicio ya sea base de datos o de la Api"
            $('#amount').val(result.amount)
        }).fail((response) => {
            console.log(response.responseText)
            Swal.fire({
                title: "Amount",
                text: "There is an error",
                icon: "error",
            })
        });
}

function getToDayDate() {
    const now = new Date();
    const day = String(now.getDate()).padStart(2, '0'); // Asegura que el día tenga dos dígitos
    const month = String(now.getMonth() + 1).padStart(2, '0'); // Los meses son de 0 a 11, por lo que se suma 1
    const year = now.getFullYear();
    var date = day + '/' + month + '/' + year;
    $('#date').val(date);
}


$("#btnCreatePayment").click(function () {
    

        const now = new Date();
        const day = String(now.getDate()).padStart(2, '0'); // Asegura que el día tenga dos dígitos
        const month = String(now.getMonth() + 1).padStart(2, '0'); // Los meses son de 0 a 11, por lo que se suma 1
        const year = now.getFullYear();
        var date = year + '-' + month + '-' + day;


        const apiUrlCreatePayment = API_URL_BASE + "/Payment/Create" // hacer el payment 

        $.ajax({
            url: apiUrlCreatePayment,
            method: "POST",
            hasContent: true,
            data: JSON.stringify({ 'id': 0, 'userId': $('#userId').val(), 'date': date, 'amount': $('#amount').val(), 'paymentMethodId': $('#PaymentMethod').val(), 'status': 'active', 'couponName': $('#coupon').val() }), //para el post 
            contentType: "application/json;charset=utf-8",
            dataType: "json",
        })
            .done((result) => {
                console.log(result);
                getPaymentbyID(result.dataResponse);
                Swal.fire({
                    title: "Payment",
                    text: "Payment processed sucessfully",
                    icon: "success",
                }).then(function () {
                    window.location.href = apiUrlGet;
                }
                );
            }).fail((response) => {
                console.log(response.responseText)
                console.log(typeUser)
                Swal.fire({
                    title: "Payment",
                    text: "There is an error",
                    icon: "error",
                })
            });


});


function getPaymentbyID(id) {

    const apiUrlGetPaymentbyID = API_URL_BASE + "/Payment/RetrieveById/" + id; // traer el payment

    $.ajax({
        url: apiUrlGetPaymentbyID,
        method: "GET",
        hasContent: true,
        //data: JSON.stringify(typeUser), para el post 
        contentType: "application/json;charset=utf-8",
        dataType: "json",
    })
        .done((result) => { // "result es el json de response del servicio ya sea base de datos o de la Api"
            $('#userId').val(result.userId);
            $('#date').val(result.date);
            $('#amount').val(result.amount);
            //$('#PaymentMethod').val(result.PaymentMethodId);
            $('#status').val(result.status);
            $('#coupon').val(result.couponName);
            
        }).fail((response) => {
            console.log(response.responseText)
            Swal.fire({
                title: "Amount",
                text: "There is an error",
                icon: "error",
            })
        });
        


}

