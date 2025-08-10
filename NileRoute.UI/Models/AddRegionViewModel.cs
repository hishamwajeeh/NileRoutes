using System.ComponentModel.DataAnnotations;

namespace NileRoute.UI.Models
{
    public class AddRegionViewModel
    {
        [Required]
        [MinLength(2, ErrorMessage = "Code has to be Minimum of a 2 Characters")]
        [MaxLength(3, ErrorMessage = "Code has to be Maximun of a 3 Characters")]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
