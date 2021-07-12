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