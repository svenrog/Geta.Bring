<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConfigureShipping.ascx.cs" Inherits="Geta.Bring.EPi.Commerce.Manager.Apps.Order.Shipping.Plugins.BringShippingGateway.ConfigureShipping" %>

<table width="600">
    <tr>
        <th class="FormLabelCell">API url:</th>
        <td class="FormLabelCell">
            <asp:TextBox runat="server" ID="txtApiUrl"/>
        </td>
    </tr>
    <tr>
        <th class="FormLabelCell">Public ID:</th>
        <td class="FormLabelCell">
            <asp:TextBox runat="server" ID="txtPublicId"/>
        </td>
    </tr>
    <tr>
        <th class="FormLabelCell">Default ship from country:</th>
        <td class="FormLabelCell">
            <asp:DropDownList runat="server" ID="ddlCountryFrom" DataValueField="Code" DataTextField="Name"/>
        </td>
    </tr>
    <tr>
        <th class="FormLabelCell">Default ship from postal code:</th>
        <td class="FormLabelCell">
            <asp:TextBox runat="server" ID="txtPostalCodeFrom"/>
        </td>
    </tr>
</table>