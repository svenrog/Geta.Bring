using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace Geta.Bring.Sample
{
    [ContentType(
        DisplayName = "Bring Shipping Guide Sample Block", 
        Description = "Bring Shipping sample block to show how rates can be retrieved.", 
        GUID = "B3B7932B-97A8-4985-A0D5-16664F6A1B57")]
    [ImageUrl("~/Content/BringRatesSample/posten-logo-block.png")]
    public class BringRatesSampleBlock : BlockData
    {
         
    }
}