namespace LABCC.Domain.Interfaces.Services;

public interface IBaseService<TEntity>
{
    Task<bool> CreateAsync(TEntity customer);

    Task<TEntity?> GetAsync(Guid id);

    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<bool> UpdateAsync(TEntity customer);

    Task<bool> DeleteAsync(Guid id);
}