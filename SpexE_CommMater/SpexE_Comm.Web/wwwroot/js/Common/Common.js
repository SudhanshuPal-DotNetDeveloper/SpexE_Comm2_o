function GetCookie(e) {
    for (var t = e + "=", o = decodeURIComponent(document.cookie).split(";"), r = 0; r < o.length; r++) {
        for (var n = o[r]; " " == n.charAt(0);) n = n.substring(1);
        if (0 == n.indexOf(t)) return n.substring(t.length, n.length);
    }
    return "";
}

function numberOnly(input) {
    var regex = /[^0-9]/gi;
    input.value = input.value.replace(regex, "");
}

function ShowSpinner() {
    $("#Spinner").show();
}
function HideSpinner() {
    $("#Spinner").hide();
}