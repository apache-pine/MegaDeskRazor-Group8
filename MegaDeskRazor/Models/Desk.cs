using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MegaDeskRazor.Models
{
    public class Desk
    {
        // Constants
        public const int DESK_MIN_WIDTH = 24;
        public const int DESK_MAX_WIDTH = 96;
        public const int DESK_MIN_DEPTH = 12;
        public const int DESK_MAX_DEPTH = 48;
        public const int DESK_MIN_NUM_DRAWERS = 0;
        public const int DESK_MAX_NUM_DRAWERS = 7;

        // Properties
        public int DeskId { get; set; }

        [Required]
        public int Width { get; set; }

        [Required]
        public int Depth { get; set; }

        [Display(Name = "Number of Drawers")]
        public int NumDrawers { get; set; }

        [Display(Name = "Desktop Material")]
        [Required]
        public int DesktopMaterialId { get; set; }

        // Navigation Properties
        public DesktopMaterial? DesktopMaterial { get; set; }
    }
}
