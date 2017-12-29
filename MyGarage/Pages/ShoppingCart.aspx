<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="Pages_ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:panel ID="pnlShoppingCart" runat="server">

    </asp:panel>
    <table>
        <tr>
            <td><b>Total: </b></td>
            <td>
                <asp:literal ID="litTotal" runat="server" Text=""></asp:literal>
            </td>
        </tr>

        <tr>
            <td><b>Vat: </b></td>
            <td>
                <asp:literal ID="litVat" runat="server" Text=""></asp:literal>
            </td>
        </tr>

        <tr>
            <td><b>Shipping: </b></td>
            <td>
$ 15            </td>
        </tr>

        <tr>
            <td><b>Total Amount: </b></td>
            <td>
                <asp:literal ID="litTotalAmount" runat="server" Text=""></asp:literal>
            </td>
        </tr>

        <tr>
            <td>
                <asp:linkbutton ID="lnkContinue" runat="server" PostBackUrl="~/index.aspx" Text="Continue Shopping" ></asp:linkbutton>
          OR
                <asp:button ID="btnCheckOut" PostBackUrl="~/Pages/Success.aspx" CssClass="button" Width="250px" runat="server" text="Continue Checkout" />
                </td>
        </tr>
    </table>
</asp:Content>

