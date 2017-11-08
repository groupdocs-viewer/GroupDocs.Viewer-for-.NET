///// ***************************************************** //////
///// DYNAMIC CONFIGURATIONS PARAMETERS WITH DEFAULT VALUES
///// ***************************************************** //////

// All veriables are utilized in Index.cshtml & app.js files.

var DefaultFilePath = '';
var isImageToggle = false;
var RotateAngel = 0;
var ZoomValue = 100;
var WatermarkText = "Watermark Text";
var WatermarkColor = 16711680;
var WatermarkPosition = "Diagonal";
var WatermarkWidth = null;
var WatermarkOpacity = 255;
var ShowWatermark = true;
var ShowImageToggle = true;
var ShowZoomIn = true;
var ShowZoomOut = true;
var ShowRotateImage = true;
var ShowPreviousDocument = true;
var ShowNextDocument = true;
var ShowDownload = true;
var ShowPDFDownload = true;
var ShowFileSelection = true;
var ShowThubmnailPanel = true;

function resizeIFrame() {
    ZoomValue = (ZoomValue > 10 ? ZoomValue / 100 : ZoomValue);
    ZoomValue = (ZoomValue <= 0.05 ? 0.05 : ZoomValue);
    ZoomValue = (ZoomValue >= 6 ? 6 : ZoomValue);
    //alert("isImageToggle:  " + isImageToggle);
    //alert("zoomvalue:  " + ZoomValue);
    var mdcards = document.querySelectorAll("md-card");
    var iframes = document.querySelectorAll("iframe");

    for (var i = 0; i < iframes.length; i++) {
        var body = iframes[i].contentWindow.document.body,
        html = iframes[i].contentWindow.document.documentElement,
        height = Math.max(
            body.scrollHeight,
            body.offsetHeight,
            html.clientHeight,
            html.scrollHeight,
            html.offsetHeight
        ),
        width = Math.max(
            body.scrollWidth,
            body.offsetWidth,
            html.clientWidth,
            html.scrollWidth,
            html.offsetWidth
        );


        if (isImageToggle) {
            iframes[i].contentWindow.document.body.style = "text-align: center !important;";
        }
        //alert("i: " + i + "  Height: " + height + "  multi height: " + (height * (ZoomValue < 1 ? 1 : ZoomValue)));
        iframes[i].style = "height:" + parseInt(height) + "px!important; width:100%!important; ";
        height = parseInt(height) + 10;
        height = (height * (parseFloat(ZoomValue) < 1 ? 1 : parseFloat(ZoomValue)));
        height = parseInt(height);
        //alert("i: " + i + "  Height: " + height + "  multi height: " + (height * (ZoomValue < 1 ? 1 : ZoomValue)));
        //mdcards[i].style = "height:" + (height * ZoomValue) + "px !important; width:100%!important; overflow: visible !important;";
        if (ZoomValue > 1) {
            mdcards[i].style = "zoom: " + ZoomValue + "; -moz-transform: scale(" + ZoomValue + "); -moz-transform-origin: 0 0; -o-transform: scale(" + ZoomValue + "); -o-transform-origin: 0 0; -webkit-transform: scale(" + ZoomValue + "); -webkit-transform-origin: 0 0; height:" + height + "px !important; width:100%!important; overflow: visible !important;";
        }
        else {
            mdcards[i].style = "zoom: " + ZoomValue + "; -moz-transform: scale(" + ZoomValue + "); -o-transform: scale(" + ZoomValue + "); -webkit-transform: scale(" + ZoomValue + "); height:" + height + "px !important; width:100%!important; overflow: visible !important;";
        }
    }
}