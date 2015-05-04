﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BC_Danh_muc_giam_tru_quyet_toan.aspx.cs" Inherits="QuanLyDuToan.BaoCaoQT.BC_PL05_Danh_muc_giam_tru_quyet_toan" %>

<%@ Import Namespace="SQLDataAccess" %>
<%@ Import Namespace="WebUS" %>

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
      <style>
        #tblPL05 > thead > tr > th {
			border: 1px solid #000;
		}
        .so_tien {
            text-align:right;
        }
        #tblPL05 {
        background-color:white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="h3 text-center">DANH MỤC CÔNG TRÌNH GIẢM TRỪ</h3>
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
    <table class="table table-hover table-bordered" style="width: 1200px" id="tblPL05">
        <thead>
            <tr>
                <th style="width:50px">STT</th>
                <th style="width:500px">Danh mục</th>
                <th style="width:400px">Nội dung</th>
                <th>Giá trị</th>
            </tr>
        </thead>
        <tbody>
            <%-- level 0: Theo đơn vị --%>
            <%decimal i = 1; %>
            <%foreach (var donvi in lst_don_vi.OrderBy(x => x.TEN_DON_VI).ToList())
              { %>
            <tr>
                <%-- STT --%>
                <td style="text-align:center;font-weight:bold"><%=i++%></td>
                <%-- Đơn vị --%>
                <td style="font-weight:bold"><%=donvi.TEN_DON_VI%></td>
                <%-- Nội dung --%>
                <td></td>
                <%-- Giá trị --%>
                <td>
                    <label class="so_tien"><%=lst_PL04.Where(x=>x.ID_DON_VI==donvi.ID_DON_VI).Select(x=>(x.GIA_TRI_QUYET_TOAN-x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)).ToList().Sum()%></label>
                </td>

            </tr>
            <%-- level 1: Theo loại nhiệm vụ --%>
                           <%foreach (var loai_nhiem_vu in lst_PL04.Where(x=>x.ID_DON_VI==donvi.ID_DON_VI).Select(x=> new {Ten_nhiem_vu = x.TEN_LOAI_NHIEM_VU, STT = x.TT}).Distinct().OrderBy(x=>x.STT))
                          { %>
                        <tr>
                            <%-- STT --%>
                            <td style="font-weight:bold; text-align:center"><%=loai_nhiem_vu.STT%></td>
                            <%-- Nhiệm vụ --%>
                            <td style="font-weight:bold"><%=loai_nhiem_vu.Ten_nhiem_vu%></td>
                            <%-- Nội dung --%>
                            <td></td>
                            <%-- Giá trị --%>
                            <td>
                                <label class="so_tien"><%=lst_PL04.Where(x=>x.ID_DON_VI==donvi.ID_DON_VI&&x.TEN_LOAI_NHIEM_VU==loai_nhiem_vu.Ten_nhiem_vu).Select(x=>(x.GIA_TRI_QUYET_TOAN-x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)).ToList().Sum()%></label>
                            </td>

                        </tr>
            <%-- level 2: Theo Công trình --%>
                          <%foreach (var cong_trinh in lst_PL04.Where(x=>x.ID_DON_VI==donvi.ID_DON_VI && x.TEN_LOAI_NHIEM_VU==loai_nhiem_vu.Ten_nhiem_vu).Select(x=> new {Ten_cong_trinh = x.CONG_TRINH, STT = x.TT}).Distinct())
                          { %>
                        <tr>
                            <%-- STT --%>
                            <td style="text-align:center"></td>
                            <%-- công trình --%>
                            <td style="font-style:italic; font-weight:bold"><%=cong_trinh.Ten_cong_trinh%></td>
                            <%-- Nội dung --%>
                            <td><% %></td>
                            <%-- Giá trị --%>
                            <td>
                                <label class="so_tien"><%=lst_PL04.Where(x=>x.ID_DON_VI==donvi.ID_DON_VI&&x.TEN_LOAI_NHIEM_VU==loai_nhiem_vu.Ten_nhiem_vu&&x.CONG_TRINH==cong_trinh.Ten_cong_trinh).Select(x=>(x.GIA_TRI_QUYET_TOAN-x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)).ToList().Sum()%></label>
                            </td>

                        </tr>
            <%-- level 3: Theo dự án --%>
                          <%foreach (var du_an in lst_PL04.Where(x=>x.ID_DON_VI==donvi.ID_DON_VI && x.TEN_LOAI_NHIEM_VU==loai_nhiem_vu.Ten_nhiem_vu && x.CONG_TRINH==cong_trinh.Ten_cong_trinh).Select(x=> new {Ten_du_an = x.DU_AN, STT = x.TT, NOI_DUNG = x.GHI_CHU}).Distinct())
                          { %>
                        <tr>
                            <%-- STT --%>
                            <td style="text-align:center"></td>
                            <%-- Dự án --%>
                            <td><%=du_an.Ten_du_an%></td>
                            <%-- Nội dung --%>
                            <td><%=du_an.NOI_DUNG %></td>
                            <%-- Giá trị --%>
                            <td>
                                <label class="so_tien"><%=lst_PL04.Where(x=>x.ID_DON_VI==donvi.ID_DON_VI&&x.TEN_LOAI_NHIEM_VU==loai_nhiem_vu.Ten_nhiem_vu&&x.CONG_TRINH==cong_trinh.Ten_cong_trinh&&x.DU_AN==du_an.Ten_du_an).Select(x=>(x.GIA_TRI_QUYET_TOAN-x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM) ).ToList().Sum()%></label>
                            </td>

                        </tr>
            <%} %>
            <%} %>
            <%} %>
            <%} %>
        </tbody>
        <tfoot>
        </tfoot>
    </table>
</asp:Content>
