const exerciseUpdate = (e) => {
    e.preventDefault()
    const exerciseUpdate = {}

    exerciseUpdate.id = $("#exerciseID").val()
    exerciseUpdate.description = $("#description").val()
    exerciseUpdate.machineId = $("#machineId").val()
    exerciseUpdate.exerciseBaseId = $("#exerciseBaseId").val()
    exerciseUpdate.reps = $("#reps").val()
    exerciseUpdate.weight = $("#weight").val()
    exerciseUpdate.time = $("#time").val()



    console.log(exerciseUpdate)

    const apiUrl = API_URL_BASE + "/Exercise/Update"
    $.ajax({
        url: apiUrl,
        method: "PUT",
        hasContent: true,
        data: JSON.stringify(exerciseUpdate),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
    })
        .done((result) => {
            console.log(result);
            Swal.fire({
                title: "Exercise",
                text: "Exercise Updated",
                icon: "success",
            })
        }).fail((response) => {
            console.log(response.responseText)
            Swal.fire({
                title: "Exercise",
                text: "Exercise could not be updated",
                icon: "error",
            })
        });
}

$("#exerciseUpdateForm").on('submit', exerciseUpdate)




let table = $('#exerciseTable').DataTable({
    data: [],
    columns: [
        { data: 'id' },
        { data: 'description' },
        { data: 'machineId' },
        { data: 'exerciseBaseId' },    
        { data: 'reps' },
        { data: 'weight' },
        { data: 'time' },
    
    ]
});

const capitalize = (word) => {
    return word.charAt(0).toUpperCase() + word.slice(1)
}

const prepareTableData = (result) => {
    table.clear().rows.add(result).draw();
}

$(document).ready(() => {
    const apiUrl = API_URL_BASE + "/Exercise/RetrieveAll"
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

