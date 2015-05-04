<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tudm.aspx.cs" Inherits="tudm" %>

<!DOCTYPE html>
<meta charset="utf-8" />
<html>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:TextBox ID="m_txt_ma_so_parent" runat="server" placeholder="Ma so parent"></asp:TextBox>
		<asp:Button id="m_cmd_get_ma_so_children" runat="server" Text="get ma so" OnClick="m_cmd_get_ma_so_children_Click" />
		<asp:TextBox ID="m_txt_ma_so_children" runat="server" placeholder="Ma so children"></asp:TextBox>
    </div>
    </form>
</body>
</html>
