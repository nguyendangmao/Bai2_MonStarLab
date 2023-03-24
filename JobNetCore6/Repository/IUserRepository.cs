using JobNetCore6.Entities;

namespace JobNetCore6.Repository
{
    public interface IUserRepository
    {
        public Task<AppUser> Create(AppUser _object);
        public Task Delete(Guid? id);
        public Task<AppUser> Update(AppUser _object);
        public Task<IEnumerable<AppUser>> GetAll();
        public Task<AppUser> GetById(Guid? Id);
    }
}
