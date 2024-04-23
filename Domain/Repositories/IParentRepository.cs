using Domain.Entities;

namespace Domain.Repositories;
public interface IParentRepository
{
    Task<Parent?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Parent?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    void Add(Parent parent);
    

}
