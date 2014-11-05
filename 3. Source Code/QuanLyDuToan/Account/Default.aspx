<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Account_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/jquery-ui.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $(".tb").autocomplete({

                source: function (request, response) {
                    $.ajax({
                        url: "../ChucNang/PersonService.asmx/GetOto",
                        data: "{ 'name_prefix': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    value: item.strTEN_TAI_SAN,
                                    dcID: item.dcID
                                }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(textStatus);
                        }
                    });
                },
                minLength: 1,
                select: function (event, ui) {
                    document.getElementById("<%= m_txt_id_oto.ClientID%>").value = ui.item.dcID;
                    console.log(ui.item.dcID);
                }
            });
        });
    </script>
    <script type="text/javascript">
        // Hàm này dùng để check all checkbox trên lưới
        function SelectAllCheckboxes(spanChk) {
            // Added as ASPX uses SPAN for checkbox
            var oItem = spanChk.children;
            var theBox = (spanChk.type == "checkbox") ? spanChk : spanChk.children.item[0];
            xState = theBox.checked;
            elm = theBox.form.elements;

            for (i = 0; i < elm.length; i++)
                if (elm[i].type == "checkbox" && elm[i].id != theBox.id) {
                    if (elm[i].checked != xState)
                        elm[i].click();
                }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <span class="cssManField">Ô tô</span>
    <asp:TextBox ID="tbAuto" runat="server" class="tb" Width="25%">
    </asp:TextBox>
    <span class="cssManField">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        ID</span>
    <asp:TextBox ID="m_txt_id_oto" runat="server"></asp:TextBox>
    <asp:GridView ID="m_grv_danh_sach_nha" runat="server" AutoGenerateColumns="False"
        Width="100%" DataKeyNames="ID" ShowFooter="true" CellPadding="4" ForeColor="#333333"
        AllowPaging="True" AllowSorting="True" PageSize="35">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <!-- Header checkbox -->
                    <input type="checkbox" id="chkAll" onclick="javascript:SelectAllCheckboxes(this)"
                        runat="server" />
                </HeaderTemplate>
                <ItemTemplate>
                    <!-- cái này là checkbox, hiểu là dữ liệu của cột -->
                    <asp:CheckBox runat="server" ID="chkItem" ToolTip='<%# Eval("ID") %>' />
                    <asp:CheckBox runat="server" ID="chkTrangThai" Visible="false" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %></ItemTemplate>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#810c15" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#810c15" Font-Bold="True" ForeColor="White" />
        <PagerSettings Position="TopAndBottom" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle CssClass="cssSelectedRow" BackColor="#C5BBAF" Font-Bold="True"
            ForeColor="#333333"></SelectedRowStyle>
    </asp:GridView>
    <asp:Button ID="m_cmd_hien_thi_id" runat="server" Text="Click" OnClick="m_cmd_hien_thi_id_Click" />
</asp:Content>
