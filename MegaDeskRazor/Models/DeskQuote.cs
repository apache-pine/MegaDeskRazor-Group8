using System.ComponentModel.DataAnnotations;
using MegaDeskRazor.Data;

namespace MegaDeskRazor.Models
{
    public class DeskQuote
    {
        // Constants
        public const decimal BASE_DESK_PRICE = 200.00M;
        public const decimal DRAWER_PRICE = 50.00M;
        public const decimal SURFACE_AREA_PRICE = 1.00M;

        // Properties
        public int DeskQuoteId { get; set; }

        [Display(Name = "Customer Name")]
        [StringLength(60, MinimumLength = 3)]
        public string CustomerName { get; set; }

        [Display(Name = "Quote Date")]
        public DateTime QuoteDate { get; set; }

        [Display(Name = "Quote Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal QuotePrice { get; set; }

        [Display(Name = "Delivery Type")]
        public int DeliveryTypeId { get; set; }

        public int DeskId { get; set; }

        // Navigation Properties
        public Desk Desk { get; set; }

        [Display(Name = "Delivery Type")]
        public DeliveryType DeliveryType { get; set; }

        // Methods
        public decimal GetQuotePrice(MegaDeskRazorContext context)
        {
            decimal quotePrice = BASE_DESK_PRICE;
            decimal surfaceArea = this.Desk.Depth * this.Desk.Width;
            decimal surfacePrice = 0.00M;

            if (surfaceArea > 1000)
            {
                surfacePrice = (surfaceArea - 1000) * SURFACE_AREA_PRICE;
            }

            decimal drawerPrice = this.Desk.NumDrawers * DRAWER_PRICE;

            decimal materialPrice = 0.00M;

            var surfaceMaterialPrices = context.DesktopMaterial.Where(d => d.DesktopMaterialId == this.Desk.DesktopMaterialId).FirstOrDefault();

            materialPrice = surfaceMaterialPrices.DesktopMaterialPrice;

            decimal shippingPrice = 0.00M;

            var shippingPrices = context.DeliveryType.Where(d => d.DeliveryTypeId == this.DeliveryTypeId).FirstOrDefault();

            if (surfaceArea < 1000)
            {
                shippingPrice = shippingPrices.PriceUnder1000;
            }
            else if (surfaceArea <= 2000)
            {
                shippingPrice = shippingPrices.PriceBetween1000And2000;
            }
            else
            {
                shippingPrice = shippingPrices.PriceOver2000;
            }

            quotePrice = quotePrice + surfacePrice + drawerPrice + materialPrice + shippingPrice;
            return quotePrice;
        }
    }
}
