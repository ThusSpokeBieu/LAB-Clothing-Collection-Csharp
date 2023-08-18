namespace LABCC.Domain.Interfaces.Repositories;

public interface IBaseRepository<TEntityDto>
{
    Task<bool> CreateAsync(TEntityDto customer);

    Task<TEntityDto?> GetAsync(Guid id);

    Task<IEnumerable<TEntityDto>> GetAllAsync();
    
    Task<IEnumerable<TEntityDto>> GetAllAsync(int page);

    Task<bool> UpdateAsync(TEntityDto customer);

    Task<bool> DeleteAsync(Guid id);
}