using Domain.Interfaces;

namespace Infra.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }

        ICategoryRepository CategoryRepository { get; }

        void Commit();
    }
}
