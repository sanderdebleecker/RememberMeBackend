using RememberMeBackend.Models.Data;

namespace RememberMeBackend.Data.Repositories {
    public class UserRepository : GenericRepository<ApplicationUser>, IUserRepository {
        public UserRepository(MemoryDbContext context) : base(context) {
        }

        public MemoryDbContext MemoryDbContext => Context as MemoryDbContext;
    }
}