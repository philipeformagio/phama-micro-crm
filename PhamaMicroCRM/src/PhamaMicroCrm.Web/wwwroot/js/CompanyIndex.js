var dataTable;

$(document).ready(function () {

    loadDataTable();
    SetModal();

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
                                <a href="/detalhes-empresa/${data}" class="btn btn-info text-white" style="cursor:pointer;">
                                    <spam class="fa fa-search"></spam>
                                </a>
                                &nbsp;
                                <a href="/editar-empresa/${data}" class="btn btn-warning" style="cursor:pointer;">
                                    <spam class="fa fa-pencil-alt"></spam>
                                </a>
                                &nbsp;
                                <a class="btn btn-danger" style="cursor:pointer;" onclick="Delete('/deletar-empresa/${data}')">
                                    <spam class="fa fa-trash"></spam>
                                </a>
                            <div>`;
                }, "width": "40%"
            }
        ],
        "language": {
            "decimal": ",",
            "emptyTable": "Nenhum dado encontrado",
            "search": "Pesquisar:",
            "paginate": {
                "first": "Primeiro",
                "previous": "Anterior",
                "next": "Próximo",
                "last": "Ultimo"
            },
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