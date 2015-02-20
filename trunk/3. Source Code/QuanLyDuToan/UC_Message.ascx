<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Message.ascx.cs" Inherits="QuanLyDuToan.UC_Message" %>
<div class="aspnet_web_form_core">
	<div class="<%=strClassMessage %>" style="width: 300px; float: right; margin-right: 50px">
		<span class="close" data-dismiss="alert">&times;</span>
		<strong>
			<asp:Label ID="m_lbl_mess_title" runat="server"></asp:Label></strong>
		<asp:Label ID="m_lbl_mess_content" runat="server"></asp:Label>
	</div>
</div>
<script type="text/javascript">
	$(".aspnet_web_form_core").fadeTo(3000, 500).slideToggle(1000, function () {
		$("aspnet_web_form_core").alert('close');
	});
</script>
