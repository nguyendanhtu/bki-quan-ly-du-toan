<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F520_theo_doi_tinh_hinh_giao_von_qbt.aspx.cs" Inherits="QuanLyDuToan.BaoCao.F520_theo_doi_tinh_hinh_giao_von_qbt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        th, td {
            width:100px;
            padding-right:5px;
        }

        th {
            text-align:center;
        }

        .keHoachClass {
            background-color:#edb681;
        }

        .soDuClass {
            background-color:#abe093;
        }

        .giaoVonClass {
            background-color:#a4a3d7;
            color:white;
        }
        
	    .height30 {
	        height:30px;
        }

	    .lb {
	        width:100px; 
            float:left;
            text-align:right;
            line-height:20px;
        }
       
    </style>
     <script src="../Scripts/jquery.doubleScroll.js"></script>
     <script>
         function pageLoad(sender, args) {
             if (args.get_isPartialLoad()) {
                 $('#double-scroll').doubleScroll();
                $("#<%=m_txt_tu_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });
                $("#<%=m_txt_den_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });

            }
        }
        $(document).ready(function () {
            $('#double-scroll').doubleScroll();
            $("#<%=m_txt_tu_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });
            $("#<%=m_txt_den_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });
        }
       )
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
	</asp:ScriptManager>

	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
        <div>
            <div style="text-align:center;">
            <span style="font-weight: bold">CỘNG HOÀ XÃ HỘI CHỦ NGHĨA VIỆT NAM</span>
		    <br />
		    <span style="font-weight: bold">Độc lập - Tự do - Hạnh Phúc</span>
		    <br />
		    <br />
		    <span style="font-weight: bold">BÁO CÁO THEO DÕI TÌNH HÌNH GIAO VỐN QBT</span>
        </div>
        <div style="color:black;width:350px; text-align:center; margin:auto;height: 74px;">
           <div class="height30">
                <div class="lb" style="margin-right:30px">Từ ngày</div>
                     <div id="datetimepicker1" class="input-group date datepicker" style="width: 200px;">
                          <asp:TextBox ID="m_txt_tu_ngay" placeholder="dd/MM/yyyy" runat="server" CssClass="cssTextBox form-control  date-start" Height="30px" Width="164px"></asp:TextBox>
                           <span class="input-group-addon"><span class="glyphicon-calendar glyphicon"></span>
                           </span>
                      </div>
                </div>
                <div class="height30">
				<div class="lb" style="margin-right:30px">Đến ngày</div>
                    <div id="datetimepicker2" class="input-group date datepicker" style="width: 200px;">
                    <asp:TextBox ID="m_txt_den_ngay" placeholder="dd/MM/yyyy" runat="server" CssClass="cssTextBox form-control date-end" Height="30px" Width="164px"></asp:TextBox>
                    <span class="input-group-addon"><span class="glyphicon-calendar glyphicon"></span>
                    </span>
                 </div>
            </div>      
        </div>
        <div style="width:350px; text-align:center; margin:auto;height: 45px;">
            <asp:Button ID="m_cmd_xem_bao_cao" Text="Xem báo cáo" runat="server" cssclass="btn" OnClick="m_cmd_xem_bao_cao_Click" />
            <asp:Button ID="m_cmd_xuat_excel" Text="Xuất excel" runat="server" cssclass="btn" Enabled="true" OnClick="m_cmd_xuat_excel_Click" />
        </div>
        <div style="width:1200px; overflow-y:hidden; margin:0px auto;">
                <div id="double-scroll" >
                <asp:gridview Width="2500px" runat="server" id="m_grv_bao_cao_giao_von" AutoGenerateColumns="False" EnableModelValidation="True">
                    <Columns>
                        <asp:BoundField DataField="TEN_DON_VI" HeaderText="Đơn vị" HtmlEncode="False" >
                        <HeaderStyle Width="200px" CssClass="pinned thpinned"/>
                        <ItemStyle Width="200px" CssClass="pinned"/>
                        </asp:BoundField>
                    </Columns>
                </asp:gridview>
                </div>
            </div>
        </ContentTemplate>
	<Triggers>
			<asp:PostBackTrigger ControlID="m_cmd_xuat_excel" />
	</Triggers>
    </asp:UpdatePanel>
	<asp:UpdateProgress ID="UpdateProgress1" runat="server">
		<ProgressTemplate>
			<div class="cssLoadWapper">
				<div class="cssLoadContent">
					<img src="../Images/loadingBar.gif" alt="" />
					<p>
						Đang gửi yêu cầu, hãy đợi ...
					</p>
				</div>
			</div>
		</ProgressTemplate>
	</asp:UpdateProgress>
</asp:Content>
