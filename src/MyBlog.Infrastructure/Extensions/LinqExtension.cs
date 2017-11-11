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

        public static ICollection<T> Except<T, TKey>(this ICollection<T> items, ICollection<T> other, Func<T, TKey> key)
        {
            return items
                .GroupJoin(other, key, key, (item, tempItems) => new { item, tempItems })
                .SelectMany(t => t.tempItems.DefaultIfEmpty(), (t, temp) => new { t, temp })
                .Where(t => ReferenceEquals(null, t.temp) || t.temp.Equals(default(T)))
                .Select(t => t.t.item)
                .ToList();
        }
    }
}