var rotation = 0;

jQuery.fn.rotate = function (degrees) {
    $(this).css({
        '-webkit-transform': 'rotate(' + degrees + 'deg)',
        '-moz-transform': 'rotate(' + degrees + 'deg)',
        '-ms-transform': 'rotate(' + degrees + 'deg)',
        'transform': 'rotate(' + degrees + 'deg)'
    });
};

$(function () {
    $('.optional').hide();
    $('#grpTransform').hide();
    $('#chkWatermark').change(function () {
        if ($(this).is(":checked"))
            $('#watermarkDiv').show();
        else
            $('#watermarkDiv').hide();
    });
    $('#chkReorder').change(function () {
        if ($(this).is(":checked")) {
            $('#reorderDiv').show();
            $('#rotateDiv').show();
            $('#reorderable').sortable({
                update: function (e, ui) {
                    $('#rotation_container').empty();
                    var guid = $('#hfguid').val();
                    var start = ui.item.attr('id');
                    var newIndex = ui.item.index();

                    var param = ""
                    if ($('input[name="RenderOptions"]:checked').val() == "html")
                        param = 'action=renderashtmlwithreorder&filepath=' + guid + '&start=' + start + '&new=' + newIndex;
                    else
                        param = 'action=renderasimagewithreorder&filepath=' + guid + '&start=' + start + '&new=' + newIndex;

                    Render(param);
                    $('#reorderDiv').show();
                }
            });
            $('#rotation_container').droppable({
                drop: function (event, ui) {
                    var id = ui.draggable.attr('id');
                    $(this).empty();
                    var elem = $('<div id="' + id + '"  >' + id + '</div>');
                    $(this).addClass("ui-state-highlight").append(elem);
                    var rotation = 0;
                    elem.click(function () {
                        if (rotation > 360)
                            rotation = 0;
                        else
                            rotation += 90;

                        $(this).rotate(rotation);
                        var guid = $('#hfguid').val();

                        var param = ""
                        if ($('input[name="RenderOptions"]:checked').val() == "html")
                            param = 'action=renderashtmlwithrotate&filepath=' + guid + '&page=' + $(this).attr('id') + '&angle=' + 90;
                        else
                            param = 'action=renderasimagewithrotate&filepath=' + guid + '&page=' + $(this).attr('id') + '&angle=' + 90;


                        Render(param);
                    });

                }
            });

        } else {
            $('#reorderDiv').hide();
            $('#rotateDiv').hide();
            $('#reorderable').sortable("destroy");
        }
    });

    $('#btnWatermark').click(function (e) {
        reset();
        var guid = $('#hfguid').val();
        var text = $('#txtWatermark').val();

        var param = ""
        if ($('input[name="RenderOptions"]:checked').val() == "html")
            param = 'action=renderashtmlwithwatermark&filepath=' + guid + '&watermark=' + text;
        else
            param = 'action=renderasimagewithwatermark&filepath=' + guid + '&watermark=' + text;


        Render(param);

    });

    $('#btnRender').click(function (e) {
        e.preventDefault();
        reset();
        // Get the file from File upload
        var fileUpload = $("#inputFile").get(0);
        var files = fileUpload.files;
        var test = new FormData();
        for (var i = 0; i < files.length; i++) {
            test.append(files[i].name, files[i]);
        }
        // Post the uploaded file to the http handler 
        $.ajax({
            url: "Controllers/UploadHandler.ashx",
            type: "POST",
            contentType: false,
            processData: false,
            data: test,
            success: function (result) {

                $('#hfguid').val(result);

                var param = ""
                if ($('input[name="RenderOptions"]:checked').val() == "html")
                    param = 'action=renderashtml&filepath=' + result;
                else
                    param = 'action=renderasimage&filepath=' + result;


                Render(param);
            },
            error: function (err) {
                if (err.status == 422)
                    alert('Please upload a valid file');
                else
                    alert(err.statusText);
            }
        });
    });
})



function Render(param) {

    // make an ajax request to retrieve convert and retrieve the HTML text of uploaded word document.
    $.ajax({
        url: "Controllers/MainHandler.ashx",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        data: param,
        responseType: "json",
        beforeSend: onProgress,
        success: GenerateHtml,
        complete: onComplete,
        error: onFail
    });

    return false;
}

function onProgress() {

    $('.viewer').text('Working.......');
}
function GenerateHtml(result) {
    // in a case of success the returned result would be written in the result box
    $('.viewer').text('');
    $('#reorderable').empty();
   
    $(result).each(function (page) {

        $('.viewer').append(this.HtmlContent);
        $('#reorderable').append('<li id="' + this.PageNmber + '" >' + this.PageNmber + '</li>');
       

    });


}
function onComplete() {
    $('#grpTransform').show();
    alert('Working Complete');
}
function onFail(err) {

    $('#viewer').text(err.statusText);
}
function reset() {
    $('#grpTransform').hide();
    $('.optional').hide();
    $('#chkWatermark').prop('checked', false);
    $('#chkReorder').prop('checked', false);
    $('#rotation_container').empty();
}