/// <reference path="../jquery-1.4.1.js" />
/// <reference path="../../QuyetToan/PL04_danh_muc_cong_trinh_quyet_toan.aspx" />
/// <reference path="../script.js" />
//function autoFormatInitData() {
//	var lst_str = $('.str_money');
//	for (var i = 0; i < lst_str.length; i++) {
//		$(lst_str[i]).text(getFormatedNumberString($(lst_str[i]).text()));
//	}
//}
var lstParaClass = [".GTDTCTDD", ".GTCTHTNTCNCNN", ".GTCTHTNN", ".DTDNQTTN", ".GTCTHTDQTLKDNBC", ".GTCTHTCNSQT", ".KHCDCN", ".cong"];
var gdPL04 = {
	cancel: function xoa_trang() {
		$('#txtCongTrinh').val('');
		$('#txtDuAn').val('');
		$('#lblKeHoachNamTruocChuaChiHetChuyenSang').text('0');
		$('#lblQuyetDinhDieuChinhCuoiCung').text('0');
		$('.giaoKH').each(function (index, value) {
			$(this).val('0');
		});
		$('#txtGiaTriDuToanCongTrinhDuocDuyet').val('0');
		$('#txtGiaTriCTHTNamTruocConNoChuyenSangNamNay').val('0');
		$('#txtGiaTriCTHTNamNay').val('0');
		$('#lblCong').text('0');
		$('#txtGiaTriDeNghiQuyetToanTrongNam').val('0');
		$('#txtGiaTriCTHTDaQuyetToanLKDenNamBaoCao').val('0');
		$('#txtGiaTriCTHTChuyenNamSauQT').val('0');
		$('#txtKeHoachConDuCuoiNam').val('0')
		$('#btnCapNhat').attr('id_giao_dich', '-1');
	},
	isChangeDataNeedToUpdate: function () {
		lst_input = $('.input_control');
		for (var i = 0; i < lst_input.length; i++) {
			$(lst_input[i]).bind("keypress keyup keydown change blur", function () {
				$(this).parent().parent().find('.cap_nhat').val("Cập nhật").addClass("btn-primary").removeClass("btn-success");
			});
		}
	},
	autoComputedByRow: function (i) {

		var strGiaTriDuToanCongTrinhDuocDuyet = '.GiaTriDuToanCongTrinhDuocDuyet.' + i;
		var strGiaTriCTHTNamTruocConNoChuyenSangNamNay = '.GiaTriCTHTNamTruocConNoChuyenSangNamNay.' + i;
		var strGiaTriGiaTriCTHTNamNay = '.GiaTriCTHTNamNay.' + i;
		var strGiaTriDeNghiQuyetToanTrongNam = '.GiaTriDeNghiQuyetToanTrongNam.' + i;
		var strGiaTriCTHTDaQuyetToanLKDenNamBaoCao = '.GiaTriCTHTDaQuyetToanLKDenNamBaoCao.' + i;
		var strQDDCCC = '.QDDCCC.' + i;
		var strcong = '.cong.' + i;
		var strGTCTHTCNSQT = '.GTCTHTCNSQT.' + i;
		var strKHCDCN = '.KHCDCN.' + i;
		$(strGiaTriCTHTNamTruocConNoChuyenSangNamNay).bind("keypress keyup keydown change blur", function (txtGTCTHTNamNay) {
			$(strcong).text(
				getFormatedNumberString(parseFloat($(strGiaTriGiaTriCTHTNamNay).val().split(',').join('').split('.').join(''))
				+ parseFloat($(strGiaTriCTHTNamTruocConNoChuyenSangNamNay).val().split(',').join('').split('.').join(''))
				+ '')
				).change();
		});
		$(strGiaTriGiaTriCTHTNamNay).bind("keypress keyup keydown change blur", function (txtGTCTHTNamNay) {
			$(strcong).text(
				getFormatedNumberString(parseFloat($(strGiaTriGiaTriCTHTNamNay).val().split(',').join('').split('.').join(''))
				+ parseFloat($(strGiaTriCTHTNamTruocConNoChuyenSangNamNay).val().split(',').join('').split('.').join(''))
				+ '')
				).change();
		});
		$(strcong).bind("keypress keyup keydown change blur", function (txtGTCTHTNamNay) {
			$(strGTCTHTCNSQT).text(
				getFormatedNumberString(parseFloat($(strcong).text().split(',').join('').split('.').join(''))
				- parseFloat($(strGiaTriDeNghiQuyetToanTrongNam).val().split(',').join('').split('.').join(''))
				+ '')
				).change();
		});
		$(strGiaTriDeNghiQuyetToanTrongNam).bind("keypress keyup keydown change blur", function (txtGTCTHTNamNay) {
			$(strGTCTHTCNSQT).text(
				getFormatedNumberString(parseFloat($(strcong).text().split(',').join('').split('.').join(''))
				- parseFloat($(strGiaTriDeNghiQuyetToanTrongNam).val().split(',').join('').split('.').join(''))
				+ '')
				).change();
		});
		$(strQDDCCC).bind("keypress keyup keydown change blur", function (txtGTCTHTNamNay) {
			$(strKHCDCN).text(
				getFormatedNumberString(parseFloat($(strQDDCCC).text().split(',').join('').split('.').join(''))
				- parseFloat($(strGiaTriDeNghiQuyetToanTrongNam).val().split(',').join('').split('.').join(''))
				+ '')
				).change();
		});
		$(strGiaTriDeNghiQuyetToanTrongNam).bind("keypress keyup keydown change blur", function (txtGTCTHTNamNay) {
			$(strKHCDCN).text(
				getFormatedNumberString(parseFloat($(strQDDCCC).text().split(',').join('').split('.').join(''))
				- parseFloat($(strGiaTriDeNghiQuyetToanTrongNam).val().split(',').join('').split('.').join(''))
				+ '')
				).change();
		});

	},
	autoComputedLoaiNhiemVuByCongTrinh: function (index, paraClassValue) {
		var strLNV = paraClassValue + "[ma_so='lnv_" + index + "\'";
		var strCT = paraClassValue + "[ma_so_parent='lnv_" + index + "\'";
		var lstCT = $(strCT);
		for (var i = 0; i < lstCT.length; i++) {
			$(lstCT[i]).bind("keypress keyup keydown change blur", function () {
				var tong = 0;
				for (var j = 0; j < lstCT.length; j++) {
					var elementValue = $(lstCT[j]).text();
					if ($(lstCT[j]).text() == "") {
						elementValue = $(lstCT[j]).val();
					}
					tong = parseFloat(tong) + parseFloat(elementValue.split(',').join('').split('.').join(''));
				}
				$(strLNV).text(getFormatedNumberString(tong));
			});
		}
	},
	autoComputedCongTrinhByDuAn: function (index, paraClassValue) {
		var strCT = paraClassValue + "[ma_so='ct_" + index + "\'";
		var strDA = paraClassValue + "[ma_so_parent='ct_" + index + "\'";
		var lstDA = $(strDA);
		for (var i = 0; i < lstDA.length; i++) {
			$(lstDA[i]).bind("keypress keyup keydown change blur", function () {
				var tong = 0;
				for (var j = 0; j < lstDA.length; j++) {
					var elementValue = $(lstDA[j]).text();
					if ($(lstDA[j]).text() == "") {
						elementValue = $(lstDA[j]).val();
					}
					tong = parseFloat(tong) + parseFloat(elementValue.split(',').join('').split('.').join(''));
				}
				$(strCT).text(getFormatedNumberString(tong)).change();
			});
		}
	},
	check_validate_input: function () {
		return true;
	},
	reloadGrid: function updateGrid() {
		var v_dc_id_don_vi = $('#m_ddl_don_vi').val();
		var v_i_nam = $('#m_txt_nam').val();
		if (this.check_validate_input()) {
			$('#loading').show();
			$.ajax({
				url: '../WebMethod/PL04.asmx/genGrid',
				type: 'post',
				data: {
					ip_dc_id_don_vi: v_dc_id_don_vi
					, ip_i_nam: v_i_nam
				},
				dataType: 'text',
				error: function () {
					$('#loading').hide();
					alert('Xảy ra lỗi trong quá trình thực hiện, Bạn vui lòng thực hiện lại thao tác!');
				},
				success: function (data) {
					$('#loading').hide();
					var grid = data.split("*****")[0];
					MaxLNV = data.split("*****")[1];
					MaxCT = data.split("*****")[2];
					
					$('#grid').empty().append(grid);
					$('#grid').doubleScroll();
					$('#tblPL04').scrollbarTable();
					
					gdPL04.autoValidateInput();
					gdPL04.isChangeDataNeedToUpdate();
					for (var i = 0; i < MaxRecord; i++) {
						gdPL04.autoComputedByRow(i);
					}

					for (var para = 0; para < lstParaClass.length; para++) {
						for (var j = 1; j <= MaxCT; j++) {
							gdPL04.autoComputedCongTrinhByDuAn(j, lstParaClass[para]);
						}
						for (var i = 1; i <= MaxLNV; i++) {
							gdPL04.autoComputedLoaiNhiemVuByCongTrinh(i, lstParaClass[para]);
						}
					}

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
		var lst_str = $('.format_so_tien');
		for (var i = 0; i < lst_str.length; i++) {
			$(lst_str[i]).val(getFormatedNumberString($(lst_str[i]).val()));
		}
		$('.format_so_tien').bind("change blur keyup focus", function (e) {
			var arr_keyCode_comma = [110, 188, 190];


			if ((e.keyCode >= 48 && e.keyCode <= 57)
				|| (e.keyCode >= 96 && e.keyCode <= 105)
				|| Enumerable.From(arr_keyCode_comma)
					.Where(function (x) { return x == e.keyCode })
					.ToArray().length > 0) {
				var str_format = getFormatedNumberString($(this).val().split(",").join("").split(".").join());
				$(this).val(str_format);
			}
		});
		var lst_str = $('.str_money');
		for (var i = 0; i < lst_str.length; i++) {
			$(lst_str[i]).text(getFormatedNumberString($(lst_str[i]).text()));
		}
		$('#txtGiaTriCTHTNamTruocConNoChuyenSangNamNay, #txtGiaTriCTHTNamNay')
			.bind("keypress keyup keydown change blur", function () {
				$('#lblCong').text(
					getFormatedNumberString(
				parseFloat($('#txtGiaTriCTHTNamTruocConNoChuyenSangNamNay').val().split(',').join('').split('.').join(''))
				+ parseFloat($('#txtGiaTriCTHTNamNay').val().split(',').join('').split('.').join(''))
				+ ''));
			});

		$('#txtGiaTriDeNghiQuyetToanTrongNam, #lblCong')
			.bind("keypress keyup keydown change blur", function () {
				$('#lblGiaTriCTHTChuyenNamSauQT').text(
					getFormatedNumberString(
				parseFloat($('#lblCong').text().split(',').join('').split('.').join(''))
				- parseFloat($('#txtGiaTriDeNghiQuyetToanTrongNam').val().split(',').join('').split('.').join(''))
				+ ''));
			});
		$('#lblQuyetDinhDieuChinhCuoiCung, #txtGiaTriDeNghiQuyetToanTrongNam')
			.bind("keypress keyup keydown change blur", function () {
				$('#lblKeHoachConDuCuoiNam').text(
					getFormatedNumberString(
				parseFloat($('#lblQuyetDinhDieuChinhCuoiCung').text().split(',').join('').split('.').join(''))
				- parseFloat($('#txtGiaTriDeNghiQuyetToanTrongNam').val().split(',').join('').split('.').join(''))
				+ ''));
			});

	},
	editItem: function editGD(button) {
		this.cancel();
		var v_txt_du_an = $(button).parent().parent().find('.du_an');
		$('#btnCapNhat').attr('id_giao_dich', $(v_txt_du_an).attr('id_giao_dich'));
		$('#txtCongTrinh').val($(v_txt_du_an).attr('cong_trinh'));
		$('#LoaiNhiemVu').val($(v_txt_du_an).attr('ten_loai_nhiem_vu'));
		$('#txtDuAn').val($(v_txt_du_an).text());
		var lblKeHoachNamTruocChuaChiHetChuyenSang = $(button).parent().parent().find('.KeHoachNamTruocChuaChiHetChuyenSang');
		var lstGiaoKH = $(button).parent().parent().find('.giaoKH');
		var lblQuyetDinhDieuChinhCuoiCung = $(button).parent().parent().find('.QuyetDinhDieuChinhCuoiCung');
		var lblGiaTriDuToanCongTrinhDuocDuyet = $(button).parent().parent().find('.GiaTriDuToanCongTrinhDuocDuyet');
		var lblGiaTriCTHTNamTruocConNoChuyenSangNamNay = $(button).parent().parent().find('.GiaTriCTHTNamTruocConNoChuyenSangNamNay');
		var lblGiaTriCTHTNamNay = $(button).parent().parent().find('.GiaTriCTHTNamNay');
		var lblGiaTriDeNghiQuyetToanTrongNam = $(button).parent().parent().find('.GiaTriDeNghiQuyetToanTrongNam');
		var lblGiaTriCTHTDaQuyetToanLKDenNamBaoCao = $(button).parent().parent().find('.GiaTriCTHTDaQuyetToanLKDenNamBaoCao');
		$('#lblKeHoachNamTruocChuaChiHetChuyenSang').text($(lblKeHoachNamTruocChuaChiHetChuyenSang).text()).change();
		$('#lblQuyetDinhDieuChinhCuoiCung').text($(lblQuyetDinhDieuChinhCuoiCung).text()).change();

		$('#txtGiaTriDuToanCongTrinhDuocDuyet').val($(lblGiaTriDuToanCongTrinhDuocDuyet).text()).change();
		$('#txtGiaTriCTHTNamTruocConNoChuyenSangNamNay').val($(lblGiaTriCTHTNamTruocConNoChuyenSangNamNay).text()).change();
		$('#txtGiaTriCTHTNamNay').val($(lblGiaTriCTHTNamNay).text()).change();
		$('#txtGiaTriDeNghiQuyetToanTrongNam').val($(lblGiaTriDeNghiQuyetToanTrongNam).text()).change();
		$('#txtGiaTriCTHTDaQuyetToanLKDenNamBaoCao').val($(lblGiaTriCTHTDaQuyetToanLKDenNamBaoCao).text()).change();

	},
	update: function UpdateGiaoDich(button) {
		lblDuAN = $(button).parent().parent().find('.du_an')
		txtGTDTCongTrinhDuocDuyet = $(button).parent().parent().find('.GiaTriDuToanCongTrinhDuocDuyet');
		txtGTCTHTNamTruocConNoChuyenSangNamNay = $(button).parent().parent().find('.GiaTriCTHTNamTruocConNoChuyenSangNamNay');
		txtGTCTHTNamNay = $(button).parent().parent().find('.GiaTriCTHTNamNay');
		txtGTDNQTTrongNam = $(button).parent().parent().find('.GiaTriDeNghiQuyetToanTrongNam');
		txtGTCTHTDQTLKDenNamBaoCao = $(button).parent().parent().find('.GiaTriCTHTDaQuyetToanLKDenNamBaoCao');

		if (gdPL04.isCheckValidateDataOk(
			$(txtGTDTCongTrinhDuocDuyet).val()
			, $(txtGTCTHTNamTruocConNoChuyenSangNamNay).val()
			, $(txtGTCTHTNamNay).val()
			, $(txtGTDNQTTrongNam).val()
			, $(txtGTCTHTDQTLKDenNamBaoCao).val()
			)) {
			$.ajax({
				url: '../WebMethod/PL04.asmx/UpdateGiaoDich',
				type: 'post',
				data: {
					ip_dc_id_giao_dich: $(lblDuAN).attr('id_giao_dich')
					, ip_str_TT: $(lblDuAN).attr('ten_loai_nhiem_vu')
					, ip_str_ten_loai_nhiem_vu: $(lblDuAN).attr('ten_loai_nhiem_vu')
					, ip_str_cong_trinh: $(lblDuAN).attr('cong_trinh')
					, ip_str_du_an: $(lblDuAN).text()
					, ip_str_GTDTCongTrinhDuocDuyet: $(txtGTDTCongTrinhDuocDuyet).val()
					, ip_str_GTCTHTNamTruocConNoChuyenSangNamNay: $(txtGTCTHTNamTruocConNoChuyenSangNamNay).val()
					, ip_str_GTCTHTNamNay: $(txtGTCTHTNamNay).val()
					, ip_str_GTDNQTTrongNam: $(txtGTDNQTTrongNam).val()
					, ip_str_GTCTHTDQTLKDenNamBaoCao: $(txtGTCTHTDQTLKDenNamBaoCao).val()

				},
				dataType: 'text',
				error: function () {
					alert('Xảy ra lỗi trong quá trình thực hiện, Bạn vui lòng thực hiện lại thao tác!');
				},
				success: function () {
					//gdPL02.reloadGrid();
					$(button).val("Đã cập nhật").removeClass("btn-primary").addClass("btn-success");
				}
			});
		}
		else {
			alert("Bạn phải nhập số tiền!");
		}

	},
	deleteItem: function deleteGiaoDich(button) {
		var txt_ma_tieu_muc = $(button).parent().parent().find('.ma_tieu_muc');
		var v_id_giao_dich = $(txt_ma_tieu_muc).attr('id_giao_dich');
		var isSureDelete = confirm('Bạn có chắc chắn muốn xoá bản ghi này?');
		if (isSureDelete) {
			//$.ajax({
			//	url: '../WebMethod/PL02.asmx/DeleteGiaoDich',
			//	type: 'post',
			//	data: {
			//		ip_dc_id_giao_dich: v_id_giao_dich
			//	},
			//	dataType: 'text',
			//	error: function () {
			//		alert('Xảy ra lỗi trong quá trình thực hiện, Bạn vui lòng thực hiện lại thao tác!');
			//	},
			//	success: function (data) {
			//		if (data == "true") {
			//			gdPL02.reloadGrid();
			//		}
			//		else alert('Xảy ra lỗi trong quá trình thực hiện, Bạn vui lòng thực hiện lại thao tác!');
			//	}
			//});
		}
	},
	isCheckValidateDataOk: function (strGTDTCongTrinhDuocDuyet
									, strGTCTHTNamTruocConNoChuyenSangNamNay
									, strGTCTHTNamNay
									, strGTDNQTTrongNam
									, strGTCTHTDQTLKDenNamBaoCao) {
		return strGTDTCongTrinhDuocDuyet != ""
		&& strGTCTHTNamTruocConNoChuyenSangNamNay != ""
		&& strGTCTHTNamNay != ""
		&& strGTDNQTTrongNam != ""
		&& strGTCTHTDQTLKDenNamBaoCao != "";
	},
	formatTable: function formatTable() {
		var table = $('#tblPL04').dataTable({

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
			"sDom": 'T<"clear"><"top"f>rt<"bottom">',
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
	updateAll: function () {
		var lstBtnCapNhat = $('.cap_nhat');
		for (var i = 0; i < lstBtnCapNhat.length; i++) {
			$(lstBtnCapNhat[i]).click();
		}
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
	gdPL04.load_data_to_ddl_don_vi(m_lst_don_vi);
	gdPL04.reloadGrid();
	
})