$(document).ready(function () {
    getProductData();
});

function getProductData() {

    var url = "/api/Product";

    $.ajax({
        url: url,
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        type: 'GET',
        success: function (result) {
            if (result) {
                $("#tblProductBody").html(" ");
                var row = " ";

                for (i = 0; i < result.length; i++){
        row = row
            + "<tr>"
            + "<td>" + result[i].Name + "</td>"
            + "<td>" + result[i].Price + "</td>"
            + "<td>" + result[i].Quantity + "</td>"
            + "<td>" + result[i].Active + "</td>"
            + "<td>" + "<button class='btn btn danger' onclick='deleteProduct(" + result[i].Id + ")'>Delete</button> " + "</td>"
            + "<td>" + "<button class='btn btn danger' onclick='getProduct(" + result[i].Id + ")'>Update</button> " + "</td>"
            + "</tr>";

    }
}
if (row != null) {
    $("#tblProductBody").append(row);
}
},
error: function(msg) {
    alert(msg);
}
        
    })

}

function SaveProduct() {
    var Product = {};

    Product.Name = $("#txtProductName").val();
    Product.Price = $("#txtProductPrice").val();
    Product.Quantity = $("#txtProductQuantity").val();
    Product.Active = 1;
    var id = $("#txtProductId").val();

    if (id == 0) {
        var url = 'api/Product';
    }
    else {
        var url = 'api/Product/' + id;
    }

    if (Product) {
        $.ajax({
            url: url,
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            data: JSON.stringify(Product),
            type: 'POST',
            success: function (result) {
                clear();
                alert(result);
                getProductData();
            },
            error: function (msg) {
                alert(msg);
            }
        })
    }
}

function clear() {
    $("#txtProductName").html('');
    $("#txtProductPrice").html('');
    $("#txtProductQuantity").html('');
}

function getProduct(id) {
    var url = 'api/Product/' + id;
    $.ajax({
        url: url,
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        type: 'GET',
        success: function (result) {
            $("#txtProductName").val(result.Name);
            $("#txtProductPrice").val(result.Price);
            $("#txtProductQuantity").val(result.Quantity);
            $("#txtProductId").attr('value', result.Id);

        },
        error: function (msg) {
            alert(msg);
        }
    })
}

function deleteProduct(id) {
    var url= '/api/Product/' + id;
    $.ajax({
        url: url,
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        type: 'Delete',
        success: function (result) {
            clear();
            alert(result);
            getProductData();
        },
        error: function (result) {
            alert(msg);
        }
    })
}