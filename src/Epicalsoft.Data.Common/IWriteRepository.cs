namespace Epicalsoft.Data.Common
{
    public interface IWriteRepository<T, W> where T : Entity<W>
    {
        public IUnitOfWork UnitOfWork { get; }
    }
}