using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBlog.Infrastructure.Extensions
{
    public static class EnumerableExtensions
    {
        public static HelperResult Each<TItem>(this IEnumerable<TItem> items,
            Func<IndexedItem<TItem>, HelperResult> template)
        {
            return new HelperResult(writer =>
            {
                for (var i = 0; i < items.Count(); i++)
                {
                    template(new IndexedItem<TItem>(i, items.ElementAt(i))).WriteTo(writer);
                }
            });
        }
    }

    public class IndexedItem<TModel>
    {
        public IndexedItem(int index, TModel item)
        {
            Index = index;
            Item = item;
        }

        public int Index { get; set; }

        public TModel Item { get; set; }
    }
}