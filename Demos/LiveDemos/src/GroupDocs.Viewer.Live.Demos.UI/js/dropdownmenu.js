
function searchMenuClick2() {
    document.getElementById("searchDropdown2").classList.toggle("show");
    $("#searchMenuText2").focus();
}

function filterDropdown2() {

    $(".types li").removeClass("current");
    $(".formats-inner li").hide();

    var filter = document.getElementById("searchMenuText2").value.toUpperCase();
    if (filter.length > 0) {
        $(".formats-inner li:contains('" + filter + "')").show();
    }
}

$(document).on('click', 'body *', function () {
    if (document.getElementById("searchDropdown2") != null && document.getElementById("searchDropdown2").classList.value.endsWith("show")) {
        document.getElementById("searchDropdown2").classList.remove("show");
    }
});