namespace Geta.Bring.Shipping.Model
{
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

        public int SortOrder { get; private set; }
        public string MainDisplayCategory { get; private set; }
        public string SubDisplayCategory { get; private set; }
        public string DisplayName { get; private set; }
        public string ProductName { get; private set; }
        public string DescriptionText { get; private set; }
        public string HelpText { get; private set; }
        public string Tip { get; private set; }
        public int MaxWeightInKgs { get; private set; }
    }
}