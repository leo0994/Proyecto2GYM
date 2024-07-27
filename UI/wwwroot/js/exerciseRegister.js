const exerciseInsert = (e) => {
    e.preventDefault()
    const exerciseCreate = {}

    exerciseCreate.id = $("#exerciseID").val()
    exerciseCreate.description = $("#description").val()
    exerciseCreate.machineId = $("#machineId").val()
    exerciseCreate.exerciseBaseId = $("#exerciseBaseId").val()
    exerciseCreate.reps = $("#reps").val()
    exerciseCreate.weight = $("#weight").val()
    exerciseCreate.time = $("#time").val()



    console.log(exerciseCreate)

    const apiUrl = API_URL_BASE + "/Exercise/Create"
    $.ajax({
        url: apiUrl,
        method: "POST",
        hasContent: true,
        data: JSON.stringify(exerciseCreate),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
    })
        .done((result) => {
            console.log(result);
            Swal.fire({
                title: "Exercise",
                text: "Exercise Created",
                icon: "success",
            })
        }).fail((response) => {
            console.log(response.responseText)
            Swal.fire({
                title: "Exercise",
                text: "Exercise could not be created",
                icon: "error",
            })
        });
}

$("#exerciseRegisterForm").on('submit', exerciseInsert)
