namespace CountryLibrary.Models
{
    public class ApiResponse<T>
    {
        public List<T> Data { get; set; }
        public bool IsSucess { get; set; } = true;
        public string Message { get; set; } = string.Empty;

    }
}
