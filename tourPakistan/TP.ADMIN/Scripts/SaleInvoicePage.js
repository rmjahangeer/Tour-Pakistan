
$('#addItem').on("click", function (event) {

    AddItemToGrid();
});
$('#addItem').on("keydown", function (event) {
    if (event.which === 13) {
        AddItemToGrid();
    }
});



function AddItemToGrid() {
    var index = $('#TotalCount').val();
    //var index = $("#tblItemDetails").children("tbody").children("tr").length;
    var obj = new Object();
    if (ValidateItemAdd(obj)) {
        var available;
        if (window.orderedProducts[obj.itemProductId] == null) {
            var stock = $("#itemInStock").val();
            available = stock.split(" ");
            var quantityToBeAdded = parseFloat($("#ItemQty").val());

            if (available[0] >= quantityToBeAdded && quantityToBeAdded > 0) {
                var html = '<tr data-id="' + index + '">' +
                    '<td style="display:none">' +
                    '<input name="OrderItems.Index" type="hidden" value="' + index + '"/>' +
                    '<input  name="OrderItems[' + index + '].OrderItemId" type="hidden" value="-1">' +
                    '</td>' +
                    //PRODUCT CODE
                    '<td>' +
                    '<input class="TableTextBox valid" tabindex="-1" id="OrderItems_' + index + '__ProductId" name="OrderItems[' + index + '].ProductId" readonly="readOnly" type="text" value="' + obj.itemProductId + '">' +
                    '</td>' +
                    //Product Name
                    //'<td class="highlight">' + obj.itemName + '</td>' +
                    '<td>' +
                    '<input class="TableTextBox" tabindex="-1"  readonly="readOnly" type="text" value="' + obj.itemName + '">' +
                    '</td>' +
                    //Product Price
                    '<td>' +
                    '<input class="TableTextBox valid"  tabindex="-1" name="OrderItems[' + index + '].Product.SalePrice" id="OrderItems_' + index + '__SalePrice" readonly="readOnly" type="text" value="' + obj.salePrice + '">' +
                    '</td>' +
                    //Quantity
                    '<td>' +
                    '<input class="TableEditableTextBox valid GridValueChange NumberValue"  name="OrderItems[' + index + '].Quantity"  id="OrderItems_' + index + '__Quantity"  type="text" value="' + obj.itemQty + '">' +
                    '</td>' +

                    //Sub Total
                    '<td>' +
                    '<input class="TableTextBox valid"  readonly="readOnly" tabindex="-1" id="OrderItems_' + index + '__Subtotal" name="OrderItems[' + index + '].Subtotal"  type="text" value="' + obj.itemSubTotal + '">' +
                    '</td>' +


                    //Discount Amount
                    '<td>' +
                    '<input class="TableEditableTextBox valid GridValueChange DecimalValue"  id="OrderItems_' + index + '__Discount" name="OrderItems[' + index + '].Discount"  type="text" value="' + obj.itemDiscPrice + '">' +
                    '</td>' +
                    //Total
                    '<td>' +
                    '<input class="TableTextBox valid" tabindex="-1" name="OrderItems[' + index + '].TotalItemAmount"  id="OrderItems_' + index + '__TotalItemAmount" readonly="readOnly" type="text" value="' + obj.itemTotalprice + '">' +
                    '</td>' +
                    '<td>' +
                    '<a href="javascript:;" tabindex="-1" class="btn default btn-xs red deleteRow">' +
                    '<i class="fa fa-trash-o"  ></i></a> </td> ' +
                    '<input id="OrderItems_' + index + '__IsModified" name="OrderItems[' + index + '].IsModified" type="hidden" value="False">' +
                    '</tr>';

                window.window.orderedProducts[obj.itemProductId] = obj.itemQty;

                stock = $("#itemInStock").val();
                window.available = stock.split(" ");
                quantityToBeAdded = parseFloat($("#ItemQty").val());
                $("#itemInStock").val(available[0] - quantityToBeAdded + " Left");
                window.window.productAvailableQuantity[obj.itemProductId] = parseFloat(available[0]) - parseFloat(quantityToBeAdded);

                $('#tblItemDetails').append(html);
                $('#TotalCount').val(++index);

                CalculateOrderTotals();
                ResetItemDetail();
                RestrictNumberOnlyFields();
            }
            else {
                stock = $("#itemInStock").val();
                window.available = stock.split(" ");
                tostAvailableQty(window.available[0]);
            }
        } else {

            stock = $("#itemInStock").val();
            available = stock.split(" ");
            quantityToBeAdded = parseFloat($("#ItemQty").val());

            if (available[0] >= quantityToBeAdded) {
                $("tr").each(function () {
                    currentRow = $(this);
                    $(currentRow).find("td:nth-child(2) input").each(function () {
                        if (obj.itemProductId == $(this).val()) {
                            var quantityToBeAdded = parseFloat($("#ItemQty").val());

                            var quan = parseFloat($(currentRow).find("td:nth-child(5) input").val()) + parseFloat(quantityToBeAdded);
                            var controlId = $(currentRow).find("td:nth-child(5) input").attr("id");
                            $("#" + controlId).val(quan);
                            //$("#1" + parseFloat($(currentRow).find("td:nth-child(5) input").val())).val(quan);
                            window.orderedProducts[obj.itemProductId] = quan;

                            GridValueChanged("Added", controlId);
                        }
                    });
                });
            }
            else {
                stock = $("#itemInStock").val();
                window.available = stock.split(" ");
                tostAvailableQty(window.available[0]);
            }
        }
    }
}

