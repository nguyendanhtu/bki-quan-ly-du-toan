/// <reference path="../linq.js" />
/// <reference path="../../Test/tudm.aspx" />
var tudm = {
	load_data_to_ddl_chuong: function () {
		var v_lst_chuong = Enumerable.From(m_lst_chuong)
							.OrderBy(function (x) { return x.MA_SO; })
							.ToArray();


		var v_html="";
		for (var i = 0; i < v_lst_chuong.length; i++) {
			v_html += "<option value='" + v_lst_chuong[i].ID + "'>" + v_lst_chuong[i].MA_SO+"_"+v_lst_chuong[i].TEN + "</option>";
		}
		$('#m_ddl_chuong').append(v_html);
	}
}

$(document).ready(function () {
	tudm.load_data_to_ddl_chuong();
});