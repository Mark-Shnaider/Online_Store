AddToCart = function (element) {
    var amount = document.querySelector(".product-amount").children[1].valueAsNumber;
    var ProductId = $(element).data("product-id");
    var CartId = $(element).data("cart-id");
    $.ajax({
        type: "POST",
        url: urls.AddItemToCart,
        data: {
            CartId: CartId,
            ProductId: ProductId,
            amount: amount
        },
        success: function (data) {
            if (data.data.isValid != false)
                UpdateShopCartItems(CartId);
        },
        error: function () {
            AjaxError();
        }
    });
};

RemoveFromCart = function (element) {
    var ItemId = $(element).data("item-id");
    var CartId = $(element).data("cart-id");
    $.ajax({
        type: "POST",
        url: urls.RemoveItemFromCart,
        data: {
            ItemId: ItemId,
        },
        success: function (data) {
            UpdateShopCartItems(CartId);
        },
        error: function () {
            AjaxError();
        }
    });

};

UpdateShopCartItems = function (CartId) {
    $.ajax({
        type: "GET",
        url: urls.GetCartItems,
        data: {
            Id: CartId
        },
        success: function (data) {
            $('#CartContainer').html(data)
        },
    });
};