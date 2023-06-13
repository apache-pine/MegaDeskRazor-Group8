using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaDeskRazor.Models
{
    public class Desk
    {
        // Properties
        public int DeskId { get; set; }

        [Range(24, 96, ErrorMessage = "Please enter a number between 24 and 96.")]
        public int Width { get; set; }

        [Range(12, 48, ErrorMessage = "Please enter a number between 12 and 48.")]
        public int Depth { get; set; }

        [Display(Name = "Number of Drawers"), Range(0, 7, ErrorMessage = "Please enter a number between 0 and 7.")]
        public int NumDrawers { get; set; }

        [Display(Name = "Desktop Material"), Required(ErrorMessage = "Please select a desktop material.")]
        public int DesktopMaterialId { get; set; }

        // Navigation Properties
        [Display(Name = "Desktop Material")]
        public DesktopMaterial DesktopMaterial { get; set; }

        public DeskQuote DeskQuote { get; set; }
    }
}
