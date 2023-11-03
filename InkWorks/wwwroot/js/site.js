
    function inicializarDataTable(selector) {
        $(selector).DataTable({
            language: {
                "decimal": "",
                "emptyTable": "Sem dados disponíveis",
                "info": "Mostrando de _START_ a _END_ de um total de _TOTAL_ entradas",
                "infoEmpty": "Mostrando 0 de 0 de um total de 0 entradas",
                "infoFiltered": "(filtrado de um total de _MAX_ entradas)",
                "infoPostFix": "",
                "thousands": ",",
                "lengthMenu": "Mostrar _MENU_ entradas",
                "loadingRecords": "A carregar...",
                "processing": "",
                "search": "Procurar:",
                "zeroRecords": "Não foram encontrados registos correspondentes",
                "paginate": {
                    "first": "Primeira",
                    "last": "Última",
                    "next": "Próxima",
                    "previous": "Anterior"
                },
                "aria": {
                    "sortAscending": ": ativar para ordenar a coluna de forma ascendente",
                    "sortDescending": ": ativar para ordenar a coluna de forma descendente"
                }
            }
        });
    }

$(document).ready(function () {
    inicializarDataTable('#Clientes');
    inicializarDataTable('#Trabalhos');
    inicializarDataTable('#Utilizadores');
  
});
