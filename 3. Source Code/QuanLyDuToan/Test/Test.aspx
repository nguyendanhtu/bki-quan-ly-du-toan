<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="QuanLyDuToan.Test.Test" %>

<%@ Register Src="~/UC_Message.ascx" TagPrefix="uc1" TagName="UC_Message" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<uc1:UC_Message runat="server" id="m_uc_message" />
	<asp:Button ID="m_cmd_mess_click" runat="server" Text="Click me to show mess" OnClick="m_cmd_mess_click_Click" />
</asp:Content>
