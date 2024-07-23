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

$("#linkRoutineForm").on('submit', linkExerciseRoutine)
