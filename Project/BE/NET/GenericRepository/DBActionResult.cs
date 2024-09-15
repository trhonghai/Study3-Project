namespace NET.GenericRepository
{
    /// <summary>
    /// Represents the result of a database operation.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DBActionResult<T>
    {
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
        public string ErrorMessage { get; set; }

        public string StatusCode { get; set; } = "200";

        public int CreatedId { get; set; }

        public DBActionResult() { }

        public DBActionResult(bool isSuccess, T? data, string errorMessage = "Unknown error")
        {
            IsSuccess = isSuccess;
            Data = data;
            ErrorMessage = errorMessage;
        }

        public static DBActionResult<T> Success(T data)
        {
            return new DBActionResult<T>(true, data);
        }

        public static DBActionResult<T> Failure(string errorMessage)
        {
            return new DBActionResult<T>(false, default, errorMessage);
        }
    }
}

