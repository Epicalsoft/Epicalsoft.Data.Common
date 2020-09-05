namespace Epicalsoft.Data.Common
{
    public class ListingItem<T> : ObservableObject
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
            Data = data;
        }
    }
}