
var id = 0;

$("#addButton").click(() => {
    var productId = $("#productId").val();
    var productName = $("#productId option:selected").text();
    var qty = $("#qty").val();
    var unitPrice = $("#unitPrice").val();
    var discountPercent = $("#discountPercent").val();

    var tr = '<tr>';
    var producttd = '<td> <input type="hidden" name="OrderDetails['+id+'].ProductId" value="'+productId+'"/>' + productName + '</td>';
    var qtyTd = '<td> <input type="hidden" name="OrderDetails[' + id + '].Qty" value="' + qty +'"/>' + qty + '</td>';
    var upTd = '<td><input type="hidden" name="OrderDetails[' + id + '].UnitPrice" value="' + unitPrice +'"/> ' + unitPrice + '</td>';
    var dpTd = '<td><input type="hidden" name="OrderDetails[' + id + '].DiscountPercentage" value="' + discountPercent +'"/> ' + discountPercent + '</td>';

    tr += producttd + qtyTd + upTd + dpTd + '</tr>';

    $("#tbOrderDetails").append(tr);

    id++;

});