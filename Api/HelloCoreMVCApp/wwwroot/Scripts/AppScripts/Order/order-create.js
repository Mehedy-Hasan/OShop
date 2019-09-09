
var dtlRowCount = 1;
$(document).ready(function() {
    getEmptyDtlTable();
});

$(document.body).on("click", "#btnSubmit", function () {
    var model = {
        OrderDetails: []
    };
    var id = $("#Id").val();
    model.OrderNo = $("#OrderNo").val();
    model.OrderDate = $("#OrderDate").val();
    model.CustomerId = $("#CustomerId").val();
    model.ProductId = $("#ProductId").val();
    // dtls
    var dtlTable = $('#dtlTable').DataTable();
    var dtls = dtlTable.rows().data();

    for (var r = 0; r < dtls.length; r++) {
        model.OrderDetails.push({
            Id: dtls.cell(r, 1).data(), 
            ProductId: dtls.cell(r, 2).data(),
            Qty: dtls.cell(r, 4).data(),
            UnitPrice: dtls.cell(r, 5).data(),
            DiscountPercentage: dtls.cell(r, 6).data()
           
        });
    }

        $.ajax({
            url: "/Order/Create",
            data: model,
            type: "POST",
            success: function (e) {
                if (e>0) {
                    toastr.success("Data Save Success", "Success!!!");
                    refreshForm();
                    
                } else {
                    toastr.warning("Data Save Fail.", "Warning!!!");
                    refreshForm();
                }
            },
            error: function (request, status, error) {
                var response = jQuery.parseJSON(request.responseText);
                toastr.error(response.errorMassage, "Error");
            }
        });
});


function getEmptyDtlTable() {

    $("#dtlTable").DataTable().destroy();
    var t = $('#dtlTable').DataTable({
        "columnDefs": [
            {
                "targets": [0],
                "visible": false,
                "searchable": false
            },
            {
                "targets": [1],
                "visible": false,
                "searchable": false
            },
            {
                "targets": [2],
                "visible": false,
                "searchable": false
            },
            
            {
                "targets": [7],
                "data": null,
                "defaultContent":
                    "<a class='btn btn-info btn-sm js-dtlEdit'><i class='fa fa-edit' aria-hidden='true'></i></a>" +
                        "<a class='btn btn-danger btn-sm js-dtlDelete'><i class='fa fa-trash' aria-hidden='true'></i></a>"
            }
        ],
        "searching": false,
        "paging": false,
        "ordering": false,
        "info": false


    });
   
    t.clear().draw();
}

//Add Operation
$(document.body).on("click","#btnAdd",function () {
    
        var rowId = $("#dtlRowHiden").val();
        var dtlId = $("#dtlIdHiden").val();
        var productId = $("#ProductId").val();
        var productName = $("#ProductId option:selected").text();
        var unitPrice = $("#unitPrice").val();
        var qty = $("#qty").val();
        var disPercent = $("#discountPercent").val();
       
        if (productId > 0 && unitPrice > 0) {

            var t = $('#dtlTable').DataTable();

            if (rowId > 0) {
                // row update
                var temp = t.row(rowId - 1).data();
                temp[1] = dtlId;
                temp[2] = productId;
                temp[3] = productName;
                temp[4] = qty;
                temp[5] = unitPrice ; 
                temp[6] = disPercent;
                $('#dtlTable').dataTable().fnUpdate(temp, rowId - 1, undefined, false);
            }
            else {
                // row add
                t.row.add([
                    dtlRowCount,
                    dtlId,
                    productId,
                    productName,
                    qty,
                    unitPrice, 
                    disPercent
                ]).draw(false);

                dtlRowCount++;
                toastr.success("Data Added");
            }
            refreshDtlInputFiled();
            

        } else if (productName === "") {
            toastr.warning("Please Select Product.", "Warning!!!");
            $("#ProductId").focus();
        } else {
            toastr.warning("Please Insert Unit Price.", "Warning!!!");
            $("#unitPrice").focus();
    }
        
    });

$(document.body).on("click", ".js-dtlEdit", function () {
    var t = $('#dtlTable').DataTable();
    var data = t.row($(this).parents('tr')).data();
    
    $("#dtlRowHiden").val(data[0]);
    $("#dtlIdHiden").val(data[1]);

    $("#ProductId").val(data[3]);
    $("#qty").val(data[4]);
    $("#unitPrice").val(data[5]); 
    $("#discountPercent").val(data[6]);
    $("#ProductId").val(data[2]);
});

$(document.body).on("click", ".js-dtlDelete", function () {
    var button = $(this);
    //bootbox.confirm("Are you sure to delete this data?", function (result) {
    //    if (result) {
            var t = $('#dtlTable').DataTable();
            t.row(button.parents("tr")).remove().draw(false);
            toastr.success("Data successfully delete");
        //}
    //});
    refreshDtlInputFiled();
});

function refreshDtlInputFiled() {
    $("#dtlRowHiden").val("");
    $("#dtlIdHiden").val(0);
    $("#ProductId").val("Select...");
    $("#unitPrice").val("");
    $("#qty").val("");
    $("#discountPercent").val("");

}

function refreshForm() {
    $("#dtlRowHiden").val("");
    $("#dtlIdHiden").val(0);
    //$("#ProductId").val("");
    $("#unitPrice").val("");
    $("#qty").val("");
    $("#discountPercent").val("");

    dtlRowCount = 1;
    getEmptyDtlTable();
}

