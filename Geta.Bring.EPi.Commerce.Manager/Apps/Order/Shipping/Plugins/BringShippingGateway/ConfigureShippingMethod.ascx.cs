using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using Geta.Bring.Shipping.Model;
using Mediachase.Commerce.Orders.Dto;
using Mediachase.Web.Console.BaseClasses;
using Mediachase.Web.Console.Interfaces;

namespace Geta.Bring.EPi.Commerce.Manager.Apps.Order.Shipping.Plugins.BringShippingGateway
{
    public partial class ConfigureShippingMethod : OrderBaseUserControl, IGatewayControl
    {
        private string _validationGroup = string.Empty;
        private ShippingMethodDto _shippingMethodDto;

        public void SaveChanges(object dto)
        {
            _shippingMethodDto = dto as ShippingMethodDto;

            if (_shippingMethodDto != null && _shippingMethodDto.ShippingMethodParameter != null)
            {
                ShippingMethodDto.ShippingMethodParameterRow productIdRow = GetOrCreateParameterRow("BringProductId");
                ShippingMethodDto.ShippingMethodParameterRow postalCodeFromRow = GetOrCreateParameterRow("PostalCodeFrom");
                ShippingMethodDto.ShippingMethodParameterRow ediRow = GetOrCreateParameterRow("EDI");
                ShippingMethodDto.ShippingMethodParameterRow postingAtPostOfficeRow = GetOrCreateParameterRow("PostingAtPostOffice");
                ShippingMethodDto.ShippingMethodParameterRow additionalServicesRow = GetOrCreateParameterRow("AdditionalServices");

                productIdRow.Value = ddlBringProducts.SelectedValue;
                postalCodeFromRow.Value = txtPostalCodeFrom.Text;
                ediRow.Value = cbEdi.Checked.ToString();
                postingAtPostOfficeRow.Value = cbPostingAtPostOffice.Checked.ToString();
                additionalServicesRow.Value = GetSelectedListItemsString(cblAdditionalServices.Items);

                AttachParameterRow(productIdRow);
                AttachParameterRow(postalCodeFromRow);
                AttachParameterRow(ediRow);
                AttachParameterRow(postingAtPostOfficeRow);
                AttachParameterRow(additionalServicesRow);
            }
        }

        public void LoadObject(object dto)
        {
            _shippingMethodDto = dto as ShippingMethodDto;

            if (!Page.IsPostBack)
            {
                BindProductList();
                BindAdditionalServices();
            }

            if (_shippingMethodDto != null && _shippingMethodDto.ShippingMethodParameter.Rows.Count > 0)
            {

                ShippingMethodDto.ShippingMethodParameterRow productIdRow = GetParameterRow("BringProductId");
                ShippingMethodDto.ShippingMethodParameterRow postalCodeFromRow = GetParameterRow("PostalCodeFrom");
                ShippingMethodDto.ShippingMethodParameterRow ediRow = GetParameterRow("EDI");
                ShippingMethodDto.ShippingMethodParameterRow postingAtPostOfficeRow = GetParameterRow("PostingAtPostOffice");

                if (productIdRow != null)
                {
                    ddlBringProducts.SelectedValue = productIdRow.Value;
                }

                if (postalCodeFromRow != null)
                {
                    txtPostalCodeFrom.Text = postalCodeFromRow.Value;
                }

                cbEdi.Checked = ediRow == null || ediRow.Value.Equals("true", StringComparison.InvariantCultureIgnoreCase);

                if (postingAtPostOfficeRow != null)
                {
                    cbPostingAtPostOffice.Checked = postingAtPostOfficeRow.Value.Equals("true", StringComparison.InvariantCultureIgnoreCase);
                }
            }
        }

        private ShippingMethodDto.ShippingMethodParameterRow GetOrCreateParameterRow(string parameterName)
        {
            ShippingMethodDto.ShippingMethodParameterRow row = GetParameterRow(parameterName);

            if (row == null)
            {
                row = _shippingMethodDto.ShippingMethodParameter.NewShippingMethodParameterRow();
                row.ShippingMethodId = _shippingMethodDto.ShippingMethod[0].ShippingMethodId;
                row.Parameter = parameterName;
            }

            return row;
        }

        private ShippingMethodDto.ShippingMethodParameterRow GetParameterRow(string parameterName)
        {
            return _shippingMethodDto.ShippingMethodParameter.FirstOrDefault(x => x.Parameter == parameterName);
        }

        private void AttachParameterRow(ShippingMethodDto.ShippingMethodParameterRow row)
        {
            if (row.RowState == DataRowState.Detached)
            {
                _shippingMethodDto.ShippingMethodParameter.Rows.Add(row);
            }
        }

        private string GetSelectedListItemsString(ListItemCollection items)
        {
            string value = string.Empty;
            var count = 0;

            foreach (ListItem item in items)
            {
                if (item.Selected)
                {
                    if (count++ > 0)
                    {
                        value += ",";
                    }

                    value += item.Value;
                }
            }

            return value;
        }

        private void BindProductList()
        {
            ddlBringProducts.DataSource = Product.All;
            ddlBringProducts.DataBind();
        }

        private void BindAdditionalServices()
        {
            cblAdditionalServices.DataSource = AdditionalService.All;
            cblAdditionalServices.DataBind();
        }

        public string ValidationGroup { get { return _validationGroup; } set { _validationGroup = value; } }
    }
}