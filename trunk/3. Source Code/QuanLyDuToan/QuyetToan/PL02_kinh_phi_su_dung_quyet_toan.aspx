<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PL02_kinh_phi_su_dung_quyet_toan.aspx.cs" Inherits="QuanLyDuToan.QuyetToan.PL02_kinh_phi_su_dung_quyet_toan" %>

<%@ Import Namespace="SQLDataAccess" %>
<%@ Import Namespace="WebUS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<style>
		.table > thead > tr > th {
			vertical-align: middle;
			border-bottom: 2px solid #ddd;
		}

		.clkm {
			width: 50px;
		}

		.so_tien {
			width: 80px;
		}

		.scroll {
			max-height: 60px;
			overflow: auto;
		}
		#tblPL02 > thead > tr > th{
			border: 1px solid #000;
		}
		#tblPL02 > tbody > tr > td {
			border-right: 1px solid #ddd;
			
		}
		#tblPL02 > tfoot > tr {
			background-color:lightblue;
		}
		#tblPL02  {
		border-left: 1px solid #ddd;
		}
	</style>
	<script type="text/javascript">
		var idChuong =<%= ID_CHUONG_LOAI_KHOAN_MUC.CHUONG.ToString()%> +"";
		var idLoai =<%= ID_CHUONG_LOAI_KHOAN_MUC.LOAI.ToString()%> +"";
		var idKhoan =<%= ID_CHUONG_LOAI_KHOAN_MUC.KHOAN.ToString()%> +"";
		var idMuc =<%= ID_CHUONG_LOAI_KHOAN_MUC.MUC.ToString()%> +"";
		var idTieuMuc =<%=ID_CHUONG_LOAI_KHOAN_MUC.TIEU_MUC.ToString()%> +"";
		var IdDonVi=<%=m_dc_id_don_vi%>;
		var strLDC_I=<%="\'"+lst_NDC[0]+"\'"%>;
		var strLDC_II=<%="\'"+lst_NDC[1]+"\'"%>;
		var m_lst_clkm = <%= Newtonsoft.Json.JsonConvert.SerializeObject(lst_clkm)%>;
		var m_lst_don_vi=<%= Newtonsoft.Json.JsonConvert.SerializeObject(m_lst_don_vi)%>;
		var m_dc_id_don_vi=<%= m_dc_id_don_vi%>;
		
	</script>
	<script src="../Scripts/UI/PL02.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div class="col-sm-12">
		<h3 class="text-center">Phần II:  Kinh phí đã sử dụng đề nghị quyết toán</h3>
		<div class="col-sm-12 text-center">
			<select id="m_ddl_don_vi" style="width:250px"></select>
			<input type="text" class="form-control" id="m_txt_nam" value="<%=DateTime.Now.Year %>" />
			<input type="button" value="Tải dữ liệu" class="btn btn-sm btn-success" onclick="gdPL02.reloadGrid()" />
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
