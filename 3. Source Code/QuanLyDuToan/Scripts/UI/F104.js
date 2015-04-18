/// <reference path="../../DuToan/F104_nhap_du_toan_ke_hoach.aspx" />
/// <reference path="../linq.js" />
/// <reference path="../jquery.linq.js" />>
var F104 = {
	initDropdownlistEvent: function () {
		$('#m_ddl_loai').bind("change", function () {
			var html = "<option value='-1'>---Chọn Khoản---</option>";
			var v_id_loai=$('#m_ddl_loai').val();
			var lstKhoan = Enumerable.From(m_lst_clkm)
				.Where(function (x) {
					return x.ID_LOAI == idKhoan
						&& x.ID_CHA == v_id_loai;
				})
				.OrderBy(function (x) { return x.MA_SO })
				.ToArray();
			for (var i = 0; i < lstKhoan.length; i++) {
				html += "<option value='" + lstKhoan[i].ID + "'>"+lstKhoan[i].MA_SO.trim()+" "+lstKhoan[i].TEN+"</<option>";
			}
			$('#m_ddl_khoan').empty();
			$('#m_ddl_khoan').append(html);
			$('#m_ddl_khoan').select2();

		})
		$('#m_ddl_khoan').bind("change", function () {
		});
		$('#m_ddl_tieu_muc').bind("change", function () {
		})
		$('#m_ddl_muc').bind("change", function () {
			var html = "<option value='-1'>---Chọn Tiểu mục---</option>";
			var v_id_muc = $('#m_ddl_muc').val();
			var lstTieuMuc = Enumerable.From(m_lst_clkm)
				.Where(function (x) {
					return x.ID_LOAI == idTieuMuc
						&& x.ID_CHA == v_id_muc;
				})
				.OrderBy(function (x) { return x.MA_SO })
				.ToArray();
			for (var i = 0; i < lstTieuMuc.length; i++) {
				html += "<option value='" + lstTieuMuc[i].ID + "'>" + lstTieuMuc[i].MA_SO.trim() + " " + lstTieuMuc[i].TEN + "</<option>";
			}
			$('#m_ddl_tieu_muc').empty();
			$('#m_ddl_tieu_muc').append(html);
			$('#m_ddl_tieu_muc').select2();
		})
	}
}

$(document).ready(function () {
	F104.initDropdownlistEvent();
});

function pageLoad(sender, args) {
	if (args.get_isPartialLoad()) {
		F104.initDropdownlistEvent();

	}
}