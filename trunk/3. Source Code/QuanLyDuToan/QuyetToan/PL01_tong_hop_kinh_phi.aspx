<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PL01_tong_hop_kinh_phi.aspx.cs" Inherits="QuanLyDuToan.QuyetToan.PL01_tong_hop_kinh_phi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<script src="../Scripts/UI/PL01.js"></script>
	<script src="../Scripts/jquery.dataTables.js"></script>
	<script src="../Scripts/jquery.fixedheadertable.min.js"></script>
	<style>
		.format_so_tien {
			text-align: right;
		}

		.top {
			text-align: right;
		}

		.form-control {
			background-color: white;
			/*width:110px;*/
			width:100%;
		}
		#tblPL01 > thead > tr > th{
			border: 1px solid #000;
		}
		#tblPL01 > tbody > tr > td {
			border-right: 1px solid #ddd;
			
		}
		#tblPL01  {
		border-left: 1px solid #ddd;
		}
	</style>
	<script type="text/javascript">
		var m_lst_loai = <%= Newtonsoft.Json.JsonConvert.SerializeObject(lst_loai)%>;
		var m_lst_don_vi=<%= Newtonsoft.Json.JsonConvert.SerializeObject(m_lst_don_vi)%>;
		var m_dc_id_don_vi=<%=m_dc_id_don_vi%>;
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div>
		<div class="col-sm-12">
			<h3 class="text-center">TỔNG HỢP TÌNH HÌNH KINH PHÍ VÀ QUYẾT TOÁN CHI QUỸ BẢO TRÌ ĐƯỜNG BỘ</h3>
			<div class="col-sm-12 text-center">
				<select id="m_ddl_don_vi" style="width:250px"></select>
			<input type="text" class="form-control" id="m_txt_nam" value="<%=DateTime.Now.Year %>" style="width:110px"/>	
				<input type="button" value="Tải dữ liệu" class="btn btn-sm btn-success" onclick="PL01.load_data_to_grid()" />
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
	</div>
</asp:Content>
