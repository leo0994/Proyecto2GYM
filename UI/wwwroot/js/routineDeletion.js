const routineDeletion = (e) => {
    e.preventDefault()
    const routineDelete = {}

    routineDelete.id = $("#routineID").val()



    const apiUrl = API_URL_BASE + "/Routine/Delete"
    $.ajax({
        url: apiUrl,
        method: "DELETE",
        hasContent: true,
        data: JSON.stringify(routineDelete),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
    })
        .done((result) => {
            console.log(result);
            Swal.fire({
                title: "Routine Deletion",
                text: "Routine Deleted",
                icon: "success",
            })
        }).fail((response) => {
            console.log(response.responseText)
            Swal.fire({
                title: "Routine Deletion",
                text: "Routine could not be Deleted",
                icon: "error",
            })
        });
}

$("#deleteRoutineForm").on('submit', routineDeletion)



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

