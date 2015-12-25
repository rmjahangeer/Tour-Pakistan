function LoadProductStockByCode(control) {
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
            success: ProductStockLoaded,
            error: function (textStatus, errorThrown) {
                $.unblockUI();
                alert("Status: " + textStatus); alert("Error: " + errorThrown);
            }
        });
    }
}
function CalculateBillTotals() {
    var itemPurchasePrice = 0;
    var itemDisc = parseFloat($('#DiscountAmount').val()) || 0;
    var itemTotal = 0;
    // var index = $("#tblItemDetails").children("tbody").children("tr").length; //Total for loop
    var index = $("#PurchaseBillItemsTableBody").children("tr").length;
    for (var i = 0; i < index; i++) {
        itemPurchasePrice += (parseFloat($('#InventoryItems_' + i + '__PurchasePrice').val()) * parseFloat($('#InventoryItems_' + i + '__Quantity').val())) || 0;
    }

    itemTotal = itemPurchasePrice - itemDisc;
    $('#SubTotal').val(itemPurchasePrice);
    $('#GrossTotal').val(itemTotal);
    $('#PaidAmount').val(0);
    //$('#PaidAmount').val(itemTotal);

    CalculateDiscount("#DiscountPercent");
}
function ProductStockLoaded(data) {
    $.unblockUI();
    if (data.ProductVariationId <= 0) {
        toastr.error("No Product Item found with given Code");

        $("#btnAddItem").attr("disabled", true);
    } else {
        toastr.success("Product Item found successfully");
        $("#ProductVariationId").val(data.ProductVariationId);
        $("#Barcode").val(data.Barcode);
        $("#CurrentStock").val(data.AvailableQuantity);
        $("#ProductName").val(data.ProductName);
        $("#Brand").val(data.BrandName);
        $("#ItemUnit").val(data.UnitTitle);
        $("#SalePrice").val(data.SalePrice);
        $("#PurchasePrice").val(data.PurchasePrice);
       
        ShowProfit();
        $("#btnAddItem").attr("disabled", false);

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
        //   $("#isFeatured").parents('span').removeClass("checked");
        //   $("#isFeatured").prop('checked', data.IsFeatured).change();
        //}
    }
}
function CalculateProfit(from, to) {
    if (from > 0) {
        var profit = ((to - from) / from) * 100;
        return profit > 0 ? profit.toFixed(0) : 0;
    } else {
        return 0;
    }
}
function ShowProfit() {
    var fromValue = parseFloat($("#PurchasePrice").val());
    var toValue = parseFloat($("#SalePrice").val());
    $("#ProfitAmount").val((isNaN(toValue) ? 0 : toValue) - (isNaN(fromValue) ? 0 : fromValue));

    var profit = CalculateProfit(isNaN(fromValue) ? 0 : fromValue, isNaN(toValue) ? 0 : toValue);
    $("#ProfitPercent").val(profit+"%");
}
function CalculateDiscount(control) {
    control = $(control);
    var subTotal = parseFloat($("#SubTotal").val()) || 0;
    var discountAmount = parseFloat($("#DiscountAmount").val()) || 0;
    var discountPercent = parseFloat($("#DiscountPercent").val()) || 0;
    if (discountAmount > 0 || discountPercent > 0) {
        if (control.attr('id') == "DiscountPercent") {
            discountAmount = subTotal * (discountPercent / 100);
        } else {
            discountPercent = (discountAmount / subTotal)*100;
        }
        $("#DiscountAmount").val(discountAmount.toFixed(2));
        $("#DiscountPercent").val(discountPercent.toFixed(2)).attr('title', discountPercent.toFixed(2));
        $("#GrossTotal").val((subTotal - discountAmount).toFixed(2));
        $('#PaidAmount').val(0);
        //$('#PaidAmount').val((subTotal - discountAmount).toFixed(2));
    }
}
function LoadCustomerByEmailOrPhone(control) {
    var code = $("#" + control.id).val();
    $.blockUI({ message: '<h3><img src="../Images/loading.gif" height=55px; width=55px; /> Fetching Product...</h2>' });

    if (code != "" && code != "0") {
        $.ajax({
            url: "/Api/Customer",
            type: "GET",
            data: { id: code },
            dataType: "json",
            success: CustomerLoaded,
            error: function (textStatus, errorThrown) {
                $.unblockUI();
                alert("Status: " + textStatus); alert("Error: " + errorThrown);
            }
        });
    }
}
function CustomerLoaded(data) {
    $.unblockUI();
    if (data==null) {
        toastr.error("No Customer found.");
    } else {
        toastr.success("Customer found successfully");
        var Id = data.Id;
        var Name = data.Name;
        var Phone = data.Phone;
        var Address = data.Address;
        var Email = data.Email;
        var Comments = data.Comments;
        var RecCreatedDate = data.RecCreatedDate;
        var RecLastUpdatedDate = data.RecLastUpdatedDate;
        var RecCreatedBy = data.RecCreatedBy;
        var RecLastUpdatedBy = data.RecLastUpdatedBy;
    }
}
$('#btnAddParticular').on("click", function () {
    //validate fields
    if (!(ValidateFieldsByClass("mandatoryModal"))) {
        return false;
    }


    var productVariationId = $("#ProductVariationId").val();
    var itemBarcode = $("#Barcode").val();
    var itemProductName = $("#ProductName").val();

    var itemUnit = $("#ItemUnit").val();
    var itemQuantity = parseInt($("#Quantity").val());
    var itemPurchasePrice = $("#PurchasePrice").val();
    var itemSalePrice = $("#SalePrice").val();

    //Check if item already added
    var itemFoundAtIndex = $("td").filter(function () {
        var itemCode = $(this).find('input:first').val();
        return itemCode == productVariationId;
    }).closest("tr").data('id');
    if (parseInt(itemFoundAtIndex) >= 0) {
        var alreadyQty = parseInt($('#InventoryItems_' + itemFoundAtIndex + '__Quantity').val());
        $('#InventoryItems_' + itemFoundAtIndex + '__Quantity').val(alreadyQty + itemQuantity);
        $('#InventoryItems_' + itemFoundAtIndex + '__PurchasePrice').val(itemPurchasePrice);
        $('#InventoryItems_' + itemFoundAtIndex + '__SalePrice').val(itemSalePrice);
    }
    else{
        ////add new row
        var index = $("#PurchaseBillItemsTableBody").children("tr").length;
        var productId = $("#ProductModel_ProductId").val();
        if ($("#PurchaseBillItemsTableBody").children("tr").children("td").html() == "No data available in table") {
            index = index - 1;
            $("#PurchaseBillItemsTableBody").children("tr").remove();
        }
        var indexCell = "<td style='display:none'>" +
            "<input name='InventoryItems.Index' type='hidden' value='" + index + "' />" +
            "<input name='InventoryItems[" + index + "].PurchaseBillId' id='InventoryItems_" + index + "__PurchaseBillId' type='hidden'  value='" + productId + "'/>" +
            "</td>";

        //InventoryItems
        var html = ' <tr data-id=' + index + '>' +
            indexCell +
            '<td>' +
            '<input id="InventoryItems_' + index + '__ProductVariationId"  tabindex="-1" name="InventoryItems[' + index + '].ProductVariationId" value="' + productVariationId + '" type="text" class = "ProductTableColumn" readOnly = "readOnly"/>' +
            '</td>' +
            '<td>' +
            '<input id="InventoryItems_' + index + '__Barcode"  tabindex="-1" value="' + itemBarcode + '" type="text" class = "ProductTableColumn" readOnly = "readOnly"/>' +
            '</td>' +
            '<td>' +
            '<input id="InventoryItems_' + index + '__ProductName"  tabindex="-1" value="' + itemProductName + '" type="text" class = "ProductTableColumn" readOnly = "readOnly"/>' +
            '</td>' +
            '<td>' +
            '<input id="InventoryItems_' + index + '__UnitTitle"  tabindex="-1" value="' + itemUnit + '" type="text" class = "ProductTableColumn" readOnly = "readOnly"/>' +
            '</td>' +
            '<td>' +
            '<input id="InventoryItems_' + index + '__Quantity"  tabindex="-1" name="InventoryItems[' + index + '].Quantity" value="' + itemQuantity + '" class = "ProductTableColumn" readOnly = "readOnly"/>' +
            '</td>' +
            '<td>' +
            '<input id="InventoryItems_' + index + '__PurchasePrice"  tabindex="-1" name="InventoryItems[' + index + '].PurchasePrice" value="' + itemPurchasePrice + '" class = "ProductTableColumn" readOnly = "readOnly"/>' +
            '</td>' +
            '<td>' +
            '<input id="InventoryItems_' + index + '__SalePrice"  tabindex="-1" name="InventoryItems[' + index + '].SalePrice" value="' + itemSalePrice + '" type="text" class = "ProductTableColumn" readOnly = "readOnly"/>' +
            '</td>' +
            '<td>' +
                //'<a href="javascript:;" class="btn default btn-xs blue editRow" title="Edit"><i class="fa fa-pencil"></i></a>' +
                '&nbsp;<a href="javascript:;"  tabindex="-1" class="btn default btn-xs red deleteRow" title="Delete"><i class="fa fa-trash-o"></i></a>' +
            '</td>' +
            '</tr>';
        $('#PurchaseBillItemsTableBody').append(html);
    }
    CalculateBillTotals();
    //$('#ProductVariantForm').trigger("reset");
    clearInputFields("#PurchaseBillItems");
    //change button text
    //$("#ProductItemAddBtn").text("Add");
    //disableAddButton();
});

$('.deleteRow').live("click", function () {
   
    var index = $(event.target).closest('tr').data('id');
    //var productVariation = $('#InventoryItems_' + index + '__ProductVariationId').val();
    //if (productVariation != "") {
    //    if (!confirm("Are you sure to delete this product item from Database permanently?")) {
    //        return;
    //    }
    //    $.ajax({
    //        data: { id: productVariation },
    //        url: "/Product/DeleteProduct",
    //        type: "GET",
    //        dataType: "json",
    //        success: function(response) {
    //            if (response == true)
    //                toastr.success("Item deleted successfully.");
    //            else
    //                toastr.warning("Item cannot be deleted, already exists in orders.");
    //        },
    //    });
    //} else 
    {
        if (!confirm("Are you sure to delete this product item from bill?")) {
            return;
        }
    }

    $(this).parent().parent().remove();
    CalculateBillTotals();
});

