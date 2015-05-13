/// <reference path="../script.js" />
/// <reference path="../linq.js" />
/// <reference path="../jquery.linq.js" />>
var F404 = {
	initialFormLoad: function () {
		$('#m_txt_ngay_nhap').val(m_str_now);
		$(".datepicker").datepicker({ format: 'dd/mm/yyyy' });
		F404.defineEvent();
		F404.load_data_to_ddl_don_vi(m_lst_don_vi);
		
		F404.formatControlByNguon();
		F404.formatControlBYRole();

		F404.reloadGrid();
		////computed event in grid
		//F404.autoComputedBYLoaiNhiemVuCongTrinhDuAn();

		////format control so tien
		//F404.formatInitialSoTien();


	},
	defineEvent: function () {

		$('#m_ddl_don_vi').bind("change", function () {
			//reload grid
			//F404.reloadGrid();
		});
	},

	/*region Events*/
	formatControlByNguon: function () {
		var lst_nguon_ns = $('.ns');
		var lst_nguon_qbt = $('.qbt');
		if (m_str_nguon_ns == "N") {
			$('#m_lbl_title').text('Nhập giá trị thực hiện - Nguồn Quỹ bảo trì');
			//Quy bao tri
			for (var i = 0; i < lst_nguon_ns.length; i++) {
				$(lst_nguon_ns[i]).hide();
			}
			for (var i = 0; i < lst_nguon_qbt.length; i++) {
				$(lst_nguon_qbt[i]).show();
			}
		}
		else {
			//Ngan sach
			$('#m_lbl_title').text('Nhập giá trị thực hiện - Nguồn Ngân sách');
			for (var i = 0; i < lst_nguon_ns.length; i++) {
				$(lst_nguon_ns[i]).show();
			}
			for (var i = 0; i < lst_nguon_qbt.length; i++) {
				$(lst_nguon_qbt[i]).hide();
			}

		}
	},
	formatControlSoTien: function () {
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
		
	},
	formatInitialSoTien: function () {
		var lst = $('.format_so_tien, .grid_tong');
		for (var i = 0; i < lst.length; i++) {
			$(lst[i]).val(getFormatedNumberString($(lst[i]).val().split(",").join("").split(".").join()));
		}

	},
	/*endregion Events*/
	check_validate_load_grid: function () {
		if ($('#m_txt_ngay_nhap').val()=="") {
			alert("Bạn phải nhập Ngày tháng!");
			return false;
		}
		return true;
	},
	/*region CRUD*/

	updateAll: function () {
		//tao list data submit to server
		$('#loading').show();
		var lst_data = [];
		var lst_td = $('.muc, .du_an, .tieu_muc');
		for (var i = 0; i < lst_td.length; i++) {
			var item_data = {
				ID: $(lst_td[i]).attr('id_giao_dich'),
				GIA_TRI_THUC_HIEN_QBT: $(lst_td[i]).find('.gia_tri_thuc_hien_qbt').val(),
				GIA_TRI_THUC_HIEN_NS: $(lst_td[i]).find('.gia_tri_thuc_hien_ns').val(),

			}
			lst_data.push(item_data);
		}
		//console.log(lst_data);
		//ajax submit to server
		$.ajax({
			url: '../WebMethod/F404.asmx/UpdateAll',
			type: 'post',
			data: { ip_str_arr: JSON.stringify(lst_data) },
			dataType: "text",
			error: function (data) {
				alert('Xảy ra lỗi trong quá trình thực hiện, Bạn vui lòng thực hiện lại thao tác!');
				//reload grid
			},
			success: function (data) {
				//reload grid
				F404.reloadGrid();
			}
		});
	},
	cancel: function () {
		$('#m_cmd_ghi_du_lieu').attr('id_giao_dich', '-1');
		$('#m_txt_cong_trinh').val('');
		$('#m_txt_du_an').val('');
		$('#m_txt_chieu_dai_tuyen').val('0');
		$('#m_txt_kinh_phi_nam_truoc_chuyen_sang').val('0');
		$('#m_txt_kinh_phi_quy_bao_tri').val('0');
		$('#m_txt_tong').val('0');
		$('#m_txt_ghi_chu').val('');
		$('#m_txt_noi_dung_du_toan').val('');
		$('#m_txt_kinh_phi_ngan_sach').val('0');
		$('#m_txt_tong_muc_dau_tu').val('0');
		$('#m_txt_thoi_gian_thuc_hien').val('0');
		$('#m_cmd_ghi_du_lieu').val('Ghi dữ liệu');
	},

	reloadGrid: function () {
		var id_don_vi = $('#m_ddl_don_vi').val();
		var v_str_ngay_nhap = $('#m_txt_ngay_nhap').val();
		if (F404.check_validate_load_grid()) {
			$('#loading').show();
			$.ajax({
				url: '../WebMethod/F404.asmx/genGrid',
				type: 'post',
				data: {
					ip_dc_ID_DON_VI: id_don_vi
					, ip_str_nguon_ns: m_str_nguon_ns
					, ip_str_ngay_nhap: v_str_ngay_nhap
				},
				dataType: "text",
				error: function (data) {
					$('#loading').hide();
					//alert('Xảy ra lỗi trong quá trình thực hiện, Bạn vui lòng thực hiện lại thao tác!');
					F404.reloadGrid();
					//reload grid
				},
				success: function (data) {
					//reload grid
					$('#F404 tbody').empty().append(data);
					//computed event in grid
					

					//computed event in grid
					F404.autoComputedBYLoaiNhiemVuCongTrinhDuAn();

					//format control so tien
					F404.formatInitialSoTien();
					F404.formatControlSoTien();

					
					F404.formatControlByNguon();
					
					F404.formatControlBYRole();

					//format label .so_tien
					var v_lst = $('.so_tien');
					for (var i = 0; i < v_lst.length; i++) {
						var str_format = getFormatedNumberString($(v_lst[i]).text().split(',').join('').split('.').join(''));
						$(v_lst[i]).text(str_format);
						//console.log(str_format);
					}
					$('#loading').hide();
				}
			});
		}
	},
	/*endregion CRUD*/

	/*region tool*/
	openTool: function () {
		$('#toolQuyetDinh').bPopup();
		//$('#toolQuyetDinh').css('z-index',400);
	},
	closeTool: function () {
		$('#toolQuyetDinh').bPopup().close();
	},
	excuteTool: function () {
		//excuted tool
		var id_quyet_dinh_1 = $('#m_ddl_quyet_dinh_1').val();
		var id_quyet_dinh_2 = $('#m_ddl_quyet_dinh_2').val();
		var id_don_vi = $('#m_ddl_don_vi').val();
		$.ajax({
			url: '../WebMethod/F404.asmx/CopyItemFromQuyetDinh',
			type: 'post',
			data: {
				ip_dc_id_don_vi: id_don_vi
				, ip_dc_id_quyet_dinh_1: id_quyet_dinh_1
				, ip_dc_id_quyet_dinh_2: id_quyet_dinh_2
			},
			dataType: "text",
			error: function (data) {
				$('#loading').hide();
				alert('Xảy ra lỗi trong quá trình thực hiện, Bạn vui lòng thực hiện lại thao tác!');
			},
			success: function (data) {
				//reload grid theo quyet dinh 2
				$('#m_ddl_quyet_dinh').val(id_quyet_dinh_2).change();

				//close tool
				F404.closeTool();
			}
		});

	},
	/*endregion tool*/


	load_data_to_ddl_don_vi: function (lst) {
		var html_don_vi = "";
		for (var i = 0; i < lst.length; i++) {
			html_don_vi += "<option value='" + lst[i].ID + "'>" + lst[i].TEN_DON_VI + "</option>";
		}
		$('#m_ddl_don_vi').empty().append(html_don_vi).select2();
		//.change() event to call reloadGrid()
	},
	autoComputedByParent: function (ma_so_parent) {
		//define parent row
		var tr_parent = $('#F404 tbody tr').find("[ma_so='" + ma_so_parent + "']").parent();
		var txt_parent_gia_tri_thuc_hien_qbt = $(tr_parent).find('.gia_tri_thuc_hien_qbt');
		var txt_parent_gia_tri_thuc_hien_ns = $(tr_parent).find('.gia_tri_thuc_hien_ns');
		//foreach children
		var lst_children = $('#F404 tbody tr').find("[ma_so_parent='" + ma_so_parent + "']");
		for (var i = 0; i < lst_children.length; i++) {
			//var v_lst_children = $('#F404 tbody tr').find("[ma_so_parent='" + ma_so_parent + "']");
			var txt_children_gia_tri_thuc_hien_qbt = $(lst_children[i]).parent().find('.gia_tri_thuc_hien_qbt');
			var txt_children_gia_tri_thuc_hien_ns = $(lst_children[i]).parent().find('.gia_tri_thuc_hien_ns');

			//define event
			//Quy bao tri
			$(txt_children_gia_tri_thuc_hien_qbt).bind("change keyup keydown", function () {
				var tong = 0;
				for (var j = 0; j < lst_children.length; j++) {
					tong += parseFloat($(lst_children[j]).parent().find('.gia_tri_thuc_hien_qbt').val().split(',').join('').split('.').join(''));
				}
				$(txt_parent_gia_tri_thuc_hien_qbt).val(getFormatedNumberString(tong)).change();
			});
			//Ngan sach
			$(txt_children_gia_tri_thuc_hien_ns).bind("change keyup keydown", function () {
				var tong = 0;
				for (var j = 0; j < lst_children.length; j++) {
					tong += parseFloat($(lst_children[j]).parent().find('.gia_tri_thuc_hien_ns').val().split(',').join('').split('.').join(''));
				}
				$(txt_parent_gia_tri_thuc_hien_ns).val(getFormatedNumberString(tong)).change();
				console.log(tong);
			});
		}
	},
	autoComputedBYLoaiNhiemVuCongTrinhDuAn: function () {
		var lst_temp_lnv = ["0"];
		var lst_temp_ct = [];
		var lst_temp_da = [];
		var lst_lnv = $('#F404 tbody tr').find("[ma_so_parent='0']");
		for (var i = 0; i < lst_lnv.length; i++) {
			lst_temp_lnv.push($(lst_lnv[i]).attr('ma_so'));
			var lst_ct = $('#F404 tbody tr').find("[ma_so_parent='" + $(lst_lnv[i]).attr('ma_so') + "']");
			for (var j = 0; j < lst_ct.length; j++) {
				lst_temp_ct.push($(lst_ct[j]).attr('ma_so'));
				var lst_da = $('#F404 tbody tr').find("[ma_so_parent='" + $(lst_ct[j]).attr('ma_so') + "']");
				for (var k = 0; k < lst_da.length; k++) {
					lst_temp_da.push($(lst_da[k]).attr('ma_so'));
				}
			}
		}
		var lst_item = $.merge($.merge($.merge([], lst_temp_lnv), lst_temp_ct), lst_temp_da);
		//defind event
		for (var i = 0; i < lst_item.length; i++) {
			F404.autoComputedByParent(lst_item[i]);
		}
	},

	formatControlBYRole: function () {
		//Neu la don vi khac thi khong duoc xoa, them
		if ($('#m_ddl_don_vi').val() != m_dc_id_don_vi) {
			//khong co quyen xoa
			$('.private_don_vi').hide();
			$('.sua_giao_dich').val('Xem');
		}
		else {
			$('.private_don_vi').show();
			$('.sua_giao_dich').val('Sửa');
		}
	},


}

$(document).ready(function () {
	F404.initialFormLoad();
});