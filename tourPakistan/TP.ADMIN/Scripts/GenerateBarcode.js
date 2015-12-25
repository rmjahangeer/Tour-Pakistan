function newbarcode() {
        var date = new Date();
        var components = [
            date.getUTCFullYear(),
            date.getUTCMonth()+1,
            date.getUTCDate(),
            date.getUTCHours(),
            date.getUTCMinutes(),
            date.getUTCSeconds(),
            date.getUTCMilliseconds()
        ];

        var id = components.join("");
        return id;
}

function generateBarcode(value, name) {
    if (value == "null") {
        value = "0";
        $("#barcodeTarget").empty();
        $("#ProductName").empty();
        $("#CountOfPrint").val("1");
        $("#CountDiv").css("display", "none");
    } else {

        $("#CountDiv").css("display", "block");
        var btype = "ean13";

        var settings = {
            bgColor: "#FFFFFF",
            color: "#000000",
            barWidth: "2",
            barHeight: "80",
        };
        $("#barcodeDivs").show();
        $("#barcodeTarget").html("").show().barcode(value, btype, settings);
        $("#ProductName").text(name);
    }
}