using RememberMeBackend.Data.Repositories;
using System;

namespace RememberMeBackend.Data.Actions {
    public interface IUnitOfWork : IDisposable {
        IUserRepository Users { get; }
        int Complete();
    }
}
