namespace LABCC.Domain.Interfaces.Services;

public interface IBaseService<TEntity, TDto, TParams>
{
    Task<bool> CreateAsync(TEntity customer);

    Task<TDto?> GetAsync(Guid id);

    Task<IEnumerable<TDto>> GetAllAsync(int page, TParams @params);

    Task<bool> UpdateAsync(TEntity customer);

    Task<bool> DeleteAsync(Guid id);
}