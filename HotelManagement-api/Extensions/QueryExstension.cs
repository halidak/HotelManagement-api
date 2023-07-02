using HotelManagement_api.DTOs;
using System.Linq.Expressions;

namespace HotelManagement_api.Extensions
{
    public static class QueryExtension
    {
        //za sortiranje
        public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query, UnitQueryDto unitQuery, Dictionary<string, Expression<Func<T, object>>> sortCol)
        {
            if (string.IsNullOrEmpty(unitQuery.SortBy) || !sortCol.ContainsKey(unitQuery.SortBy))
            {
                return query;
            }

            bool isSortAscending = unitQuery.IsSortAscending ?? false;

            if (isSortAscending)
            {
                query = query.OrderBy(sortCol[unitQuery.SortBy]);
            }
            else
            {
                query = query.OrderByDescending(sortCol[unitQuery.SortBy]);
            }

            return query;
        }



        //paginacija
        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, UnitQueryDto unitQuery)
        {
            int page = unitQuery.Page ?? 1;
            int pageSize = unitQuery.PageSize ?? 10;

            if (page <= 0)
            {
                page = 1;
            }
            if (pageSize <= 0)
            {
                pageSize = 10;
            }

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}
