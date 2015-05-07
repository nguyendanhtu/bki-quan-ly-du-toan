<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PL04_Danh_muc_giam_tru_quyet_toan_don_vi.aspx.cs" Inherits="QuanLyDuToan.QuyetToan.PL04_Danh_muc_giam_tru_quyet_toan_don_vi" %>

<%@ Import Namespace="SQLDataAccess" %>
<%@ Import Namespace="WebUS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=m_ddl_chon_nam.ClientID%>").select2();
            $("#<%=m_ddl_don_vi.ClientID%>").select2();
            var lst = $('.so_tien');
            for (var i = 0; i < lst.length; i++) {
                $(lst[i]).text(formatString($(lst[i]).text()));
            }
        })
        function pageLoad(sender, args) {
            if (args.get_isPartialLoad()) {
                $("#<%=m_ddl_chon_nam.ClientID%>").select2();
                $("#<%=m_ddl_don_vi.ClientID%>").select2();
            }
        }

    </script>
    <style>
        #tblPL05 > thead > tr > th {
            border: 1px solid #000;
        }

        .so_tien {
            text-align: right;
        }

        #tblPL05 {
            background-color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="h3 text-center">DANH MỤC CÔNG TRÌNH GIẢM TRỪ</h3>
    <div class="height30" style="margin: 0 auto;">
        <div class="control text-center">
            <span class="lb" style="font-weight: 300; font-size: medium">Đơn vị</span>
            &nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="m_ddl_don_vi" runat="server" Width="200px" AutoPostBack="True" CssClass="select2" OnSelectedIndexChanged="m_ddl_don_vi_SelectedIndexChanged"></asp:DropDownList>
            &nbsp;&nbsp;&nbsp;
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
                <th>TT</th>
                <th style="width:300px">Nội dung</th>
                <th style="width: 100px">Giá trị khối lượng công trình hoàn thành trong năm</th>
                <th style="width: 100px">Giá trị khối lượng được quyết toán</th>
                <th style="width: 100px">Giá trị giảm trừ thanh toán </th>
                <th style="width:200px">Ghi chú</th>
            </tr>
            <tr>
                <th>1</th>
                <th>2</th>
                <th>3</th>
                <th>4</th>
                <th>5=3-4</th>
                <th>6</th>
            </tr>
        </thead>
        <tbody>
            <%-- level 1: Theo loại nhiệm vụ --%>
            <%foreach (var loai_nhiem_vu in lst_PL04.Select(x => new { Ten_nhiem_vu = x.TEN_LOAI_NHIEM_VU, STT = x.TT }).Distinct().OrderBy(x => x.STT))
              { %>
            <tr>
                <%-- STT --%>
                <td style="font-weight: bold; text-align: center"><%=loai_nhiem_vu.STT%></td>
                <%--Nội dung --%>
                <td style="font-weight: bold; width:300px"><%=loai_nhiem_vu.Ten_nhiem_vu%></td>
                <%-- GTKLCTHT --%>
                <td>
                    <label class="so_tien"><%=lst_PL04.Where(x=>x.TEN_LOAI_NHIEM_VU==loai_nhiem_vu.Ten_nhiem_vu).Select(x=>(x.GIA_TRI_CTHT_NAM_NAY + x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY)).ToList().Sum()%></label>
                </td>
                <%-- GTKLQT --%>
                <td>
                    <label class="so_tien"><%=lst_PL04.Where(x=>x.TEN_LOAI_NHIEM_VU==loai_nhiem_vu.Ten_nhiem_vu).Select(x=>x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM).ToList().Sum()%></label>
                </td>
                <%-- GTGTTT --%>
                <td>
                    <label class="so_tien"><%=lst_PL04.Where(x=>x.TEN_LOAI_NHIEM_VU==loai_nhiem_vu.Ten_nhiem_vu).Select(x=>(x.GIA_TRI_CTHT_NAM_NAY + x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY+x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM-x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)).ToList().Sum()%></label>
                </td>
                <%-- Ghi chú --%>
                <td>
                    <label><%=lst_PL04.Where(x=>x.TEN_LOAI_NHIEM_VU==loai_nhiem_vu.Ten_nhiem_vu).Select(x=>x.GHI_CHU)%></label></td>
            </tr>
            <%-- level 2: Theo Công trình --%>
            <%foreach (var cong_trinh in lst_PL04.Where(x => x.TEN_LOAI_NHIEM_VU == loai_nhiem_vu.Ten_nhiem_vu).Select(x => new { Ten_cong_trinh = x.CONG_TRINH, STT = x.TT }).Distinct())
              { %>
            <tr>
                <%-- STT --%>
                <td style="text-align: center"></td>
                <%-- Nội dung --%>
                <td style="font-style: italic; font-weight: bold"><%=cong_trinh.Ten_cong_trinh%></td>
                <%-- GTKLCTHT --%>
                <td>
                    <label class="so_tien"><%=lst_PL04.Where(x=>x.TEN_LOAI_NHIEM_VU==loai_nhiem_vu.Ten_nhiem_vu&&x.CONG_TRINH==cong_trinh.Ten_cong_trinh).Select(x=>(x.GIA_TRI_CTHT_NAM_NAY + x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY)).ToList().Sum()%></label>
                </td>
                <%-- GTKLQT --%>
                <td>
                    <label class="so_tien"><%=lst_PL04.Where(x=>x.TEN_LOAI_NHIEM_VU==loai_nhiem_vu.Ten_nhiem_vu&&x.CONG_TRINH==cong_trinh.Ten_cong_trinh).Select(x=>x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM).ToList().Sum()%></label>
                </td>
                <%-- GTGTTT --%>
                <td>
                    <label class="so_tien"><%=lst_PL04.Where(x=>x.TEN_LOAI_NHIEM_VU==loai_nhiem_vu.Ten_nhiem_vu&&x.CONG_TRINH==cong_trinh.Ten_cong_trinh).Select(x=>(x.GIA_TRI_CTHT_NAM_NAY + x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY+x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM-x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)).ToList().Sum()%></label>
                </td>
                <%-- Ghi chú --%>
                <td>
                    <label><%=lst_PL04.Where(x=>x.TEN_LOAI_NHIEM_VU==loai_nhiem_vu.Ten_nhiem_vu&&x.CONG_TRINH==cong_trinh.Ten_cong_trinh).Select(x=>x.GHI_CHU)%></label></td>
            </tr>
            <%-- level 3: Theo dự án --%>
            <%foreach (var du_an in lst_PL04.Where(x => x.TEN_LOAI_NHIEM_VU == loai_nhiem_vu.Ten_nhiem_vu && x.CONG_TRINH == cong_trinh.Ten_cong_trinh).Select(x => new { Ten_du_an = x.DU_AN, STT = x.TT, NOI_DUNG = x.GHI_CHU }).Distinct())
              { %>
            <tr>
                <%-- STT --%>
                <td style="text-align: center"></td>
                <%-- Nội dung --%>
                <td><%=du_an.Ten_du_an%></td>
                <%-- GTKLCTHT --%>
                <td>
                    <label class="so_tien"><%=lst_PL04.Where(x=>x.TEN_LOAI_NHIEM_VU==loai_nhiem_vu.Ten_nhiem_vu&&x.CONG_TRINH==cong_trinh.Ten_cong_trinh&&x.DU_AN==du_an.Ten_du_an).Select(x=>(x.GIA_TRI_CTHT_NAM_NAY + x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY)).ToList().Sum()%></label>
                </td>
                <%-- GTKLQT --%>
                <td>
                    <label class="so_tien"><%=lst_PL04.Where(x=>x.TEN_LOAI_NHIEM_VU==loai_nhiem_vu.Ten_nhiem_vu&&x.CONG_TRINH==cong_trinh.Ten_cong_trinh&&x.DU_AN==du_an.Ten_du_an).Select(x=>x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM).ToList().Sum()%></label>
                </td>
                <%-- GTGTTT --%>
                <td>
                    <label class="so_tien"><%=lst_PL04.Where(x=>x.TEN_LOAI_NHIEM_VU==loai_nhiem_vu.Ten_nhiem_vu&&x.CONG_TRINH==cong_trinh.Ten_cong_trinh&&x.DU_AN==du_an.Ten_du_an).Select(x=>(x.GIA_TRI_CTHT_NAM_NAY + x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY+x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM-x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)).ToList().Sum()%></label>
                </td>
                <%-- Ghi chú --%>
                <td>
                    <label><%=lst_PL04.Where(x=>x.TEN_LOAI_NHIEM_VU==loai_nhiem_vu.Ten_nhiem_vu&&x.CONG_TRINH==cong_trinh.Ten_cong_trinh&&x.DU_AN==du_an.Ten_du_an).Select(x=>x.GHI_CHU).ToString()%></label></td>

            </tr>
            <%} %>
            <%} %>
            <%} %>
        </tbody>
        <tfoot>
        </tfoot>
    </table>
</asp:Content>
