using JobNetCore6.Core.Models;
using JobNetCore6.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobNetCore6.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly AppDBContext _appDbContext;

        public UserRepository(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<AppUser> Create(AppUser appuser)
        {
            _appDbContext.AppUsers!.Add(appuser);
            await _appDbContext.SaveChangesAsync();
            return appuser;
        }
        public async Task Delete(Guid? id)
        {
            var delete = await _appDbContext.AppUsers!.FindAsync(id);
            if (delete != null)
            {
                _appDbContext.Remove(delete);
            }
           await  _appDbContext.SaveChangesAsync();

        }
        public async Task<IEnumerable<AppUser>> GetAll()
        {
            return await _appDbContext.AppUsers!.ToListAsync();

        }
        public async Task<AppUser> GetById(Guid? id)
        {

            var getbyid = await _appDbContext.AppUsers!.FirstOrDefaultAsync(n=>n.Id.Equals(id));
            return getbyid!;

        }
        public async Task<AppUser> Update(AppUser appuser)
        {
            _appDbContext.Update(appuser);      
            await  _appDbContext.SaveChangesAsync();
            return appuser!;

        }
    }
}
