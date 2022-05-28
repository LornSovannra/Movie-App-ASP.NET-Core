using Movie_App.EnumerableModels;
using System.ComponentModel.DataAnnotations;

namespace Movie_App.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Duraction is required.")]
        [Display(Name = "Duration (mn)")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "SubTitle is required.")]
        public string SubTitle { get; set; }

        [Required(ErrorMessage = "Release Date is required.")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Language is required.")]
        public string Language { get; set; }

        [Required(ErrorMessage = "Movie Type is required.")]
        [Display(Name = "Movie Type")]
        public MovieType MovieType { get; set; }
    }
}
