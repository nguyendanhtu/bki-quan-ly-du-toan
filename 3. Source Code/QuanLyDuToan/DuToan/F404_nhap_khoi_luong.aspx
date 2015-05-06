<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F404_nhap_khoi_luong.aspx.cs" Inherits="QuanLyDuToan.DuToan.F404_nhap_khoi_luong" %>

<%@ Import Namespace="IP.Core.IPCommon" %>
<%@ Import Namespace="WebDS.CDBNames" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
	<style type="text/css">
		.cssFontBold {
			font-weight: bold;
		}

		.text-middle {
			margin-top: 7px;
		}
		.form-control {
			width: 100%;
			font-size: 11px;
			background-color: white;
		}
		.loai_nhiem_vu, .loai_khoan, .cong_trinh {
			font-weight: bold;
		}
	</style>
	<script src="../Scripts/linq.js"></script>
	<script src="../Scripts/jquery.linq.js"></script>
	<script type="text/javascript">
		var m_dc_id_don_vi=<%=m_dc_id_don_vi%>;
		var m_lst_don_vi=<%= Newtonsoft.Json.JsonConvert.SerializeObject(m_lst_don_vi)%>;
		var m_str_nguon_ns="<%=m_str_nguon%>";
		var m_str_now='<%=CIPConvert.ToStr(DateTime.Now,"dd/MM/yyyy")%>';
	</script>
	<script src="../Scripts/UI/F404.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
	<div style="width: 1200px; margin: auto">

		<div class="col-sm-12 cssPageTitleBG">
			<label id="m_lbl_title" class="cssPageTitle"></label>
		</div>

		<div class="col-sm-12">
			<div style="width: 800px; margin: auto">
				<div class="col-sm-12">
					<div class="col-sm-1 text-right text-middle">Đơn vị</div>
					<div class="col-sm-3">
						<select id="m_ddl_don_vi" style="width: 200px"></select>
					</div>
					<div class="col-sm-2 text-right text-middle">Ngày tháng</div>
					<div class="col-sm-3">
						<input type="text" id="m_txt_ngay_nhap" placeholder="dd/MM/yyyy" runat="server" class="date-start  datepicker" value='<%# IP.Core.IPCommon.CIPConvert.ToStr(DateTime.Now,"dd/MM/yyyy")%>' />
					</div>
					<div class="col-sm-3">
						<input type="button" class="btn btn-sm btn-primary" value="Tải dữ liệu"  onclick="F404.reloadGrid()"  />
					</div>
				</div>
			</div>
		</div>
		<div class="col-sm-12">
			<table style="width: 900px;margin:auto; border: 1px solid black" class="table table-hover" id="F404">
				<thead>
					<tr>
						<th>Nhiệm vụ chi</th>
						<th style="width: 100px" class="qbt">Giá trị thực hiện đã nghiệm thu A-B</th>
						<th style="width: 100px" class="ns">Giá trị thực hiện đã nghiệm thu A-B</th>
					</tr>
				</thead>
				<tbody>
				</tbody>
				<tfoot>
					<tr>
						<td colspan="3" class="text-center">
							<input type="button" class="btn btn-sm btn-success private_don_vi" id="m_cmd_luu_du_lieu" value="Lưu dữ liệu" onclick="F404.updateAll()" />
							<input type="button" class="btn btn-sm btn-default" id="m_cmd_huy_thao_tac" value="Huỷ thao tác" onclick="F404.reloadGrid()" />
						</td>
					</tr>
				</tfoot>
			</table>
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


