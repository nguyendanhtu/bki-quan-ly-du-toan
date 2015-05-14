<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BC_PL01_Tong_hop_tinh_hinh_kinh_phi_quyet_toan.aspx.cs" Inherits="QuanLyDuToan.BaoCaoQT.BC_PL02_Tong_hop_tinh_hinh_kinh_phi_quyet_toan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/jquery.doubleScroll.js"></script>
    <script src="../Scripts/fixHeader.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var lst = $('.so_tien');
            for (var i = 0; i < lst.length; i++) {
                $(lst[i]).text(formatString($(lst[i]).text()));
                $("#<%=m_ddl_chon_nam.ClientID%>").select2();
            }
            $('#btlPL01').scrollbarTable();
            $('#double-scroll').doubleScroll();
        })
    </script>
    <style>
        /*#btlPL01 > thead > tr > th {
            border: 1px solid #000;
        }*/

        #tblPL01 {
            background-color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="h3 text-center">PL01 - TỔNG HỢP TÌNH HÌNH KINH PHÍ VÀ QUYẾT TOÁN CHI QŨY BẢO TRÌ ĐƯỜNG BỘ</h3>
    <div class="height30" style="margin: 0 auto;">
        <div class="control text-center">
            <span class="lb" style="font-weight: 300; font-size: medium">Năm</span>
            &nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="m_ddl_chon_nam" runat="server" Width="80px" AutoPostBack="True" CssClass="select2" OnSelectedIndexChanged="m_ddl_chon_nam_SelectedIndexChanged"></asp:DropDownList>
        </div>
    </div>
    <br />
    <div style="margin: 0px auto; width:1200px">
        <div style="width: 1200px" id="double-scroll">
            <table class="table-hover table-bordered" id="btlPL01" style="width:<%=with_table%>px">
                <thead>
                    <tr class="text-center">
                        <th style="width: 80px">Mã số</th>
                        <th style="width: 350px">Chỉ tiêu</th>
                        <%foreach (var don_vi in lst_don_vi.OrderBy(x => x.TEN_DON_VI
))
                          {%>
                        <th class="text-center" style="width: 200px"><span><%=don_vi.TEN_DON_VI%></span></th>
                        <%}%>
                    </tr>
                </thead>
                <tbody>
                    <%foreach (var item in lst_PL01.Select(x => new { ChiTieu = x.CHI_TIEU, MaSo = x.MA_SO }).Distinct().ToList())
                      {%>
                    <tr>
                        <td class="text-center" style="width: 80px">
                            <span class=" ma_so <%= item.MaSo %>"><%= item.MaSo %></span>
                        </td>
                        <td class="" style="width: 350px">
                            <strong class="ma_so_parent <%= item.ChiTieu %>"><%= item.ChiTieu %></strong>
                        </td>
                        <%foreach (var don_vi in lst_don_vi.OrderBy(x => x.TEN_DON_VI
))
                          {%>
                        <td style="text-align: right; width: 200px">
                            <span class="so_tien"><%=lst_PL01.Where(x=>x.ID_DON_VI==don_vi.ID_DON_VI&&x.MA_SO==item.MaSo).Select(x=>x.SO_BAO_CAO).FirstOrDefault() %></span>
                        </td>
                        <%}%>
                    </tr>
                    <%}%>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
