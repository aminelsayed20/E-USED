using E_USED.Data;
using NuGet.Protocol.Core.Types;

namespace E_USED.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public Repository(ApplicationDbContext context)
        {
         _context = context;
        }
        public void Insert(T obj)
        {
           _context.Set<T>().Add(obj);
        }

        public void Delete(T obj)
        {
           _context.Set<T>().Remove(obj);
        }
        public void Update(T obj)
        {
            _context.Set<T>().Update(obj);
        }
        public T Get(Func<T, bool> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);  // to find using id, name..  
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }


    }
}