function ValidateItemAdd(obj) {

    if (ValidateFieldsByClass('mandatoryItem')) {
        obj.itemCode = $('#ItemBarcode').val();
        obj.itemProductId = $('#ItemProductId').val();
        obj.salePrice = $('#SalePrice').val();
        obj.itemQty = $('#ItemQty').val();
        obj.itemSubTotal = $('#TotalPrice').val();
        obj.itemDiscPerc = $('#ItemDiscPerc').val();
        obj.itemDiscPrice = $('#ItemDiscPrice').val();
        obj.itemTotalprice = $('#GrandTotal').val();
        obj.itemName = $("#ProductsDDList option:selected").text();
        return true;
    }
    return false;


}

function ResetItemDetail() {
    $('#OrderItemAddInfo').find('input:text').val('0');
    $('#OrderItemAddInfo').find('label').val('');
    $('#ItemQty').val('1');
    $('#ItemBarcode').val('');
    $('#ItemProductId').val('');

}


jQuery(document).on('keydown', function (ev) {
    if (ev.which === 13) {

        // Avoid form submit
        return false;
    }
});
var isBarCode = false;
jQuery('.searchBarcode').on('keydown', function (ev) {
    
    if (ev.which === 13) {
        isBarCode = true;
        LoadProductByCodeForSaleInvoice(document.getElementById('ItemBarcode'));
        // Avoid form submit
        return false;
    }
});
jQuery('.searchBarcode').on('change', function (ev) {
    LoadProductByCodeForSaleInvoice(document.getElementById('ItemBarcode'));
    // Avoid form submit
    return false;
});


function LoadProductByCodeForSaleInvoice(control) {
    var productCode = $("#" + control.id).val();
    loadProductFromServer(productCode);
}


function loadProductFromServer(productCode) {
    if (productCode == "") {
        toastr.warning("No Barcode found for this Product");
        return;
    }
    $.blockUI({ message: '<h3><img src="../Images/loading.gif" height=55px; width=55px; /> Fetching Product...</h2>' });
    if (productCode != "" && productCode != "0") {
        $.ajax({
            url: "/Api/ProductVariationStock",
            type: "GET",
            data: { code: productCode },
            dataType: "json",
            success: ProductLoadedForSaleInvoice,
            error: function (textStatus, errorThrown) {
                $.unblockUI();
                alert("Status: " + textStatus); alert("Error: " + errorThrown);
            }
        });
    }
}
function ProductLoadedForSaleInvoice(data) {
    $.unblockUI();
    $("#ItemBarcode").val(data.Barcode != null ? data.Barcode : data.ProductVariationId);
    $("#ItemProductId").val(data.ProductVariationId);
    //$("#ItemName").val(data.Name);
    $("#ProductsDDList").select2("val", data.Barcode != null ? data.Barcode : data.ProductVariationId);
    $("#SalePrice").val(data.SalePrice);
    if (window.orderedProducts[data.ProductVariationId] == null)
        $("#itemInStock").val((data.AvailableQuantity));
    else if (window.orderedProducts[data.ProductVariationId] >= data.AvailableQuantity)
        $("#itemInStock").val((0));
    else
        $("#itemInStock").val((data.AvailableQuantity - window.orderedProducts[data.ProductVariationId]));
    window.productAvailableQuantity[data.ProductVariationId] = data.AvailableQuantity;
    CalculateTotals();
    if (data.ProductVariationId <= 0) {
        toastr.error("No Product found with given Code");
        $('#ItemQty').val(1);
    }
    else {
        //toastr.success("Product found successfully");
        if (isBarCode)
            AddItemToGrid();
    }
    isBarCode = false;
}

