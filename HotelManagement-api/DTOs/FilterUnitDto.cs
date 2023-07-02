namespace HotelManagement_api.DTOs
{
    public class FilterUnitDto
    {
        public int? Floor { get; set; }
        public int? NumberOfPeople { get; set; }
        public DateTime? PeriodOf { get; set; }
        public DateTime? PeriodTo { get; set; }
    }
}
