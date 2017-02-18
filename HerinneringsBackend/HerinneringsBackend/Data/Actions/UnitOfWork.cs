using RememberMeBackend.Data.Repositories;

namespace RememberMeBackend.Data.Actions {
    public class UnitOfWork : IUnitOfWork {
        private readonly MemoryDbContext _context;

        public UnitOfWork(MemoryDbContext context) {
            _context = context;
            Users = new UserRepository(_context);
        }

        public IUserRepository Users { get; private set; }

        public int Complete() {
            return _context.SaveChanges();
        }
        public void Dispose() {
            _context.Dispose();
        }
    }
}