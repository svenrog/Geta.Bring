<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConfigureShippingMethod.ascx.cs" Inherits="Geta.Bring.EPi.Commerce.Manager.Apps.Order.Shipping.Plugins.BringShippingGateway.ConfigureShippingMethod" %>

<table width="600">
    <tr>
        <th class="FormLabelCell">Bring Product Id:</th>
        <td class="FormLabelCell">
            <asp:DropDownList runat="server" ID="ddlBringProducts" DataValueField="Code" DataTextField="DisplayName"/>
        </td>
    </tr>
    <tr>
        <th class="FormLabelCell">Ship from postal code:</th>
        <td class="FormLabelCell">
            <asp:TextBox runat="server" ID="txtPostalCodeFrom"/>
        </td>
    </tr>
    <tr>
        <th class="FormLabelCell">EDI:</th>
        <td class="FormLabelCell">
            <asp:CheckBox runat="server" ID="cbEdi" Checked="True"/>
        </td>
    </tr>
    <tr>
        <th class="FormLabelCell">Parcel delivered to post office:</th>
        <td class="FormLabelCell">
            <asp:CheckBox runat="server" ID="cbPostingAtPostOffice"/>
        </td>
    </tr>
    <tr>
        <th class="FormLabelCell">Additional services:</th>
        <td class="FormLabelCell">
            <asp:CheckBoxList runat="server" ID="cblAdditionalServices" DataValueField="Code" DataTextField="DisplayName" RepeatLayout="Flow" />
        </td>
    </tr>
</table>