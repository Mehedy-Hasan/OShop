

var id = 0;

$("#addButton").click(() => {
    var item = getData();

    var tr = '<tr>';
    var productTd = '<td> <input id="js-productId" type="hidden" name="OrderDetails[' + id +'].item.productId" value="'+item.productId+'"/>' + item.productName + '</td>';
    var qtyTd = '<td> <input id="js-qty" type="hidden" name="OrderDetails[' + id + '].item.qty" value="' + item.qty +'"/>' + item.qty + '</td>';
    var upTd = '<td><input id="js-unitPrice" type="hidden" name="OrderDetails[' + id + '].item.unitPrice" value="' + item.unitPrice +'"/> ' + item.unitPrice + '</td>';
    var dpTd = '<td><input id="js-discountPercentace" type="hidden" name="OrderDetails[' + id + '].item.discountPercent" value="' + item.discountPercent +'"/> ' + item.discountPercent + '</td>';
    var editTd = '<td><button class="btn btn-warning btn-sm" data-name="' + item.unitPrice+'" onclick="editRow(this)">Edit</button></td>';

    tr += productTd + qtyTd + upTd + dpTd + editTd+ '</tr>';

    $("#tbOrderDetails").append(tr);

    id++;

    $("#qty").val("");
    $("#unitPrice").val("");
    $("#discountPercent").val("");

});

function editRow(obj) {
    var unitPrice = $(obj).attr("data-unitPrice");

    $("#unitPrice").val(unitPrice)};
    
}

//$(document.body).on("click",".js-inlineEdit",function() {
//    var rowIndex = $(this).attr("data-rowNumber");
//    $("#tableIndexId").val(rowIndex);
//    $("#js-productId").val($("#js-productId" + rowIndex).text());
//    $("#js-qty").val($("#js-qty" + rowIndex).text());
//    $("#js-unitPrice").val($("#js-unitPrice" + rowIndex).text());
//    $("#js-discountPercentace").val($("#js-discountPercentace" + rowIndex).text());
//});

function getData() {
    var productId = $("#productId").val();
    var productName = $("#productId option:selected").text();
    var qty = $("#qty").val();
    var unitPrice = $("#unitPrice").val();
    var discountPercent = $("#discountPercent").val();

    var item = {
        "productId": productId,
        "productName": $("#productId option:selected").text(),
        "qty": qty,
        "unitPrice": unitPrice,
        "discountPercent": discountPercent
    }
    return item;
};

