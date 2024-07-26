// Function to create equipment

const apiUrlView = API_URL_BASE_NORMAL + "/EquipmentAdmin/Update"

const createEquipment = (e) => {
    e.preventDefault();
    const equipment = {
        name: $("#name").val(),
        description: $("#description").val()
    };

    const apiUrl = API_URL_BASE + "/Machine/Create";

    $.ajax({
        url: apiUrl,
        method: "POST",
        hasContent: true,
        data: JSON.stringify(equipment),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
    })
        .done((result) => {
            console.log(result);
            Swal.fire({
                title: "Equipment",
                text: "Equipment created successfully",
                icon: "success",
            }).then(() => {
                window.location.reload();
            });

        }).fail((response) => {
            console.log(response);
            Swal.fire({
                title: "Equipment",
                text: "Equipment creation unsuccessful",
                icon: "error",
            });
        });
}

// Attach event handler to form submit
$("#createEquipmentForm").on('submit', createEquipment);

// Function to delete equipment
function Delete(id)
{
    const apiUrl = API_URL_BASE + "/Machine/Delete/" + id;

    $.ajax({
        url: apiUrl,
        method: "DELETE",
        hasContent: true,
        contentType: "application/json;charset=utf-8",
        dataType: "json",
    })
        .done((result) => {
            console.log(result);
            Swal.fire({
                title: "Equipment",
                text: "Equipment was deleted successfully",
                icon: "success",
            }).then(() => {
                location.reload();
            });

        }).fail((response) => {
            console.log(response.responseText);
            Swal.fire({
                title: "Equipment",
                text: "Error, equipment wasn't deleted",
                icon: "error",
            });
        });
}

// Initialize DataTable
let table = $('#equipmentTable').DataTable({
    data: [],
    columns: [
        { data: 'name' },
        { data: 'description' },
        {
            data: 'id', render: function (data, type, row) {
                return '<a href="' + apiUrlView + "?id=" + row.id + '" target="_self"><img src="../img/botonActualizar.png" alt="Update" width="20px" height="20px" />';
            }
        },
        {
            data: 'id', render: function (data, type, row) {
                return '<button onclick="return Delete(' + row.id + ')"><img src="../img/botonEliminar.png" alt="Delete" width="20px" height="20px" /></button>';
            }
        }
    ]
});

// Function to capitalize words
const capitalize = (word) => {
    return word.charAt(0).toUpperCase() + word.slice(1);
}

// Function to prepare and load table data
const prepareTableData = (result) => {
    table.clear().rows.add(result).draw();
}

// Document ready function
$(document).ready(() => {
    const apiUrl = API_URL_BASE + "/Machine/RetrieveAll";
    $.ajax({
        url: apiUrl,
    })
        .done((result) => {
            prepareTableData(result);
        })
        .fail((error) => {
            Swal.fire({
                title: "Mensaje",
                text: "There was an error with the search: " + error,
                icon: "error",
            });
        });
});
