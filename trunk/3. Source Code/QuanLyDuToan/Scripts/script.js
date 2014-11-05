$(document).ready(function () {

    //Thu gọn/mở rộng giao diện
    $(".initial-expand").hide();

    $("td.cssPageTitleBG").click(function () {
        $(this).children(".expand-collapse-text").toggle();
        $(this).parent("tr").siblings("tr").toggle();
    });

    //Content boxes expand/collapse 2
    /*$("span.expand-collapse-text").click(function () {
    $(this).toggle();
    $(this).siblings(".expand-collapse-text").toggle();
    $(this).parent("td").parent("tr").siblings("tr").slideToggle();
    });*/

    //Định dạng chuối ký tự kiểu tiền tệ
    $(".csscurrency").bind({
        blur: function () { $(this).val(getFormatedNumberString($(this).val())); },
        focus: function () { $(this).val(getNumber($(this).val())); }
    });
});

//function getFormatedNumberString(ip_str_number) {
//    ip_str_number = ip_str_number.toString().replace(/\$|\,/g, '');
//    if (isNaN(ip_str_number))
//        ip_str_number = "0";
//    sign = (ip_str_number == (ip_str_number = Math.abs(ip_str_number)));
//    ip_str_number = Math.floor(ip_str_number * 100 + 0.50000000001);
//    ip_str_number = Math.floor(ip_str_number / 100).toString();
//    for (var i = 0; i < Math.floor((ip_str_number.length - (1 + i)) / 3); i++)
//        ip_str_number = ip_str_number.substring(0, ip_str_number.length - (4 * i + 3)) + ',' +
//            ip_str_number.substring(ip_str_number.length - (4 * i + 3));
//    return (((sign) ? '' : '-') + ip_str_number);
//}

//function getFormatedNumberString(ip_str_number) {
//    ip_str_number = ip_str_number.toString().replace(/\$|\,/g, '');
//    if (isNaN(ip_str_number))
//        ip_str_number = "0";
//    sign = (ip_str_number == (ip_str_number = Math.abs(ip_str_number)));
//    v_digits = Number(ip_str_number) - Math.floor(ip_str_number);
//    v_digits = Math.floor(v_digits * 10000 + 0.50000000001);
//    v_digits = (v_digits / 10000).toString();
//    ip_str_number = Math.floor(ip_str_number).toString();
//    v_digits = v_digits.toString().substr(1, 3);
//    for (var i = 0; i < Math.floor((ip_str_number.length - (1 + i)) / 3); i++)
//        ip_str_number = ip_str_number.substring(0, ip_str_number.length - (4 * i + 3)) + ',' +
//            ip_str_number.substring(ip_str_number.length - (4 * i + 3));
//    return (((sign) ? '' : '-') + ip_str_number + v_digits);
//}

function getFormatedNumberString(ip_str_number) {
    ip_str_number = ip_str_number.toString().replace(/\$|\,/g, '');
    if (isNaN(ip_str_number))
        ip_str_number = "0";
    sign = (ip_str_number == (ip_str_number = Math.abs(ip_str_number)));
    ip_str_number = Math.floor(ip_str_number * 100 + 0.50000000001);
    ip_str_number = Math.floor(ip_str_number / 100).toString();
    for (var i = 0; i < Math.floor((ip_str_number.length - (1 + i)) / 3); i++)
        ip_str_number = ip_str_number.substring(0, ip_str_number.length - (4 * i + 3)) + ',' +
            ip_str_number.substring(ip_str_number.length - (4 * i + 3));
    return (((sign) ? ip_str_number : '0'));
}

function getNumber(ip_str_number) {
    ip_str_number = ip_str_number.toString().replace(/\$|\,/g, '');
    if (isNaN(ip_str_number))
        ip_str_number = "0";
    return ip_str_number;
}

function pageLoad(sender, args) {
    if (args.get_isPartialLoad()) {
        //Thu gọn/mở rộng giao diện
        $(".initial-expand").hide();

        $("td.cssPageTitleBG").click(function () {
            $(this).children(".expand-collapse-text").toggle();
            $(this).parent("tr").siblings("tr").toggle();
        });

        //Content boxes expand/collapse 2
        /*$("span.expand-collapse-text").click(function () {
        $(this).toggle();
        $(this).siblings(".expand-collapse-text").toggle();
        $(this).parent("td").parent("tr").siblings("tr").slideToggle();
        });*/

        //Định dạng chuối ký tự kiểu tiền tệ
        $(".csscurrency").bind({
            blur: function () { $(this).val(getFormatedNumberString($(this).val())); },
            focus: function () { $(this).val(getNumber($(this).val())); }
        });
    }
}