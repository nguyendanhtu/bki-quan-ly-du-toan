<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="QuanLyDuToan.Default" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div style="margin-left: 5%">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick">
                </asp:Timer>
                <br />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>
    </div>

    <div style="clip: rect(auto, auto, auto, auto); margin-left: 5%; padding-right: 5%;" >
     
     <table width = "315px" >
        <tr class="title_ttql">
            <td >
              THÔNG TIN QUẢN LÝ  
            </td>
        </tr>
     </table>
     
    <!-- Bang Dat -->
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tbody>
            <tr>
                <td style="padding-left: 8px; padding-right: 5px;" valign="top">
                    <table border="0" cellpadding="0" cellspacing="0" width="300">
                        <tbody>
                            <tr>
                                <td valign="top">
                                    <table border="0" width="200" cellpadding="0" cellspacing="3" align="left">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <a href="#" title="Quản lý dự toán">
                                                        <img border="0" src="http://poipic.coccoc.vn/poi/previews/20141027/p1_14144024414354e8efbd9ca3a6d68ba20552f0d36a7328.jpg?r=1420951651735&user_id=af1708686de0f00e76eb63353cb15fe49bbac9b6" width="200" 
                                                        title="Quản lý dự toán" /></a>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 5px;">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p class="link_news_hot" style="margin-top: 0px; margin-bottom: 5px">
                                        <a href="#">Quản lý dự toán</a></p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table border="0" cellpadding="0" cellspacing="0" width="98%">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    Tập hợp các thông tin về dự toán của đơn vị sử dụng, theo dõi tình hình dự toán, báo cáo cho tổng cục.
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 5px;">
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
                <td style="width: 40%; padding-left: 5px; padding-right: 8px; border-left: 1px solid rgb(229, 229, 229);"
                    valign="top">
                    <table id="Table5" style="width: 100%; border-collapse: collapse;" border="0" cellspacing="0">
                        <tbody>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a href="/QuanLyDuToan/ChucNang/F101_QuanLyDat.aspx" style="font-weight: bold">Quản lý đơn vị sử dụng</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2015-01-12
                                                        14:45:58</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a class="link_OtherNews" href="/QuanLyDuToan/ChucNang/F104_DeNghiXuLyDat.aspx" style="font-weight: bold">Giao kế hoạch cho các đơn vị sử dụng</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2015-01-12
                                                        23:17:05</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a class="link_OtherNews" href="/QuanLyDuToan/ChucNang/F105_KhauHaoDat.aspx" style="font-weight: bold">Giao kế hoạch</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2015-01-12
                                                        23:22:17</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>  
                          
                        </tbody>
                    </table>
                </td>
                <td style="width: 60%; padding-left: 5px; padding-right: 8px; border-left: 1px solid rgb(229, 229, 229);"
                    valign="top">
                    <table id="Table6" style="width: 100%; border-collapse: collapse;" border="0" cellspacing="0">
                        <tbody>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a class="link_OtherNews" href="#" style="font-weight: bold">Báo cáo tổng cục</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2015-01-12
                                                        15:05:17</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a class="link_OtherNews" href="#" style="font-weight: bold">Báo cáo đơn vị</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2015-01-12
                                                        14:10:57</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
    <!-- Ket thuc bang Nha-->
    <hr />
    <!-- Bang Nha -->
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tbody>
            <tr>
                <td style="padding-left: 8px; padding-right: 5px;" valign="top">
                    <table border="0" cellpadding="0" cellspacing="0" width="300">
                        <tbody>
                            <tr>
                                <td valign="top">
                                    <table border="0" width="200" cellpadding="0" cellspacing="3" align="left">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <a href="#" title="Quản lý giao vốn">
                                                        <img border="0" src="http://drvn.gov.vn/webdrvn/index.php?q=system/files/publications/MrDong-ThuhutFDI.png&1420599085" width="200" title="Quản lý giao vốn" /></a>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 5px;">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p class="link_news_hot" style="margin-top: 0px; margin-bottom: 5px">
                                        <a href="#">Quản lý giao vốn</a></p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table border="0" cellpadding="0" cellspacing="0" width="98%">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    Tập hợp các thông tin giao vốn của đơn vị sử dụng, theo dõi tình hình giao vốn, báo cáo cho tổng cục.
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 5px;">
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
                <td style="width: 40%; padding-left: 5px; padding-right: 8px; border-left: 1px solid rgb(229, 229, 229);"
                    valign="top">
                    <table id="Table1" style="width: 100%; border-collapse: collapse;" border="0" cellspacing="0">
                        <tbody>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a href="/QuanLyDuToan/ChucNang/F100_QuanLyNha.aspx" style="font-weight: bold">Quản lý công tác giao vốn</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2015-01-12
                                                        14:45:58</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                             <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a class="link_OtherNews" href="/QuanLyDuToan/ChucNang/F102_DeNghiXuLyNha.aspx" style="font-weight: bold">Báo cáo tiến độ</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2015-01-12
                                                        23:17:05</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a class="link_OtherNews" href="/QuanLyDuToan/ChucNang/F302_khau_hao_nha.aspx" style="font-weight: bold">Báo cáo giao vốn</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2015-01-12
                                                        23:22:17</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                          
                        </tbody>
                    </table>
                </td>
                <td style="width: 60%; padding-left: 5px; padding-right: 8px; border-left: 1px solid rgb(229, 229, 229);"
                    valign="top">
                    <table id="Table4" style="width: 100%; border-collapse: collapse;" border="0" cellspacing="0">
                        <tbody>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a class="link_OtherNews" href="#" style="font-weight: bold">Quyết định bổ sung</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2015-01-12
                                                        15:05:17</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a class="link_OtherNews" href="#" style="font-weight: bold">Danh sách các đơn vị cập nhật thông tin</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2015-01-12
                                                        14:10:57</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                          
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
    <!-- Ket thuc bang Nha-->
    <hr />
    <!-- Bang Oto -->
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tbody>
            <tr>
                <td style="padding-left: 8px; padding-right: 5px;" valign="top">
                    <table border="0" cellpadding="0" cellspacing="0" width="300">
                        <tbody>
                            <tr>
                                <td valign="top">
                                    <table border="0" width="200" cellpadding="0" cellspacing="3" align="left">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <a href="#" title="Quản lý giai ngan">
                                                        <img border="0" src="http://drvn.gov.vn/webdrvn/index.php?q=system/files/imagecache/news_image_small/publications/doiGPLX.png" width="200" title="Quản lý giải ngân"></a>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 5px;">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p class="link_news_hot" style="margin-top: 0px; margin-bottom: 5px">
                                        <a href="#">Quản lý giải ngân </a></p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table border="0" cellpadding="0" cellspacing="0" width="98%">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    Tập hợp các thông tin giải ngân của đơn vị sử dụng, theo dõi tình hình giải ngân, báo cáo cho tổng cục.
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 5px;">
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
                <td style="width: 40%; padding-left: 5px; padding-right: 8px; border-left: 1px solid rgb(229, 229, 229);"
                    valign="top">
                    <table id="Table2" style="width: 100%; border-collapse: collapse;" border="0" cellspacing="0">
                        <tbody>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a href="/QuanLyDuToan/ChucNang/F500_QuanLyOto.aspx" style="font-weight: bold">Báo cáo giải ngân của đơn vị để báo cáo Tổng cục </a>&nbsp;<br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2015-01-12
                                                        14:45:58</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a class="link_OtherNews" href="/QuanLyDuToan/ChucNang/F410_DeNghiXuLyOto.aspx" style="font-weight: bold">Báo cáo tiến độ giải ngân của Tổng cục</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2015-01-12
                                                        23:17:05</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a class="link_OtherNews" href="/QuanLyDuToan/ChucNang/F103_KhauHaoOto.aspx" style="font-weight: bold">Theo dõi công tác giải ngân</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2015-01-12
                                                        23:22:17</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                           
                        </tbody>
                    </table>
                </td>

                <td style="width: 60%; padding-left: 5px; padding-right: 8px; border-left: 1px solid rgb(229, 229, 229);"
                    valign="top">
                    <table id="Table7" style="width: 100%; border-collapse: collapse;" border="0" cellspacing="0">
                        <tbody>
                        <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a class="link_OtherNews" href="#" style="font-weight: bold">Tổng hợp các báo cáo của đơn vị</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2015-01-12
                                                        15:05:17</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a class="link_OtherNews" href="#" style="font-weight: bold">Kế hoạch điều chỉnh</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2015-01-12
                                                        14:10:57</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
    <!-- Ket thuc Oto-->
    <hr />
    <!-- Bang Tai San Khac -->
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tbody>
            <tr>
                <td style="padding-left: 8px; padding-right: 5px;" valign="top">
                    <table border="0" cellpadding="0" cellspacing="0" width="300">
                        <tbody>
                            <tr>
                                <td valign="top">
                                    <table border="0" width="200" cellpadding="0" cellspacing="3" align="left">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <a href="#" title="Quản lý quyết toán">
                                                        <img border="0" src="http://drvn.gov.vn/webdrvn/index.php?q=system/files/imagecache/news_image_small/publications/hop%20led.png" width="200" title="Quản lý quyết toán"></a>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 5px;">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p class="link_news_hot" style="margin-top: 0px; margin-bottom: 5px">
                                        <a href="#">Quản lý quyết toán</a></p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table border="0" cellpadding="0" cellspacing="0" width="98%">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    Tập hợp các thông tin quyết toán của đơn vị sử dụng, theo dõi tình hình quyết toán, báo cáo cho tổng cục
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 5px;">
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
                <td style="width: 40%; padding-left: 5px; padding-right: 8px; border-left: 1px solid rgb(229, 229, 229);"
                    valign="top">
                    <table id="Table3" style="width: 100%; border-collapse: collapse;" border="0" cellspacing="0">
                        <tbody>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a href="/QuanLyDuToan/ChucNang/F200_DanhMucTaiSanKhac.aspx" style="font-weight: bold">Báo cáo tổng hợp kinh phí</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2015-01-11
                                                        14:45:58</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a class="link_OtherNews" href="/QuanLyDuToan/ChucNang/F202_DeNghiXuLyTaiSanKhac.aspx" style="font-weight: bold">Thanh tra kiểm tra</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2015-01-12
                                                        23:17:05</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a class="link_OtherNews" href="/QuanLyDuToan/ChucNang/F303_khau_hao_tai_san_khac.aspx" style="font-weight: bold">Danh mục công trình, thu chi phí nhà,giảm trừ</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2015-01-12
                                                        23:22:17</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>

                <td style="width: 60%; padding-left: 5px; padding-right: 8px; border-left: 1px solid rgb(229, 229, 229);"
                    valign="top">
                    <table id="Table8" style="width: 100%; border-collapse: collapse;" border="0" cellspacing="0">
                        <tbody>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a class="link_OtherNews" href="#" style="font-weight: bold">Tổng hợp báo cáo đơn vị</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2015-01-12
                                                        15:05:17</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a class="link_OtherNews" href="#" style="font-weight: bold">Tổng hợp báo cáo quyết toán quỹ bảo trì đường bộ</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2015-01-12
                                                        14:10:57</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>

            </tr>
        </tbody>
    </table>
    <!-- Ket thuc bang Tai San Khac-->

    </div>
    
</asp:Content>

