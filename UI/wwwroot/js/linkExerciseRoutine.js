const linkExerciseRoutine = (e) => {
    e.preventDefault()
    const linkExercise = {}




    //linkExercise.id = 0
    linkExercise.IdRoutine = $("#routineID").val()
    linkExercise.IdExercise = $("#exerciseID").val()
    console.log(linkExercise)

    const apiUrl = API_URL_BASE + "/ExerciseRoutine/Create"
    $.ajax({
        url: apiUrl,
        method: "POST",
        hasContent: true,
        data: JSON.stringify(linkExercise),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
    })
        .done((result) => {
            console.log(result);
            Swal.fire({
                title: "Routine",
                text: "Exercise added to Routine",
                icon: "success",
            })
        }).fail((response) => {
            console.log(response.responseText)
            Swal.fire({
                title: "Routine",
                text: "Exercise could not be added to Routine",
                icon: "error",
            })
        });
}

$("#linkRoutineForm").on('submit', linkExerciseRoutine)





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

