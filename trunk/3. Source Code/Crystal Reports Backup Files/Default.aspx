<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
  <table  cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
<tr>
		<td class="cssPageTitleBG">
		    <asp:Label CssClass="cssPageTitle" runat="server" ID="m_lbl_header">Báo cáo thống kê .....</asp:Label>
		</td>
	</tr>
    <tr>
		<td>
        </td>
	</tr>
	<tr>
		<td align="center" colspan="2" valign="top">
   <asp:GridView ID="m_grv_bao_cao_tong_hop" AllowPaging="True" 
                runat="server" AutoGenerateColumns="False" 
                Width="80%" DataKeyNames="ID"
                CellPadding="4" ForeColor="#333333" 
                PageSize="30">
                  <AlternatingRowStyle BackColor="White" />
                <Columns>
                    
                </Columns>
                  <EditRowStyle BackColor="#7C6F57" />
                  <HeaderStyle BackColor="#810c15" Font-Bold="True" ForeColor="White" />
                  <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                  <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle CssClass="cssSelectedRow" BackColor="#C5BBAF" Font-Bold="True" 
                      ForeColor="#333333"></SelectedRowStyle>
            </asp:GridView>
            </td>
	</tr>
</table>
</asp:Content>
