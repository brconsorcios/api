$(function () {

    $('#swfupload-control').swfupload({
        upload_url: "/inside/fotos/AjaxUpload/",
        //file_post_name: 'uploadfile',
        post_params: {"id": "" + $("#id").val() + ""},
        file_size_limit: "1024",
        file_types: "*.jpg",
        file_types_description: "Image files",
        file_upload_limit: 30,
        flash_url: "/Content/expadm/SWFUpload/swfupload/swfupload.swf",
        button_image_url: '/Content/expadm/SWFUpload/swfupload/wdp_buttons_upload_114x29.png',
        button_width: 114,
        button_height: 29,
        button_placeholder: $('#button')[0],
        debug: false
    })
        .bind('fileQueued', function (event, file) {
            var listitem = '<li id="' + file.id + '" >' +
                'File: <em>' + file.name + '</em> (' + Math.round(file.size / 1024) + ' KB) <span class="progressvalue" ></span>' +
                '<div class="progressbar" ><div class="progress" ></div></div>' +
                '<p class="status" >Pending</p>' +
                '<span class="cancel" >&nbsp;</span>' +
                '</li>';
            $('#log').append(listitem);
            $('li#' + file.id + ' .cancel').bind('click', function () {
                var swfu = $.swfupload.getInstance('#swfupload-control');
                swfu.cancelUpload(file.id);
                $('li#' + file.id).slideUp('fast');

            });
            // start the upload since it's queued
            $(this).swfupload('startUpload');
        })
        .bind('fileQueueError', function (event, file, errorCode, message) {
            alert('Size of the file ' + file.name + ' is greater than limit');
        })
        .bind('fileDialogComplete', function (event, numFilesSelected, numFilesQueued) {
            $('#queuestatus').text('Files Selected: ' + numFilesSelected + ' / Queued Files: ' + numFilesQueued);
        })
        .bind('uploadStart', function (event, file) {
            $('#log li#' + file.id).find('p.status').text('Uploading...');
            $('#log li#' + file.id).find('span.progressvalue').text('0%');
            $('#log li#' + file.id).find('span.cancel').hide();
            $('#ajax-panel').fadeIn();
        })
        .bind('uploadProgress', function (event, file, bytesLoaded) {
            //Show Progress
            var percentage = Math.round((bytesLoaded / file.size) * 100);
            $('#log li#' + file.id).find('div.progress').css('width', percentage + '%');
            $('#log li#' + file.id).find('span.progressvalue').text(percentage + '%');
        })
        .bind('uploadSuccess', function (event, file, serverData) {
            var item = $('#log li#' + file.id);
            item.find('div.progress').css('width', '100%');
            item.find('span.progressvalue').text('100%');
            //var pathtofile = '<a href="uploads/' + file.name + '" target="_blank" >view &raquo;</a>';
            var pathtofile = '';
            item.addClass('success').find('p.status').html('Completo!!! | ' + pathtofile);
        })
        .bind('uploadComplete', function (event, file) {
            // upload has completed, try the next one in the queue

            $.get("/inside/fotos/ajaxAnexosAlbum", {id: "" + $("#id").val() + ""}, function (html) {

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

            });

            $('#ajax-panel').hide();
            $(this).swfupload('startUpload');
        })
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
                $.post("/inside/fotos/FotosSortOrder", {itemIdQueryString: $(this).sortable("serialize")});
            }
        });
});