using HotelManagement.Contracts.Models;
using HotelManagement.Data.Models;

namespace HotelManagement_api.DTOs
{
    public class UnitQueryDto : IQueryObj
    {
        public double? Price { get; set; }
        public string? SortBy { get; set; }
        public bool? IsSortAscending { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public int? Floor { get; set; }
        public int? NumberOfPeople { get; set; }
        public DateTime? PeriodOf { get; set; }
        public DateTime? PeriodTo { get; set; }
    }
}
