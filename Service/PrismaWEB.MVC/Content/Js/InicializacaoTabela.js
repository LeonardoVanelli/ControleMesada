$(document).ready(function () {
    //Table
    $("#dataTable").DataTable({
        "language": {
            "sEmptyTable": "Nenhum registro encontrado",
            "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
            "sInfoFiltered": "(Filtrados de _MAX_ registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "_MENU_ resultados por página",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Próximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Último"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        }
    });
    //ComboBox
    $('.ui.dropdown').dropdown();
    //Masc
    $("#telefone").inputmask("mask", { "mask": "(99) 9999-99999" });
    $("#Cpf").inputmask("mask", { "mask": "999.999.999-99", removeMaskOnSubmit: true }, { reverse: true });
    $("#Cep").inputmask("mask", { "mask": "99999-999", removeMaskOnSubmit: true });
    $("#TelefoneFixo").inputmask("mask", { "mask": "(99)9999-9999", removeMaskOnSubmit: true });
    $("#TelefoneMovel").inputmask("mask", { "mask": "(99)9999-9999[9]", removeMaskOnSubmit: true });
    $("#Numero").inputmask("mask", { "mask": "99999", removeMaskOnSubmit: true });
    $("#nascimento").inputmask("mask", { "mask": "99/99/9999" });
    $("#preco").inputmask("mask", { "mask": "999.999,99" }, { reverse: true });
    $("#valor").inputmask("mask", { "mask": "#.##9,99" }, { reverse: true });
    $("#ip").inputmask("mask", { "mask": "999.999.999.999" });
});