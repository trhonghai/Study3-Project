namespace NET.Dto
{
    public class PaginatedResult<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int TotalPages { get; set; }
    }
}
