using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GraphAPI.Models
{
    public class Movie
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "The movie title is required")]
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string Instructor { get; set; } = String.Empty;
        public DateTime ReleaseDate { get; set; }
                
    }
}
