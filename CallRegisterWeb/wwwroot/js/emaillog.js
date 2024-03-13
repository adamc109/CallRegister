var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/user/emaillog/getall' },
        "columns": [
            { data: 'id', "width": "15%" },
            { data: 'agent', "width": "15%" },
            { data: 'allocatedDate', "width": "15%" },
            { data: 'dateDue', "width": "15%" },
            { data: 'dateCompleted', "width": "15%" },
            { data: 'internal', "width": "15%" },
            { data: 'products.name', "width": "15%" }

        ]
    });
}



