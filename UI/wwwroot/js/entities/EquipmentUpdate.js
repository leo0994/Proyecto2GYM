$(document).ready(function () {
    var urlParams = new URLSearchParams(window.location.search);
    console.log(urlParams.get('id'));

    const apiUrlUpdate = API_URL_BASE + "/Machine/Update";
    const apiUrlGetById = API_URL_BASE + "/Machine/RetrieveById/" + urlParams.get('id');

    $.ajax({
        url: apiUrlGetById,
        method: "GET",
        hasContent: true,
        contentType: "application/json;charset=utf-8",
        dataType: "json",
    })
        .done((result) => {
            console.log(result); 
            $('#idMachine').val(result.id)
            $('#name').val(result.name)
            $('#description').val(result.description)
        }).fail((response) => {
            console.log(response.responseText)
            Swal.fire({
                title: "Equipment",
                text: "Information retrieved unsuccessfully",
                icon: "error",
            })
        });

    $("#btnUpdate").click(function (e) {
        e.preventDefault();

        var idMachine = $('#idMachine').val()
        var name = $('#name').val()
        var description = $('#description').val()

        const apiUrl = API_URL_BASE_NORMAL + "/EquipmentAdmin/Equipment";

        $.ajax({
            url: API_URL_BASE + "/Machine/Update",
            method: "PUT",
            hasContent: true,
            data: JSON.stringify({ 'id': idMachine, 'name': name, 'description': description }),
            contentType: "application/json;charset=utf-8",
            dataType: "json",
        })
            .done((result) => {
                console.log(result);
                Swal.fire({
                    title: "Equipment",
                    text: "Equipment was updated sucessfully",
                    icon: "success",
                }).then(function () {
                    window.location.href = apiUrl;
                });
            }).fail((response) => {
                console.log(response.responseText)
                Swal.fire({
                    title: "Equipment",
                    text: "Equipment updated unsuccessfully",
                    icon: "error",
                })
            });

    });

});