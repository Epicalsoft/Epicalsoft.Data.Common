using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

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
            {
                Items[i].Order = i + 1;
                Items[i].PropertyChanged -= ListingItem_PropertyChanged;
                Items[i].PropertyChanged += ListingItem_PropertyChanged;
            }
        }

        private void ListingItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ItemPropertyChanged?.Invoke(this, new ItemPropertyChangedEventArgs<T>((ListingItem<T>)sender, e.PropertyName));
        }

        public void Add(T item)
        {
            Add(new ListingItem<T>(item));
        }

        public bool Contains(T item)
        {
            return Items.Any(x => ReferenceEquals(x.Data, item));
        }

        public void Remove(T item)
        {
            var matches = Items.Where(x => ReferenceEquals(x.Data, item)).ToList();
            foreach (var match in matches)
                Remove(match);
        }
    }
}