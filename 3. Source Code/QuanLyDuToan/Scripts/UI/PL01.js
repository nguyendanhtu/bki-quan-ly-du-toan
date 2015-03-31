/// <reference path="../BigInt.js" />
/// <reference path="../jquery-1.4.1.js" />
function CouldUpdate(button) {
	$(button)
		.removeClass('btn-warning')
		.removeClass('btn-danger')
		.removeClass('btn-primary')
		.removeClass('btn-success')
		.addClass('btn-primary')
		.val('Chưa cập nhật!');
}
function DaCapNhat(button) {
	$(button)
		.removeClass('btn-warning')
		.removeClass('btn-danger')
		.removeClass('btn-primary')
		.removeClass('btn-success')
		.addClass('btn-success')
		.val('Đã cập nhật!');
}
function cap_nhat(button) {
	$(button).val('Đang gửi yêu cầu...');
	$(button).removeClass('btn-success');
	$(button).addClass('btn-warning');
	txt_sbc = $(button).parent().parent().find('.so_bao_cao');
	txt_sxd = $(button).parent().parent().find('.so_xet_duyet');
	$.ajax({
		url: '../WebMethod/PL01.asmx/update_giao_dich',
		type: 'post',
		data: { ip_dc_id_giao_dich: $(txt_sbc).attr('id_giao_dich'), ip_str_so_bao_cao: $(txt_sbc).val(), ip_str_so_xet_duyet: $(txt_sxd).val() },
		dataType: 'text',
		error: function () {
			alert('Xảy ra lỗi trong quá trình thực hiện, Bạn vui lòng thực hiện lại thao tác!');
		},
		success: function (data) {
			$(button).removeClass('btn-warning');
			if (data == 'true') {
				$(button).val('Đã cập nhật');
				$(button).addClass('btn-success');
			}
			else {
				$(button).val('Thất bại');
				$(button).addClass('btn-danger');
			}

		}
	});
}
function luu_du_lieu() {
	var stack_update = $('.cap_nhat');
	for (var i = 0; i < stack_update.length; i++) {
		$(stack_update[i]).click();
	}
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
	CouldUpdate($(strClassParent).parent().parent().find('.cap_nhat'));
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
					CouldUpdate($(lst_children[i]).parent().parent().find('.cap_nhat'));
				}
				$(strClassSoBaoCao).val(formatString('' + tong)).change();
				CouldUpdate($(strClassSoBaoCao).parent().parent().find('.cap_nhat'));
			}
		}));
}
function computedValueByFormula(lstFormula, classCongThuc) {
	var tong = 0;
	for (var i = 0; i < lstFormula.length; i++) {
		var strClass = lstFormula[i].split('-').join('').split('+').join('');
		//Kiểm tra xem các thành phần là phải cộng hay trừ, 
		//nếu có dấu - ở trước thì ta sẽ trừ (isAdd=false) và ngược lại
		var heSo = 1;
		if (lstFormula[i].indexOf('-') != -1) {
			heSo = -1;
		}
		if (strClass != '') {
			tong = tong + parseFloat(
									$('.' + classCongThuc + '.' + strClass).val()
									) * heSo;
			//console.log(i + ':' + strClass + ':' + parseFloat(
			//						$('.' + classCongThuc + '.' + strClass).val()
			//						) * heSo);
		}
	}
	return tong;
}

function EventByFormula(ma_so_parent, classCongThuc) {
	var strClassFormula = '' + '.cong_thuc.' + ma_so_parent + '';
	var lstFormula = $(strClassFormula).text().split('|');
	for (var i = 0; i < lstFormula.length; i++) {

		var strClass = lstFormula[i].split('-').join('').split('+').join('');
		//Tao su kien

		if (strClass != '') {
			$('.' + classCongThuc + '.' + strClass).bind("keypress keyup keydown change", (function (e) {
				$('.' + classCongThuc + '.' + ma_so_parent)
					.val(computedValueByFormula(lstFormula, classCongThuc));

			}));
			CouldUpdate($('.' + classCongThuc + '.' + strClass).parent().parent().find('.cap_nhat'));
		}


	}
}

function autoTinhTong(maxMaSo) {
	for (var i = 0; i <= maxMaSo; i++) {
		setTong(i, 'so_bao_cao');
		setTong(i, 'so_xet_duyet');
		EventByFormula(i, 'so_bao_cao');
		EventByFormula(i, 'so_xet_duyet');
	}
}
function formatTable() {
	var table = $('#tblPL01').dataTable({

		"sPaginationType": "full_numbers",
		"iDisplayLength": 500,
		"bServerSide": false,
		"bProcessing": true,
		"bSort": false,
		"bAutoWidth": false,
		"sScrollY": "600",
		"sScrollX": "100%",
		"sScrollXInner": "100%",
		"bScrollCollapse": true,
		"bInfo": true,
		"sDom": 'T<"clear"><"top">rt<"bottom">',
		"bFilter": true,
		"bLengthChange": true,
		"oLanguage": {
			"sSearch": "Tìm kiếm: ",
			"sEmptyTable": "Không có dữ liệu phù hợp!",
			"sInfo": "Có _TOTAL_ bản ghi (Trang hiện tại: từ _START_ đến _END_)",
			"sInfoFiltered": " - Có tất cả _MAX_ bản ghi",
			"oPaginate": {
				"sPrevious": "Trang trước",
				"sNext": "Trang tiếp",
				"sFirst": "Trang đầu",
				"sLast": "Trang cuối"
			},
			"sProcessing": "Đang tải dữ liệu!"
		}
	});
	new $.fn.dataTable.FixedHeader(table);
}
$(document).ready(function () {
	autoTinhTong(70);
	formatInputMoneyInit();
	$('.cap_nhat').each(function () {
		DaCapNhat(this);
	});
	formatTable();
});


