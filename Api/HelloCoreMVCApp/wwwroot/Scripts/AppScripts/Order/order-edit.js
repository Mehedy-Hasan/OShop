

var id = 0;

$("#addButton").click(() => {
    var item = getData();

    var tr = '<tr>';
    var productTd = '<td> <input id="productId' + id + '" type="hidden" name="OrderDetails[' + id +'].item.productId" value="'+item.productId+'"/>' + item.productName + '</td>';
    var qtyTd = '<td> <input id="qty' + id + '" type="hidden" name="OrderDetails[' + id + '].item.qty" value="' + item.qty +'"/>' + item.qty + '</td>';
    var upTd = '<td><input id="unitPrice' + id + '" type="hidden" name="OrderDetails[' + id + '].item.unitPrice" value="' + item.unitPrice +'"/> ' + item.unitPrice + '</td>';
    var dpTd = '<td><input id="discountPrice' + id + '" type="hidden" name="OrderDetails[' + id + '].item.discountPercent" value="' + item.discountPercent +'"/> ' + item.discountPercent + '</td>';
    var editTd = '<td><button class="btn btn-warning btn-sm" data-unitPrice="'+item.unitPrice+'" onclick="editRow(this)">Edit</button></td>;

    tr += productTd + qtyTd + upTd + dpTd + editTd+ '</tr>';

    $("#tbOrderDetails").append(tr);

    id++;

    $("#qty").val("");
    $("#unitPrice").val("");
    $("#discountPercent").val("");

});

function editRow(obj) {
    var unitPrice = $(this).attr("data-unitPrice");

    $("#unitPrice").val(unitPrice);
    
}

//$(document.body).on("click",".js-inlineEdit",function() {
//    var button = $(this);
//    var rowNumber = button.attr("data-rowNumber");
//    var q = $("#tableIndexId").val(rowNumber);
//    var b = $("#productId").val($("#productId" + rowNumber).text());
//    var c = $("#unitPrice").val($("#unitPrice" + rowNumber).text());
//    var d = $("#qty").val($("#qty" + rowNumber).text());
    
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

