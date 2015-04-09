/// <reference path="../../QuyetToan/PL05_DanhMucGiaTriCongTrinhHoanThanhGiamTruThanhToan.aspx" />
/// <reference path="../linq.js" />
/// <reference path="../jquery.linq.js" />
/// <reference path="../jquery.bpopup.js" />
/// <reference path="../jquery.bpopup.js" />
/// <reference path="../script.js" />
/// <reference path="../jquery-1.4.1.js" />

var lstClassPara = [".GTKLCTHTTN", ".GTKLDQT"];
var PL05 = {
	loadDataToLoaiNhiemVu: function () {
		var html = "";
		var lstLNV = Enumerable.From(lstPL04)
							.Select(function (x) { return { TT: x.TT, TEN_LOAI_NHIEM_VU: x.TEN_LOAI_NHIEM_VU } })
							.Distinct(function (x) { return x.TT })
							.OrderBy(function (x) { return x.TT })
							.ToArray();
		for (var i = 0; i < lstLNV.length; i++) {
			html += "<option value='" + lstLNV[i].TEN_LOAI_NHIEM_VU + "'>" + lstLNV[i].TT + " - " + lstLNV[i].TEN_LOAI_NHIEM_VU + "</<option>";
		}
		$('#m_cbo_loai_nhiem_vu').empty();
		$('#m_cbo_loai_nhiem_vu').append(html);
		$('#m_cbo_loai_nhiem_vu').select2();
	},
	loadDataToCongTrinh: function () {
		var html = "";
		var tenLNV = $('#m_cbo_loai_nhiem_vu').val();
		var lstCongTrinh = Enumerable.From(lstPL04)
							.Where(function (x) { return x.TEN_LOAI_NHIEM_VU == tenLNV })
							.Select(function (x) { return x.CONG_TRINH })
							.Distinct(function (x) { return x })
							.ToArray();
		for (var i = 0; i < lstCongTrinh.length; i++) {
			html += "<option value='" + lstCongTrinh[i] + "'>" + lstCongTrinh[i] + "</<option>";
			$('#m_cbo_cong_trinh').empty();
			$('#m_cbo_cong_trinh').append(html);
			$('#m_cbo_cong_trinh').select2();
			$('#cong_trinh').text($('#m_cbo_cong_trinh').val());
		}
	},
	loadDataToDuAn: function () {
		var html = "";
		var tenLNV = $('#m_cbo_loai_nhiem_vu').val();
		var tenCT = $('#m_cbo_cong_trinh').val();
		var lstDuAn = Enumerable.From(lstPL04)
							.Where(function (x) { return x.TEN_LOAI_NHIEM_VU == tenLNV && x.CONG_TRINH == tenCT })
							.Select(function (x) { return x.DU_AN })
							.Distinct(function (x) { return x })
							.ToArray();
		for (var i = 0; i < lstDuAn.length; i++) {
			html += "<option value='" + lstDuAn[i] + "'>" + lstDuAn[i] + "</<option>";
			$('#m_cbo_du_an').empty();
			$('#m_cbo_du_an').append(html);
			$('#m_cbo_du_an').select2();
			$('#du_an').text($('#m_cbo_du_an').val());
		}
	},
	initialEvents: function () {
		$('#m_cbo_loai_nhiem_vu').change(function () {
			PL05.loadDataToCongTrinh();
			PL05.loadDataToDuAn();
		});
		$('#m_cbo_cong_trinh').change(function () {
			PL05.loadDataToDuAn();
			$('#cong_trinh').text($(this).val());
		});
		$('#m_cbo_du_an').change(function () {
			$('#du_an').text($(this).val());
		});
	},
	autoComputedParentByMaSo: function (index, paraClassValue, idClass) {
		var strparent = '#' + idClass + ' tbody>tr ' + paraClassValue + "[ma_so='" + index + "\']";
		var strChildren = '#' + idClass + ' tbody>tr ' + paraClassValue + "[ma_so_parent='" + index + "\']";
		var lstChildren = $(strChildren);
		for (var i = 0; i < lstChildren.length; i++) {
			$(lstChildren[i]).bind("keypress keyup keydown change blur", function () {
				var tong = 0;
				for (var j = 0; j < lstChildren.length; j++) {
					var elementValue = $(lstChildren[j]).text();
					if ($(lstChildren[j]).text() == "") {
						elementValue = $(lstChildren[j]).val();
					}
					tong = parseFloat(tong) + parseFloat(elementValue.split(',').join('').split('.').join(''));
				}
				if ($(strparent).is('td')) {
					$(strparent).text(getFormatedNumberString(tong)).change();
				}
				else $(strparent).val(getFormatedNumberString(tong)).change();
			});
		}
	},
	editItem: function (button, idGD, TenLoaiNhiemVu, CongTrinh, DuAn) {
		$('#ThongTinChung').attr('id_giao_dich', idGD);
		$('#m_cbo_loai_nhiem_vu').val(TenLoaiNhiemVu.trim()).change();
		$('#m_cbo_cong_trinh').val(CongTrinh.trim()).change();
		$('#m_cbo_du_an').val(DuAn.trim()).change();
		var strClassCurrentRow = "#tbl_pl05 tbody > tr [id_gd='" + idGD + "']";
		$('#' + 'I_GTKLDQT').val('0').val($(strClassCurrentRow).parent().find('.' + 'I_GTKLDQT').text()).change();
		$('#' + 'I_GTKLCTHTTN').val('0').val($(strClassCurrentRow).parent().find('.' + 'I_GTKLCTHTTN').text()).change();
		$('#' + 'II_GTKLDQT').val('0').val($(strClassCurrentRow).parent().find('.' + 'II_GTKLDQT').text()).change();
		$('#' + 'II_GTKLCTHTTN').val('0').val($(strClassCurrentRow).parent().find('.' + 'II_GTKLCTHTTN').text()).change();
		$('#' + 'III_1_GTKLDQT').val('0').val($(strClassCurrentRow).parent().find('.' + 'III_1_GTKLDQT').text()).change();
		$('#' + 'III_1_GTKLCTHTTN').val('0').val($(strClassCurrentRow).parent().find('.' + 'III_1_GTKLCTHTTN').text()).change();
		$('#' + 'III_2_GTKLDQT').val('0').val($(strClassCurrentRow).parent().find('.' + 'III_2_GTKLDQT').text()).change();
		$('#' + 'III_2_GTKLCTHTTN').val('0').val($(strClassCurrentRow).parent().find('.' + 'III_2_GTKLCTHTTN').text()).change();
		$('#' + 'III_3_GTKLDQT').val('0').val($(strClassCurrentRow).parent().find('.' + 'III_3_GTKLDQT').text()).change();
		$('#' + 'III_3_GTKLCTHTTN').val('0').val($(strClassCurrentRow).parent().find('.' + 'III_3_GTKLCTHTTN').text()).change();
		$('#' + 'IV_1_GTKLDQT').val('0').val($(strClassCurrentRow).parent().find('.' + 'IV_1_GTKLDQT').text()).change();
		$('#' + 'IV_1_GTKLCTHTTN').val('0').val($(strClassCurrentRow).parent().find('.' + 'IV_1_GTKLCTHTTN').text()).change();
		$('#' + 'IV_2_GTKLDQT').val('0').val($(strClassCurrentRow).parent().find('.' + 'IV_2_GTKLDQT').text()).change();
		$('#' + 'IV_2_GTKLCTHTTN').val('0').val($(strClassCurrentRow).parent().find('.' + 'IV_2_GTKLCTHTTN').text()).change();
		$('#' + 'IV_3_GTKLDQT').val('0').val($(strClassCurrentRow).parent().find('.' + 'IV_3_GTKLDQT').text()).change();
		$('#' + 'IV_3_GTKLCTHTTN').val('0').val($(strClassCurrentRow).parent().find('.' + 'IV_3_GTKLCTHTTN').text()).change();
		$('#' + 'IV_4_GTKLDQT').val('0').val($(strClassCurrentRow).parent().find('.' + 'IV_4_GTKLDQT').text()).change();
		$('#' + 'IV_4_GTKLCTHTTN').val('0').val($(strClassCurrentRow).parent().find('.' + 'IV_4_GTKLCTHTTN').text()).change();
		$('#' + 'V_GTKLDQT').val('0').val($(strClassCurrentRow).parent().find('.' + 'V_GTKLDQT').text()).change();
		$('#' + 'V_GTKLCTHTTN').val('0').val($(strClassCurrentRow).parent().find('.' + 'V_GTKLCTHTTN').text()).change();

		$('#ThongTinChung').bPopup();

	},
	deleteItem: function (idGD) {

	},
	checkValidateDataIsOk: function () {
		if ($('#' + 'I_GTKLDQT').val() == '') { alert('Bạn phải nhập số tiền'); $('#' + 'I_GTKLDQT').focus(); return false; }
		if ($('#' + 'I_GTKLCTHTTN').val() == '') { alert('Bạn phải nhập số tiền'); $('#' + 'I_GTKLCTHTTN').focus(); return false; }
		if ($('#' + 'II_GTKLDQT').val() == '') { alert('Bạn phải nhập số tiền'); $('#' + 'II_GTKLDQT').focus(); return false; }
		if ($('#' + 'II_GTKLCTHTTN').val() == '') { alert('Bạn phải nhập số tiền'); $('#' + 'II_GTKLCTHTTN').focus(); return false; }
		if ($('#' + 'III_1_GTKLDQT').val() == '') { alert('Bạn phải nhập số tiền'); $('#' + 'III_1_GTKLDQT').focus(); return false; }
		if ($('#' + 'III_1_GTKLCTHTTN').val() == '') { alert('Bạn phải nhập số tiền'); $('#' + 'III_1_GTKLCTHTTN').focus(); return false; }
		if ($('#' + 'III_2_GTKLDQT').val() == '') { alert('Bạn phải nhập số tiền'); $('#' + 'III_2_GTKLDQT').focus(); return false; }
		if ($('#' + 'III_2_GTKLCTHTTN').val() == '') { alert('Bạn phải nhập số tiền'); $('#' + 'III_2_GTKLCTHTTN').focus(); return false; }
		if ($('#' + 'III_3_GTKLDQT').val() == '') { alert('Bạn phải nhập số tiền'); $('#' + 'III_3_GTKLDQT').focus(); return false; }
		if ($('#' + 'III_3_GTKLCTHTTN').val() == '') { alert('Bạn phải nhập số tiền'); $('#' + 'III_3_GTKLCTHTTN').focus(); return false; }
		if ($('#' + 'IV_1_GTKLDQT').val() == '') { alert('Bạn phải nhập số tiền'); $('#' + 'IV_1_GTKLDQT').focus(); return false; }
		if ($('#' + 'IV_1_GTKLCTHTTN').val() == '') { alert('Bạn phải nhập số tiền'); $('#' + 'IV_1_GTKLCTHTTN').focus(); return false; }
		if ($('#' + 'IV_2_GTKLDQT').val() == '') { alert('Bạn phải nhập số tiền'); $('#' + 'IV_2_GTKLDQT').focus(); return false; }
		if ($('#' + 'IV_2_GTKLCTHTTN').val() == '') { alert('Bạn phải nhập số tiền'); $('#' + 'IV_2_GTKLCTHTTN').focus(); return false; }
		if ($('#' + 'IV_3_GTKLDQT').val() == '') { alert('Bạn phải nhập số tiền'); $('#' + 'IV_3_GTKLDQT').focus(); return false; }
		if ($('#' + 'IV_3_GTKLCTHTTN').val() == '') { alert('Bạn phải nhập số tiền'); $('#' + 'IV_3_GTKLCTHTTN').focus(); return false; }
		if ($('#' + 'IV_4_GTKLDQT').val() == '') { alert('Bạn phải nhập số tiền'); $('#' + 'IV_4_GTKLDQT').focus(); return false; }
		if ($('#' + 'IV_4_GTKLCTHTTN').val() == '') { alert('Bạn phải nhập số tiền'); $('#' + 'IV_4_GTKLCTHTTN').focus(); return false; }
		if ($('#' + 'V_GTKLDQT').val() == '') { alert('Bạn phải nhập số tiền'); $('#' + 'V_GTKLDQT').focus(); return false; }
		if ($('#' + 'V_GTKLCTHTTN').val() == '') { alert('Bạn phải nhập số tiền'); $('#' + 'V_GTKLCTHTTN').focus(); return false; }

		return true;
	},
	updateGiaoDich: function () {
		if (this.checkValidateDataIsOk()) {
			$.ajax({
				url: '../WebMethod/PL05.asmx/UpdateGiaoDich',
				type: 'post',
				data: {
					ip_dc_id_giao_dich:$('#ThongTinChung').attr('id_giao_dich'),
					ip_str_I_GTKLDQT: $('#' + 'I_GTKLDQT').val(),
					ip_str_I_GTKLCTHTTN: $('#' + 'I_GTKLCTHTTN').val(),
					ip_str_II_GTKLDQT: $('#' + 'II_GTKLDQT').val(),
					ip_str_II_GTKLCTHTTN: $('#' + 'II_GTKLCTHTTN').val(),
					ip_str_III_1_GTKLDQT: $('#' + 'III_1_GTKLDQT').val(),
					ip_str_III_1_GTKLCTHTTN: $('#' + 'III_1_GTKLCTHTTN').val(),
					ip_str_III_2_GTKLDQT: $('#' + 'III_2_GTKLDQT').val(),
					ip_str_III_2_GTKLCTHTTN: $('#' + 'III_2_GTKLCTHTTN').val(),
					ip_str_III_3_GTKLDQT: $('#' + 'III_3_GTKLDQT').val(),
					ip_str_III_3_GTKLCTHTTN: $('#' + 'III_3_GTKLCTHTTN').val(),
					ip_str_IV_1_GTKLDQT: $('#' + 'IV_1_GTKLDQT').val(),
					ip_str_IV_1_GTKLCTHTTN: $('#' + 'IV_1_GTKLCTHTTN').val(),
					ip_str_IV_2_GTKLDQT: $('#' + 'IV_2_GTKLDQT').val(),
					ip_str_IV_2_GTKLCTHTTN: $('#' + 'IV_2_GTKLCTHTTN').val(),
					ip_str_IV_3_GTKLDQT: $('#' + 'IV_3_GTKLDQT').val(),
					ip_str_IV_3_GTKLCTHTTN: $('#' + 'IV_3_GTKLCTHTTN').val(),
					ip_str_IV_4_GTKLDQT: $('#' + 'IV_4_GTKLDQT').val(),
					ip_str_IV_4_GTKLCTHTTN: $('#' + 'IV_4_GTKLCTHTTN').val(),
					ip_str_V_GTKLDQT: $('#' + 'V_GTKLDQT').val(),
					ip_str_V_GTKLCTHTTN: $('#' + 'V_GTKLCTHTTN').val(),
					ip_str_ten_loai_nhiem_vu: $('#m_cbo_loai_nhiem_vu').val(),
					ip_str_cong_trinh: $('#m_cbo_cong_trinh').val(),
					ip_str_du_an: $('#m_cbo_du_an').val(),
					ip_dc_nam: $('#m_cbo_nam').val(),
					ip_dc_id_don_vi:$('#tbl_pl05').attr('id_don_vi')

				},
				dataType: 'text',
				error: function () {
					alert('Xảy ra lỗi trong quá trình thực hiện, Bạn vui lòng thực hiện lại thao tác!');
				},
				success: function (data) {
					PL05.cancel();
					//Reload Grid;

				}
			});
		}
	},
	addItem: function () {
		$('#ThongTinChung').attr('id_giao_dich', -1);
		$('#' + 'I_GTKLDQT').val('0').change()
		$('#' + 'I_GTKLCTHTTN').val('0').change()
		$('#' + 'II_GTKLDQT').val('0').change()
		$('#' + 'II_GTKLCTHTTN').val('0').change()
		$('#' + 'III_1_GTKLDQT').val('0').change()
		$('#' + 'III_1_GTKLCTHTTN').val('0').change()
		$('#' + 'III_2_GTKLDQT').val('0').change()
		$('#' + 'III_2_GTKLCTHTTN').val('0').change()
		$('#' + 'III_3_GTKLDQT').val('0').change()
		$('#' + 'III_3_GTKLCTHTTN').val('0').change()
		$('#' + 'IV_1_GTKLDQT').val('0').change()
		$('#' + 'IV_1_GTKLCTHTTN').val('0').change()
		$('#' + 'IV_2_GTKLDQT').val('0').change()
		$('#' + 'IV_2_GTKLCTHTTN').val('0').change()
		$('#' + 'IV_3_GTKLDQT').val('0').change()
		$('#' + 'IV_3_GTKLCTHTTN').val('0').change()
		$('#' + 'IV_4_GTKLDQT').val('0').change()
		$('#' + 'IV_4_GTKLCTHTTN').val('0').change()
		$('#' + 'V_GTKLDQT').val('0').change()
		$('#' + 'V_GTKLCTHTTN').val('0').change()
		$('#ThongTinChung').bPopup();
	},
	cancel: function () {
		$('#ThongTinChung').attr('id_giao_dich', -1);
		$('#ThongTinChung').bPopup().close();
	},
	initialFormLoad: function () {
		PL05.cancel();
	},
	formatSoTien: function () {
		var lstStrSoTien = $('.str_money');
		for (var i = 0; i < lstStrSoTien.length; i++) {
			$(lstStrSoTien[i]).text(getFormatedNumberString($(lstStrSoTien[i]).text()));
		}
		var lstFormatSoTien = $('.format_so_tien');
		for (var i = 0; i < lstFormatSoTien.length; i++) {
			$(lstFormatSoTien[i]).val(getFormatedNumberString($(lstFormatSoTien[i]).val()));
		}
	}

}



$(document).ready(function () {
	PL05.loadDataToLoaiNhiemVu();
	PL05.loadDataToCongTrinh();
	PL05.loadDataToDuAn();
	PL05.initialEvents();
	for (var para = 0; para < lstClassPara.length; para++) {
		for (var i = 1; i < 20; i++) {
			//PL05.autoComputedParentByMaSo(i, lstClassPara[para], 'tbl_pl05');
			PL05.autoComputedParentByMaSo(i, lstClassPara[para], 'tblDetail');
		}
	}
	PL05.formatSoTien();
	//PL05.initialFormLoad();
});