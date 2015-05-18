<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F505_DuToanThuChiPhiPha.aspx.cs" Inherits="QuanLyDuToan.DuToan.F505_DuToanThuChiPhiPha" %>

<%@ Import Namespace="QuanLyDuToan.App_Code" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<script src="../Scripts/UI/F505.js"></script>
	<script src="../Scripts/jquery.bpopup.js"></script>
	<script src="../Scripts/linq.js"></script>
	<script src="../Scripts/jquery.linq.js"></script>
	<script src="../Scripts/jquery.dataTables.js"></script>
	<style type="text/css">
		#ThongTinChung {
			background-color: white;
			display: none;
		}

		.form-control {
			background-color: white;
		}

		
		#F505 > thead > tr > th {
			border: 1px solid #000;
		}

		#F505 > tbody > tr > td {
			border-right: 1px solid #ddd;
		}

		#F505 {
			border-left: 1px solid #ddd;
			border-bottom: 1px solid #ddd;
		}
		.text-bold {
			font-weight: bolder;
			font-style: italic;
		}

		.disable {
			pointer-events: none;
			background-color: #eee;
		}
		.thuc_hien_quy_i, .thuc_hien_quy_ii, .thuc_hien_quy_iii, .thuc_hien_quy_iv, .phan_bo_quy_i, .phan_bo_quy_ii, .phan_bo_quy_iii , .phan_bo_quy_iv,.kinh_phi_giao {
			width:80px;
			font-size:11px;
		}
	</style>
	<script type="text/javascript">
		var m_dc_id_don_vi=<%=m_dc_id_don_vi%>;
		var lst_du_toan_thu_chi_phi_pha=<%= Newtonsoft.Json.JsonConvert.SerializeObject(m_lst_du_toan_thu_chi_phi_pha
			.Select(x=>new {
			ID=x.ID
			,MA_SO=x.MA_SO
			,MA_SO_PARENT=x.MA_SO_PARENT
			,TT=x.TT
			,HANG_MUC=x.HANG_MUC
			,KINH_PHI_GIAO_KH=x.KINH_PHI_GIAO_KH
			})
			
			 .ToList())%>;
		var form_mode="<%=m_str_form_mode%>";
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div class='row'>
		<div class='col-sm-12'>
			<div class='col-sm-4 text-right' style="margin-top:6px">
				<label>Chọn quyết định</label>
			</div>
			<div class='col-sm-4'>
				<select id='m_ddl_quyet_dinh' style='width: 400px'>
					<%foreach (var qd in m_lst_quyet_dinh)%>
					<%{%>
					<option value='<%=qd.ID %>'><%=qd.SO_QUYET_DINH+' '+qd.NOI_DUNG %></option>
					<%}%>
				</select>
			</div>
			<div class='col-sm-4'>
			</div>
		</div>
		<div class='col-sm-12' id="grid">
			
		</div>

	</div>
	<div id='ThongTinChung' class='popup' style='width: 700px; display: none' id_giao_dich='-1' ma_so_parent='-1'>
		<h4 id='detail-title' class='text-center' style='border-bottom: 1px solid black; font-weight: bolder'>Cập nhật hạng mục thu chi phí phà</h4>

		<div class='popup-content' style='margin: 30px'>
			<div class='col-sm-12'>
				<div class='col-sm-1'>
					<input type='text' id='tt' style='width: 50px' class='form-control text-center' placeholder='TT' />
				</div>
				<div class='col-sm-8'>
					<input type='text' id='hang_muc' class='form-control' style='width: 100%' placeholder='Hạng mục' />
				</div>
				<div class='col-sm-3'>
					<input type='text' id='kinh_phi_giao' class='form-control text-right' placeholder='Kinh phí đã giao' />
				</div>
			</div>
			<br />
			<br />
			<div class='col-sm-12 text-center' style='margin-bottom: 30px'>
				<input type='button' class='btn btn-sm btn-success' value='Cập nhật' onclick='F505.insertItem()' />
				<input type='button' class='btn btn-sm btn-default' value='Huỷ thao tác' onclick='F505.cancel()' />
			</div>
		</div>
	</div>
</asp:Content>

