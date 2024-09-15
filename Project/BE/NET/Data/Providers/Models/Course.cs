using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NET.Dto;

namespace NET.Data.Providers.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(255, ErrorMessage = "Title cannot be longer than 255 characters.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "No Purchase is required")]
        [Range(0, int.MaxValue, ErrorMessage = "No Purchase must be greater than 0")]
        public int NoPurchase { get; set; }

        [Required(ErrorMessage = "Target is required")]
        [StringLength(255, ErrorMessage = "Target cannot be longer than 255 characters.")]
        public string Target { get; set; }
        public decimal Rating { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(255, ErrorMessage = "Description cannot be longer than 255 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Type is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Type is required")]

        public int TypeId { get; set; }

        public static implicit operator Course(PaginatedResult<Course> v)
        {
            throw new NotImplementedException();
        }
    }
}