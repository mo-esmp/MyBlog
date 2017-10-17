using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace MyBlog.Infrastructure.Extensions
{
    public static class LinqExtension
    {
        public static IOrderedEnumerable<TSource> SortBy<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, SortOrder sortOrder)
        {
            return sortOrder == SortOrder.Descending
                ? source.OrderByDescending(keySelector)
                : source.OrderBy(keySelector);
        }

        public static IOrderedQueryable<TSource> SortBy<TSource, TKey>
            (this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, SortOrder sortOrder)
        {
            return sortOrder == SortOrder.Descending
                ? source.OrderByDescending(keySelector)
                : source.OrderBy(keySelector);
        }
    }
}