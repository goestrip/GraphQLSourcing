using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphAPI.Models
{
    public class SuperPower
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "The superpower is required")]
        public string Power { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        
    }
}
