var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/phonelog/getall' },
        "columns": [
            { data: 'id', "width": "10%" },
            { data: 'agent', "width": "10%" },
            { data: 'allocatedDate', "width": "10%" },
            { data: 'dateDue', "width": "10%" },
            { data: 'dateCompleted', "width": "10%" },
            { data: 'internal', "width": "10%" },
            { data: 'products.name', "width": "10%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                       <a href="/admin/phonelog/EditPhone?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Edit</a>
                    </div >`
                }
                , "width": "25%"
            }

        ]
    });
}



