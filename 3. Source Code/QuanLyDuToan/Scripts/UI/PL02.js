function cap_nhat() {
	$('#tbl tbody').hide();
	$('#tbl').empty();
	$.ajax({
		url: '../WebMethod/PL01.asmx/genGrid',
		type: 'post',
		data: {},
		dataType: 'text',
		error: function () {
			alert('Xảy ra lỗi trong quá trình thực hiện, Bạn vui lòng thực hiện lại thao tác!');
		},
		success: function (data) {
			$('#tbl').append(data);
			initialRelation();
		}
	});
}
function initialRelation() {
	$('#txt_tieu_muc').bind("keypress keyup keydown change", function () {
		var arr_noi_dung_chi = $.grep(m_lst_clkm, function (element, index) {
			return element.MaSo == $('#txt_tieu_muc').val();
		});
		if (arr_noi_dung_chi.length > 0) {
			$('#lbl_noi_dung_chi').text(arr_noi_dung_chi[0].Ten);
		}
	});
	$('#txt_loai').bind("keypress keyup keydown change blur", function () {
		var arr_noi_dung_chi = $.grep(m_lst_clkm, function (element, index) {
			return element.MaSo == $('#txt_loai').val()
				&& element.IdLoai == idLoai;
		});
		if (arr_noi_dung_chi.length < 1) {
			$('#txt_loai').css('background', 'lightgray').focus();
		}
		else {
			$('#txt_loai').css('background', 'white');
		}
	});
	$('#txt_khoan').bind("keypress keyup keydown change blur", function () {
		var arr_noi_dung_chi = $.grep(m_lst_clkm, function (element, index) {
			return element.MaSo == $('#txt_khoan').val()
				&& element.IdLoai == idKhoan
				&& element.MaSoParent == $('#txt_loai').val();
		});
		if (arr_noi_dung_chi.length < 1) {
			$('#txt_khoan').css('background', 'lightgray').focus();
		}
		else {
			$('#txt_khoan').css('background', 'white');
		}
	});
	$('#txt_muc').bind("keypress keyup keydown change blur", function () {
		var arr_noi_dung_chi = $.grep(m_lst_clkm, function (element, index) {
			return element.MaSo == $('#txt_muc').val()
				&& element.IdLoai == idMuc;
		});
		if (arr_noi_dung_chi.length < 1) {
			$('#txt_muc').css('background', 'lightgray').focus();
		}
		else {
			$('#txt_muc').css('background', 'white');
		}
	});
	$('#txt_tieu_muc').bind("keypress keyup keydown change blur", function () {
		var arr_noi_dung_chi = $.grep(m_lst_clkm, function (element, index) {
			return element.MaSo == $('#txt_tieu_muc').val()
				&& element.IdLoai == idTieuMuc
				&& element.MaSoParent == $('#txt_muc').val();
		});
		if (arr_noi_dung_chi.length < 1) {
			$('#txt_tieu_muc').css('background', 'lightgray').focus();
		}
		else {
			$('#txt_tieu_muc').css('background', 'white');
		}
	});
}
$(document).ready(function () {
	initialRelation();
})
