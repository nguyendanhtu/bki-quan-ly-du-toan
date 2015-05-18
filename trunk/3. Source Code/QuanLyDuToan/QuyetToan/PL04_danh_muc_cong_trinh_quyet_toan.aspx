<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PL04_danh_muc_cong_trinh_quyet_toan.aspx.cs" Inherits="QuanLyDuToan.QuyetToan.PL04_danh_muc_cong_trinh_quyet_toan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<script src="../Scripts/UI/PL04.js"></script>
	<style type="text/css">
		
		#tblPL04 > thead > tr > th {
			border: 1px solid #000;
		}

		#tblPL04 > tbody > tr > td {
			border-right: 1px solid #ddd;
		}

		#tblPL04 {
			border-left: 1px solid #ddd;
			border-bottom: 1px solid #ddd;
		}


		.so_tien {
			width: 82px;
			text-align: right;
		}

		body {
			font-family: "Helvetica Neue", Helvetica, Arial, sans-serif;
			font-size: 11px;
		}

		.form-control {
			/* display: block; */
			padding: 3px 2px;
			font-size: 11px;
		}
		.form-control {
			background-color: white;
		}
		.table {
			max-width: 300%;
			background: white;
		}

		.tt {
			width: 20px !important;
		}

		.cong_trinh_hang_muc {
			width: 250px !important;
		}

		.gia_tri {
			width: 88px !important;
		}

		.table > tbody > tr > th, .table > tfoot > tr > th, .table > thead > tr > td, .table > tbody > tr > td, .table > tfoot > tr > td {
			padding-left: 2px;
		}

		.table {
			margin-bottom: 0px;
		}
	</style>
	<script type="text/javascript">
		var MaxRecord =<%=lst_pl04.Count%> +'';
		var MaxLNV =<%=lst_pl04.Select(x => new { x.TEN_LOAI_NHIEM_VU, x.TT }).OrderBy(x=>x.TT).Distinct().ToList().Count%> +'';
		var MaxCT =<%=lst_pl04.Select(x => new { x.CONG_TRINH, x.TEN_LOAI_NHIEM_VU}).Distinct().ToList().Count%> +'';
		var m_lst_don_vi=<%= Newtonsoft.Json.JsonConvert.SerializeObject(m_lst_don_vi)%>;
		var m_dc_id_don_vi=<%= m_dc_id_don_vi%>;
		var form_mode="<%=m_str_form_mode%>";
	</script>
	<script src="../Scripts/jquery.doubleScroll.js"></script>
	<script src="../Scripts/fixHeader.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div class="col-sm-12">
		<h3 class="text-center">BÁO CÁO THỰC HIỆN XỬ LÝ 
KIẾN NGHỊ CỦA KIỂM TOÁN, THANH TRA, TÀI CHÍNH</h3>
		<div class="col-sm-12 text-center">
			<select id="m_ddl_don_vi" style="width:250px"></select>
			<input type="text" class="form-control" style="width:110px" id="m_txt_nam" value="<%=DateTime.Now.Year %>" />
			<input type="button" value="Tải dữ liệu" class="btn btn-sm btn-success" onclick="gdPL04.reloadGrid()" />
		</div>

	</div>
	<div class="col-sm-12">
		<div id="grid" style="">
		</div>
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
