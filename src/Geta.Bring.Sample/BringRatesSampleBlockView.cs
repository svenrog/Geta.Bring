using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using Geta.Bring.Shipping.Model;

namespace Geta.Bring.Sample
{
    public class BringRatesSampleBlockView
    {
        public ViewState State { get; private set; }

        [Required]
        public string CountryFrom { get; set; }
        [Required(ErrorMessage = "Fra postnummer nødvendig.")]
        public string PostalCodeFrom { get; set; }
        [Required]
        public string CountryTo { get; set; }
        [Required(ErrorMessage = "Til postnummer nødvendig.")]
        public string PostalCodeTo { get; set; }
        public DateTime? ShippingDateAndTime { get; set; }
        public int? Weight { get; set; }
        public int? Length { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public int? Volume { get; set; }
        public bool Edi { get; set; }
        public bool ShippedFromPostOffice { get; set; }
        public string[] Products { get; set; }
        public string[] AdditionalServices { get; set; }

        public IEnumerable<EstimateGroup> EstimateGroups { get; private set; }

        public IEnumerable<SelectListItem> CountriesFromList
        {
            get
            {
                yield return new SelectListItem { Value = "NO", Text = "Norway" };
                yield return new SelectListItem { Value = "SE", Text = "Sweden" };
                yield return new SelectListItem { Value = "FI", Text = "Finland" };
                yield return new SelectListItem { Value = "DK", Text = "Denmark" };
            }
        }

        public IEnumerable<SelectListItem> CountriesToList
        {
            get
            {
                yield return new SelectListItem { Value = "NO", Text = "Norway" };
                yield return new SelectListItem { Value = "SE", Text = "Sweden" };
                yield return new SelectListItem { Value = "FI", Text = "Finland" };
                yield return new SelectListItem { Value = "DK", Text = "Denmark" };
            }
        }

        public IEnumerable<SelectListItem> ProductList
        {
            get { return Product.All.Select(x => new SelectListItem { Value = x.Code, Text = x.DisplayName }); }
        }

        public IEnumerable<SelectListItem> AdditionalServiceList
        {
            get { return AdditionalService.All.Select(x => new SelectListItem { Value = x.Code, Text = x.DisplayName }); }
        }

        public BringRatesSampleBlockView()
        {
            State = ViewState.SearchForm;
            EstimateGroups = Enumerable.Empty<EstimateGroup>();
        }

        public BringRatesSampleBlockView(IEnumerable<EstimateGroup> estimateGroups)
        {
            State = ViewState.Results;
            EstimateGroups = estimateGroups;
        }

        public class EstimateGroup
        {
            public string MainCategory { get; private set; }
            public IEnumerable<ShipmentEstimate> Estimates { get; private set; }

            public EstimateGroup(string mainCategory, IEnumerable<ShipmentEstimate> estimates)
            {
                if (mainCategory == null) throw new ArgumentNullException("mainCategory");
                if (estimates == null) throw new ArgumentNullException("estimates");
                MainCategory = mainCategory;
                Estimates = estimates;
            }
        }

        public enum ViewState
        {
            SearchForm,
            Results
        }
    }
}