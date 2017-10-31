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
                var productIdRow = GetOrCreateParameterRow("BringProductId");
                var customerNumberRow = GetOrCreateParameterRow("BringCustomerNumber");
                var postalCodeFromRow = GetOrCreateParameterRow("PostalCodeFrom");
                var ediRow = GetOrCreateParameterRow("EDI");
                var postingAtPostOfficeRow = GetOrCreateParameterRow("PostingAtPostOffice");
                var additionalServicesRow = GetOrCreateParameterRow("AdditionalServices");
                var priceRoundingRow = GetOrCreateParameterRow("PriceRounding");
                var priceAdjustmentOperatorRow = GetOrCreateParameterRow("PriceAdjustmentOperator");
                var priceAdjustmentPercentRow = GetOrCreateParameterRow("PriceAdjustmentPercent");

                productIdRow.Value = ddlBringProducts.SelectedValue;
                customerNumberRow.Value = txtCustomerNumber.Text;
                postalCodeFromRow.Value = txtPostalCodeFrom.Text;
                ediRow.Value = cbEdi.Checked.ToString();
                postingAtPostOfficeRow.Value = cbPostingAtPostOffice.Checked.ToString();
                additionalServicesRow.Value = GetSelectedListItemsString(cblAdditionalServices.Items);
                priceRoundingRow.Value = cbPriceRounding.Checked.ToString();
                priceAdjustmentOperatorRow.Value = rbPriceAdjustmentAdd.Checked.ToString();
                priceAdjustmentPercentRow.Value = txtPercentAdjustment.Text;

                AttachParameterRow(productIdRow);
                AttachParameterRow(customerNumberRow);
                AttachParameterRow(postalCodeFromRow);
                AttachParameterRow(ediRow);
                AttachParameterRow(postingAtPostOfficeRow);
                AttachParameterRow(additionalServicesRow);
                AttachParameterRow(priceRoundingRow);
                AttachParameterRow(priceAdjustmentOperatorRow);
                AttachParameterRow(priceAdjustmentPercentRow);
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

                var productIdRow = GetParameterRow("BringProductId");
                var customerNumberRow = GetParameterRow("BringCustomerNumber");
                var postalCodeFromRow = GetParameterRow("PostalCodeFrom");
                var ediRow = GetParameterRow("EDI");
                var postingAtPostOfficeRow = GetParameterRow("PostingAtPostOffice");
                var priceRoundingRow = GetParameterRow("PriceRounding");
                var priceAdjustmentOperatorRow = GetParameterRow("PriceAdjustmentOperator");
                var priceAdjustmentPercentRow = GetParameterRow("PriceAdjustmentPercent");

                if (productIdRow != null)
                {
                    ddlBringProducts.SelectedValue = productIdRow.Value;
                }

                if (customerNumberRow != null)
                {
                    txtCustomerNumber.Text = customerNumberRow.Value;
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

                if (priceRoundingRow != null)
                {
                    cbPriceRounding.Checked = priceRoundingRow.Value.Equals("true", StringComparison.InvariantCultureIgnoreCase);
                }

                if (priceAdjustmentOperatorRow != null)
                {
                    var add = priceAdjustmentOperatorRow.Value.Equals("true", StringComparison.InvariantCultureIgnoreCase);

                    rbPriceAdjustmentAdd.Checked = add;
                    rbPriceAdjustmentSubtract.Checked = !add;
                }

                if (priceAdjustmentPercentRow != null)
                {
                    txtPercentAdjustment.Text = priceAdjustmentPercentRow.Value;
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