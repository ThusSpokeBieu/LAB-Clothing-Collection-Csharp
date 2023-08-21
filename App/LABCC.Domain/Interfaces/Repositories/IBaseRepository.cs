namespace LABCC.Domain.Interfaces.Repositories;

public interface IBaseRepository<TEntityDto, TParams>
{
    Task<bool> CreateAsync(TEntityDto customer);

    Task<TEntityDto?> GetAsync(string @param);

    Task<IEnumerable<TEntityDto>> GetAllAsync(int page, TParams? parameters);

    Task<bool> UpdateAsync(TEntityDto customer);

    Task<bool> DeleteAsync(Guid id);
}