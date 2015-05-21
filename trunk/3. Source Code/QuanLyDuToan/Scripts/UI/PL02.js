var gdPL02 = {
	cancel: function xoa_trang() {
		$('#btnCapNhat').val('Ghi dữ liệu');
		$('#txt_loai').val('');
		$('#txt_khoan').val('');
		$('#txt_muc').val('');
		$('#txt_so_bao_cao').val('0');
		$('#txt_so_xet_duyet').val('0');
		$('#txt_tieu_muc').val('').change();
		$('#btnCapNhat').attr('id_giao_dich', '-1');
		$('#I').prop('checked', 'checked')
	},
	check_validate_input: function () {
		return true;
	},
	reloadGrid: function updateGrid() {

		var v_id_don_vi = $('#m_ddl_don_vi').val();
		var v_i_nam = $('#m_txt_nam').val();
		if (this.check_validate_input()) {
			$('#loading').show();
			$.ajax({
				url: '../WebMethod/PL02.asmx/genGrid',
				type: 'post',
				data: {
					ip_dc_id_don_vi: v_id_don_vi
					, ip_i_nam: v_i_nam
				},
				dataType: 'text',
				error: function () {
					$('#loading').hide();
					alert('Xảy ra lỗi trong quá trình thực hiện, Bạn vui lòng thực hiện lại thao tác!');
				},
				success: function (data) {
					$('#loading').hide();
					$('#grid').empty().append(data);
					gdPL02.autoValidateInput();

					if (m_dc_id_don_vi == $('#m_ddl_don_vi').val()) {
						$('.thao_tac').show();
					}
					else {
						$('.thao_tac').hide();
					}
				}
			});
		}
	},
	autoValidateInput: function initialRelation() {
		var lst_str = $('.str_money');
		for (var i = 0; i < lst_str.length; i++) {
			$(lst_str[i]).text(getFormatedNumberString($(lst_str[i]).text()));
		}
		CCommon.format_so_tien();
		$('#txt_so_bao_cao, #txt_so_xet_duyet').bind("keypress keyup keydown change blur", function () {
			$('#lbl_chenh_lech').text(getFormatedNumberString(
				parseFloat($('#txt_so_bao_cao').val().split(',').join('').split('.').join(''))
				- parseFloat($('#txt_so_xet_duyet').val().split(',').join('').split('.').join(''))
				+ ''));
		});
		$('#txt_loai').bind("keypress keyup keydown change blur", function () {
			var arr_noi_dung_chi = $.grep(m_lst_clkm, function (element, index) {
				return element.MaSo == $('#txt_loai').val()
					&& element.IdLoai == idLoai;
			});
			if (arr_noi_dung_chi.length < 1) {
				$('#txt_loai').css('background', 'lightgray');
			}
			else {
				$('#txt_loai').css('background', 'white');
				$('#txt_khoan').change();
			}
		});
		$('#txt_khoan').bind("keypress keyup keydown change blur", function () {
			var arr_noi_dung_chi = $.grep(m_lst_clkm, function (element, index) {
				return element.MaSo == $('#txt_khoan').val()
					&& element.IdLoai == idKhoan
					&& element.MaSoParent == $('#txt_loai').val();
			});
			if (arr_noi_dung_chi.length < 1) {
				$('#txt_khoan').css('background', 'lightgray');
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
				$('#txt_muc').css('background', 'lightgray');
			}
			else {
				$('#txt_muc').css('background', 'white');
				$('#txt_tieu_muc').change();
			}
		});
		$('#txt_tieu_muc').bind("keypress keyup keydown change blur", function () {
			var arr_noi_dung_chi = $.grep(m_lst_clkm, function (element, index) {
				return element.MaSo == $('#txt_tieu_muc').val().trim()
					&& element.IdLoai == idTieuMuc
					&& element.MaSoParent == $('#txt_muc').val().trim();
			});
			if (arr_noi_dung_chi.length < 1) {
				$('#txt_tieu_muc').css('background', 'lightgray');
				$('#lbl_noi_dung_chi').text('');
			}
			else {
				$('#txt_tieu_muc').css('background', 'white');
				$('#lbl_noi_dung_chi').text(arr_noi_dung_chi[0].Ten);
			}
		});
	},
	editItem: function editGD(button) {
		this.cancel();
		$('#btnCapNhat').val('Cập nhật')
		var txt_ma_tieu_muc = $(button).parent().parent().find('.ma_tieu_muc');
		$('#btnCapNhat').attr('id_giao_dich', $(txt_ma_tieu_muc).attr('id_giao_dich'));
		var txt_so_bao_cao = $(button).parent().parent().find('.so_bao_cao');
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
			$('#loading').show();
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
					, ip_dc_id_don_vi: $('#m_ddl_don_vi').val()
					, ip_dc_nam: $('#m_txt_nam').val()
				},
				dataType: 'text',
				error: function () {
					$('#loading').hide();
					alert('Xảy ra lỗi trong quá trình thực hiện, Bạn vui lòng thực hiện lại thao tác!');
				},
				success: function () {
					$('#loading').hide();
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
	},
	formatTable: function formatTable() {
		var table = $('#tblPL02').dataTable({

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
	},
	load_data_to_ddl_don_vi: function (lst) {
		var html_don_vi = "";
		for (var i = 0; i < lst.length; i++) {
			html_don_vi += "<option value='" + lst[i].ID + "'>" + lst[i].TEN_DON_VI + "</option>";
		}
		$('#m_ddl_don_vi').empty().append(html_don_vi).select2();
		//.change() event to call reloadGrid()
	},
}
$(document).ready(function () {
	var IdGiaoDich = -1;
	gdPL02.load_data_to_ddl_don_vi(m_lst_don_vi);
	gdPL02.autoValidateInput();
	gdPL02.reloadGrid();
})
