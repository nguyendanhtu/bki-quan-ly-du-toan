$(document).ready(function () {

	//Thu gọn/mở rộng giao diện
	//$(".initial-expand").hide();

	//$("td.cssPageTitleBG").click(function () {
	//    $(this).children(".expand-collapse-text").toggle();
	//    $(this).parent("tr").siblings("tr").toggle();
	//});

	//Content boxes expand/collapse 2
	/*$("span.expand-collapse-text").click(function () {
    $(this).toggle();
    $(this).siblings(".expand-collapse-text").toggle();
    $(this).parent("td").parent("tr").siblings("tr").slideToggle();
    });*/

	//Định dạng chuối ký tự kiểu tiền tệ
	//$(".csscurrency").bind({
	//    blur: function () { $(this).val(getFormatedNumberString($(this).val())); },
	//    focus: function () { $(this).val(getNumber($(this).val())); }
	//});
	$('.format_so_tien').bind("change blur keyup focus", function (e) {
		var arr_keyCode_comma = [110, 188, 190];


		if ((e.keyCode >= 48 && e.keyCode <= 90)
			|| (e.keyCode >= 96 && e.keyCode <= 105)
			|| Enumerable.From(arr_keyCode_comma)
				.Where(function (x) { return x == e.keyCode })
				.ToArray().length > 0) {
			var str_format = getFormatedNumberString($(this).val().split(",").join("").split(".").join());
			$(this).val(str_format);
		}
	});
	$(document).on("blur", ".csscurrency", function (e) {
		e.preventDefault();
		$(this).val(getFormatedNumberString($(this).val()));
	})
	$(document).on("focus", ".csscurrency", function (e) {
		e.preventDefault();
		$(this).val(getNumber($(this).val()));
	})

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
function format_input(input) {
	// If the regex doesn't match, `replace` returns the string unmodified
	return (input.toString()).replace(
	  // Each parentheses group (or 'capture') in this regex becomes an argument 
	  // to the function; in this case, every argument after 'match'
	  /^([-+]?)(0?)(\d+)(.?)(\d+)$/g, function (match, sign, zeros, before, decimal, after) {

	  	// Less obtrusive than adding 'reverse' method on all strings
	  	var reverseString = function (string) { return string.split('').reverse().join(''); };

	  	// Insert commas every three characters from the right
	  	var insertCommas = function (string) {

	  		// Reverse, because it's easier to do things from the left
	  		var reversed = reverseString(string);

	  		// Add commas every three characters
	  		var reversedWithCommas = reversed.match(/.{1,3}/g).join(',');

	  		// Reverse again (back to normal)
	  		return reverseString(reversedWithCommas);
	  	};

	  	// If there was no decimal, the last capture grabs the final digit, so
	  	// we have to put it back together with the 'before' substring
	  	return sign + (decimal ? insertCommas(before) + decimal + after : insertCommas(before + after));
	  }
	);
};
function getFormatedNumberString(ip_str_number) {
	ip_str_number = ip_str_number.toString().replace(/\$|\,/g, '');
	if (isNaN(ip_str_number))
		ip_str_number = "0";
	sign = (ip_str_number == (ip_str_number = Math.abs(ip_str_number)));
	ip_str_number = Math.floor(ip_str_number * 100 + 0.50000000001);
	ip_str_number = Math.floor(ip_str_number / 100).toString();
	for (var i = 0; i < Math.floor((ip_str_number.length - (1 + i)) / 3) ; i++)
		ip_str_number = ip_str_number.substring(0, ip_str_number.length - (4 * i + 3)) + ',' +
            ip_str_number.substring(ip_str_number.length - (4 * i + 3));
	return (((sign) ? ip_str_number : '-' + ip_str_number));
}
function formatNumber(num) {
	return num.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,")
}
function getNumber(ip_str_number) {
	ip_str_number = ip_str_number.toString().replace(/\$|\,/g, '');
	if (isNaN(ip_str_number))
		ip_str_number = "0";
	return ip_str_number;
}
function formatString(str) {
	var index = 0;
	var count_comma = 0;
	var str2 = "";
	for (i = str.length - 1; i >= 0; i--) {
		if (!isNaN(str[i])) {
			str2 = str[i] + str2;
			index += 1;
			if (index % 3 == 0 && index != str.length - count_comma) {
				str2 = "," + str2;
			}
		}
		else {
			count_comma += 1;
		}
	}
	return str2;
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
		$(".format_so_tien").keyup(function (e) {
			if (e.keyCode != 17 && e.keyCode != 16 && e.keyCode != 37 && e.keyCode != 39 && e.keyCode != 36) {
				$(this).val(formatString($(this).val()));
			}
		});
	}
}

var CCommon = {
	thong_bao: function (text, className) {
		//className: warn, error, success, info
		$.notify(text, className);
	}
}