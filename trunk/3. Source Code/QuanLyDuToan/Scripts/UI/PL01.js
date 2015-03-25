/// <reference path="../BigInt.js" />
/// <reference path="../jquery-1.4.1.js" />
function cap_nhat() {
}

function formatInputMoneyInit() {
	var lst_SoXetDuyet = $('.so_xet_duyet');
	var lst_SoBaoCao = $('.so_bao_cao');
	for (var i = 0; i < lst_SoXetDuyet.length; i++) {
		$(lst_SoXetDuyet[i]).val(formatString($(lst_SoXetDuyet[i]).val()));
	}
	for (var i = 0; i < lst_SoBaoCao.length; i++) {
		$(lst_SoBaoCao[i]).val(formatString($(lst_SoBaoCao[i]).val()));
	}
}
function setTong(ma_so_parent, classTinhTong) {
	var strClassParent = '' + '.ma_so_parent.' + ma_so_parent + '';
	var strClassSoBaoCao = '' + '.' + classTinhTong + '.' + ma_so_parent + '';
	var lst_children = $(strClassParent).parent().parent().find('.' + classTinhTong);

	$(strClassParent).parent().parent().find('.' + classTinhTong)
		.bind("keypress keyup keydown change", (function (e) {
			if (e.keyCode != 17
				&& e.keyCode != 16
				&& e.keyCode != 37
				&& e.keyCode != 39
				&& e.keyCode != 36) {
			var tong = 0.0;
			for (var i = 0; i < lst_children.length; i++) {
				tong += parseFloat($(lst_children[i]).val()
									.split(',').join('').split('.').join(''));
			}
			$(strClassSoBaoCao).val(formatString('' + tong)).change();
		}
	}));
}
function computedValueByFormula(lstFormula) {
	for (var i = 0; i < lstFormula.length; i++) {
		var strClass = lstFormula[i].split('-').join('').split('+').join('');
		//Kiểm tra xem các thành phần là phải cộng hay trừ, 
		//nếu có dấu - ở trước thì ta sẽ trừ (isAdd=false) và ngược lại
		var isAdd = true;
		if (lstFormula[i].indexOf('-')!=-1) {
			isAdd = false;
		}
	}
}
function autoTinhTong(maxMaSo) {
	for (var i = 0; i <= maxMaSo; i++) {
		setTong(i, 'so_bao_cao');
		setTong(i, 'so_xet_duyet');
	}
}
$(document).ready(function () {
	autoTinhTong(70);
	formatInputMoneyInit()
});


