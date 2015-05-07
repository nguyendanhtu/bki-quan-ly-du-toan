var lstClassPara = [".SKNKTNN", ".SKNCQTC", ".SDNKTNN", ".SDNCQTC"];
var PL03 = {
	initialFormLoad: function () {
		PL03.load_data_to_ddl_don_vi(m_lst_don_vi);
		PL03.reloadGrid();
		PL03.autoFormatInitialDataDisplay();
		PL03.isChangeDataNeedToUpdate();
		for (var ma_so = 0; ma_so < 20; ma_so++) {

			PL03.autoComputedByRow(ma_so);
			for (var i = 0; i < lstClassPara.length; i++) {
				PL03.autoComputedParentByMaSo(ma_so, lstClassPara[i]);
			}
		}
	},
	autoComputedParentByMaSo: function (index, paraClassValue) {
		var strparent = paraClassValue + "[ma_so='" + index + "\'";
		var strChildren = paraClassValue + "[ma_so_parent='" + index + "\'";
		var strChildren = $(strChildren);
		for (var i = 0; i < strChildren.length; i++) {
			$(strChildren[i]).bind("keypress keyup keydown change blur", function () {
				var tong = 0;
				for (var j = 0; j < strChildren.length; j++) {
					var elementValue = $(strChildren[j]).text();
					if ($(strChildren[j]).text() == "") {
						elementValue = $(strChildren[j]).val();
					}
					tong = parseFloat(tong) + parseFloat(elementValue.split(',').join('').split('.').join(''));
				}
				$(strparent).val(getFormatedNumberString(tong)).change();
			});
		}
	},
	autoFormatInitialDataDisplay: function initialRelation() {
		var lst_str = $('.format_so_tien');
		for (var i = 0; i < lst_str.length; i++) {
			$(lst_str[i]).val(getFormatedNumberString($(lst_str[i]).val().split(",").join("").split(".").join()));
		}
		var lst_str = $('.str_money');
		for (var i = 0; i < lst_str.length; i++) {
			$(lst_str[i]).text(getFormatedNumberString($(lst_str[i]).text().split(",").join("").split(".").join()));
		}
	},
	autoComputedByRow: function (index) {
		var strSKNTong = ".SKNTong[ma_so='" + index + "\'";
		var strSKNKTNN = ".SKNKTNN[ma_so='" + index + "\'";
		var strSKNCQTC = ".SKNCQTC[ma_so='" + index + "\'";

		var strSDNTong = ".SDNTong[ma_so='" + index + "\'";
		var strSDNKTNN = ".SDNKTNN[ma_so='" + index + "\'";
		var strSDNCQTC = ".SDNCQTC[ma_so='" + index + "\'";

		var strSCPNTong = ".SCPNTong[ma_so='" + index + "\'";
		var strSCPNKTNN = ".SCPNKTNN[ma_so='" + index + "\'";
		var strSCPNCQTC = ".SCPNCQTC[ma_so='" + index + "\'";

		//So kien nghi kiem toan nha nuoc, co quan tai chinh
		//2
		$(strSKNKTNN).bind("keypress keyup keydown change blur", function () {
			//1=2+3
			$(strSKNTong).text(
				getFormatedNumberString(
				parseFloat($(strSKNKTNN).val().split(',').join('').split('.').join(''))
				+ parseFloat($(strSKNCQTC).val().split(',').join('').split('.').join('')))
				).change();
			//8=2-5
			$(strSCPNKTNN).text(
				getFormatedNumberString(
				parseFloat($(strSKNKTNN).val().split(',').join('').split('.').join(''))
				- parseFloat($(strSDNKTNN).val().split(',').join('').split('.').join('')))
				).change();

		});
		//3
		$(strSKNCQTC).bind("keypress keyup keydown change blur", function () {
			//1=2+3
			$(strSKNTong).text(
				getFormatedNumberString(
				parseFloat($(strSKNKTNN).val().split(',').join('').split('.').join(''))
				+ parseFloat($(strSKNCQTC).val().split(',').join('').split('.').join('')))
				).change();
			//9=3-6
			$(strSCPNCQTC).text(
				getFormatedNumberString(
				parseFloat($(strSKNCQTC).val().split(',').join('').split('.').join(''))
				- parseFloat($(strSDNCQTC).val().split(',').join('').split('.').join('')))
				).change();
		});

		//So de nghi kiem toan nha nuoc, co quan tai chinh
		//5
		$(strSDNKTNN).bind("keypress keyup keydown change blur", function () {
			//4=5+6
			$(strSDNTong).text(
				getFormatedNumberString(
				parseFloat($(strSDNKTNN).val().split(',').join('').split('.').join(''))
				+ parseFloat($(strSDNCQTC).val().split(',').join('').split('.').join('')))
				).change();
			//8=2-5
			$(strSCPNKTNN).text(
				getFormatedNumberString(
				parseFloat($(strSKNKTNN).val().split(',').join('').split('.').join(''))
				- parseFloat($(strSDNKTNN).val().split(',').join('').split('.').join('')))
				).change();
		});
		//6
		$(strSDNCQTC).bind("keypress keyup keydown change blur", function () {
			//4=5+6
			$(strSDNTong).text(
				getFormatedNumberString(
				parseFloat($(strSDNKTNN).val().split(',').join('').split('.').join(''))
				+ parseFloat($(strSDNCQTC).val().split(',').join('').split('.').join('')))
				).change();
			//9=3-6
			$(strSCPNCQTC).text(
				getFormatedNumberString(
				parseFloat($(strSKNCQTC).val().split(',').join('').split('.').join(''))
				- parseFloat($(strSDNCQTC).val().split(',').join('').split('.').join('')))
				).change();
		});

		//So con phai nop Quy bao tri
		//8
		$(strSCPNCQTC).bind("keypress keyup keydown change blur", function () {
			//7=8+9
			$(strSCPNTong).text(
				getFormatedNumberString(
				parseFloat($(strSCPNCQTC).text().split(',').join('').split('.').join(''))
				+ parseFloat($(strSCPNKTNN).text().split(',').join('').split('.').join('')))
				).change();
		});
		//9
		$(strSCPNKTNN).bind("keypress keyup keydown change blur", function () {
			//7=8+9
			$(strSCPNTong).text(
				getFormatedNumberString(
				parseFloat($(strSCPNCQTC).text().split(',').join('').split('.').join(''))
				+ parseFloat($(strSCPNKTNN).text().split(',').join('').split('.').join('')))
				).change();
		});
	},
	isChangeDataNeedToUpdate: function () {
		lst_input = $('.input_control');
		for (var i = 0; i < lst_input.length; i++) {
			$(lst_input[i]).bind("keypress keyup keydown change blur", function () {
				$(this).parent().parent().find('.cap_nhat').val("Cập nhật").addClass("btn-primary").removeClass("btn-success");
			});
		}
	},
	updateGiaoDich: function (button) {
		var txtSKNKTNN = $(button).parent().parent().find('.SKNKTNN');
		var txtSKNCQTC = $(button).parent().parent().find('.SKNCQTC');
		var txtSDNKTNN = $(button).parent().parent().find('.SDNKTNN');
		var txtSDNCQTC = $(button).parent().parent().find('.SDNCQTC');
		var idGiaoDich = $(button).parent().parent().find('.noi_dung').attr('id_giao_dich');
		$.ajax({
			url: '../WebMethod/PL03.asmx/UpdateGiaoDich',
			type: 'post',
			data: {
				ip_dc_id_giao_dich: idGiaoDich
				, ip_str_SKNKTNN: $(txtSKNKTNN).val()
				, ip_str_SKNCQTC: $(txtSKNCQTC).val()
				, ip_str_SDNKTNN: $(txtSDNKTNN).val()
				, ip_str_SDNCQTC: $(txtSDNCQTC).val()
			},
			dataType: 'text',
			error: function () {
				alert('Xảy ra lỗi trong quá trình thực hiện, Bạn vui lòng thực hiện lại thao tác!');
			},
			success: function () {
				$(button).val("Đã cập nhật").removeClass("btn-primary").addClass("btn-success");
			}
		})
	},
	updateAll: function () {
		var lstBtnCapNhat = $('.cap_nhat');
		for (var i = 0; i < lstBtnCapNhat.length; i++) {
			$(lstBtnCapNhat[i]).click();
		}
	},
	check_validate_input: function () {
		return true;
	},
	load_data_to_ddl_don_vi: function (lst) {
		var html_don_vi = "";
		for (var i = 0; i < lst.length; i++) {
			html_don_vi += "<option value='" + lst[i].ID + "'>" + lst[i].TEN_DON_VI + "</option>";
		}
		$('#m_ddl_don_vi').empty().append(html_don_vi).select2();
		//.change() event to call reloadGrid()
	},
	reloadGrid: function () {
		if (this.check_validate_input()) {
			$('#loading').show();
			var v_dc_id_don_vi = $('#m_ddl_don_vi').val();
			var v_i_nam = $('#m_txt_nam').val();
			$.ajax({
				url: '../WebMethod/PL03.asmx/genGrid',
				type: 'post',
				data: {
					ip_dc_id_don_vi: v_dc_id_don_vi
					, ip_i_nam: v_i_nam
				},
				success: function (data) {
					$('#loading').hide();
					$('#grid').empty().append(data);
					PL03.autoFormatInitialDataDisplay();
					PL03.isChangeDataNeedToUpdate();
					for (var ma_so = 0; ma_so < 20; ma_so++) {

						PL03.autoComputedByRow(ma_so);
						for (var i = 0; i < lstClassPara.length; i++) {
							PL03.autoComputedParentByMaSo(ma_so, lstClassPara[i]);
						}
					}
				},
				error: function (data) {
					$('#loading').hide();
					alert('Đã có lỗi xảy ra trong quá trình thực hiện, Bạn vui lòng thực hiện lại thao tác!');
				}
			})
		}
	}
}

$(document).ready(function () {
	PL03.initialFormLoad();
})