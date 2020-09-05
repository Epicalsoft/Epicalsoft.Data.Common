using System.Collections.ObjectModel;

namespace Epicalsoft.Data.Common
{
    public class Listing<T> : ObservableCollection<ListingItem<T>>
    {
        public event ItemPropertyChangedEventHandler<T> ItemPropertyChanged;

        public Listing()
        {
            CollectionChanged += Listing_CollectionChanged;
        }

        private void Listing_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            for (int i = 0; i < Items.Count; i++)
                Items[i].Order = i + 1;
        }

        internal void RaiseItemPropertyChanged(ListingItem<T> item, string propertyName)
        {
            ItemPropertyChanged?.Invoke(this, new ItemPropertyChangedEventArgs<T>(item, propertyName));
        }
    }
}