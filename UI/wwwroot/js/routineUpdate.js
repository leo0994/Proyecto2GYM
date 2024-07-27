const routineUpdate = (e) => {
    e.preventDefault()
    const routineUpdate = {}

    routineUpdate.id = $("#routineID").val()
    routineUpdate.userId = $("#clientID").val()
    routineUpdate.creatorId = $("#trainerID").val()
    console.log(routineUpdate)

    const apiUrl = API_URL_BASE + "/Routine/Update"
    $.ajax({
        url: apiUrl,
        method: "PUT",
        hasContent: true,
        data: JSON.stringify(routineUpdate),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
    })
        .done((result) => {
            console.log(result);
            Swal.fire({
                title: "Routine",
                text: "Routine Updated",
                icon: "success",
            })
        }).fail((response) => {
            console.log(response.responseText)
            Swal.fire({
                title: "Routine",
                text: "Routine could not be updated",
                icon: "error",
            })
        });
}

$("#updateRoutineForm").on('submit', routineUpdate)


let table = $('#routineTable').DataTable({
    data: [],
    columns: [
        { data: 'id' },
        { data: 'userId' },
        { data: 'creatorId' },
    ]
});

const capitalize = (word) => {
    return word.charAt(0).toUpperCase() + word.slice(1)
}

const prepareTableData = (result) => {
    table.clear().rows.add(result).draw();
}

$(document).ready(() => {
    const apiUrl = API_URL_BASE + "/Routine/RetrieveAll"
    $.ajax({
        url: apiUrl,
    })
        .done((result) => {
            prepareTableData(result)
        })
        .fail((error) => {
            Swal.fire({
                title: "Mensaje",
                text: "There was an error uploading date to table: " + error,
                icon: "error",
            });
        });
}
)



