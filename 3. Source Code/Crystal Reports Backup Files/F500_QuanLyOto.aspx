<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F500_QuanLyOto.aspx.cs" Inherits="ChucNang_F500_QuanLyOto" %>
<%@ Register assembly="eWorld.UI" namespace="eWorld.UI" tagprefix="ew" %>
<%@ Import Namespace ="IP.Core.IPCommon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
 a 
 {
   text-decoration:none;    
 }
        .style1
        {
            width: 13%;
        }
        .style2
        {
            width: 1%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
    <tr>
		<td class="cssPageTitleBG" colspan="3">
		    <asp:label id="Label1" runat="server" CssClass="cssPageTitle" 
                Text="Quản lý ô tô"/>
		</td>
	</tr>	
    <tr>
        <td>
        
        <table cellspacing="0" cellpadding="2" style="width:1000px;" class="cssTable" border="0"> 
            <tr>
                <td align="right" style="width:7%;">
			        &nbsp;</td>
                <td align="left" colspan="3">
                    <asp:ValidationSummary ID="vdsCategory" runat="server" CssClass="cssManField" 
                        Font-Bold="true" />
                </td>
                <td align="right" colspan="4">
			        &nbsp;</td>
                <td align="left" class="style1">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:7%;">
			        <asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField" />
                         </td>
                <td align="left" colspan="3">
                    &nbsp;</td>
                <td align="right" colspan="4">
			        &nbsp;</td>
                <td align="left" class="style1">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:7%;">
			        &nbsp;</td>
                <td align="left" colspan="3">
                    &nbsp;</td>
                <td align="right" colspan="4">
			        &nbsp;</td>
                <td align="left" class="style1">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:7%;">
			<asp:label id="lblFullName14" CssClass="cssManField" runat="server" 
                Text="Bộ, Tỉnh" />
                         </td>
                <td align="left" colspan="3">
                    <asp:DropDownList ID="m_dll_bo_tinh" runat="server" Width="265px">
                    </asp:DropDownList>
                </td>
                <td align="right" colspan="4">
			        &nbsp;</td>
                <td align="left" class="style1">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:7%;">
			<asp:label id="lblFullName15" CssClass="cssManField" runat="server" 
                Text="Đơn vị chủ quản" />
                         </td>
                <td align="left" colspan="3">
                    <asp:DropDownList ID="m_ddl_dv_chu_quan" runat="server" Width="265px">
                    </asp:DropDownList>
                </td>
                <td align="right" colspan="4">
			        &nbsp;</td>
                <td align="left" class="style1">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:7%;">
			<asp:label id="lblFullName16" CssClass="cssManField" runat="server" 
                Text="Đơn vị sử dụng tài sản" />
                         </td>
                <td align="left" colspan="3">
                    <asp:DropDownList ID="m_ddl_dv_sd_ts" runat="server" Width="265px">
                    </asp:DropDownList>
                </td>
                <td align="right" colspan="4">
			        &nbsp;</td>
                <td align="left" class="style1">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:7%;">
			        &nbsp;</td>
                <td align="left" colspan="3">
                    &nbsp;</td>
                <td align="right" colspan="4">
			        &nbsp;</td>
                <td align="left" class="style1">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:7%;">
			<asp:label id="lblFullName13" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;L&lt;/U&gt;oại xe" />
                         </td>
                <td align="left" colspan="3">
                    <asp:DropDownList ID="m_ddl_loai_xe" runat="server" Width="265px">
                    </asp:DropDownList>
                </td>
                <td align="right" colspan="4">
			        &nbsp;</td>
                <td align="left" class="style1">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:7%;">
			<asp:label id="lblFullName" CssClass="cssManField" runat="server" 
                Text="Nhãn hiệu" />
                         </td>
                <td align="left" colspan="3">
                &nbsp;<asp:TextBox ID="m_txt_ten_nhan_hieu" runat="server" CssClass="cssTextBox" 
                        Width="84%"></asp:TextBox>
		            &nbsp;</td>
                <td align="right" colspan="4">
			<asp:label id="lblFullName2" CssClass="cssManField" runat="server" 
                Text="Giá trị theo số kế toán (ngàn đồng)" />
		            </td>
                <td align="left" class="style1"></td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
                    <asp:label id="Label17" CssClass="cssManField" runat="server" 
                Text="Biển kiểm soát" /></td>
                <td align="left" colspan="3">
                        <asp:TextBox ID="m_txt_bien_kiem_soat" runat="server" CssClass="cssTextBox" 
                        Width="85%"></asp:TextBox>
                    </td>
                <td align="left" style="width:7%;" rowspan="2">
			<asp:label id="lblFullName3" CssClass="cssManField" runat="server" 
                Text="Nguyên giá" />
                         </td>
                <td align="right" colspan="3" style="margin-left: 40px">
			<asp:label id="lblFullName4" CssClass="cssManField" runat="server" 
                Text="Nguồn NS" />
                </td>
                <td align="left" class="style1">
                    <asp:TextBox ID="m_txt_nguon_ns" runat="server" CssClass="cssTextBox" 
                        Width="85%"></asp:TextBox>
		            </td>
            </tr>                   
            <tr>
                <td align="right" style="width:5%;">
                    <asp:label id="Label14" CssClass="cssManField" runat="server" 
                Text="Số chỗ ngồi/Tải trọng" /></td>
                <td align="left" colspan="3">
                     <asp:TextBox ID="m_txt_tai_trong" runat="server" CssClass="cssTextBox" 
                        Width="85%"></asp:TextBox></td>
                <td align="right" colspan="3" style="margin-left: 40px">
			<asp:label id="lblFullName5" CssClass="cssManField" runat="server" 
                Text="Nguồn khác" />
                </td>
                <td align="left" class="style1">
                    <asp:TextBox ID="m_txt_nguon_khac" runat="server" CssClass="cssTextBox" 
                        Width="85%"></asp:TextBox>
		            </td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
                    <asp:label id="Label15" CssClass="cssManField" runat="server" 
                Text="Nước sản xuất" /></td>
                <td align="left" colspan="3">
                     <asp:TextBox ID="m_txt_nuoc_san_xuat" runat="server" CssClass="cssTextBox" 
                        Width="85%"></asp:TextBox></td>
                <td align="left" colspan="4">
			<asp:label id="lblFullName6" CssClass="cssManField" runat="server" 
                Text="Giá trị còn lại" />
                         </td>
                <td align="left" class="style1">
                    <asp:TextBox ID="m_txt_gia_tri_con_lai" runat="server" CssClass="cssTextBox" 
                        Width="85%"></asp:TextBox>
		            </td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
                    <asp:label id="Label4" CssClass="cssManField" runat="server" 
                Text="Năm sản xuất" /></td>
                <td align="left" colspan="3">
                     <asp:TextBox ID="m_txt_nam_san_xuat" runat="server" CssClass="cssTextBox" 
                        Width="85%"></asp:TextBox></td>
                <td  align="right" colspan="4">
			<asp:label id="lblFullName7" CssClass="cssManField" runat="server" 
                Text="Hiện trạng sử dụng (chiếc)" />
                         </td>
                <td align="left" class="style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
                    <asp:label id="Label19" CssClass="cssManField" runat="server" 
                Text="Cống suất xe" /></td>
                <td align="left" colspan="3">
                     <asp:TextBox ID="m_txt_cong_suat_xe" runat="server" CssClass="cssTextBox" 
                        Width="85%"></asp:TextBox></td>
                <td align="left" colspan="4">
			<asp:label id="lblFullName8" CssClass="cssManField" runat="server" 
                Text="QLNN" />
                         </td>
                <td align="left" class="style1">
                    <asp:TextBox ID="m_txt_qlnn" runat="server" CssClass="cssTextBox" 
                        Width="85%"></asp:TextBox>
		            </td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
                    <asp:label id="Label20" CssClass="cssManField" runat="server" 
                Text="Chức danh sử dụng xe" /></td>
                <td align="left" colspan="3">
                     <asp:TextBox ID="m_txt_chuc_danh_sd_xe" runat="server" CssClass="cssTextBox" 
                        Width="85%"></asp:TextBox></td>
                <td align="left" style="width:7%;"  rowspan="2">
			<asp:label id="lblFullName9" CssClass="cssManField" runat="server" 
                Text="HĐ sự nghiệp" />
                         </td>
                <td align="right" colspan="3" style="margin-left: 40px">
			<asp:label id="lblFullName11" CssClass="cssManField" runat="server" 
                Text="Kinh doanh" />
                </td>
                <td align="left" class="style1">
                    <asp:TextBox ID="m_txt_kinh_doanh" runat="server" CssClass="cssTextBox" 
                        Width="85%"></asp:TextBox>
		            </td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
                    <asp:label id="Label21" CssClass="cssManField" runat="server" 
                Text="Nguồn gốc xe" /></td>
                <td align="left" colspan="3">
                     <asp:TextBox ID="m_txt_nguon_goc_xe" runat="server" CssClass="cssTextBox" 
                        Width="85%"></asp:TextBox></td>
                <td align="right" colspan="3" style="margin-left: 40px">
			<asp:label id="lblFullName12" CssClass="cssManField" runat="server" 
                Text="Không kinh doanh" />
                </td>
                <td align="left" class="style1">
                    <asp:TextBox ID="m_txt_khong_kinh_doanh" runat="server" CssClass="cssTextBox" 
                        Width="85%"></asp:TextBox>
		            </td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
                    &nbsp;</td>
                <td align="left" colspan="3">
                     &nbsp;</td>
                <td align="left" colspan="4">
			<asp:label id="lblFullName10" CssClass="cssManField" runat="server" 
                Text="HĐ khác" />
                         </td>
                <td align="left" class="style1">
                    <asp:TextBox ID="m_txt_hd_khac" runat="server" CssClass="cssTextBox" 
                        Width="85%"></asp:TextBox>
		            </td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
                    <asp:label id="Label18" CssClass="cssManField" runat="server" 
                Text="Ngày tháng năm sử dụng" /></td>
                <td align="left" colspan="3">
                     <asp:Calendar ID="m_dt_ngay_su_dung" runat="server" BackColor="#FFFFCC" 
                         BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" 
                         Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" 
                         ShowGridLines="True" Width="220px">
                         <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                         <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                         <OtherMonthDayStyle ForeColor="#CC9966" />
                         <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                         <SelectorStyle BackColor="#FFCC66" />
                         <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" 
                             ForeColor="#FFFFCC" />
                         <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                     </asp:Calendar>
                </td>
                <td style="width:7%;" class="csscurrency">
                    &nbsp;</td>
                <td align="right" colspan="3" style="margin-left: 40px">
                    <asp:label id="Label22" CssClass="cssManField" runat="server" 
                Text="Ngày cập nhật" /></td>
                <td align="left" class="style1">
                     <asp:Calendar ID="m_dt_ngay_sd" runat="server" BackColor="#FFFFCC" 
                         BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" 
                         Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" 
                         ShowGridLines="True" Width="220px">
                         <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                         <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                         <OtherMonthDayStyle ForeColor="#CC9966" />
                         <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                         <SelectorStyle BackColor="#FFCC66" />
                         <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" 
                             ForeColor="#FFFFCC" />
                         <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                     </asp:Calendar>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="5">

                &nbsp;&nbsp;&nbsp;

                <asp:label id="lblFullName1" CssClass="cssLabel" runat="server" 
                
                
                        Text="(Từ khóa tìm kiếm: Nhãn hiệu, Biển kiểm soát , Tải trọng, Nước sản xuất, Năm sản xuất, Công suất xe...)" />

		        </td>
                <td align="left" colspan="3" style="margin-left: 40px">
			        &nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			        <asp:Label ID="lbl_ghi_chu0" runat="server" CssClass="cssManField" 
                        Text="Từ khóa tìm kiếm" />
                </td>
                <td align="left" colspan="3">          
                     <asp:TextBox ID="m_txt_tim_kiem" runat="server" CssClass="cssTextBox" 
                        Width="85%"></asp:TextBox></td>
                <td align="left" style="width:7%;">     
			        &nbsp;</td>     
                    <td align="left" style="width:1%;"></td>
                 <td align="right" style="width:5%;"></td>
                <td align="left" class="style2"></td>     <td align="left" class="style1"></td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			        &nbsp;</td>
                <td align="left" style="width:10%;">          
			        &nbsp;</td>
			    <td align="left" style="width:1%;">
                    &nbsp;</td>
			
                <td align="left" style="width:5%;">
			        &nbsp;</td>
                <td align="left" style="width:7%;">     
			        &nbsp;</td>     
                    <td align="left" style="width:1%;">&nbsp;</td>
                 <td align="right" style="width:5%;">&nbsp;</td>
                <td align="left" class="style2">&nbsp;</td>     <td align="left" class="style1">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			        &nbsp;</td>
                <td align="left" style="width:10%;">          
			        &nbsp;</td>
			    <td align="left" style="width:1%;">
                    &nbsp;</td>
			
                <td align="left" style="width:5%;">
			        &nbsp;</td>
                <td align="left" style="width:7%;">     
			        &nbsp;</td>     
                    <td align="left" style="width:1%;">&nbsp;</td>
                 <td align="right" style="width:5%;">&nbsp;</td>
                <td align="left" class="style2">&nbsp;</td>     <td align="left" class="style1">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" colspan="4" >
			        <asp:Button ID="m_cmd_tim_kiem" runat="server" accessKey="c" 
                        CssClass="cssButton" onclick="m_cmd_tim_kiem_Click" Text="Tìm kiếm(s)" 
                        Width="98px" />
                    <asp:Button ID="m_cmd_tao_moi" runat="server" accessKey="c" 
                        CssClass="cssButton" onclick="m_cmd_tao_moi_Click" Text="Tạo mới(c)" 
                        Width="98px" />
                    <asp:Button ID="m_cmd_cap_nhat" runat="server" accessKey="u" 
                        CssClass="cssButton" onclick="m_cmd_cap_nhat_Click" Text="Cập nhật(u)" 
                        Width="98px" />
                    <asp:Button ID="btnCancel" runat="server" accessKey="r" CssClass="cssButton" 
                        onclick="btnCancel_Click" Text="Xóa trắng(r)" Width="98px" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <%--<asp:LinkButton id="m_lbt_advanced_search" PostBackUrl="/QuanLyTaiSan/ChucNang/F205_AdvanceSearchGiangVien.aspx" runat="server" CausesValidation="false" Text= "Tìm kiếm nâng cao"></asp:LinkButton>--%>
			    </td>
                <td align="left" >    
			        &nbsp;</td>
                             <td align="left" >&nbsp;</td>
                 <td align="right" >
                 <asp:HiddenField id="hdf_id" runat="server"/></td>
                <td align="left" class="style2" ></td>    
                <td align="left" class="style1" >&nbsp;</td>
            </tr>
            </table>        
        </td>
    </tr>  
    <tr>
		<td class="cssPageTitleBG" colspan="3">
		    <asp:label id="m_lbl_ket_qua_loc_du_lieu" runat="server" CssClass="cssPageTitle" 
                Text="Kết quả lọc dữ liệu"/>
		</td>
	</tr>	
    <tr>
		<td align="left">
        &nbsp;<br />
                <asp:Label ID="m_lbl_thong_bao" runat="server" CssClass="cssManField" />
        </td>
        <td >
		    &nbsp;</td>
	</tr>	
	<tr>
		<td align="center" colspan="3" style="height:450px;" valign="top">
		    &nbsp;
   <asp:GridView ID="m_grv_dm_oto" AllowPaging="True" 
                runat="server" AutoGenerateColumns="False" 
                Width="101%" DataKeyNames="ID"
                CellPadding="4" ForeColor="#333333" 
            AllowSorting="True" 
            onpageindexchanging="m_grv_dm_oto_PageIndexChanging" 
            onrowdeleting="m_grv_dm_oto_RowDeleting" PageSize="15" >
                  <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><asp:Label ID="m_lbl_stt" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                 <asp:TemplateField HeaderText="Bộ, Tỉnh" >
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ĐV chủ quản">
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ĐV sử dụng tài sản">
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Loại xe">
                    </asp:TemplateField>      
                    <asp:BoundField DataField="NHAN_HIEU" HeaderText="Nhãn hiệu" />
                    <asp:BoundField DataField="BIEN_KIEM_SOAT" HeaderText="Biển kiểm soát" />
                    <asp:BoundField DataField="TAI_TRONG" HeaderText="Tải trọng" />
                    <asp:BoundField DataField="NUOC_SAN_XUAT" HeaderText="Nước sản xuất" />
                    <asp:BoundField DataField="NAM_SAN_XUAT" HeaderText="Năm sản xuất" />
                    <asp:BoundField DataField="NAM_SU_DUNG" HeaderText="Năm sử dụng" />
                    <asp:BoundField DataField="CONG_SUAT_XE" HeaderText="Công suất " />
                    <asp:BoundField DataField="CHUC_DANH_SU_DUNG_XE" 
                        HeaderText="Chức danh sử dụng xe" />
                    <asp:BoundField DataField="NGUON_GOC_XE" HeaderText="Nguồn gốc" />
                    <asp:BoundField DataField="NGUON_NS" HeaderText="Nguồn NS" />
                    <asp:BoundField DataField="NGUON_KHAC" HeaderText="Nguồn khác" />
                    <asp:BoundField DataField="GIA_TRI_CON_LAI" HeaderText="Giá trị còn lại" />
                    <asp:BoundField DataField="QLNN" HeaderText="QLNN" />
                    <asp:BoundField DataField="KINH_DOANH" HeaderText="Kinh doanh" />
                    <asp:BoundField DataField="KHONG_KINH_DOANH" HeaderText="Không kinh doanh" />
                    <asp:BoundField DataField="HD_KHAC" HeaderText="HĐ khác" />
                      <asp:CommandField ShowEditButton="True" />

                    <asp:CommandField ShowDeleteButton="True" />

                </Columns>
                  <EditRowStyle BackColor="#7C6F57" />
                  <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                  <HeaderStyle BackColor="#810c15" Font-Bold="True" ForeColor="White" />
                  <PagerSettings Position="TopAndBottom" />
                  <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                  <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle CssClass="cssSelectedRow" BackColor="#C5BBAF" Font-Bold="True" 
                      ForeColor="#333333"></SelectedRowStyle>
            </asp:GridView>
            </td>
	</tr>	

</table>

</asp:Content>
