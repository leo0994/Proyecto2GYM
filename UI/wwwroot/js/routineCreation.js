const routineCreation = (e) => {
    e.preventDefault()
    const routineCreate = {}




    routineCreate.id = 0
    routineCreate.userId = $("#clientID").val()
    routineCreate.creatorId = $("#trainerID").val()
    console.log(routineCreate)

    const apiUrl = API_URL_BASE + "/Routine/Create"
    $.ajax({
        url: apiUrl,
        method: "POST",
        hasContent: true,
        data: JSON.stringify(routineCreate),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
    })
        .done((result) => {
            console.log(result);
            Swal.fire({
                title: "Routine",
                text: "Routine Created",
                icon: "success",
            })
        }).fail((response) => {
            console.log(response.responseText)
            Swal.fire({
                title: "Routine",
                text: "Routine could not be created",
                icon: "error",
            })
        });
}

$("#createRoutineForm").on('submit', routineCreation)
