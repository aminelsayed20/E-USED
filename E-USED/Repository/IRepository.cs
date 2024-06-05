namespace E_USED.Repository
{
    public interface IRepository<T> where T : class
    {
        public void Insert(T obj);
        public void Delete(T obj);
        public T Get(Func<T, bool> predicate);
        public List<T> GetAll();
        public void Update(T obj);
        public int Save();
    }
}
