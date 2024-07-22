$(document).ready(function () { 
    var urlParams = new URLSearchParams(window.location.search); // funcion nativa del javascript que saca los parametros de la URL
    console.log(urlParams.get('id')); // saca el parametro ID

    const apiUrlModify = API_URL_BASE + "/TypeUser/Update" // put de la modificacion
    const apiUrlbyId = API_URL_BASE + "/TypeUser/GetById/" + urlParams.get('id') // traer by ID



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
            $('#idRole').val(result.id)
            $('#name').val(result.name)
        }).fail((response) => {
            console.log(response.responseText)
            Swal.fire({
                title: "Roles Table",
                text: "Se ha presentado un fallo",
                icon: "error",
            })
        });
 
    $("#btnUpdateRole").click(function () {
        //alert ("click en el boton")

        var idRole = $('#idRole').val()
        console.log(idRole)
        var name = $('#name').val()
        const apiUrlGet = API_URL_BASE_NORMAL + "/TypeUser/GetAll"

        $.ajax({
            url: apiUrlModify,
            method: "PUT",
            hasContent: true,
            data: JSON.stringify({ 'id': idRole, 'name': name }), //para el post 
            contentType: "application/json;charset=utf-8",
            dataType: "json",
        })
            .done((result) => { // "result es el json de response del servicio ya sea base de datos o de la Api"
                console.log(result); // json de la base de datos desde la consola
                Swal.fire({
                    title: "Role",
                    text: "Role was modify sucessfully",
                    icon: "success",
                }).then(function () {
                    window.location.href = apiUrlGet;
                }
                ); 
            }).fail((response) => {
                console.log(response.responseText)
                Swal.fire({
                    title: "Roles Table",
                    text: "There was an error",
                    icon: "error",
                })
            });

    });

});











