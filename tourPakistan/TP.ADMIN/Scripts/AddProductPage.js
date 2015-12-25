$('#ProductItemAddBtn').on("click", function () {
    //validate fields
    if (!(ValidateFieldsByClass("mandatoryModal"))) {
        return false;
    }
    var itemBarcode = $("#Barcode").val();
    var itemUnitId = $("#UnitId").val();
    var itemUnitTitle = $("#UnitId option:selected").text().toLowerCase().indexOf("select") >= 0 ? "" : $("#UnitId option:selected").text();
    var itemShelfTitle = $("#ShelfId option:selected").text().toLowerCase().indexOf("select") >= 0 ? "" : $("#ShelfId option:selected").text();
    var itemShelfId = $("#ShelfId").val();
    var itemMinStockLevel = $("#MinStockLevel").val();
    var itemDescription = $("#ItemDescription").val();

    var itemRowIndex = $("#itemRowIndex").val();
    var index = $("#ProductVariationTableBody").children("tr").length;
    var productId = $("#ProductModel_ProductId").val();
    if (itemRowIndex == "") {
    //    //add new row

        if ($("#ProductVariationTableBody").children("tr").children("td").html() == "No data available in table") {
            index = index - 1;
            $("#ProductVariationTableBody").children("tr").remove();
        }
        var indexCell = "<td style='display:none'>" +
            "<input name='ProductVariations.Index' type='hidden' value='" + index + "' />" +
            "<input name='ProductVariations[" + index + "].ProductId' id='ProductVariations_" + index + "__ProductId' type='hidden'  value='" + productId + "'/>" +
            "<input name='ProductVariations[" + index + "].ProductVariationId' id='ProductVariations_" + index + "__ProductVariationId' type='hidden' />" +
            "</td>";

        //ProductVariations
        var html = ' <tr data-id=' + index + '>' +
            indexCell +
            '<td>' +
            '<input id="ProductVariations_' + index + '__Barcode" name="ProductVariations[' + index + '].Barcode" value="' + itemBarcode + '" type="text" class = "ProductTableColumn" readOnly = "readOnly"/>' +
            '</td>' +
            '<td>' +
            '<input id="ProductVariations_' + index + '__UnitId" name="ProductVariations[' + index + '].UnitId" value="' + itemUnitId + '" type="hidden"/><input type="text" id="ProductVariations_' + index + '__UnitTitle" class="ProductTableColumn" value="' + itemUnitTitle + '"/>' +
            '</td>' +
            '<td>' +
            '<input id="ProductVariations_' + index + '__ShelfId" name="ProductVariations[' + index + '].ShelfId" value="' + itemShelfId + '" type="hidden"/><input type="text" id="ProductVariations_' + index + '__ShelfTitle" class="ProductTableColumn" value="' + itemShelfTitle + '"/>' +
            '</td>' +
            '<td>' +
            '<input id="ProductVariations_' + index + '__MinimumStockLimit" name="ProductVariations[' + index + '].MinimumStockLimit" value="' + itemMinStockLevel + '" type="text" class = "ProductTableColumn" readOnly = "readOnly"/>' +
            '</td>' +
            '<td>' +
            '<input id="ProductVariations_' + index + '__ProductVariantDescription" name="ProductVariations[' + index + '].ProductVariantDescription" value="' + itemDescription + '" type="text" class = "ProductTableColumn" readOnly = "readOnly"/>' +
            '</td>' +
            '<td>' +
            '<a href="javascript:;" class="btn default btn-xs blue editRow" title="Edit"><i class="fa fa-pencil"></i></a>' +
            '&nbsp;<a href="javascript:;" class="btn default btn-xs red deleteRow" title="Delete"><i class="fa fa-trash-o"></i></a>' +
            '</td>' +
            '</tr>';
        $('#ProductVariationTableBody').append(html);
    } else {
        index = itemRowIndex;
        $("#itemRowIndex").val("");
        //change input text value
        $("#ProductVariations_" + index + "__Barcode").val(itemBarcode);
        $("#ProductVariations_" + index + "__UnitId").val(itemUnitId);
        $("#ProductVariations_" + index + "__UnitTitle").val(itemUnitTitle);
        $("#ProductVariations_" + index + "__ShelfId").val(itemShelfId);
        $("#ProductVariations_" + index + "__ShelfTitle").val(itemShelfTitle);
        $("#ProductVariations_" + index + "__MinimumStockLimit").val(itemMinStockLevel);
        $("#ProductVariations_" + index + "__ProductVariantDescription").val(itemDescription);

        
    }

    //$('#ProductVariantForm').trigger("reset");
    clearInputFields("#ProductVariantForm");
    //change button text
    $("#ProductItemAddBtn").text("Add");
    disableAddButton();
});
function enableAddButton() {
    $("#ProductItemAddBtn").removeClass("disabled");
}
function disableAddButton() {
    $("#ProductItemAddBtn").addClass("disabled");
}
//Load popup for contacts table row's data
$('.editRow').live('click', function () {
    //get the id from tr that is selected for the item popup
    var index = $(event.target).closest('tr').data('id');
    $("#itemRowIndex").val(index);
    //get item's values
    var itemBarcode = $("#ProductVariations_" + index + "__Barcode").val();
    var itemUnitId = $("#ProductVariations_" + index + "__UnitId").val();
    var itemShelfId = $("#ProductVariations_" + index + "__ShelfId").val();
    var itemMinStockLevel = $("#ProductVariations_" + index + "__MinimumStockLimit").val();
    var itemDescription = $("#ProductVariations_" + index + "__ProductVariantDescription").val();

    $("#Barcode").val(itemBarcode);
    $("#MinStockLevel").val(itemMinStockLevel);
    $("#ItemDescription").val(itemDescription);
    $("#UnitId").select2('val', itemUnitId);
    $("#ShelfId").select2('val', itemShelfId);

    //change button text
    $("#ProductItemAddBtn").text("Update");
    enableAddButton();
});

