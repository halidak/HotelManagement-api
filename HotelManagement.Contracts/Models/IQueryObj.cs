using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Contracts.Models
{
    public interface IQueryObj
    {
        //sortiranje
        public string? SortBy { get; set; }
        public bool? IsSortAscending { get; set; }
        //paginacija
        public int? Page { get; set; }
        public int? PageSize { get; set; }

    }
}
