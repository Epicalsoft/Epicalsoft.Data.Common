using System;

namespace Epicalsoft.Data.Common
{
    public delegate void ItemPropertyChangedEventHandler<T>(object sender, ItemPropertyChangedEventArgs<T> e) where T : class;

    public class ItemPropertyChangedEventArgs<T> : EventArgs where T : class
    {
        public ItemPropertyChangedEventArgs(ListingItem<T> item, string propertyName)
        {
            Item = item;
            PropertyName = propertyName;
        }

        public ListingItem<T> Item { get; }
        public string PropertyName { get; }
    }
}