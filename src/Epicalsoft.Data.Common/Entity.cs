namespace Epicalsoft.Data.Common
{
    public abstract class Entity<T>
    {
        public virtual T Id { get; protected set; }

        public override bool Equals(object obj)
        {
            var other = obj as Entity<T>;

            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (Id.Equals(default(T)) || other.Id.Equals(default(T)))
                return false;

            return Id.Equals(other.Id);
        }

        public static bool operator ==(Entity<T> a, Entity<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<T> a, Entity<T> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }
    }
}