using System;

namespace Epicalsoft.Data.Common
{
    public class ListingItem<T> : ObservableObject, IEquatable<ListingItem<T>> where T : class
    {
        public T Data { get; }

        private int order;

        public int Order
        {
            get { return order; }
            internal set { SetProperty(ref order, value); }
        }

        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set { SetProperty(ref isSelected, value); OnPropertyChanged(nameof(IsUnselected)); }
        }

        public bool IsUnselected => !IsSelected;

        private bool isEnabled;

        public bool IsEnabled
        {
            get { return isEnabled; }
            set { SetProperty(ref isEnabled, value); OnPropertyChanged(nameof(IsDisabled)); }
        }

        public bool IsDisabled => !IsEnabled;

        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); OnPropertyChanged(nameof(IsIdle)); }
        }

        public bool IsIdle => !IsBusy;

        public ListingItem(T data)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));

            Data = data;
        }

        public static bool operator ==(ListingItem<T> a, ListingItem<T> b) => a is object && a.Equals(b);

        public static bool operator !=(ListingItem<T> a, ListingItem<T> b) => !(a == b);

        public override bool Equals(object obj) => Equals(obj as ListingItem<T>);

        public bool Equals(ListingItem<T> other)
        {
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            return Data.Equals(other.Data);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Data.GetHashCode()).GetHashCode();
        }
    }
}