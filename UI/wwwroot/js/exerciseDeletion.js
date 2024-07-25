const exerciseDeletion = (e) => {
    e.preventDefault()
    const exerciseDelete = {}

    exerciseDelete.id = $("#exerciseID").val()
    exerciseDelete.description = ""
    exerciseDelete.machine_id = 0
    exerciseDelete.exerciseBase_id = 0
    exerciseDelete.reps = 0
    exerciseDelete.weight = 0
    exerciseDelete.time = 0




    const apiUrl = API_URL_BASE + "/Exercise/Delete"
    $.ajax({
        url: apiUrl,
        method: "DELETE",
        hasContent: true,
        data: JSON.stringify(exerciseDelete),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
    })
        .done((result) => {
            console.log(result);
            Swal.fire({
                title: "Exercise Deletion",
                text: "Exercise Deleted",
                icon: "success",
            })
        }).fail((response) => {
            console.log(response.responseText)
            Swal.fire({
                title: "Exercise Deletion",
                text: "Exercise could not be Deleted",
                icon: "error",
            })
        });
}

$("#deleteExerciseForm").on('submit', exerciseDeletion)




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

