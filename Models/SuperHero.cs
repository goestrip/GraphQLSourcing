using System.ComponentModel.DataAnnotations;

namespace GraphAPI.Models
{
    public class SuperHero
    {
      
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please specify a name for the superhero")]
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string Height { get; set; } = String.Empty;
        public ICollection<SuperPower> Superpowers { get; set; } = new List<SuperPower>();
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
        
    }
}
