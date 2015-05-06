/// <reference path="../../DuToan/F104_nhap_du_toan_ke_hoach.aspx" />
/// <reference path="../linq.js" />
/// <reference path="../jquery.linq.js" />
var F505 = {
	initialControl: function () {
		$('#m_ddl_quyet_dinh').select2();
		this.autoComputed();
		this.autoFormatInitialValue();
		//this.FormatTable();
		//format by form_mode
		$('.giao_kh, .thuc_hien').hide();
		$('.' + form_mode).show();
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
				$('#F505 tbody').empty();
				$('#F505').append(data);
				F505.initialControl();
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
		//reset value control
		$('#tt').val('').focus();
		$('#hang_muc').val('');
		$('#kinh_phi_giao').val('');
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
				F505.reloadGrid();
			}
		});


	},
	cancel: function () {
		$('#ThongTinChung').bPopup().close();
	},
	saveItem: function (button, id_giao_dich) {
		var id_quyet_dinh = $('#m_ddl_quyet_dinh').val();
		var tt = $(button).parent().parent().find('.tt').val();
		var hang_muc = $(button).parent().parent().find('.hang_muc').val();
		var kinh_phi_giao = $(button).parent().parent().find('.kinh_phi_giao').val();
		if (this.check_data_is_validate(button)) {
			$.ajax({
				url: '../WebMethod/F505.asmx/SaveItem',
				type: 'post',
				data: {
					ip_dc_id_quyet_dinh: id_quyet_dinh
					, ip_dc_id_don_vi: m_dc_id_don_vi
					, ip_dc_id_giao_dich: id_giao_dich
					, ip_str_tt: tt
					, ip_str_hang_muc: hang_muc
					, ip_str_kinh_phi_giao: kinh_phi_giao
					, ip_str_GHI_CHU_GIAO_KH: ''
				},
				dataType: 'text',
				error: function () {
					F505.Message('Xảy ra lỗi trong quá trình thực hiện, Bạn vui lòng thực hiện lại thao tác!');
				},
				success: function (data) {
					//F505.cancel();
				}
			});
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
				F505.cancel();
				F505.reloadGrid();
			}
		});
	},
	saveAllData: function () {
		var id_don_vi = m_dc_id_don_vi;//$('#m_ddl_don_vi').val();
		var lst_tr = $("#F505 tbody tr[loai='data'");
		var lst_item = [];
		for (var i = 0; i < lst_tr.length; i++) {
			var item = {
				ip_dc_id_don_vi: id_don_vi
			, ip_dc_id_giao_dich: $(lst_tr[i]).attr('id_giao_dich')
			, ip_str_tt: $(lst_tr[i]).find('.tt').val()
			, ip_str_hang_muc: $(lst_tr[i]).find('.hang_muc').val()
			, ip_str_kinh_phi_giao: $(lst_tr[i]).find('.kinh_phi_giao').val()
			, ip_str_KLTH_QUY_I: $(lst_tr[i]).find('.thuc_hien_quy_i').val()
			, ip_str_KLTH_QUY_II: $(lst_tr[i]).find('.thuc_hien_quy_ii').val()
			, ip_str_KLTH_QUY_III: $(lst_tr[i]).find('.thuc_hien_quy_iii').val()
			, ip_str_KLTH_QUY_IV: $(lst_tr[i]).find('.thuc_hien_quy_iv').val()
			, ip_str_GHI_CHU_GIAO_KH: ''
			, ip_str_GHI_CHU_QUY_I: ''
			, ip_str_GHI_CHU_QUY_II: ''
			, ip_str_GHI_CHU_QUY_III: ''
			, ip_str_GHI_CHU_QUY_IV: ''
			, ip_str_PHAN_BO_QUI_I: $(lst_tr[i]).find('.phan_bo_quy_i').val()
			, ip_str_PHAN_BO_QUY_II: $(lst_tr[i]).find('.phan_bo_quy_ii').val()
			, ip_str_PHAN_BO_QUY_III: $(lst_tr[i]).find('.phan_bo_quy_iii').val()
			, ip_str_PHAN_BO_QUY_IV: $(lst_tr[i]).find('.phan_bo_quy_iv').val()
			, ip_str_GHI_CHU_PHAN_BO_QUY_I: ''
			, ip_str_GHI_CHU_PHAN_BO_QUY_II: ''
			, ip_str_GHI_CHU_PHAN_BO_QUY_III: ''
			, ip_str_GHI_CHU_PHAN_BO_QUY_IV: ''
			}
			lst_item.push(item);
		}
		console.log(lst_item);
		$.ajax({
			url: '../WebMethod/F505.asmx/UpdateAll',
			type: 'post',
			data: { ip_str_arr: JSON.stringify(lst_item) },
			dataType: "text",
			error: function (data) {
				alert('Xảy ra lỗi trong quá trình thực hiện, Bạn vui lòng thực hiện lại thao tác!');
				//reload grid
			},
			success: function (data) {
				console.log('success');
				//reload grid
				//F104.reloadGrid();
			}
		})
	},
	autoComputed: function () {
		var lstClass = ['kinh_phi_giao', 'phan_bo_quy_i', 'phan_bo_quy_ii', 'phan_bo_quy_iii', 'phan_bo_quy_iv', 'thuc_hien_quy_i', 'thuc_hien_quy_ii', 'thuc_hien_quy_iii', 'thuc_hien_quy_iv'];
		for (var i = 0; i < lstClass.length; i++) {
			this.autoComputedByClass(lstClass[i]);
		}
	},
	autoComputedByClass: function (className) {
		var lst_ma_so = Enumerable.From($('.'+className)).Select(function (x) { return $(x).attr('ma_so') }).ToArray();
		for (var i = 0; i < lst_ma_so.length; i++) {
			F505.autoComputedChildren(lst_ma_so[i], className);
		}
	},
	autoComputedChildren: function (ma_so_parent, classCongThuc) {
		var strClassParent = "." + classCongThuc + "[ma_so='" + ma_so_parent + "']";
		var strClassChildren = "." + classCongThuc + "[ma_so_parent='" + ma_so_parent + "']";
		var lstChildren = $(strClassChildren);
		for (var i = 0; i < lstChildren.length; i++) {

			$(lstChildren[i]).bind("keypress keyup keydown change", (function (e) {
				if (e.keyCode != 17
					&& e.keyCode != 16
					&& e.keyCode != 37
					&& e.keyCode != 39
					&& e.keyCode != 36) {
					var tong = 0.0;
					for (var j = 0; j < lstChildren.length; j++) {
						tong += parseFloat($(lstChildren[j]).val()
											.split(',').join('').split('.').join(''));
					}
					$(strClassParent).val(getFormatedNumberString(tong)).change();
				}
			}));
		}
	},
	autoFormatInitialValue: function () {
		var lstFormat = $('.kinh_phi_giao');
		for (var i = 0; i < lstFormat.length; i++) {
			var value = $(lstFormat[i]).val();
			$(lstFormat[i]).val(getFormatedNumberString(value)).change();
			//$(lstFormat[i]).bind("keypress keyup keydown change", (function (e) {
			//	if (e.keyCode != 17 && e.keyCode != 16 && e.keyCode != 37 && e.keyCode != 39 && e.keyCode != 36) {
			//		$(this).val(formatString($(this).val()));
			//	}
			//}))
		}
	},
	FormatTable: function formatTable() {
		var table = $('#F505').dataTable({

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
}

$(document).ready(function () {
	F505.initialControl();
});