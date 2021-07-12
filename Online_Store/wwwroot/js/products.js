UpdateProducts = function (id, cartid) {
    $.ajax({
        type: "GET",
        url: urls.GetProducts,
        data: {
            CategoryId: id,
            Id: cartid
        },
        success: function (data) {
            $("#ProductContainer").html(data);
        },

    });
};