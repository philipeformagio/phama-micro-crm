var dataTable;

$(document).ready(function () {

    loadDataTable();

});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/Companies/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "20%" },
            { "data": "field", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/detalhes-empresa/${data}" class="btn btn-success text-white" style="cursor:pointer; width:87px;">
                                    Visualizar
                                </a>
                                &nbsp;
                                <a href="/editar-empresa/${data}" class="btn btn-success text-white" style="cursor:pointer; width:70px;">
                                    Editar
                                </a>
                                &nbsp;
                                <a class="btn btn-danger text-white" style="cursor:pointer; width:75px;" onclick="Delete('/deletar-empresa/${data}')">
                                    Deletar
                                </a>
                            <div>`;
                }, "width": "40%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
};

function Delete(url) {
    swal({
        title: "Deseja deletar?",
        text: "Once deleted, you will not be able to recover",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {

        var t = $("input[name='__RequestVerificationToken']").val();

        if (willDelete) {
            $.ajax({
                type: "DELETE",
                headers:
                {
                    "RequestVerificationToken": t
                },
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}