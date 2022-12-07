<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Designation.aspx.cs" Inherits="submissionCHALLANGE_6.Designation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <h1 align="center">Grid View</h1>
            <table align="center">
                
                <tr>
                    <td>
                        Department
                    </td>
                    <td>
                        <asp:DropDownList ID="ddldpt" runat="server" AutoPostBack="True">
                        
                            </asp:DropDownList>

                    </td>
                </tr>
                <tr>
                    <td>
                         Enter  Designation
                    </td>
                    <td>
                        <asp:TextBox ID="txtdesig" runat="server"></asp:TextBox>
                    </td>
                   
                </tr>
                 <tr>
                    <td>
                                <asp:Button ID="btnsub" runat="server" Text="Register" OnClick="btnsub_Click"  />
                    </td>
                     </tr>
                     </table>
            <br />
            <br />

            <asp:GridView ID="GridView1" runat="server" align="center" AutoGenerateColumns="False" DataKeyNames="DesignationId" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                <Columns>
                    <asp:BoundField DataField="depname" HeaderText="DEPARTMENT" />
                    <asp:BoundField DataField="DesignationName" HeaderText="DESIGNATION" />
                    <asp:CommandField HeaderText="UPDATE" ShowEditButton="True" />
                    <asp:HyperLinkField DataNavigateUrlFields="DesignationId" DataNavigateUrlFormatString="Redirect.aspx?did={0}"  HeaderText="NEXT PAGE" Text="Go" />
                    <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                </Columns>
             </asp:GridView> 
        </div>
        
    </form>
</body>
</html>