function CalculateTotals() {

    var obj = new Object();
    obj.salePrice = $('#SalePrice').val();
    obj.itemQty = $('#ItemQty').val();
    obj.itemSubTotal = obj.salePrice * obj.itemQty;
    obj.itemDiscPrice = $('#ItemDiscPrice').val();
    obj.GrandTotal = obj.itemSubTotal - obj.itemDiscPrice;

    $('#GrandTotal').val(obj.GrandTotal);
    $('#TotalPrice').val(obj.itemSubTotal);
}

$('.calcPrice').change(function () {

    CalculateTotals();
});

function GridValueChanged(from, controlId) {

    var counterID = $('#' + controlId).parent().parent().attr("data-id");
    var qty = parseFloat($('#OrderItems_' + counterID + '__Quantity').val());

    if (from == "Added") {

        var stock = $("#itemInStock").val();
        var available = stock.split(" ");

        var quantityToBeAdded = parseFloat($("#ItemQty").val());
        var productId = $('#OrderItems_' + counterID + '__ProductId').val();

        if (available[0] >= quantityToBeAdded && qty > 0) {

            $("#itemInStock").val((parseFloat(available[0]) - parseFloat(quantityToBeAdded)) + " Left");
            window.productAvailableQuantity[productId] = parseFloat(available[0]) - parseFloat(quantityToBeAdded);
            updateGridValue(counterID, qty);
        } else {
            if (qty == 0 || (qty > (parseFloat(window.productAvailableQuantity[productId]) + parseFloat(window.orderedProducts[productId])))) {
                if (qty > (parseFloat(window.productAvailableQuantity[productId]) + parseFloat(window.orderedProducts[productId]))) {
                    tostAvailableQty((parseFloat(window.productAvailableQuantity[productId]) + parseFloat(window.orderedProducts[productId])));
                }
                $('#OrderItems_' + counterID + '__Quantity').val(window.orderedProducts[productId]);
            }
        }

    } else if (from == "Updated") {

        productId = $('#OrderItems_' + counterID + '__ProductId').val();
        if (window.orderedProducts[productId] > qty && qty > 0) {
            window.productAvailableQuantity[productId] = parseFloat(window.productAvailableQuantity[productId]) + parseFloat(window.orderedProducts[productId]) - qty;
            $("#itemInStock").val(window.productAvailableQuantity[productId] + " Left");
            window.orderedProducts[productId] = parseFloat(qty);
            updateGridValue(counterID, qty);
        }

        else if ((parseFloat(window.productAvailableQuantity[productId]) + parseFloat(window.orderedProducts[productId])) >= parseFloat(qty) && qty > 0) {
            window.productAvailableQuantity[productId] = (parseFloat(window.productAvailableQuantity[productId]) + parseFloat(window.orderedProducts[productId])) - qty;
            $("#itemInStock").val(window.productAvailableQuantity[productId] + " Left");
            window.orderedProducts[productId] = qty;
            updateGridValue(counterID, qty);
        } else {
            if (qty == 0 || (qty > (parseFloat(window.productAvailableQuantity[productId]) + parseFloat(window.orderedProducts[productId])))) {
                if (qty > (parseFloat(window.productAvailableQuantity[productId]) + parseFloat(window.orderedProducts[productId]))) {
                    tostAvailableQty((parseFloat(window.productAvailableQuantity[productId]) + parseFloat(window.orderedProducts[productId])));
                }
                $('#OrderItems_' + counterID + '__Quantity').val(window.orderedProducts[productId]);
            }
        }

    }
    else if (from == "Discount") {
        updateGridValue(counterID, qty);
    }
    ResetItemDetail();
    return true;
}
function updateGridValue(counterID, qty) {
    var price = $('#OrderItems_' + counterID + '__SalePrice').val();
    var discRS = $('#OrderItems_' + counterID + '__Discount').val();

    //window.orderedProducts[productId] = qty;
    var subTotal = price * qty;

    var discPerc = (discRS * 100) / subTotal;

    //Checking max allowed... if any problem i will revert it to 0
    var maxAllowedDiscPerc = $('#AllowedMaxDiscount').val();
    if (parseFloat(discPerc) > parseFloat(maxAllowedDiscPerc)) {
        $('#OrderItems_' + counterID + '__Discount').val(0);
        toastr.error("ORDER EXCEEDING SALE DISCOUNT LIMIT");
        discRS = $('#OrderItems_' + counterID + '__Discount').val();
    }

    $('#OrderItems_' + counterID + '__IsModified').val('True');

    $('#OrderItems_' + counterID + '__Subtotal').val(subTotal);
    var Total = subTotal - discRS;
    $('#OrderItems_' + counterID + '__TotalItemAmount').val(Total);
    CalculateOrderTotals();

}
//$('.GridValueChange').change(function (a, b) {
$(document).on('keydown', '.GridValueChange', function (event) {
    if (event.which === 13 || event.which === 9) {
        var status = (this.id.toLowerCase().indexOf("discount") >= 0) ? "Discount" : "Updated";
        return GridValueChanged(status, this.id);
    }
});

