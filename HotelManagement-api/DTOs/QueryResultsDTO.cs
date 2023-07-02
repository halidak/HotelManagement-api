namespace HotelManagement_api.DTOs
{
    public class QueryResultsDTO<T> where T : class
    {
        public int TotalItems { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
