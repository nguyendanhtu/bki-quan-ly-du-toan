/// <reference path="../jquery-1.4.1.js" />
/// <reference path="../script.js" />
function autoFormatInitData() {
	var lst_str = $('.str_money');
	for (var i = 0; i < lst_str.length; i++) {
		$(lst_str[i]).text(getFormatedNumberString($(lst_str[i]).text()));
	}
}
var gdPL04 = {
	cancel: function xoa_trang() {
		$('#txtCongTrinh').val('');
		$('#txtDuAn').val('');
		$('#txtKeHoachNamTruocChuaChiHetChuyenSang').val('');
		$('.giaoKH').each(function (index, value) {
			$(this).val('0');
		});
		$('#txtGiaTriDuToanCongTrinhDuocDuyet').val('0');
		$('#txtGiaTriCTHTNamTruocConNoChuyenSangNamNay').val('0');
		$('#txtGiaTriCTHTNamNay').val('0');
		$('#txtCong').val('0');
		$('#txtGiaTriDeNghiQuyetToanTrongNam').val('0');
		$('#txtGiaTriCTHTDaQuyetToanLKDenNamBaoCao').val('0');
		$('#txtGiaTriCTHTChuyenNamSauQT').val('0');
		$('#txtKeHoachConDuCuoiNam').val('0')
		$('#btnCapNhat').attr('id_giao_dich', '-1');
	},
	reloadGrid: function updateGrid() {

		$.ajax({
			url: '../WebMethod/PL02.asmx/genGrid',
			type: 'post',
			data: {},
			dataType: 'text',
			error: function () {
				alert('Xảy ra lỗi trong quá trình thực hiện, Bạn vui lòng thực hiện lại thao tác!');
			},
			success: function (data) {
				$('#tbl tbody').hide();
				$('#tbl').empty();
				$('#tbl').append(data);
				//gdPL02.autoValidateInput();
			}
		});
	},
	autoValidateInput: function initialRelation() {
		var lst_str = $('.str_money');
		for (var i = 0; i < lst_str.length; i++) {
			$(lst_str[i]).text(getFormatedNumberString($(lst_str[i]).text()));
		}
		$('#txtGiaTriCTHTNamTruocConNoChuyenSangNamNay, #txtGiaTriCTHTNamNay')
			.bind("keypress keyup keydown change blur", function () {
				$('#txtCong').text(
					getFormatedNumberString(
				parseFloat($('#txtGiaTriCTHTNamTruocConNoChuyenSangNamNay').val().split(',').join('').split('.').join(''))
				+ parseFloat($('#txtGiaTriCTHTNamNay').val().split(',').join('').split('.').join(''))
				+ ''));
			});

		$('#txtGiaTriDeNghiQuyetToanTrongNam, #txtCong')
			.bind("keypress keyup keydown change blur", function () {
				$('#txtGiaTriCTHTChuyenNamSauQT').text(
					getFormatedNumberString(
				parseFloat($('#txtCong').val().split(',').join('').split('.').join(''))
				- parseFloat($('#txtGiaTriDeNghiQuyetToanTrongNam').val().split(',').join('').split('.').join(''))
				+ ''));
			});
		$('#txtQuyetDinhDieuChinhCuoiCung, #txtGiaTriDeNghiQuyetToanTrongNam')
			.bind("keypress keyup keydown change blur", function () {
				$('#txtKeHoachConDuCuoiNam').text(
					getFormatedNumberString(
				parseFloat($('#txtQuyetDinhDieuChinhCuoiCung').val().split(',').join('').split('.').join(''))
				- parseFloat($('#txtGiaTriDeNghiQuyetToanTrongNam').val().split(',').join('').split('.').join(''))
				+ ''));
			});
		
	},
	editItem: function editGD(button) {
		this.cancel();
		var v_txt_du_an = $(button).parent().parent().find('.du_an');
		$('#btnCapNhat').attr('id_giao_dich', $(v_txt_du_an).attr('id_giao_dich'));
		var lblKeHoachNamTruocChuaChiHetChuyenSang = $(button).parent().parent().find('.KeHoachNamTruocChuaChiHetChuyenSang');
		var lblKeHoachNamTruocChuaChiHetChuyenSang = $(button).parent().parent().find('.so_bao_cao');
		var lblKeHoachNamTruocChuaChiHetChuyenSang = $(button).parent().parent().find('.so_bao_cao');
		var lblKeHoachNamTruocChuaChiHetChuyenSang = $(button).parent().parent().find('.so_bao_cao');
		var lblKeHoachNamTruocChuaChiHetChuyenSang = $(button).parent().parent().find('.so_bao_cao');
		var lblKeHoachNamTruocChuaChiHetChuyenSang = $(button).parent().parent().find('.so_bao_cao');
		var lblKeHoachNamTruocChuaChiHetChuyenSang = $(button).parent().parent().find('.so_bao_cao');
		var txt_so_xet_duyet = $(button).parent().parent().find('.so_xet_duyet');
		var v_str_ma_loai = $(txt_ma_tieu_muc).attr('ma_loai').trim();
		var v_str_ma_khoan = $(txt_ma_tieu_muc).attr('ma_khoan').trim();
		var v_str_ma_muc = $(txt_ma_tieu_muc).attr('ma_muc').trim();
		var v_str_loai = $(txt_ma_tieu_muc).attr('loai').trim();
		$('#txt_loai').val(v_str_ma_loai);
		$('#txt_khoan').val(v_str_ma_khoan);
		$('#txt_muc').val(v_str_ma_muc);
		$('#txt_tieu_muc').val($(txt_ma_tieu_muc).text().trim()).change().focus();
		$('#txt_so_bao_cao').val(getFormatedNumberString($(txt_so_bao_cao).text().trim())).change();
		$('#txt_so_xet_duyet').val(getFormatedNumberString($(txt_so_xet_duyet).text().trim())).change();
		if (v_str_loai.indexOf(strLDC_I) != -1) {
			$('#I').prop('checked', 'checked')
		}
		else {
			$('#II').prop('checked', 'checked')
		}
	},
	update: function UpdateGiaoDich() {
		var v_id_giao_dich = -1;
		var v_dc_id_don_vi = $('#btnCapNhat').attr('id_don_vi');
		if ($('#btnCapNhat').attr('id_giao_dich') != undefined) {
			v_id_giao_dich = $('#btnCapNhat').attr('id_giao_dich');
		}
		var v_str_loai = '';
		if ($('#I').is(':checked')) {
			v_str_loai = strLDC_I;
		}
		else {
			v_str_loai = strLDC_II;
		}
		if (gdPL02.isCheckValidateDataOk()) {
			$.ajax({
				url: '../WebMethod/PL02.asmx/UpdateGiaoDich',
				type: 'post',
				data: {
					ip_dc_id_giao_dich: v_id_giao_dich
					, ip_str_ma_loai: $('#txt_loai').val().trim()
					, ip_str_ma_khoan: $('#txt_khoan').val().trim()
					, ip_str_ma_muc: $('#txt_muc').val().trim()
					, ip_str_ma_tieu_muc: $('#txt_tieu_muc').val().trim()
					, ip_str_so_bao_cao: $('#txt_so_bao_cao').val().trim()
					, ip_str_so_xet_duyet: $('#txt_so_xet_duyet').val().trim()
					, ip_str_noi_dung_chi: $('#lbl_noi_dung_chi').text().trim()
					, ip_str_loai: v_str_loai.trim()
					, ip_dc_id_don_vi: IdDonVi
					, ip_dc_nam: Nam
				},
				dataType: 'text',
				error: function () {
					alert('Xảy ra lỗi trong quá trình thực hiện, Bạn vui lòng thực hiện lại thao tác!');
				},
				success: function () {
					gdPL02.reloadGrid();
				}
			});
		}
		else {
			alert("Dữ liệu Mã Loại, Mã Khoản, Mã Mục, Mã Tiểu mục không đúng! Bạn hãy kiểm tra lại!");
		}

	},
	deleteItem: function deleteGiaoDich(button) {
		var txt_ma_tieu_muc = $(button).parent().parent().find('.ma_tieu_muc');
		var v_id_giao_dich = $(txt_ma_tieu_muc).attr('id_giao_dich');
		var isSureDelete = confirm('Bạn có chắc chắn muốn xoá bản ghi này?');
		if (isSureDelete) {
			$.ajax({
				url: '../WebMethod/PL02.asmx/DeleteGiaoDich',
				type: 'post',
				data: {
					ip_dc_id_giao_dich: v_id_giao_dich
				},
				dataType: 'text',
				error: function () {
					alert('Xảy ra lỗi trong quá trình thực hiện, Bạn vui lòng thực hiện lại thao tác!');
				},
				success: function (data) {
					if (data == "true") {
						gdPL02.reloadGrid();
					}
					else alert('Xảy ra lỗi trong quá trình thực hiện, Bạn vui lòng thực hiện lại thao tác!');
				}
			});
		}
	},
	isCheckValidateDataOk: function () {
		return !($('#txt_loai').css('background-color') == "rgb(211, 211, 211)"//Ma loai nhap sai
			|| $('#txt_khoan').css('background-color') == "rgb(211, 211, 211)"//Ma khoan nhap sai
			|| $('#txt_muc').css('background-color') == "rgb(211, 211, 211)"//Ma muc nhap sai
			|| $('#txt_tieu_muc').css('background-color') == "rgb(211, 211, 211)"//Ma tieu muc nhap sai
			|| $('#txt_loai').val() == ''
			|| $('#txt_khoan').val() == ''
			|| $('#txt_muc').val() == ''
			|| $('#txt_tieu_muc').val() == ''
			)
	}
}
$(document).ready(function () {
	autoFormatInitData();
})