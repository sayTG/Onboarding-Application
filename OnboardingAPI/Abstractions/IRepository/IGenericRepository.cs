namespace OnboardingAPI.Abstractions.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> Get(dynamic id);
        Task<IEnumerable<T>> GetAll();
        Task Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
