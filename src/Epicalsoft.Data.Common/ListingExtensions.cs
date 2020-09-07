using System;
using System.Collections.Generic;

namespace Epicalsoft.Data.Common
{
    public static class ListingExtensions
    {
        public static Listing<T> ToListing<T>(this IEnumerable<T> enumerable)
        {
            var listing = new Listing<T>();
            foreach (var element in enumerable)
            {
                var item = new ListingItem<T>(element);
                item.PropertyChanged += (s, a) => { listing.RaiseItemPropertyChanged(item, a.PropertyName); };
                listing.Add(item);
            }
            return listing;
        }

        public static Listing<T> ToListing<T, W>(this IEnumerable<T> enumerable, Action<W, T> beforeAdding = null) where W : ListingItem<T>
        {
            var listing = new Listing<T>();
            foreach (var element in enumerable)
            {
                var item = (W)Activator.CreateInstance(typeof(W), element);
                beforeAdding?.Invoke(item, element);
                item.PropertyChanged += (s, a) => { listing.RaiseItemPropertyChanged(item, a.PropertyName); };
                listing.Add(item);
            }
            return listing;
        }

        public static Z ToListing<T, W, Z>(this IEnumerable<T> enumerable, Action<Z, W, T> beforeAdding = null) where Z : Listing<T> where W : ListingItem<T>
        {
            var listing = Activator.CreateInstance<Z>();
            foreach (var element in enumerable)
            {
                var item = (W)Activator.CreateInstance(typeof(W), element);
                beforeAdding?.Invoke(listing, item, element);
                item.PropertyChanged += (s, a) => { listing.RaiseItemPropertyChanged(item, a.PropertyName); };
                listing.Add(item);
            }
            return listing;
        }
    }
}