//delete company contact table row
$('.deleteRow').live("click", function () {
   
    var index = $(event.target).closest('tr').data('id');
    var productVariation = $('#ProductVariations_' + index + '__ProductVariationId').val();
    if (productVariation != "") {
        if (!confirm("Are you sure to delete this product item from Database permanently?")) {
            return;
        }
        $.ajax({
            data: { id: productVariation },
            url: "/Product/DeleteProduct",
            type: "GET",
            dataType: "json",
            success: function(response) {
                if (response == true)
                    toastr.success("Item deleted successfully.");
                else
                    toastr.warning("Item cannot be deleted, it exists in some orders.");
            },
        });
    } else
    {
        if (!confirm("Are you sure to delete this product item?")) {
            return;
        }
    }
    $(this).parent().parent().remove();
});

function LoadProductByCode(control) {
    var code = $("#" + control.id).val();
    if (code == "")
        return;
    $.blockUI({ message: '<h3><img src="../../Images/loading.gif" height=55px; width=55px; /> Fetching Product...</h3>' });

    if (code != "" && code != "0") {
        $.ajax({
            url: "/Api/ProductVariationStock",
            type: "GET",
            data: { code: code },
            dataType: "json",
            success: ProductLoaded,
            error: function (textStatus, errorThrown) {
                $.unblockUI();
                alert("Status: " + textStatus); alert("Error: " + errorThrown);
            }
        });
    }
}
function ProductLoaded(data) {
    $.unblockUI();
    if (data.ProductId <= 0) {
        toastr.error("No Product found with given Code");
    } else {
        toastr.success("Product Item found successfully");
        $("#Barcode").val(data.ProductBarCode);
        $("#ProductName").val(data.Name);
        $("#ProductDescription").val(data.Comments);
        $("#ProductId").val(data.ProductId);

        //For New Product Page Fields
        $("#Category").select2('val', data.CategoryId);
        $("#Brand").select2('val', data.BrandId); 
        $("#ProductModel_ProductId").val(data.ProductId);
        $("#ProductModel_RecCreatedBy").val(data.RecCreatedBy);
        $("#ProductModel_RecCreatedDate").val(data.RecCreatedDate);

        $("#MinimumStockLimit").val(data.MinimumStockLimit);

        //END For New Product Page Fields

        //product Image controls

        //if (data.IsWeb) {
        //    $("#isWeb").parents('span').addClass("checked");
        //    $("#isWeb").prop('checked', data.IsWeb).change();
        //    $("#ProductDefaultImageURL").prop("src", data.ProductDefaultImageURL);
        //} else {
        //    $("#ProductDefaultImageURL").prop("src", "");
        //    $("#isWeb").parents('span').removeClass("checked");
        //    $("#isWeb").prop('checked', data.IsWeb).change();
        //}

        //if (data.IsFeatured) {
        //    $("#isFeatured").parents('span').addClass("checked");
        //    $("#isFeatured").prop('checked', data.IsFeatured).change();
        //} else {
        //    $("#isFeatured").parents('span').removeClass("checked");
        //    $("#isFeatured").prop('checked', data.IsFeatured).change();

        //}
    }
}