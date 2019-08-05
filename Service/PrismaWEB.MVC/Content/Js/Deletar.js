function abrirModalDeletar(data, nomeItem) {
    console.log(nomeItem);
    $('#ModalDelete').data('iddado', data.id)
    $('#ModalDelete').modal('show');
    if (nomeItem == undefined) 
        $('#msgDeletar').text("Você realmente deseja deletar?")
     else
        $('#msgDeletar').text("Vece realmente deseja deletar: " + nomeItem + "?")
}

function DeletarItem(url, tokenAnt) {
    var id = $('#ModalDelete').data('iddado');
    AjaxDeletar(url, id, tokenAnt);
}

function AjaxDeletar(Url, Id) {

    $.ajax({
        url: Url + "/" + Id,
        type: 'POST',
        data: { __RequestVerificationToken: gettoken()}
    }).done(function (data) {
        console.log(data);
        if (data == "404") {
            $('#' + Id).parent().parent().remove()
            $('#ModalDelete').modal('hide');
        }
        else {
            $('#msgDeletar').text('Erro ao deletar: ' + data);
        }
    });
}