$('.calcDisc').change(function (a, b) {
    var obj = new Object();

    obj.salePrice = $('#SalePrice').val();
    obj.itemQty = $('#ItemQty').val();
    obj.itemSubTotal = obj.salePrice * obj.itemQty;
    obj.itemDiscPerc = $('#ItemDiscPerc').val();
    obj.itemDiscPrice = $('#ItemDiscPrice').val();



    if (this.id == "ItemDiscPerc") {
        //Means perc changes
        obj.itemDiscPrice = Math.floor(obj.itemSubTotal * (obj.itemDiscPerc / 100));
        $('#ItemDiscPrice').val(obj.itemDiscPrice);

    }
    else {
        //Means Rs change
        obj.itemDiscPerc = Math.round((obj.itemDiscPrice * 100) / obj.itemSubTotal, 1);
        $('#ItemDiscPerc').val(obj.itemDiscPerc);
    }
    //CHECKING MAX ALLOWED
    var maxAllowedDiscPerc = $('#AllowedMaxDiscount').val();

    if (parseFloat(obj.itemDiscPerc) > parseFloat(maxAllowedDiscPerc)) {
        $('#ItemDiscPerc').val(0);
        $('#ItemDiscPrice').val(0);
        toastr.error("ORDER EXCEEDING SALE DISCOUNT LIMIT");
    }
    CalculateTotals();
});

function tostAvailableQty(qty) {
    toastr.warning("Oops! Item's available quantity is " + qty);
}
function CalculateOrderTotals() {

    var itemSubTotal = 0;
    var itemDisc = 0;
    var itemQtyTotal = 0;
    // var index = $("#tblItemDetails").children("tbody").children("tr").length; //Total for loop
    var index = $('#TotalCount').val();
    for (i = 0; i < index; i++) {

        itemSubTotal += parseFloat($('#OrderItems_' + i + '__Subtotal').val()) || 0;
        itemDisc += parseFloat($('#OrderItems_' + i + '__Discount').val()) || 0;
        itemQtyTotal += parseFloat($('#OrderItems_' + i + '__Quantity').val()) || 0;
    }


    $('#OrderSubTotal').val(itemSubTotal);
    $('#OrderTotalDisc').val(itemDisc);
    $('#OrderNetTotal').val(itemSubTotal - itemDisc);
    $('#OrderItemsQty').val(itemQtyTotal);
    $('#ProductsDDList').select2('val',"");
    CalculateReturnAmount();

}
function CalculateReturnAmount(agElement) {

    var amountPaid = $('#OrderAmountGiven').val();
    var netTotal = $('#OrderNetTotal').val();
    var toGive = amountPaid - netTotal;
    $('#OrderAmountReturn').val(toGive);
}
$(document).on('keydown', '.OrderAmountGiven', function (event) {
    if (event.which === 13 || event.which === 9) {
        CalculateReturnAmount();
    }
});
$(document).on('click', '.deleteRow', function (a, b) {
    var prodId = $(this).parent().parent().find("td:nth-child(2) input").val();
    window.orderedProducts[prodId] = null;
    window.productAvailableQuantity[prodId] = 0;

    $(this).parent().parent().remove();
    CalculateOrderTotals();
});


function ValidateAmounts() {
    var OrderNetTotal = $('#OrderNetTotal').val();
    var returnAmount = $('#OrderAmountReturn').val();
    if ((returnAmount == "" || parseFloat(returnAmount) < 0) && parseFloat(OrderNetTotal) > 0) {
        toastr.error("Received Amount cannot be less than 0");
        return false;
    }
    if (parseFloat(OrderNetTotal) < 1) {
        toastr.error("Empty order can not be saved.");
        return false;
    } else {
        return true;
    }
}