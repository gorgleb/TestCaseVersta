var dataTable;
$(document).ready(function () {
    loadDataTable();
});
function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Order/GetAll"
        },
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "number", "width": "25%" },
            { "data": "sendersCity", "width": "15%" },
            { "data": "sendersAdress", "width": "15%" },
            { "data": "recipientsCity", "width": "15%" },
            { "data": "recipientsAdress", "width": "15%" },
            { "data": "cargoWeight", "width": "15%" },
            { "data": "pickupDate", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                       <div class="w-75 h-75 btn-group" role="group">
                        <a href="/Order/Upsert?id=${data}"
                        class="btn btn-primary mx-2" ><i class="bi bi-pencil-square"></i></a>
                    </div>
                     `
                },
                "width": "15%"
            },
            {
                "data": "id",
                "render": function (data) {
                    return `
                       <div class="w-75 h-75 btn-group" role="group">
                        <a href="/Order/Delete?id=${data}"
                        class="btn btn-primary mx-2" ><i class="bi bi-trash"></i></a>
                    </div>
                     `
                },
                "width": "15%"
            },



        ]
    });
}