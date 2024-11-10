namespace MsContatos.Infra.Services.Interfaces
{
    public interface IServices<T>
    {
        public Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        public Task<T> GetByIdAsync(int id, CancellationToken cancellationToken);
        public Task<bool> ExistAsync(int id, CancellationToken cancellationToken);
        public void CreateAsync(T model);
        public void UpdateAsync(T model);
        public void DeleteAsync(int id);
    }
}
