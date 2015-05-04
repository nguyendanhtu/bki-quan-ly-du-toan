<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BC_Du_toan_thu_chi_phi_pha.aspx.cs" Inherits="QuanLyDuToan.BaoCaoQT.BC_Du_toan_thu_chi_phi_pha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=m_ddl_chon_nam.ClientID%>").select2();
            var lst = $('.so_tien');
            for (var i = 0; i < lst.length; i++) {
                $(lst[i]).text(formatString($(lst[i]).text()));
            }
        })
        function pageLoad(sender, args) {
            if (args.get_isPartialLoad()) {
                $("#<%=m_ddl_chon_nam.ClientID%>").select2();
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="h3 text-center">BẢNG TỔNG HỢP DỰ TOÁN THU, CHI PHÍ PHÀ</h3>
    <div class="height30" style="margin: 0 auto;">
        <div class="control text-center">
            <span class="lb" style="font-weight: 300; font-size: medium">Năm</span>
            &nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="m_ddl_chon_nam" runat="server" Width="80px" AutoPostBack="True" CssClass="select2" OnSelectedIndexChanged="m_ddl_chon_nam_SelectedIndexChanged"></asp:DropDownList>
        </div>
    </div>
    <br />
    <div style="width: 500px">
        <label class="text-right">Đơn vị tính: đồng</label>
    </div>
    <div>
        <table style="min-width: 1200px">
            <thead>
                <tr>
                    <th rowspan="2" style="text-align: center">TT</th>
                    <th rowspan="2" style="text-align: center">Tên bến phà</th>
                    <th rowspan="2" style="text-align: center">Dự toán thu</th>
                    <th colspan="4">Dự toán chi</th>
                    <th rowspan="2" style="text-align: center">Chênh lệch thu chi phải cấp bù</th>
                </tr>
                <tr>
                    <th style="text-align: center">Chi thường xuyên</th>
                    <th style="text-align: center">Chi không thường xuyên</th>
                    <th style="text-align: center">Quỹ khen thưởng</th>
                    <th style="text-align: center">Tổng cộng</th>
                </tr>

            </thead>
            <tbody>
                <%decimal stt = 1; %>
                <%foreach (var pha in lst_pha)
                  {%>
                <tr>
                    <%-- STT --%>
                    <td><%=stt++%></td>
                    <%-- Tên phà --%>
                    <td><%=pha.TEN_PHA%></td>
                    <%-- Dự toán thu --%>
                    <td><%=lst_gd_phi_pha.Where(x=>x.ID_PHA==pha.ID_PHA && x.MA_SO==LoaiMa.DU_TOAN_THU)
                                           .Select(x=>x.KINH_PHI_GIAO_KH)
                                           .Sum()%></td>
                    <%-- Chi thường xuyên --%>
                    <td><%=lst_gd_phi_pha.Where(x=>x.ID_PHA==pha.ID_PHA && x.MA_SO == LoaiMa.CHI_THUONG_XUYEN)
                                           .Select(x=>x.KINH_PHI_GIAO_KH)
                                           .Sum()%></td>
                    <%-- Chi không thường xuyên --%>
                    <td><%=lst_gd_phi_pha.Where(x=>x.ID_PHA==pha.ID_PHA && x.MA_SO == LoaiMa.CHI_KHONG_THUONG_XUYEN)
                                           .Select(x=>x.KINH_PHI_GIAO_KH)
                                           .Sum()%></td>
                    <%-- Quỹ khen thưởng --%>
                    <td><%=lst_gd_phi_pha.Where(x=>x.ID_PHA==pha.ID_PHA && x.MA_SO == LoaiMa.QUY_KHEN_THUONG)
                                           .Select(x=>x.KINH_PHI_GIAO_KH)
                                           .Sum()%></td>
                    <%-- Tổng cộng --%>
                    <td><%=lst_gd_phi_pha.Where(x=>x.ID_PHA==pha.ID_PHA && x.MA_SO == LoaiMa.DU_TOAN_CHI)
                                           .Select(x=>x.KINH_PHI_GIAO_KH)
                                           .Sum()%></td>
                    <%-- Chênh lệch thu-chi --%>
                    <td><%=lst_gd_phi_pha.Where(x=>x.ID_PHA==pha.ID_PHA && x.MA_SO == LoaiMa.CHENH_LECH_THU_CHI)
                                           .Select(x=>x.KINH_PHI_GIAO_KH)
                                           .Sum()%></td>
                </tr>
                <% } %>
                <%-- Tổng cộng --%>
                <tr style="font-weight:bold">
                     <%-- STT --%>
                    <td></td>
                    <%-- Tên phà --%>
                    <td>Tổng cộng</td>
                      <%-- Dự toán thu --%>
                    <td><%=lst_gd_phi_pha.Where(x=>x.MA_SO==LoaiMa.DU_TOAN_THU)
                                           .Select(x=>x.KINH_PHI_GIAO_KH)
                                           .Sum()%></td>
                    <%-- Chi thường xuyên --%>
                    <td><%=lst_gd_phi_pha.Where(x=>x.MA_SO == LoaiMa.CHI_THUONG_XUYEN)
                                           .Select(x=>x.KINH_PHI_GIAO_KH)
                                           .Sum()%></td>
                    <%-- Chi không thường xuyên --%>
                    <td><%=lst_gd_phi_pha.Where(x=>x.MA_SO == LoaiMa.CHI_KHONG_THUONG_XUYEN)
                                           .Select(x=>x.KINH_PHI_GIAO_KH)
                                           .Sum()%></td>
                    <%-- Quỹ khen thưởng --%>
                    <td><%=lst_gd_phi_pha.Where(x=>x.MA_SO == LoaiMa.QUY_KHEN_THUONG)
                                           .Select(x=>x.KINH_PHI_GIAO_KH)
                                           .Sum()%></td>
                    <%-- Tổng cộng --%>
                    <td><%=lst_gd_phi_pha.Where(x=>x.MA_SO == LoaiMa.DU_TOAN_CHI)
                                           .Select(x=>x.KINH_PHI_GIAO_KH)
                                           .Sum()%></td>
                    <%-- Chênh lệch thu-chi --%>
                    <td><%=lst_gd_phi_pha.Where(x=>x.MA_SO == LoaiMa.CHENH_LECH_THU_CHI)
                                           .Select(x=>x.KINH_PHI_GIAO_KH)
                                           .Sum()%></td>
                </tr>
            </tbody>
            <tfoot>
            </tfoot>
        </table>
    </div>
</asp:Content>
