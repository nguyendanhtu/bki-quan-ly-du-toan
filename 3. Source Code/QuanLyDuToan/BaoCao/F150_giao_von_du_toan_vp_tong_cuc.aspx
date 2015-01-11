<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F150_giao_von_du_toan_vp_tong_cuc.aspx.cs" Inherits="QuanLyDuToan.BaoCao.F150_giao_von_du_toan_vp_tong_cuc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .boxControl {
	        float:left;
            width:50%; 
            height:90px;
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

	    .control {
	        width:200px; 
            float:left;
        }

	    .control select, input {
	        width:220px !important;
            margin-left:10px;    
        }

        .filter{
	        width:552px !important;
            margin-left:10px;    
        }

        .divBoxControl {
            width:30%; 
            margin:0px auto;
        }

        .setWidth {
            /*width:100px;*/
        }

        table {
          table-layout: fixed; 
          width: 100%;
        }
        td, th {
          vertical-align: top;
          width:100px;
          margin-left: -2px;
        }
        .pinned {
          position:absolute;
          left:0; 
          width:200px;
          border-top:0px;
        }
        .pinned2 {
          position:absolute;
          left:200px; 
          width:100px;
          border-left:0px;
          border-top:0px;
        }
        .pinned3 {
          position:absolute;
          left:300px; 
          width:100px;
          border-left:0px;
          border-top:0px;
        }
        .pinned4 {
          position:absolute;
          left:400px; 
          width:100px;
          border-left:0px;
          border-top:0px;
        }
        .outer 
        {
            position:relative;
            margin: 30px auto;
            width: 840px;
        }
        .inner {
          overflow-x:scroll;
          overflow-y:visible;
          width:300px; 
          margin-left:500px;
        }
        .thpinned {
            border-top:1px solid gray;
            margin-top: -1px;
        }
		
		.merge3{
			width:300px;
			border-bottom:0px;
			border-top:1px solid gray;
            font-weight:bold;
		}
		
		.merge1{
			height:28px;
			border-top:1px solid gray;
            font-weight:bold;
		}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
	</asp:ScriptManager>

	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
        <div style="text-align:center;">
            <span style="font-weight: bold">CỘNG HOÀ XÃ HỘI CHỦ NGHĨA VIỆT NAM</span>
		    <br />
		    <span style="font-weight: bold">Độc lập - Tự do - Hạnh Phúc</span>
		    <br />
		    <br />
		    <span style="font-weight: bold">TỔNG HỢP ĐÃ GIAO DỰ TOÁN CHO VĂN PHÒNG TỔNG CỤC</span>
        </div>
        <div style="color:black; text-align:center; margin-top:20px;">
            <div class="divBoxControl">
                <div class="height30">
                    <div class="lb">Tìm kiếm:</div>
				    <div class="control"><asp:TextBox ID="m_txt_tu_khoa_tim_kiem" runat="server"></asp:TextBox></div>
                </div>
                <div class="height30">
                    <div class="lb">Từ ngày</div>
				    <div class="control"><asp:TextBox ID="m_txt_tu_ngay" placeholder="dd/MM/yyyy" runat="server" CssClass="cssTextBox" Width="100px"></asp:TextBox></div>
                </div>
                <div class="height30">
				    <div class="lb">Đến ngày</div>
				    <div class="control"><asp:TextBox ID="m_txt_den_ngay" placeholder="dd/MM/yyyy" runat="server" CssClass="cssTextBox" Width="100px"></asp:TextBox></div>
                </div>
            </div>
            <div>
                <asp:Button ID="m_cmd_xem_bao_cao" Text="Xem báo cáo" runat="server" Height="24px" Width="98px" OnClick="m_cmd_xem_bao_cao_Click" />
                <asp:Button ID="m_cmd_xuat_excel" Text="Xuất excel" runat="server" Height="24px" Width="98px" />
            </div>
        </div>
        <div class="outer">
            <div class="inner">
            <asp:gridview runat="server" id="m_grv_bao_cao_giao_von" AutoGenerateColumns="False" EnableModelValidation="True" OnRowCreated="m_grv_bao_cao_giao_von_RowCreated" OnRowDataBound="m_grv_bao_cao_giao_von_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="noi_dung" HeaderText="Nội dung" HtmlEncode="False" >
                    <HeaderStyle Width="200px" CssClass="pinned thpinned"/>
                    <ItemStyle Width="200px" CssClass="pinned"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="TONG_SO" HeaderText="Tổng số" HtmlEncode="False" DataFormatString="{0:N0}">
                    <HeaderStyle CssClass="pinned2 thpinned"/>
                    <ItemStyle HorizontalAlign="Right" CssClass="pinned2"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="TU_CHU" HeaderText="Tự chủ" HtmlEncode="False" DataFormatString="{0:N0}">
                    <HeaderStyle CssClass="pinned3 thpinned"/>
                    <ItemStyle HorizontalAlign="Right" CssClass="pinned3"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="KHONG_TU_CHU" HeaderText="K. Tự chủ" DataFormatString="{0:N0}">
                    <HeaderStyle CssClass="pinned4 thpinned"/>
                    <ItemStyle HorizontalAlign="Right" CssClass="pinned4"/>
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
