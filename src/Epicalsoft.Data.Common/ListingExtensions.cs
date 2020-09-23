using System;
using System.Collections.Generic;

namespace Epicalsoft.Data.Common
{
    public static class ListingExtensions
    {
        public static Listing<T> ToListing<T>(this IEnumerable<T> enumerable) where T : class
        {
            var listing = new Listing<T>();
            foreach (var element in enumerable)
                listing.Add(element);
            return listing;
        }

        public static Listing<T, W> ToListing<T, W>(this IEnumerable<T> enumerable, Action<W, T> onAdding = null, Action<W, T> onAdded = null) where W : ListingItem<T> where T : class
        {
            var listing = new Listing<T, W>();
            foreach (var element in enumerable)
            {
                var item = (W)Activator.CreateInstance(typeof(W), element);
                onAdding?.Invoke(item, element);
                listing.Add(item);
                onAdded?.Invoke(item, element);
            }
            return listing;
        }

        public static Z ToListing<T, W, Z>(this IEnumerable<T> enumerable, Action<Z, W, T> onAdding = null, Action<Z, W, T> onAdded = null) where Z : Listing<T> where W : ListingItem<T> where T : class
        {
            var listing = Activator.CreateInstance<Z>();
            foreach (var element in enumerable)
            {
                var item = (W)Activator.CreateInstance(typeof(W), element);
                onAdding?.Invoke(listing, item, element);
                listing.Add(item);
                onAdded?.Invoke(listing, item, element);
            }
            return listing;
        }
    }
}