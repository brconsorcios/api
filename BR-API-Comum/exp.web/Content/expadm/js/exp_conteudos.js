// JavaScript Document
$(function () {

    var name = "";
    var size = "";
    var type = "";

    $(':file').change(function () {
        var file = this.files[0];
        name = file.name;
        size = file.size;
        type = file.type;
        $("#det").html("NAME: " + name + " - SIZE: " + size + " - TYPE: " + type);
        //your validation
    });

    //alert(acaoconteudo);

    $('#fileupload').click(function () {

        //alert("NAME: " + name + " - SIZE: " + size + " - TYPE: " + type);


        if (name.length < 1) {

        } else if (size > 50000000) {
            jAlert('O Arquivo <b>' + name + '</b> � muito grande!');

        } else if (type != 'application/msword' && type != 'application/vnd.xls' && type != 'application/vnd.ms-excel' && type != 'application/pdf' && type != 'image/png' && type != 'image/jpg' && !type != 'image/gif' && type != 'image/jpeg') {
            jAlert('O arquivo <b>' + name + '</b> n�o est� em um formato aceito!<br /> Os formatos aceitos s�o: JPG, GIF, PNG, ZIP, DOC, XLS e PDF!');
        } else {


            var formData = new FormData($('form')[0]);
            $("#data").html(formData);
            $.ajax({
                url: '/restrito/inside/' + acaoconteudo + '/ajaxarquivos/?rnd=' + Math.random() + 300 % 2, //server script to process data
                type: 'POST',
                //Ajax events
                beforeSend: function () {
                    $('#ajax-panel').fadeIn();
                },
                success: function (html) {
                    $('#ajax-panel').hide();
                    $(".itemList").html(html);
                    //ativando os botoes
                    $(".pics ul li").hover(
                        function () {
                            $(this).children(".actions").show("fade", 200);
                        },
                        function () {
                            $(this).children(".actions").hide("fade", 200);
                        }
                    );
                    $.jGrowl("Arquivo enviado com sucesso!");
                },
                error: function (html) {
                    //$("#mess").html(html);
                    $.jGrowl(html);
                },
                enctype: 'multipart/form-data',
                // Form data
                data: formData,
                //Options to tell JQuery not to process data or worry about content-type
                cache: false,
                contentType: false,
                processData: false
            });

        }
    });
});

$(".itemList").sortable(
    {
        connectWith: ".itemList",
        containment: "document",
        cursor: "move",
        opacity: 0.8,
        placeholder: "itemRowPlaceholder",
        //update event fires both for item list leaving and receiving
        update: function (event, ui) {
            //Extract section id from parent section box
            $.post("/restrito/inside/" + acaoconteudo + "/AnexoUpdateSortOrder", {itemIdQueryString: $(this).sortable("serialize")});
        }
    });


//=====apagar registro com ajax =====//
var Delete = function (acao, cod, id) {
    jConfirm('Voc� realmente deseja apagar?', 'Confirma��o', function (r) {
        if (r) {
            $.post(acao + "?rnd=" + Math.random() + 300 % 2, {id: "" + cod + ""},
                function (data) {
                    if (data == "apagado") {
                        $("#" + id).fadeOut();
                        $.jGrowl("Apagado com sucesso!");
                    } else {
                        $.jGrowl("N�o foi poss�vel apagar!");
                    }

                });
        }
    });
};
var IntertImgPequena = function (img, id) {
    // $('.wysiwyg').wysiwyg('insertHtml', '<div class=\"wysiwygImgPequena\"><img src=\"' + img + '\"></div>');
    $('#' + id).tinymce().execCommand('mceInsertContent', false, '<div class=\"wysiwygImgPequena\"><img src=\"' + img + '\"></div>');
    $.jGrowl('Imagem pequena enviada para o Editor com sucesso!');
}
var IntertImgGrande = function (img, id) {
    //$('.wysiwyg').wysiwyg('insertHtml', '<div class=\"wysiwygImgGrande\"><img src=\"' + img + '\" ></div>');
    $('#' + id).tinymce().execCommand('mceInsertContent', false, '<div class=\"wysiwygImgGrande\"><img src=\"' + img + '\"></div>');
    $.jGrowl('Imagem grande enviada para o Editor com sucesso!');
}

var IntertImgAnexo = function (anexo, file, id) {
    $('#' + id).tinymce().execCommand('mceInsertContent', false, '<a href=\"' + anexo + '\">' + file + '</div>');
    // $('.wysiwyg').wysiwyg('insertHtml', '<a href=\"' + anexo + '\">' + file + '</div>');
    $.jGrowl('Arquivo enviado para o Editor com sucesso!');
};
