using StockCareV2.Application.Interfaces.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockCareV2.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }

        Task CommitAsync();
    }
}
