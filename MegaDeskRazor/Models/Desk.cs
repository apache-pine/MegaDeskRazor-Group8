using System.ComponentModel.DataAnnotations;

namespace MegaDeskRazor.Models
{
    public class Desk
    {
        // Properties
        public int DeskId { get; set; }

        public int Width { get; set; }

        public int Depth { get; set; }

        [Display(Name = "Number of Drawers")]
        public int NumDrawers { get; set; }

        [Display(Name = "Desktop Material")]
        public int DesktopMaterialId { get; set; }

        // Navigation Properties
        public DesktopMaterial DesktopMaterial { get; set; }

        public DeskQuote DeskQuote { get; set; }
    }
}
