
let table = ('#subscriptionTable').DataTable({
    data: [],
    columns: [
        { data: 'name' },
        { data: 'email' },
        { data: 'date' },
        { data: 'status' }
    ]
});

const capitalize = (word) => {
    return word.charAt(0).toUpperCase() + word.slice(1)
}

const prepareTableData = (result) => {
    table.clear().rows.add(result).draw();
}

$(document).ready(() => {
    let apiUrl = API_URL_BASE + "/Subscription/RetrieveAll";
    $.ajax({
        url: apiUrl,
    })
        .done((result) => {
            prepareTableData(result)
        })
        .fail((error) => {
            Swal.fire({
                title: "Mensaje",
                text: "There was an error with the search: " + error,
                icon: "error",
            });
        });
})