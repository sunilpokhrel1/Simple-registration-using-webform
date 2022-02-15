<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ASSIGNMENTTASK.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>Name:</td>
                    <td>
                        <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Address:
                    </td>
                    <td>
                        <asp:TextBox ID="txtaddress" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Phone:</td>
                    <td>
                        <asp:TextBox ID="txtphone" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btninsert" runat="server" Text="Insert"  OnClick="btninsert_Click"> </asp:Button>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" OnRowCommand="grd_RowCommand" DataKeyNames="eid"  >
                            <Columns>
                                <asp:BoundField DataField="eid" HeaderText="eid" InsertVisible="False" ReadOnly="True" SortExpression="eid" />
                                <asp:BoundField DataField="ename" HeaderText="ename" SortExpression="ename" />
                                <asp:BoundField DataField="eadress" HeaderText="eadress" SortExpression="eadress" />
                                <asp:BoundField DataField="emob" HeaderText="emob" SortExpression="emob" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TESTREGISTRATIONConnectionString %>" SelectCommand="SELECT * FROM [employee]"></asp:SqlDataSource>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>