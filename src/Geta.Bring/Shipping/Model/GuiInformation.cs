namespace Geta.Bring.Shipping.Model
{
    /// <summary>
    /// GUI information.
    /// </summary>
    public class GuiInformation
    {
        public GuiInformation(
            int sortOrder, 
            string mainDisplayCategory, 
            string subDisplayCategory, 
            string displayName, 
            string productName, 
            string descriptionText, 
            string helpText, 
            string tip, 
            int maxWeightInKgs)
        {
            MaxWeightInKgs = maxWeightInKgs;
            Tip = tip;
            HelpText = helpText;
            DescriptionText = descriptionText;
            ProductName = productName;
            DisplayName = displayName;
            SubDisplayCategory = subDisplayCategory;
            MainDisplayCategory = mainDisplayCategory;
            SortOrder = sortOrder;
        }

        /// <summary>
        /// Order number of the estimation option.
        /// </summary>
        public int SortOrder { get; private set; }

        /// <summary>
        /// The name of main display category.
        /// </summary>
        public string MainDisplayCategory { get; private set; }

        /// <summary>
        /// The name of sub-display category.
        /// </summary>
        public string SubDisplayCategory { get; private set; }

        /// <summary>
        /// Display name of estimation option.
        /// </summary>
        public string DisplayName { get; private set; }

        /// <summary>
        /// Product name.
        /// </summary>
        public string ProductName { get; private set; }

        /// <summary>
        /// Description text.
        /// </summary>
        public string DescriptionText { get; private set; }

        /// <summary>
        /// Help text.
        /// </summary>
        public string HelpText { get; private set; }

        /// <summary>
        /// Tip.
        /// </summary>
        public string Tip { get; private set; }

        /// <summary>
        /// Max weight in kilograms.
        /// </summary>
        public int MaxWeightInKgs { get; private set; }
    }
}