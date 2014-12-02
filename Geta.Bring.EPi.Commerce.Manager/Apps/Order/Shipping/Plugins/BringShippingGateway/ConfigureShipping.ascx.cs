using System.Data;
using System.Linq;
using Mediachase.Commerce.Orders.Dto;
using Mediachase.Commerce.Orders.Managers;
using Mediachase.Web.Console.BaseClasses;
using Mediachase.Web.Console.Interfaces;

namespace Geta.Bring.EPi.Commerce.Manager.Apps.Order.Shipping.Plugins.BringShippingGateway
{
    public partial class ConfigureShipping : OrderBaseUserControl, IGatewayControl
    {
        private string _validationGroup = string.Empty;
        private ShippingMethodDto _shippingMethodDto;

        public void SaveChanges(object dto)
        {
            _shippingMethodDto = dto as ShippingMethodDto;

            if (_shippingMethodDto != null && _shippingMethodDto.ShippingOptionParameter != null)
            {
                ShippingMethodDto.ShippingOptionParameterRow apiUrlRow = GetOrCreateParameterRow("ApiUrl");
                ShippingMethodDto.ShippingOptionParameterRow publicIdRow = GetOrCreateParameterRow("PublicId");
                ShippingMethodDto.ShippingOptionParameterRow postalCodeFromRow = GetOrCreateParameterRow("PostalCodeFrom");
                ShippingMethodDto.ShippingOptionParameterRow countryFromRow = GetOrCreateParameterRow("CountryFrom");

                apiUrlRow.Value = txtApiUrl.Text;
                publicIdRow.Value = txtPublicId.Text;
                postalCodeFromRow.Value = txtPostalCodeFrom.Text;
                countryFromRow.Value = ddlCountryFrom.SelectedValue;

                AttachOptionRow(apiUrlRow);
                AttachOptionRow(publicIdRow);
                AttachOptionRow(postalCodeFromRow);
                AttachOptionRow(countryFromRow);
            }
        }

        public void LoadObject(object dto)
        {
            _shippingMethodDto = dto as ShippingMethodDto;

            if (!Page.IsPostBack)
            {
                BindCountryList();
            }

            if (_shippingMethodDto != null && _shippingMethodDto.ShippingOptionParameter.Rows.Count > 0)
            {
                ShippingMethodDto.ShippingOptionParameterRow apiUrlRow = GetParameterRow("ApiUrl");
                ShippingMethodDto.ShippingOptionParameterRow publicIdRow = GetParameterRow("PublicId");
                ShippingMethodDto.ShippingOptionParameterRow postalCodeFromRow = GetParameterRow("PostalCodeFrom");
                ShippingMethodDto.ShippingOptionParameterRow countryFromRow = GetParameterRow("CountryFrom");

                if (apiUrlRow != null)
                {
                    txtApiUrl.Text = apiUrlRow.Value;
                }
                else
                {
                    txtApiUrl.Text = "http://fraktguide.bring.no/fraktguide/products/";
                }

                if (publicIdRow != null)
                {
                    txtPublicId.Text = publicIdRow.Value;
                }

                if (postalCodeFromRow != null)
                {
                    txtPostalCodeFrom.Text = postalCodeFromRow.Value;
                }

                if (countryFromRow != null)
                {
                    ddlCountryFrom.SelectedValue = countryFromRow.Value;
                }
            }
        }

        private void BindCountryList()
        {
            var allCountries = CountryManager.GetCountries(false).Country;
            ddlCountryFrom.DataSource = allCountries;
            ddlCountryFrom.DataBind();
        }

        private void AttachOptionRow(ShippingMethodDto.ShippingOptionParameterRow row)
        {
            if (row.RowState == DataRowState.Detached)
            {
                _shippingMethodDto.ShippingOptionParameter.Rows.Add(row);
            }
        }

        private ShippingMethodDto.ShippingOptionParameterRow GetOrCreateParameterRow(string parameterName)
        {
            ShippingMethodDto.ShippingOptionParameterRow row = GetParameterRow(parameterName);

            if (row == null)
            {
                row = _shippingMethodDto.ShippingOptionParameter.NewShippingOptionParameterRow();
                row.ShippingOptionId = _shippingMethodDto.ShippingOption[0].ShippingOptionId;
                row.Parameter = parameterName;
            }

            return row;
        }

        private ShippingMethodDto.ShippingOptionParameterRow GetParameterRow(string parameterName)
        {
            return _shippingMethodDto.ShippingOptionParameter.FirstOrDefault(x => x.Parameter == parameterName);
        }

        public string ValidationGroup { get { return _validationGroup; } set { _validationGroup = value; } }
    }
}