/// <reference path="../../DuToan/F104_nhap_du_toan_ke_hoach.aspx" />
/// <reference path="../linq.js" />
/// <reference path="../jquery.linq.js" />
var F505 = {
	initialControl: function () {
		$('#m_ddl_quyet_dinh').select2();

	},
	Message: function (message) {
		alert(message);
	},
	reloadGrid: function (id_quyet_dinh, id_don_vi) {
		var id_quyet_dinh = $('#m_ddl_quyet_dinh').val();
		$.ajax({
			url: '../WebMethod/F505.asmx/genGrid',
			type: 'post',
			data: {
				ip_dc_id_quyet_dinh: id_quyet_dinh
				, ip_dc_id_don_vi: m_dc_id_don_vi
			},
			dataType: 'text',
			error: function () {
				F505.Message('Xảy ra lỗi trong quá trình thực hiện, Bạn vui lòng thực hiện lại thao tác!');
			},
			success: function (data) {
				//append grid
				

				//initial cong thuc

			}
		});

	},
	check_data_is_validate: function (button) {
		var tt = $(button).parent().parent().find('.tt').val();
		var hang_muc = $(button).parent().parent().find('.hang_muc').val() + "";
		var kinh_phi_giao = $(button).parent().parent().find('.kinh_phi_giao').val() + "";
		if (hang_muc == "undefined" || hang_muc.trim() == "") {
			this.Message("Bạn phải nhập Hạng mục!");
			$($(button).parent().parent().find('.hang_muc')).focus();
			return false;
		}
		if (kinh_phi_giao == "undefined" || kinh_phi_giao.trim() == "") {
			this.Message("Bạn phải nhập Kinh phí giao!");
			$($(button).parent().parent().find('.kinh_phi_giao')).focus();

			return false;
		}
		return true;
	},
	addSubItem: function (button, ma_so_parent) {
		$('#ThongTinChung').attr('ma_so_parent', ma_so_parent).bPopup();
		console.log('addItem, ma_so_parent = ' + $('#ThongTinChung').attr('ma_so_parent'));
	},
	deleteItem: function (button, id_giao_dich) {
		//delete Item in database
		$.ajax({
			url: '../WebMethod/F505.asmx/deleteItem',
			type: 'post',
			data: {
				ip_dc_id_giao_dich: id_giao_dich
			},
			dataType: 'text',
			error: function () {
				F505.Message('Xảy ra lỗi trong quá trình thực hiện, Bạn vui lòng thực hiện lại thao tác!');
			},
			success: function (data) {
				console.log('deleteItem, id_giao_dich=' + id_giao_dich);
				//delete row in table
				$(button).parent().parent().remove();
				//? reload grid
			}
		});
		

	},
	cancel: function () {
		$('#ThongTinChung').bPopup().close();
	},
	saveItem: function (button, id_giao_dich) {
		var tt = $(button).parent().parent().find('.tt').val();
		var hang_muc = $(button).parent().parent().find('.hang_muc').val();
		var kinh_phi_giao = $(button).parent().parent().find('.kinh_phi_giao').val();
		if (this.check_data_is_validate(button)) {
			console.log('saveItem, id_giao_dich=' + id_giao_dich + ", hang_muc: " + hang_muc + ", kinh phi giao = " + kinh_phi_giao);
		}

	},
	insertItem: function () {
		var id_quyet_dinh = $('#m_ddl_quyet_dinh').val();
		var tt = $('#tt').val();
		var hang_muc = $('#hang_muc').val();
		var ma_so_parent = $('#ThongTinChung').attr('ma_so_parent');
		var kinh_phi_giao = $('#kinh_phi_giao').val();
		//insert to database
		$.ajax({
			url: '../WebMethod/F505.asmx/InsertItem',
			type: 'post',
			data: {
				ip_dc_id_quyet_dinh: id_quyet_dinh
				, ip_dc_id_don_vi: m_dc_id_don_vi
				, ip_str_ma_so_parent: ma_so_parent
				, ip_str_ma_so: ''
				, ip_str_tt: tt
				, ip_str_hang_muc: hang_muc
				, ip_str_kinh_phi_giao: kinh_phi_giao
				, ip_str_KLTH_QUY_I: '0'
				, ip_str_KLTH_QUY_II: '0'
				, ip_str_KLTH_QUY_III: '0'
				, ip_str_KLTH_QUY_IV: '0'
				, ip_str_GHI_CHU_GIAO_KH: ''
				, ip_str_GHI_CHU_QUY_I: ''
				, ip_str_GHI_CHU_QUY_II: ''
				, ip_str_GHI_CHU_QUY_III: ''
				, ip_str_GHI_CHU_QUY_IV: ''

			},
			dataType: 'text',
			error: function () {
				F505.Message('Xảy ra lỗi trong quá trình thực hiện, Bạn vui lòng thực hiện lại thao tác!');
			},
			success: function (data) {
				//console.log('deleteItem, id_giao_dich=' + id_giao_dich);
				//delete row in table
				$(button).parent().parent().remove();
				//? reload grid
			}
		});
		//reload grid
		//this.reloadGrid();
	}
}

$(document).ready(function () {
	F505.initialControl();
});