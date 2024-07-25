const unlinkExerciseRoutine = (e) => {
    e.preventDefault()
    const unlinkExercise = {}




    unlinkExercise.id = $("#routineID").val()
    unlinkExercise.IdRoutine = 0
    unlinkExercise.IdExercise = 0
    console.log(unlinkExercise)

    const apiUrl = API_URL_BASE + "/ExerciseRoutine/DELETE"
    $.ajax({
        url: apiUrl,
        method: "DELETE",
        hasContent: true,
        data: JSON.stringify(unlinkExercise),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
    })
        .done((result) => {
            console.log(result);
            Swal.fire({
                title: "Update",
                text: "Exercise removed to Routine",
                icon: "success",
            })
        }).fail((response) => {
            console.log(response.responseText)
            Swal.fire({
                title: "Error",
                text: "Exercise could not be removed from Routine",
                icon: "error",
            })
        });
}

$("#unlinkRoutineForm").on('submit', unlinkExerciseRoutine)





let table = $('#ExerciseRoutine').DataTable({
    data: [],
    columns: [
        { data: 'id' },
        { data: 'idRoutine' },
        { data: 'idExercise' },
    
    ]
});

const capitalize = (word) => {
    return word.charAt(0).toUpperCase() + word.slice(1)
}

const prepareTableData = (result) => {
    table.clear().rows.add(result).draw();
}

$(document).ready(() => {
    const apiUrl = API_URL_BASE + "/ExerciseRoutine/RetrieveAll"
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

