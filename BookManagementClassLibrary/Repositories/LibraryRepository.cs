using BookManagementClassLibrary.DbContexts;
using BookManagementClassLibrary.Domains;
using Microsoft.EntityFrameworkCore;

namespace BookManagementClassLibrary
{
    public class LibraryRepository<TEntity> : IRepository<TEntity> where TEntity : BaseDomain
    {
        private readonly BookDbContext _bookDbContext;
        private DbSet<TEntity>? DbSet { get { return _bookDbContext.Set<TEntity>(); } }

        public LibraryRepository(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }

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
            entity.IsDeleted= true;
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
            return DbSet!.FirstOrDefault(e => e.Id == entity.Id && e.IsDeleted == false);
        }

        public List<TEntity> GetAll(TEntity entity)
        {
            return DbSet!.Where(e => e.Id == entity.Id && e.IsDeleted == false).ToList();
        }
    }
}