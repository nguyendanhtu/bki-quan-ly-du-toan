/// <reference path="../../Test/tudm.aspx" />
var tudm = {
	load_data_to_ddl_chuong: function () {
		var v_html="";
		for (var i = 0; i < m_lst_chuong.length; i++) {
			v_html += "<option value='" + m_lst_chuong[i].ID + "'>" + m_lst_chuong[i].TEN + "</option>";
		}
		console.log(v_html);
		$('#m_ddl_chuong').append(v_html);
	}
}

$(document).ready(function () {
	tudm.load_data_to_ddl_chuong();
});