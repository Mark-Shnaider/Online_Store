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
            if (data.data.isValid == false)
                alert("На складе нет столько товаров")
        },
        error: function () {
            AjaxError();
        }
    });

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

RemoveFromCart = function (element) {

    var ProductId = $(element).data("product-id");
    var CartId = $(element).data("cart-id");
    $.ajax({
        type: "POST",
        url: urls.RemoveItemFromCart,
        data: {
            CartId: CartId,
            ProductId: ProductId,
        },
        success: function (data) {
            if (data.data.isValid == false)
                alert("На складе нет столько товаров")
        },
        error: function () {
            AjaxError();
        }
    });
};


function changeValue(target, output, amount, price, num) {
    let val = parseInt(target.value);
    if (num < 0 && val <= 1) {
        return;
    }
    val += num;
    target.value = val;

    let totalInt = val * price;
    output.value = ('' + totalInt).substring(0, 6);
}