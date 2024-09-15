
namespace NET.Dto
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int NoPurchase { get; set; }
        public decimal Rating { get; set; }
        public string Target { get; set; }

        public string TypeName { get; set; }

        public static implicit operator CourseDto(PaginatedResult<CourseDto> v)
        {
            throw new NotImplementedException();
        }
    }
}