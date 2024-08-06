/// Create 
const createDiscount = (e) => {
    e.preventDefault()
    const coupons = {}

    coupons.couponsName = $("#name").val()
    coupons.numbersCoupons = $("#Quantity").val()
    coupons.expirationDate = $("#ExpirationDate").val()
    coupons.percentaje = $("#Percentaje").val()
    

    const apiUrl = API_URL_BASE + "/Coupons/Create"
    const apiUrlGet = API_URL_BASE_NORMAL + "/Discounts/GetAll"

    $.ajax({
        url: apiUrl,
        method: "POST",
        hasContent: true,
        data: JSON.stringify(coupons),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
    })
        .done((result) => {
            console.log(result);
            Swal.fire({
                title: "Coupon",
                text: "Coupon was created sucessfully",
                icon: "success",
            }).then(function () {
                window.location.href = apiUrlGet;
            }
            );
        }).fail((response) => {
            Swal.fire({
                title: "Coupon",
                text: "There is an error",
                icon: "error",
            })
        });


}

$("#CouponsForm").on('submit', createDiscount)


/// GetAll
$(document).ready(function () { 

    const apiUrlGet = API_URL_BASE + "/Coupons/GetAll"
    const apiUrlModify = API_URL_BASE_NORMAL + "/Discounts/Update"


    $.ajax({
        url: apiUrlGet,
        method: "GET",
        hasContent: true,
        //data: JSON.stringify(typeUser), para el post 
        contentType: "application/json;charset=utf-8",
        dataType: "json",
    })
        .done((result) => { // "result es el json de response del servicio ya sea base de datos o de la Api"
            console.log(result); // json de la base de datos desde la consola
            $('#CouponsTable').dataTable({ // Aqui inicializa la dataTable .net y el js y css estan en la vista layout 
                data: result, // aqui asignamos la data a la tabla 
                columns: [ // definimos que datos va a ir en cada colunma
                    { "data": "id" }, // como viene en el servicio 
                    { "data": "couponsName" }, // como viene en el servicio 
                    { "data": "numbersCoupons" }, // como viene en el servicio 
                    { "data": "expirationDate" }, // como viene en el servicio 
                    { "data": "percentaje" }, // como viene en el servicio 

                    {"data": "id",
                        render: function (data, type, row) {
                            return '<a href="' + apiUrlModify +"?id="+ row.id + '" target="_self"><img src="../img/botonActualizar.png" alt="Update" width="20px" height="20px" /></a>';
                        }
                    },

                    {"data": "id",
                        render: function (data, type, row) { // devolver un HTML
                            return '<button onclick="return Delete(' + row.id + ')"><img src="../img/botonEliminar.png" alt="Delete" width="20px" height="20px" /></button>';
                        }

                        /*render: function (data, type, row) {
                            return '<button><img src="../img/botonEliminar.png" alt="Delete" width="20px" height="20px" onclick="return Delete("+row.id+")"/></button>';

                        }*/
                    }
                ],
            });  

        }).fail((response) => {
            console.log(response.responseText)
            console.log(typeUser)
            Swal.fire({
                title: "Coupons Table",
                text: "There is an error",
                icon: "error",
            })
        });




});

/// Delete
function Delete(id)
{
    const apiUrlDelete = API_URL_BASE + "/Coupons/Delete/"+id

    $.ajax({
        url: apiUrlDelete,
        method: "Delete",
        hasContent: true,
        //data: JSON.stringify(typeUser), para el post 
        contentType: "application/json;charset=utf-8",
        dataType: "json",
    })
        .done((result) => { // "result es el json de response del servicio ya sea base de datos o de la Api"
            console.log(result); // json de la base de datos desde la consola
            Swal.fire({
                title: "Delete Coupon",
                text: "Coupon was deleted sucessfully",
                icon: "success",
            }).then(function () {
                location.reload();
            }
            );

        }).fail((response) => {
            console.log(response.responseText)
            console.log(typeUser)
            Swal.fire({
                title: "Delete Coupon",
                text: "Error, coupon was NOT deleted",
                icon: "error",
            })
        });

}











