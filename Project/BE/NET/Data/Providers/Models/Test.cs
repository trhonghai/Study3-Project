using System.ComponentModel.DataAnnotations;

namespace NET.Data.Providers.Models
{
    public class Test
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(255, ErrorMessage = "Title cannot be longer than 255 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Code is required")]
        [StringLength(255, ErrorMessage = "Code cannot be longer than 255 characters.")]
        public string Code { get; set; }

        [Range(4, 9999, ErrorMessage = "Year must be 4 digits")]
        public int Year { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Attempts must be greater than 0")]
        public int Attempts { get; set; }

        [Range(1, 12, ErrorMessage = "Month must be between 1 and 12")]
        public int Month { get; set; }

        [Range(60, int.MaxValue, ErrorMessage = "Time limit must be at least 1 minute")]
        public int TimeLimit { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Number of completed tests must be between 0 and 100")]
        public int NoCompleted { get; set; }

        [Required(ErrorMessage = "Type is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Type is required")]
        public int TypeId { get; set; }
    }
}