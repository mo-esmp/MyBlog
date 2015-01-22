using System;
using System.Linq;
using System.Runtime.Caching;

namespace MyBlog.Common.Helpers
{
    /// <summary>
    /// Cache helper class.
    /// </summary>
    public class CacheHelper
    {
        /// <summary>
        /// Initializes static members of the <see cref="CacheHelper"/> class.
        /// </summary>
        static CacheHelper()
        {
            if (Cache != null)
                return;

            Cache = MemoryCache.Default;
            DefaultPolicy = new CacheItemPolicy
            {
                SlidingExpiration = new TimeSpan(0, 0, 15, 0),
                Priority = CacheItemPriority.Default
            };
        }

        /// <summary>
        /// Adds the item to the cache.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="regionName">Name of the region which cache entry can be added.</param>
        public static void AddItem(string key, object value, string regionName = null)
        {
            Cache.Set(key, value, DefaultPolicy, regionName);
        }

        /// <summary>
        /// Adds the item to the cache.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="time">time duration which indicates whether a cache entry should be evicted if it has not been accessed in a given span of time.</param>
        /// <param name="regionName">Name of the region which cache entry can be added.</param>
        public static void AddItem(string key, object value, TimeSpan time, string regionName = null)
        {
            Cache.Set(key, value, new CacheItemPolicy { SlidingExpiration = time }, regionName);
        }

        /// <summary>
        /// Gets the item from the cache.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>System.Object.</returns>
        public static object GetItem(string key)
        {
            return Cache[key];
        }

        /// <summary>
        /// Clear the item from the cache.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="regionName">Name of the region which cache entry can be added.</param>
        public static void ClearItem(string key, string regionName = null)
        {
            Cache.Remove(key, regionName);
        }

        /// <summary>
        /// Clears the all entries in cache.
        /// </summary>
        /// <param name="regionName">Name of the region.</param>
        public static void ClearApplicationCache(string regionName = null)
        {
            // Retrieve application Cache keys
            var keys = Cache.Select(c => c.Key).ToList();

            // delete every key from cache
            foreach (var key in keys)
            {
                Cache.Remove(key, regionName);
            }
        }

        /// <summary>
        /// Gets or sets the cache object.
        /// </summary>
        /// <value>The cache.</value>
        private static ObjectCache Cache { get; set; }

        /// <summary>
        /// Gets or sets the default policy.
        /// </summary>
        /// <value>The default policy.</value>
        private static CacheItemPolicy DefaultPolicy { get; set; }
    }
}