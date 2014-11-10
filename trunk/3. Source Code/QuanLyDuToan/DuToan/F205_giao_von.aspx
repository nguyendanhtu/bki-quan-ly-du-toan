<%@ Page Language="VB" AutoEventWireup="false" CodeFile="F205_giao_von.aspx.vb" Inherits="DuToan_F205_giao_von" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="background: cornflowerblue; color: greenyellow; padding: 10px 20px" ><a>Nhập giao vốn</a></div>
        <div style="margin: 10px 20px">

            <div >
                <fieldset style="margin-left: 30px">
                    <legend>Thông tin về quyết định giao vốn:</legend>
                    <table>
                    <tr>
                        <td style="width:30%" align="right"><a style="color: red">Số QĐ   </td><td>
                        <input type="text" >
                            <asp.DropDownList>
                                <option>VD: 371/QĐ-BGTVT</option>
                                <option>VD: 372/QĐ-BGTVT</option>
                            </asp.DropDownList>
                            &nbsp;<input type="button" value="Chọn QĐ đã nhập"></td>

                    </tr>
                    <tr>
                        <td style="width:30%" align="right"><a style="color: red">Nội dung   </td><td><input type="text" size="80px"></td>
                    </tr>
                    <tr>
                        <td style="width:30%" align="right"><a style="color: red">Ngày tháng   </td><td><input type="text"  ></td>
                    </tr>
                    <tr><td></td><td><input type="button" value="Lưu QĐ"><input type="button" value="Nhập QĐ mới"></td></tr>
                </table>
             </fieldset>
            </div>
            <div>
                <fieldset style="margin-left: 30px">
                    <legend>Chi tiết</legend>
            </div>
        </div>

    </div>

</form>
</body>
</html>
