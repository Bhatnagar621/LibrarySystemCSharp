using BookManagementClassLibrary.DbContexts;
using BookManagementClassLibrary.Domains;
using Microsoft.EntityFrameworkCore;

namespace BookManagementClassLibrary.Repositories
{
    public class UserRepository<TEntity> : IRepository<TEntity> where TEntity : User
    {
        private readonly BookDbContext _bookDbContext; 

        public UserRepository(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }

        public DbSet<TEntity>? DbSet => _bookDbContext.Set<TEntity>();

        public void Add(TEntity entity)
        {
            _bookDbContext.Add(entity);
            _bookDbContext.SaveChanges();
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _bookDbContext.AddRange(entities);
            _bookDbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _bookDbContext.Update(entity);
            _bookDbContext.SaveChanges();
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _bookDbContext.UpdateRange(entities);
            _bookDbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            _bookDbContext.Update(entity);
            _bookDbContext.SaveChanges();
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDeleted = true;
                _bookDbContext.Update(entity);
            }
            _bookDbContext.SaveChanges();
        }

        public TEntity Get(TEntity entity)
        {
            return DbSet!.FirstOrDefault(e => e.Email==entity.Email && e.IsDeleted==false);
        }

        public List<TEntity> GetAll(TEntity entity)
        {
            return DbSet!.Where(e => e.Email == entity.Email && e.IsDeleted == false).ToList();   
        }
    }

}
