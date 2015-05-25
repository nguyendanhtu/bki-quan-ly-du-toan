/// <reference path="../../DuToan/F104_nhap_du_toan.aspx" />
/// <reference path="../script.js" />
/// <reference path="../linq.js" />
/// <reference path="../jquery.linq.js" />>
var F104 = {
	initialFormLoad: function () {
		F104.defineEvent();
		F104.load_data_to_ddl_don_vi(m_lst_don_vi);
		F104.load_data_to_ddl_quyet_dinh(m_lst_quyet_dinh, "#m_ddl_quyet_dinh_1", false);
		F104.load_data_to_ddl_quyet_dinh(m_lst_quyet_dinh, "#m_ddl_quyet_dinh_2", false);
		//load data to ddl_don_vi va reload grid
		F104.load_data_to_ddl_quyet_dinh(m_lst_quyet_dinh, "#m_ddl_quyet_dinh", true);

		F104.load_data_to_ddl_loai_nhiem_vu(m_lst_loai_nhiem_vu);
		F104.load_data_to_ddl_cong_trinh(m_lst_ct_da_gt);
		F104.load_data_to_ddl_chuong(m_lst_clkm);
		F104.load_data_to_ddl_loai(m_lst_clkm);
		F104.load_data_to_ddl_khoan(m_lst_clkm);
		F104.load_data_to_ddl_muc(m_lst_clkm);
		F104.load_data_to_ddl_tieu_muc(m_lst_clkm);
		$('input[type=radio][name=chi_theo]').change();
		F104.formatControlByNguon();

		//computed event in grid
		F104.autoComputedByParentRow();
		F104.autoComputedBYLoaiNhiemVuCongTrinhDuAn();

		//format control so tien
		F104.formatInitialSoTien();
		F104.autoTinhTongKinhPhi();

	},
	defineEvent: function () {
		$('#m_txt_cong_trinh').bind("change blur keyup keydown", function () {
			F104.load_data_to_ddl_du_an(m_lst_ct_da_gt);
		});
		$('input[type=radio][name=chi_theo]').change(function () {
			F104.load_data_to_ddl_loai_nhiem_vu(m_lst_loai_nhiem_vu);
			F104.visibleTheoDuAnOrTheoChuongLoaiKhoanMuc();
		});

		$('#m_ddl_loai').bind("change", function () {
			F104.load_data_to_ddl_khoan(m_lst_clkm);
		});

		$('#m_ddl_muc').bind("change", function () {
			F104.load_data_to_ddl_tieu_muc(m_lst_clkm);
		});

		$('#m_ddl_quyet_dinh').bind("change", function () {
			var qd = Enumerable.From(m_lst_quyet_dinh)
							.Where(function (x) { return x.ID == $('#m_ddl_quyet_dinh').val() })
							.FirstOrDefault();
			//Neu la qd Bo sung hoac Dieu chinh, hoi co muon chuyen cong trinh, du an tu quyet dinh khac sang khong
			//reload grid
			F104.reloadGrid();
			//Hien thi thong tin cua quyet dinh

			var v_loai_quyet_dinh = "";
			if (qd.ID_LOAI_QUYET_DINH_GIAO == KH_DAU_NAM) {
				v_loai_quyet_dinh = "QĐ đầu năm";
			}
			else if (qd.ID_LOAI_QUYET_DINH_GIAO == BO_SUNG) {
				v_loai_quyet_dinh = "QĐ bổ sung";
			}
			else if (qd.ID_LOAI_QUYET_DINH_GIAO == DIEU_CHINH) {
				v_loai_quyet_dinh = "QĐ điều chỉnh";
			}
			$('#m_txt_loai_quyet_dinh').val('').val(v_loai_quyet_dinh);
			$('#m_txt_ngay_thang').val('').val(qd.str_NGAY_THANG);
			$('#m_txt_noi_dung').val('').val(qd.NOI_DUNG);
			//$('#m_lbl_quyet_dinh_so').text(qd.SO_QUYET_DINH);
			//$('#m_lbl_ngay').text(qd.str_NGAY_THANG);
			//$('#m_lbl_ve_viec').text(qd.NOI_DUNG);
		});
		$('#m_ddl_don_vi').bind("change", function () {
			//reload grid
			F104.reloadGrid();
			//visible tool Quyet dinh
			if ($('#m_ddl_don_vi').val() == m_dc_id_don_vi) {
				$('#m_ddl_quyet_dinh').css('width', '210px');
				$('#toolButton').show();
			}
			else {
				$('#m_ddl_quyet_dinh').css('width', '240px');
				$('#toolButton').hide();
			}
			$('#m_ddl_quyet_dinh').select2("destroy");
			$('#m_ddl_quyet_dinh').select2();
		});
	},

	/*region Events*/
	visibleTheoDuAnOrTheoChuongLoaiKhoanMuc: function () {
		var lst_show = $('.theo_muc_luc_ngan_sach');
		var lst_hide = $('.theo_du_an');
		if ($('#m_rdb_theo_du_an').is(':checked')) {
			lst_show = $('.theo_du_an');
			lst_hide = $('.theo_muc_luc_ngan_sach');
		}
		for (var i = 0; i < lst_hide.length; i++) {
			$(lst_hide[i]).hide();
		}
		for (var i = 0; i < lst_show.length; i++) {
			$(lst_show[i]).show();
		}
	},
	formatControlByNguon: function () {
		var lst_nguon_ns = $('.nguon_ngan_sach');
		var lst_nguon_qbt = $('.nguon_quy_bao_tri');
		if (m_str_nguon_ns == "N") {
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
			$('#m_rdb_theo_muc_luc_ngan_sach').prop('checked', 'checked').change();
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
			var str_format = getFormatedNumberString($(this).val());

			if ((e.keyCode >= 48 && e.keyCode <= 57)
				|| (e.keyCode >= 96 && e.keyCode <= 105)
				|| Enumerable.From(arr_keyCode_comma)
					.Where(function (x) { return x == e.keyCode })
					.ToArray().length > 0) {
				var str_format = getFormatedNumberString($(this).val());
				$(this).val(str_format);
			}
		});
	},
	formatInitialSoTien: function () {
		var lst = $('.format_so_tien, .grid_tong');
		for (var i = 0; i < lst.length; i++) {
			$(lst[i]).val(getFormatedNumberString($(lst[i]).val()));
		}

	},
	autoTinhTongKinhPhi: function () {
		$('#m_txt_kinh_phi_nam_truoc_chuyen_sang_ns').bind("change keyup keydown", function () {
			var tong = 0
			tong += parseFloat($('#m_txt_kinh_phi_nam_truoc_chuyen_sang_ns').val().split(',').join('').split('.').join(''));
			tong += parseFloat($('#m_txt_kinh_phi_nam_truoc_chuyen_sang_qbt').val().split(',').join('').split('.').join(''));
			tong += parseFloat($('#m_txt_kinh_phi_quy_bao_tri').val().split(',').join('').split('.').join(''));
			tong += parseFloat($('#m_txt_kinh_phi_ngan_sach').val().split(',').join('').split('.').join(''));
			$('#m_txt_tong').val(getFormatedNumberString(tong + ''));
		});

		$('#m_txt_kinh_phi_nam_truoc_chuyen_sang_qbt').bind("change keyup keydown", function () {
			var tong = 0
			tong += parseFloat($('#m_txt_kinh_phi_nam_truoc_chuyen_sang_ns').val().split(',').join('').split('.').join(''));
			tong += parseFloat($('#m_txt_kinh_phi_nam_truoc_chuyen_sang_qbt').val().split(',').join('').split('.').join(''));
			tong += parseFloat($('#m_txt_kinh_phi_quy_bao_tri').val().split(',').join('').split('.').join(''));
			tong += parseFloat($('#m_txt_kinh_phi_ngan_sach').val().split(',').join('').split('.').join(''));
			$('#m_txt_tong').val(getFormatedNumberString(tong + ''));
		});
		$('#m_txt_kinh_phi_quy_bao_tri').bind("change keyup keydown", function () {
			var tong = 0
			tong += parseFloat($('#m_txt_kinh_phi_nam_truoc_chuyen_sang_ns').val().split(',').join('').split('.').join(''));
			tong += parseFloat($('#m_txt_kinh_phi_nam_truoc_chuyen_sang_qbt').val().split(',').join('').split('.').join(''));
			tong += parseFloat($('#m_txt_kinh_phi_quy_bao_tri').val().split(',').join('').split('.').join(''));
			tong += parseFloat($('#m_txt_kinh_phi_ngan_sach').val().split(',').join('').split('.').join(''));
			$('#m_txt_tong').val(getFormatedNumberString(tong + ''));
		});
		$('#m_txt_kinh_phi_ngan_sach').bind("change keyup keydown", function () {
			var tong = 0
			tong += parseFloat($('#m_txt_kinh_phi_nam_truoc_chuyen_sang_ns').val().split(',').join('').split('.').join(''));
			tong += parseFloat($('#m_txt_kinh_phi_nam_truoc_chuyen_sang_qbt').val().split(',').join('').split('.').join(''));
			tong += parseFloat($('#m_txt_kinh_phi_quy_bao_tri').val().split(',').join('').split('.').join(''));
			tong += parseFloat($('#m_txt_kinh_phi_ngan_sach').val().split(',').join('').split('.').join(''));
			$('#m_txt_tong').val(getFormatedNumberString(tong + ''));
		});
	},

	/*endregion Events*/

	/*region CRUD*/
	deleteGiaoDich: function (id_giao_dich) {
		if (confirm('Bạn có chắc chắn muốn xoá bản ghi này?')) {
			$('#loading').show();
			//ajax delete giao dich
			$.ajax({
				url: '../WebMethod/F104.asmx/DeleteGiaoDich',
				type: 'post',
				data: { ip_dc_ID: id_giao_dich },
				dataType: 'text',
				error: function () {
					alert('Xảy ra lỗi trong quá trình thực hiện, Bạn vui lòng thực hiện lại thao tác!');
				},
				success: function (data) {
					//reload grid
					F104.reloadGrid();
				}
			});
		}

	},
	check_validate_data_is_ok: function () {
		if ($('#m_rdb_theo_muc_luc_ngan_sach').is(':checked')) {
			//Theo muc luc ngan sach
			if ($('#m_txt_noi_dung_du_toan').val() == "") {
				alert('Bạn phải nhập nội dung dự toán');
				$('#m_txt_noi_dung_du_toan').focus();
				return false;
			}

			//validate Kinh phi nam truoc chuyen sang
			if (m_str_nguon_ns == "N") {
				//Quy bao tri
				if ($('#m_txt_kinh_phi_nam_truoc_chuyen_sang_qbt').val() == "") {
					alert('Bạn phải nhập KP năm trước chuyển sang');
					$('#m_txt_kinh_phi_nam_truoc_chuyen_sang_qbt').focus();
					return false;
				}
			}
			else if (m_str_nguon_ns == "Y") {
				//Ngan sach
				if ($('#m_txt_kinh_phi_nam_truoc_chuyen_sang_ns').val() == "") {
					alert('Bạn phải nhập KP năm trước chuyển sang');
					$('#m_txt_kinh_phi_nam_truoc_chuyen_sang_ns').focus();
					return false;
				}
			}

		}
		else {
			//Theo cong trinh, du an
			if ($('#m_txt_cong_trinh').val() == "") {
				alert('Bạn phải nhập Công trình/Quốc lộ');
				$('#m_txt_cong_trinh').focus();
				return false;
			}
			if ($('#m_txt_du_an').val() == "") {
				alert('Bạn phải nhập Dự án');
				$('#m_txt_du_an').focus();
				return false;
			}
			if ($('#m_txt_tong_muc_dau_tu').val() == "") {
				alert('Bạn phải nhập Tổng mức đầu tư');
				$('#m_txt_tong_muc_dau_tu').focus();
				return false;
			}
			if ($('#m_txt_thoi_gian_thuc_hien').val() == "") {
				alert('Bạn phải nhập Thời gian thực hiện');
				$('#m_txt_thoi_gian_thuc_hien').focus();
				return false;
			}
			if ($('#m_txt_chieu_dai_tuyen').val() == "") {
				alert('Bạn phải nhập Chiều dài tuyến');
				$('#m_txt_chieu_dai_tuyen').focus();
				return false;
			}
			//validate Kinh phi nam truoc chuyen sang
			if (m_str_nguon_ns == "N") {
				//Quy bao tri
				if ($('#m_txt_kinh_phi_nam_truoc_chuyen_sang_qbt').val() == "") {
					alert('Bạn phải nhập KP năm trước chuyển sang');
					$('#m_txt_kinh_phi_nam_truoc_chuyen_sang_qbt').focus();
					return false;
				}
			}
			else if (m_str_nguon_ns == "Y") {
				//Ngan sach
				if ($('#m_txt_kinh_phi_nam_truoc_chuyen_sang_ns').val() == "") {
					alert('Bạn phải nhập KP năm trước chuyển sang');
					$('#m_txt_kinh_phi_nam_truoc_chuyen_sang_ns').focus();
					return false;
				}
			}
			if ($('#m_txt_kinh_phi_quy_bao_tri').val() == "") {
				alert('Bạn phải nhập KP Quỹ bảo trì');
				$('#m_txt_kinh_phi_quy_bao_tri').focus();
				return false;
			}
		}
		return true;
	},
	editGiaoDich: function (id_giao_dich) {
		var gd = Enumerable.From(m_lst_gd)
					.Where(function (x) { return x.ID == id_giao_dich })
					.FirstOrDefault();
		if (gd == null) return;
		$('#m_cmd_ghi_du_lieu').attr('id_giao_dich', gd.ID);
		if (gd.ID_CONG_TRINH != 0) {
			var cong_trinh = Enumerable.From(m_lst_ct_da_gt)
				.Where(function (x) { return x.ID == gd.ID_CONG_TRINH })
				.FirstOrDefault();
			var du_an = Enumerable.From(m_lst_ct_da_gt)
				.Where(function (x) { return x.ID == gd.ID_DU_AN })
				.FirstOrDefault();
			$('#m_rdb_theo_du_an').prop('checked', 'checked').change();
			$('#m_txt_cong_trinh').val('').val(cong_trinh.TEN);
			$('#m_txt_du_an').val('').val(du_an.TEN);
		}
		else {
			var khoan = Enumerable.From(m_lst_clkm)
				.Where(function (x) { return x.ID == gd.ID_KHOAN })
				.FirstOrDefault();
			var loai = Enumerable.From(m_lst_clkm)
				.Where(function (x) { return x.ID == khoan.ID_CHA })
				.FirstOrDefault();
			$('#m_rdb_theo_muc_luc_ngan_sach').prop('checked', 'checked').change();
			$('#m_ddl_chuong').val(gd.ID_CHUONG).select2();
			$('#m_ddl_loai').val(loai.ID).change().select2();
			$('#m_ddl_khoan').val(gd.ID_KHOAN).select2();
			$('#m_ddl_muc').val(gd.ID_MUC).change().select2();
			if (gd.ID_TIEU_MUC != 0) {
				$('#m_ddl_tieu_muc').val(gd.ID_TIEU_MUC).select2();
			}
			if (gd.TU_CHU_YN == "Y") {
				$('#m_rdb_chi_thuong_xuyen').prop('checked', 'checked');
			}
			else $('#m_rdb_chi_khong_thuong_xuyen').prop('checked', 'checked');
		}
		$('#m_ddl_loai_nhiem_vu').val(gd.ID_LOAI_NHIEM_VU).select2();
		$('#m_txt_noi_dung_du_toan').val('').val(gd.GHI_CHU_1);
		$('#m_txt_chieu_dai_tuyen').val('0').val(gd.GHI_CHU_2);
		$('#m_txt_kinh_phi_nam_truoc_chuyen_sang_qbt').val('0').val(getFormatedNumberString(gd.SO_TIEN_NAM_TRUOC_CHUYEN_SANG + "")).focus().change();
		$('#m_txt_kinh_phi_nam_truoc_chuyen_sang_ns').val('0').val(getFormatedNumberString(gd.SO_TIEN_NAM_TRUOC_CHUYEN_SANG_NS + "")).focus().change();
		$('#m_txt_kinh_phi_quy_bao_tri').val('0').val(getFormatedNumberString(gd.SO_TIEN_QUY_BT + "")).change();
		$('#m_txt_tong_muc_dau_tu').val('0').val(getFormatedNumberString(gd.TONG_MUC_DAU_TU + "")).change();
		$('#m_txt_thoi_gian_thuc_hien').val('0').val(getFormatedNumberString(gd.THOI_GIAN_THUC_HIEN + "")).change();
		$('#m_txt_kinh_phi_ngan_sach').val('0').val(getFormatedNumberString(gd.SO_TIEN_NS + "")).change();
		$('#m_txt_ghi_chu').val('').val(gd.GHI_CHU);
		$('#m_cmd_ghi_du_lieu').val('Cập nhật');

	},
	insertGiaoDich: function () {
		if (this.check_validate_data_is_ok()) {
			$('#loading').show();
			//ajax insert giao dich
			var id_chuong = -1;
			var id_khoan = -1;
			var id_muc = -1;
			var id_tieu_muc = -1;
			var cong_trinh = '';
			var du_an = '';
			var id = $('#m_cmd_ghi_du_lieu').attr('id_giao_dich');
			if (id == undefined) {
				id = -1;
			}
			var tu_chu_yn = -1;
			if ($('#m_rdb_theo_muc_luc_ngan_sach').is(':checked')) {
				id_chuong = $('#m_ddl_chuong').val();
				id_khoan = $('#m_ddl_khoan').val();
				id_muc = $('#m_ddl_muc').val();
				id_tieu_muc = $('#m_ddl_tieu_muc').val();
			}
			else {
				cong_trinh = $('#m_txt_cong_trinh').val();
				du_an = $('#m_txt_du_an').val();
			}
			if (m_str_nguon_ns == "Y") {
				if ($('#m_rdb_chi_thuong_xuyen').is(':checked')) {
					tu_chu_yn = "Y";
				}
				else {
					tu_chu_yn = "N";
				}
			}
			$.ajax({
				url: '../WebMethod/F104.asmx/UpdateGiaoDich',
				type: 'post',
				data: {
					ip_dc_ID: id
					, ip_dc_ID_QUYET_DINH: $('#m_ddl_quyet_dinh').val()
					, ip_dc_ID_DON_VI: $('#m_ddl_don_vi').val()
					, ip_str_CONG_TRINH: cong_trinh
					, ip_dc_SO_TIEN_QUY_BT: $('#m_txt_kinh_phi_quy_bao_tri').val().split(',').join('').split('.').join('')
					, ip_dc_SO_TIEN_NS: $('#m_txt_kinh_phi_ngan_sach').val().split(',').join('').split('.').join('')
					, ip_dc_TONG_MUC_DAU_TU: $('#m_txt_tong_muc_dau_tu').val().split(',').join('').split('.').join('')
					, ip_dc_THOI_GIAN_THUC_HIEN: $('#m_txt_thoi_gian_thuc_hien').val().split(',').join('').split('.').join('')
					, ip_dc_ID_CHUONG: id_chuong
					, ip_dc_ID_KHOAN: id_khoan
					, ip_dc_ID_MUC: id_muc
					, ip_str_GHI_CHU: $('#m_txt_ghi_chu').val()
					, ip_dc_ID_TIEU_MUC: id_tieu_muc
					, ip_dc_SO_TIEN_NAM_TRUOC_CHUYEN_SANG_QBT: $('#m_txt_kinh_phi_nam_truoc_chuyen_sang_qbt').val().split(',').join('').split('.').join('')
					,ip_dc_SO_TIEN_NAM_TRUOC_CHUYEN_SANG_NS: $('#m_txt_kinh_phi_nam_truoc_chuyen_sang_ns').val().split(',').join('').split('.').join('')
					, ip_dc_ID_LOAI_NHIEM_VU: $('#m_ddl_loai_nhiem_vu').val()
					, ip_str_DU_AN: du_an
					, ip_str_TU_CHU_YN: tu_chu_yn
					, ip_str_GHI_CHU_1: $('#m_txt_noi_dung_du_toan').val()
					, ip_str_GHI_CHU_2: $('#m_txt_chieu_dai_tuyen').val()
					, ip_str_GHI_CHU_3: -1
					, ip_str_GHI_CHU_4: -1
				},
				dataType: 'text',
				error: function () {
					alert('Xảy ra lỗi trong quá trình thực hiện, Bạn vui lòng thực hiện lại thao tác!');
				},
				success: function (data) {
					//reload grid
					F104.reloadGrid();
				}
			});
		}
	},
	updateAll: function () {
		//tao list data submit to server
		$('#loading').show();
		var lst_data = [];
		var lst_td = $('.muc, .du_an, .tieu_muc');
		for (var i = 0; i < lst_td.length; i++) {
			var item_data = {
				ID: $(lst_td[i]).attr('id_giao_dich'),
				SO_KM: $(lst_td[i]).find('.so_km').val(),
				KP_NAM_TRUOC_CHUYEN_SANG_QBT: $(lst_td[i]).find('.kinh_phi_nam_truoc_chuyen_sang_qbt').val(),
				KP_NAM_TRUOC_CHUYEN_SANG_NS: $(lst_td[i]).find('.kinh_phi_nam_truoc_chuyen_sang_ns').val(),
				KP_NGAN_SACH: $(lst_td[i]).find('.kinh_phi_ngan_sach').val(),
				KP_QUY_BT: $(lst_td[i]).find('.kinh_phi_quy_bao_tri').val(),
				TONG_MUC_DAU_TU: $(lst_td[i]).find('.tong_muc_dau_tu').val(),
				THOI_GIAN_THUC_HIEN: $(lst_td[i]).find('.thoi_gian_thuc_hien').val()
			}
			lst_data.push(item_data);
		}
		//ajax submit to server
		$.ajax({
			url: '../WebMethod/F104.asmx/UpdateAll',
			type: 'post',
			data: { ip_str_arr: JSON.stringify(lst_data) },
			dataType: "text",
			error: function (data) {
				alert('Xảy ra lỗi trong quá trình thực hiện, Bạn vui lòng thực hiện lại thao tác!');
				//reload grid
			},
			success: function (data) {
				//reload grid
				F104.reloadGrid();
			}
		});
	},
	cancel: function () {
		$('#m_cmd_ghi_du_lieu').attr('id_giao_dich', '-1');
		$('#m_txt_cong_trinh').val('');
		$('#m_txt_du_an').val('');
		$('#m_txt_chieu_dai_tuyen').val('0');
		$('#m_txt_kinh_phi_nam_truoc_chuyen_sang_ns').val('0');
		$('#m_txt_kinh_phi_nam_truoc_chuyen_sang_qbt').val('0');
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
		$('#loading').show();
		var id_quyet_dinh = $('#m_ddl_quyet_dinh').val();
		var id_don_vi = $('#m_ddl_don_vi').val();
		$.ajax({
			url: '../WebMethod/F104.asmx/GenGrid',
			type: 'post',
			data: {
				ip_dc_ID_QUYET_DINH: id_quyet_dinh
				, ip_dc_ID_DON_VI: id_don_vi
				, ip_str_nguon: m_str_nguon_ns
			},
			dataType: "text",
			error: function (data) {
				$('#loading').hide();
				alert('Xảy ra lỗi trong quá trình thực hiện, Bạn vui lòng thực hiện lại thao tác!');
				//reload grid
			},
			success: function (data) {
				var tbody = data.split("||||||||||")[0];
				//reload grid
				$('#F104 tbody').empty().append(tbody);
				//format theo form_mode: Ngan sach or QBT
				if (m_str_nguon_ns == "N") {
					//Quy bao tri
					$('.qbt').show();
					$('.ns').hide();
				}
				else if (m_str_nguon_ns == "Y") {
					//Ngan sach
					$('.ns').show();
					$('.qbt').hide();
				}
				//computed event in grid
				F104.autoComputedByParentRow();
				F104.autoComputedBYLoaiNhiemVuCongTrinhDuAn();
				F104.formatControlBYRole();
				F104.formatControlSoTien();
				F104.formatInitialSoTien();

				//reload list giao dich
				m_lst_gd = $.parseJSON(data.split("||||||||||")[1]);
				F104.cancel();
				$('#loading').hide();
			}
		});

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
			url: '../WebMethod/F104.asmx/CopyItemFromQuyetDinh',
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
				F104.closeTool();
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
	load_data_to_ddl_quyet_dinh: function (lst, op_ddl_quyet_dinh, isSelect2) {
		var html_qd = "";
		for (var i = 0; i < lst.length; i++) {
			var v_loai_quyet_dinh = "";
			if (lst[i].ID_LOAI_QUYET_DINH_GIAO == KH_DAU_NAM) {
				v_loai_quyet_dinh = "QĐ đầu năm";
			}
			else if (lst[i].ID_LOAI_QUYET_DINH_GIAO == BO_SUNG) {
				v_loai_quyet_dinh = "QĐ bổ sung";
			}
			else if (lst[i].ID_LOAI_QUYET_DINH_GIAO == DIEU_CHINH) {
				v_loai_quyet_dinh = "QĐ điều chỉnh";
			}
			html_qd += "<option value='" + lst[i].ID + "'>" + v_loai_quyet_dinh + " _" + lst[i].str_NGAY_THANG + " _" + lst[i].SO_QUYET_DINH + " _" + lst[i].NOI_DUNG + "</option>";
		}
		if (isSelect2) {
			$(op_ddl_quyet_dinh).empty().append(html_qd).change().select2();
		}
		else $(op_ddl_quyet_dinh).empty().change().append(html_qd);
	},
	load_data_to_ddl_loai_nhiem_vu: function (lst) {
		$('#m_ddl_loai_nhiem_vu').removeAttr("disabled");
		var id_loai_tu_dien = LOAI_NHIEM_VU_NS;
		if ($('#m_rdb_theo_du_an').is(':checked')) {
			id_loai_tu_dien = LOAI_NHIEM_VU_QBT;
		}
		else if (m_str_nguon_ns == "N") {
			id_loai_tu_dien = LOAI_NHIEM_VU_QBT;
		}
		var lst_lnv = Enumerable.From(lst)
			.Where(function (x) { return x.ID_LOAI_TU_DIEN == id_loai_tu_dien })
			.OrderBy(function (x) { return x.GHI_CHU })
			.ToArray();
		var html_lnv = "";
		for (var i = 0; i < lst_lnv.length; i++) {
			html_lnv += "<option value='" + lst_lnv[i].ID + "'>" + lst_lnv[i].GHI_CHU + " - " + lst_lnv[i].TEN + "</option>";
		}
		$('#m_ddl_loai_nhiem_vu').empty().append(html_lnv).select2();
		if (!$('#m_rdb_theo_du_an').is(':checked')) {
			if (m_str_nguon_ns == "Y") {
				$('#m_ddl_loai_nhiem_vu').val('666').select2();
				$('#m_ddl_loai_nhiem_vu').attr("disabled", "disabled");
			}
		}

	},
	load_data_to_ddl_cong_trinh: function (lst) {
		var lst_ct = Enumerable.From(lst)
			.Where(function (x) { return x.ID_LOAI == ID_CONG_TRINH })
			.Select(function (x) { return x.TEN.trim() })
			.OrderBy(function (x) { return x.trim() })
			.ToArray();
		//var html_ct = "";
		//for (var i = 0; i < lst_ct.length; i++) {
		//	html_ct += "<option value='" + lst_ct[i] + "'></option>";
		//}
		//$('#dtl_cong_trinh').empty().append(html_ct);
		$("#m_txt_cong_trinh").autocomplete({
			source: lst_ct,
			minLength: 0
		}).bind('focus click', function () { $(this).autocomplete("search"); });
	},
	load_data_to_ddl_du_an: function (lst) {
		var id_cong_trinh = Enumerable.From(lst)
			.Where(function (x) { return x.ID_LOAI == ID_CONG_TRINH && x.TEN == $('#m_txt_cong_trinh').val() })
			.Select(function (x) { return x.ID })
			.FirstOrDefault();
		var lst_da = Enumerable.From(lst)
			.Where(function (x) { return x.ID_LOAI == ID_DU_AN && x.ID_CHA == id_cong_trinh })
			.Select(function (x) { return x.TEN.trim() })
			.OrderBy(function (x) { return x.trim() })
			.ToArray();
		//var html_da = "";
		//for (var i = 0; i < lst_da.length; i++) {
		//	html_da += "<option value='" + lst_da[i] + "'></option>";
		//}
		//$('#dtl_du_an').empty().append(html_da);
		$("#m_txt_du_an").val("").autocomplete({
			source: lst_da,
			minLength: 0
		}).bind('focus', function () { $(this).autocomplete("search"); });
	},
	load_data_to_ddl_chuong: function (lst) {
		var lst_chuong = Enumerable.From(lst)
			.Where(function (x) { return x.ID_LOAI == ID_CHUONG })
			.ToArray();
		var html_chuong = "";
		for (var i = 0; i < lst_chuong.length; i++) {
			html_chuong += "<option value='" + lst_chuong[i].ID + "'>" + lst_chuong[i].MA_SO.trim() + "_" + lst_chuong[i].TEN + "</option>";
		}
		$('#m_ddl_chuong').empty().append(html_chuong).val('17').attr('disabled', 'disabled').select2();
	},
	load_data_to_ddl_loai: function (lst) {
		var lst_loai = Enumerable.From(lst)
			.Where(function (x) { return x.ID_LOAI == ID_LOAI })
			.ToArray();
		var html_loai = "";
		for (var i = 0; i < lst_loai.length; i++) {
			html_loai += "<option value='" + lst_loai[i].ID + "'>" + lst_loai[i].MA_SO.trim() + "_" + lst_loai[i].TEN + "</option>";
		}
		$('#m_ddl_loai').empty().append(html_loai).select2();
	},
	load_data_to_ddl_khoan: function (lst) {
		var lst_khoan = Enumerable.From(lst)
			.Where(function (x) { return x.ID_LOAI == ID_KHOAN && x.ID_CHA == $('#m_ddl_loai').val() })
			.ToArray();
		var html_khoan = "";
		for (var i = 0; i < lst_khoan.length; i++) {
			html_khoan += "<option value='" + lst_khoan[i].ID + "'>" + lst_khoan[i].MA_SO.trim() + "_" + lst_khoan[i].TEN + "</option>";
		}
		$('#m_ddl_khoan').empty().append(html_khoan).select2();
	},
	load_data_to_ddl_muc: function (lst) {
		var lst_muc = Enumerable.From(lst)
			.Where(function (x) { return x.ID_LOAI == ID_MUC })
			.ToArray();
		var html_muc = "";
		for (var i = 0; i < lst_muc.length; i++) {
			html_muc += "<option value='" + lst_muc[i].ID + "'>" + lst_muc[i].MA_SO.trim() + "_" + lst_muc[i].TEN + "</option>";
		}
		$('#m_ddl_muc').empty().append(html_muc).select2();
	},
	load_data_to_ddl_tieu_muc: function (lst) {
		var lst_tieu_muc = Enumerable.From(lst)
			.Where(function (x) { return x.ID_LOAI == ID_TIEU_MUC && x.ID_CHA == $('#m_ddl_muc').val() })
			.ToArray();
		var html_tieu_muc = "";
		for (var i = 0; i < lst_tieu_muc.length; i++) {
			html_tieu_muc += "<option value='" + lst_tieu_muc[i].ID + "'>" + lst_tieu_muc[i].MA_SO.trim() + "_" + lst_tieu_muc[i].TEN + "</option>";
		}
		$('#m_ddl_tieu_muc').empty().append(html_tieu_muc).select2();
	},
	autoComputedBYLoaiNhiemVuCongTrinhDuAn: function () {
		var lst_temp_lnv = ["0"];
		var lst_temp_ct = [];
		var lst_temp_da = [];
		var lst_lnv = $('#F104 tbody tr').find("[ma_so_parent='0']");
		for (var i = 0; i < lst_lnv.length; i++) {
			lst_temp_lnv.push($(lst_lnv[i]).attr('ma_so'));
			var lst_ct = $('#F104 tbody tr').find("[ma_so_parent='" + $(lst_lnv[i]).attr('ma_so') + "']");
			for (var j = 0; j < lst_ct.length; j++) {
				lst_temp_ct.push($(lst_ct[j]).attr('ma_so'));
				var lst_da = $('#F104 tbody tr').find("[ma_so_parent='" + $(lst_ct[j]).attr('ma_so') + "']");
				for (var k = 0; k < lst_da.length; k++) {
					lst_temp_da.push($(lst_da[k]).attr('ma_so'));
				}
			}
		}
		var lst_item = $.merge($.merge($.merge([], lst_temp_lnv), lst_temp_ct), lst_temp_da);
		//defind event
		for (var i = 0; i < lst_item.length; i++) {
			F104.autoComputedByParent(lst_item[i]);
		}
	},
	autoComputedByParentRow: function () {
		var lst_tr = $('#F104 tbody tr');
		for (var i = 0; i < lst_tr.length; i++) {
			var txt_children_so_km = $(lst_tr[i]).find('.so_km');
			var txt_children_kinh_phi_nam_truoc_chuyen_sang_ns = $(lst_tr[i]).find('.kinh_phi_nam_truoc_chuyen_sang_ns ');
			var txt_children_kinh_phi_nam_truoc_chuyen_sang_qbt = $(lst_tr[i]).find('.kinh_phi_nam_truoc_chuyen_sang_qbt ');
			var txt_children_kinh_phi_ngan_sach = $(lst_tr[i]).find('.kinh_phi_ngan_sach');
			var txt_children_kinh_phi_quy_bao_tri = $(lst_tr[i]).find('.kinh_phi_quy_bao_tri');
			var txt_children_tong_muc_dau_tu = $(lst_tr[i]).find('.tong_muc_dau_tu');
			var txt_children_thoi_gian_thuc_hien = $(lst_tr[i]).find('.thoi_gian_thuc_hien');
			$(txt_children_kinh_phi_nam_truoc_chuyen_sang_ns).bind("change keyup keydown", function () {
				var kp_ntcs_ns = $(this).parent().parent().find('.kinh_phi_nam_truoc_chuyen_sang_ns').val();
				var kp_ntcs_qbt = $(this).parent().parent().find('.kinh_phi_nam_truoc_chuyen_sang_qbt').val();
				var kp_ns = $(this).parent().parent().find('.kinh_phi_ngan_sach').val();
				var kp_qbt = $(this).parent().parent().find('.kinh_phi_quy_bao_tri').val();
				var txt_tong = $(this).parent().parent().find('.grid_tong');
				var tong_grid = 0;
				tong_grid = +parseFloat(kp_ntcs_ns.split(',').join('').split('.').join(''))
					+ parseFloat(kp_ntcs_qbt.split(',').join('').split('.').join(''))
				+ parseFloat(kp_ns.split(',').join('').split('.').join(''))
				+ parseFloat(kp_qbt.split(',').join('').split('.').join(''));
				$(txt_tong).val(getFormatedNumberString(tong_grid));
			});
			$(txt_children_kinh_phi_nam_truoc_chuyen_sang_qbt).bind("change keyup keydown", function () {
				var kp_ntcs_ns = $(this).parent().parent().find('.kinh_phi_nam_truoc_chuyen_sang_ns').val();
				var kp_ntcs_qbt = $(this).parent().parent().find('.kinh_phi_nam_truoc_chuyen_sang_qbt').val();
				var kp_ns = $(this).parent().parent().find('.kinh_phi_ngan_sach').val();
				var kp_qbt = $(this).parent().parent().find('.kinh_phi_quy_bao_tri').val();
				var txt_tong = $(this).parent().parent().find('.grid_tong');
				var tong_grid = 0;
				tong_grid = +parseFloat(kp_ntcs_ns.split(',').join('').split('.').join(''))
					+ parseFloat(kp_ntcs_qbt.split(',').join('').split('.').join(''))
				+ parseFloat(kp_ns.split(',').join('').split('.').join(''))
				+ parseFloat(kp_qbt.split(',').join('').split('.').join(''));
				$(txt_tong).val(getFormatedNumberString(tong_grid));
			});
			$(txt_children_kinh_phi_ngan_sach).bind("change keyup keydown", function () {
				var kp_ntcs_ns = $(this).parent().parent().find('.kinh_phi_nam_truoc_chuyen_sang_ns').val();
				var kp_ntcs_qbt = $(this).parent().parent().find('.kinh_phi_nam_truoc_chuyen_sang_qbt').val();
				var kp_ns = $(this).parent().parent().find('.kinh_phi_ngan_sach').val();
				var kp_qbt = $(this).parent().parent().find('.kinh_phi_quy_bao_tri').val();
				var txt_tong = $(this).parent().parent().find('.grid_tong');
				var tong_grid = 0;
				tong_grid = +parseFloat(kp_ntcs_ns.split(',').join('').split('.').join(''))
					+ parseFloat(kp_ntcs_qbt.split(',').join('').split('.').join(''))
				+ parseFloat(kp_ns.split(',').join('').split('.').join(''))
				+ parseFloat(kp_qbt.split(',').join('').split('.').join(''));
				$(txt_tong).val(getFormatedNumberString(tong_grid));
			});
			$(txt_children_kinh_phi_quy_bao_tri).bind("change keyup keydown", function () {
				var kp_ntcs_ns = $(this).parent().parent().find('.kinh_phi_nam_truoc_chuyen_sang_ns').val();
				var kp_ntcs_qbt = $(this).parent().parent().find('.kinh_phi_nam_truoc_chuyen_sang_qbt').val();
				var kp_ns = $(this).parent().parent().find('.kinh_phi_ngan_sach').val();
				var kp_qbt = $(this).parent().parent().find('.kinh_phi_quy_bao_tri').val();
				var txt_tong = $(this).parent().parent().find('.grid_tong');
				var tong_grid = 0;
				tong_grid = +parseFloat(kp_ntcs_ns.split(',').join('').split('.').join(''))
					+ parseFloat(kp_ntcs_qbt.split(',').join('').split('.').join(''))
				+ parseFloat(kp_ns.split(',').join('').split('.').join(''))
				+ parseFloat(kp_qbt.split(',').join('').split('.').join(''));
				$(txt_tong).val(getFormatedNumberString(tong_grid));
			});

		}

	},
	autoComputedByParent: function (ma_so_parent) {
		//define parent row
		var tr_parent = $('#F104 tbody tr').find("[ma_so='" + ma_so_parent + "']");
		var txt_parent_so_km = $(tr_parent).parent().find('.so_km');
		var txt_parent_tong_muc_dau_tu = $(tr_parent).find('.tong_muc_dau_tu');
		var txt_parent_thoi_gian_thuc_hien = $(tr_parent).find('.thoi_gian_thuc_hien');
		var txt_parent_kinh_phi_nam_truoc_chuyen_sang_ns = $(tr_parent).parent().find('.kinh_phi_nam_truoc_chuyen_sang_ns ');
		var txt_parent_kinh_phi_nam_truoc_chuyen_sang_qbt = $(tr_parent).parent().find('.kinh_phi_nam_truoc_chuyen_sang_qbt ');
		var txt_parent_kinh_phi_ngan_sach = $(tr_parent).parent().find('.kinh_phi_ngan_sach');
		var txt_parent_kinh_phi_quy_bao_tri = $(tr_parent).parent().find('.kinh_phi_quy_bao_tri ');
		var txt_parent_grid_tong = $(tr_parent).parent().find('.grid_tong ');

		//foreach children
		var lst_children = $('#F104 tbody tr').find("[ma_so_parent='" + ma_so_parent + "']");
		for (var i = 0; i < lst_children.length; i++) {
			var lst_children = $('#F104 tbody tr').find("[ma_so_parent='" + ma_so_parent + "']");
			var txt_children_so_km = $(lst_children[i]).parent().find('.so_km');
			var txt_children_kinh_phi_nam_truoc_chuyen_sang = $(lst_children[i]).parent().find('.kinh_phi_nam_truoc_chuyen_sang ');
			var txt_children_tong_muc_dau_tu = $(lst_children[i]).find('.tong_muc_dau_tu');
			var txt_children_thoi_gian_thuc_hien = $(lst_children[i]).find('.thoi_gian_thuc_hien');
			var txt_children_kinh_phi_nam_truoc_chuyen_sang_ns = $(lst_children[i]).parent().find('.kinh_phi_nam_truoc_chuyen_sang_ns ');
			var txt_children_kinh_phi_nam_truoc_chuyen_sang_qbt = $(lst_children[i]).parent().find('.kinh_phi_nam_truoc_chuyen_sang_qbt ');
			var txt_children_kinh_phi_ngan_sach = $(lst_children[i]).parent().find('.kinh_phi_ngan_sach');
			var txt_children_kinh_phi_quy_bao_tri = $(lst_children[i]).parent().find('.kinh_phi_quy_bao_tri');
			var txt_children_grid_tong = $(lst_children[i]).parent().find('.grid_tong');
			//define event
			//So km
			$(txt_children_so_km).bind("change keyup keydown", function () {
				var tong = 0;
				for (var j = 0; j < lst_children.length; j++) {
					tong += parseFloat($($(lst_children[j]).parent().find('.so_km')).val());
				}
				$(txt_parent_so_km).val(tong).change();
			});
			//Tong muc dau tu
			$(txt_children_tong_muc_dau_tu).bind("change keyup keydown", function () {
				var tong = 0;
				for (var j = 0; j < lst_children.length; j++) {
					tong += parseFloat($($(lst_children[j]).parent().find('.tong_muc_dau_tu')).val());
				}
				$(txt_parent_tong_muc_dau_tu).val(tong).change();
			});
			//Thoi gian thuc hien
			$(txt_children_thoi_gian_thuc_hien).bind("change keyup keydown", function () {
				var tong = 0;
				for (var j = 0; j < lst_children.length; j++) {
					tong += parseFloat($($(lst_children[j]).parent().find('.thoi_gian_thuc_hien')).val());
				}
				$(txt_parent_thoi_gian_thuc_hien).val(tong).change();
			});
			//Kinh phi nam truoc chuyen sang
			$(txt_children_kinh_phi_nam_truoc_chuyen_sang_ns).bind("change keyup keydown", function () {
				var tong = 0;
				for (var j = 0; j < lst_children.length; j++) {
					tong += parseFloat($($(lst_children[j]).parent().find('.kinh_phi_nam_truoc_chuyen_sang_ns')).val().split(',').join('').split('.').join(''));
				}
				$(txt_parent_kinh_phi_nam_truoc_chuyen_sang_ns).val(getFormatedNumberString(tong)).change();
			});
			$(txt_children_kinh_phi_nam_truoc_chuyen_sang_qbt).bind("change keyup keydown", function () {
				var tong = 0;
				for (var j = 0; j < lst_children.length; j++) {
					tong += parseFloat($($(lst_children[j]).parent().find('.kinh_phi_nam_truoc_chuyen_sang_qbt')).val().split(',').join('').split('.').join(''));
				}
				$(txt_parent_kinh_phi_nam_truoc_chuyen_sang_qbt).val(getFormatedNumberString(tong)).change();
			});
			//Kinh phi Nguon Ngan sach
			$(txt_children_kinh_phi_ngan_sach).bind("change keyup keydown", function () {
				var tong = 0;
				for (var j = 0; j < lst_children.length; j++) {
					tong += parseFloat($($(lst_children[j]).parent().find('.kinh_phi_ngan_sach')).val().split(',').join('').split('.').join(''));
				}
				$(txt_parent_kinh_phi_ngan_sach).val(getFormatedNumberString(tong)).change();
			});
			//Kinh phi Quy bao tri
			$(txt_children_kinh_phi_quy_bao_tri).bind("change keyup keydown", function () {
				var tong = 0;
				for (var j = 0; j < lst_children.length; j++) {
					tong += parseFloat($($(lst_children[j]).parent().find('.kinh_phi_quy_bao_tri')).val().split(',').join('').split('.').join(''));
				}
				$(txt_parent_kinh_phi_quy_bao_tri).val(getFormatedNumberString(tong)).change();
			});
			//Kinh phi Tong
			$(txt_children_grid_tong).bind("change keyup keydown", function () {
				var tong = 0;
				for (var j = 0; j < lst_children.length; j++) {
					tong += parseFloat($($(lst_children[j]).parent().find('.grid_tong')).val().split(',').join('').split('.').join(''));
				}
				$(txt_parent_grid_tong).val(getFormatedNumberString(tong));
			});
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

	/*region genGrid*/
	genGridFromlst: function () {
		var arr_data = [];
		for (var i = 0; i < m_lst_gd.length; i++) {
			var gd = m_lst_gd[i];
			var level_1 = gd.ID_LOAI_NHIEM_VU;
			var level_2 = gd.ID_CONG_TRINH;
			if (gd.ID_CONG_TRINH == null) {
				level_2 = gd.ID_KHOAN;
			}
			var level_3 = gd.ID_DU_AN;
			if (gd.ID_DU_AN == null) {
				level_3 = gd.ID_MUC;
				if (gd.ID_MUC == null) {
					level_3 = gd.ID_TIEU_MUC;
				}
			}
			var html = "";
			html += "<tr>";
			html += "<td>";//button Xoa
			html += "</td>";
			html += "<td>";//button Sua
			html += "</td>";
			html += "<td>";//Nhiem vu chi
			html += Enumerable
				.From(m_lst_loai_nhiem_vu)
				.Where(function (x) { return x.ID == gd.ID_LOAI_NHIEM_VU })
				.Select(function (x) { return x.STT + " - " + x.TEN; })
				.FirstOrDefault();
			html += "</td>";
			html += "<td>";//Chieu dai tuyen
			//html +=Enumerable.From(m_lst_gd)
			html += "</td>";
			html += "<td>";//Kinh phi nam truoc chuyen sang
			html += "</td>";
			html += "<td>";//Kinh phi ngan sach
			html += "</td>";
			html += "<td>";//Kinh phi quy bao tri
			html += "</td>";
			html += "<td>";//Tong
			html += "</td>";
			html += "</tr>";

		}

		return arr_data;
	}
	/*end region genGrid*/
}

$(document).ready(function () {
	F104.initialFormLoad();
});