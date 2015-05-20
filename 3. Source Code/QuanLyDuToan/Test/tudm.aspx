<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="tudm.aspx.cs" Inherits="QuanLyDuToan.Test.tudm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<script src="../Scripts/Test/tudm.js"></script>
	<script type="text/javascript">
		var m_lst_chuong = <%= Newtonsoft.Json.JsonConvert.SerializeObject(m_lst_chuong)%>;
	</script>
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div>
		<div class="col-sm-12">
			<div class="col-sm-4">Chuong</div>
			<div class="col-sm-8">
				<select id="m_ddl_chuong">
				</select>
			</div>
		</div>
		<div class="col-sm-12">
			<div class="col-sm-4">Loai</div>
			<div class="col-sm-8">
				<select id="m_ddl_loai"></select></div>
		</div>
		<div class="col-sm-12">
			<div class="col-sm-4">Khoan</div>
			<div class="col-sm-8">
				<select id="m_ddl_khoan"></select></div>
		</div>
		<div class="col-sm-12">
			<div class="col-sm-4">Muc</div>
			<div class="col-sm-8">
				<select id="m_ddl_muc"></select></div>
		</div>
		<div class="col-sm-12">
			<div class="col-sm-4">Tieu muc</div>
			<div class="col-sm-8">
				<select id="m_ddl_tieu_muc"></select></div>
		</div>
	</div>

</asp:Content>
