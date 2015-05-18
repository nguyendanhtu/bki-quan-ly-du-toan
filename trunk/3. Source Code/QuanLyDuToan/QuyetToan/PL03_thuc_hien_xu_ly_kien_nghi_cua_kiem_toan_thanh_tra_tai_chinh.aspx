<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PL03_thuc_hien_xu_ly_kien_nghi_cua_kiem_toan_thanh_tra_tai_chinh.aspx.cs" Inherits="QuanLyDuToan.QuyetToan.PL03_thuc_hien_xu_ly_kien_nghi_cua_kiem_toan_thanh_tra_tai_chinh" %>

<%@ Import Namespace="Framework.Extensions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<style>
		#tblPL03 > thead > tr > th {
			border: 1px solid #000;
		}

		#tblPL03 > tbody > tr > td {
			border-right: 1px solid #ddd;
		}

		#tblPL03 {
			border-left: 1px solid #ddd;
			border-bottom: 1px solid #ddd;
		}

		.form-control, .format_so_tien {
			width: 90px;
			text-align: right;
			padding: 3px 2px;
			font-size: 11px;
		}
		.form-control {
			background-color: white;
		}
		.text-right {
			width: 90px;
		}
	</style>
	<script src="../Scripts/UI/PL03.js"></script>
	<script type="text/javascript">
		var m_lst_don_vi=<%= Newtonsoft.Json.JsonConvert.SerializeObject(m_lst_don_vi)%>;
		var m_dc_id_don_vi=<%= m_dc_id_don_vi%>;
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div class="col-sm-12">
		<h3 class="text-center">BÁO CÁO THỰC HIỆN XỬ LÝ 
KIẾN NGHỊ CỦA KIỂM TOÁN, THANH TRA, TÀI CHÍNH</h3>
		<div class="col-sm-12 text-center">
			<select id="m_ddl_don_vi"></select>
			<input type="text" class="form-control" style="text-align:left" id="m_txt_nam" value="<%=DateTime.Now.Year %>" />
			<input type="button" value="Tải dữ liệu" class="btn btn-sm btn-success" onclick="PL03.reloadGrid()" />
		</div>

	</div>
	<div class="col-sm-12" id="grid">
	</div>
	<div class="cssLoadWapper" style="display: none; z-index: 99999999" id="loading">
		<div class="cssLoadContent">
			<img src="../Images/loadingBar.gif" alt="" />
			<p>
				Đang gửi yêu cầu, hãy đợi ...
			</p>
		</div>
	</div>


</asp:Content>
