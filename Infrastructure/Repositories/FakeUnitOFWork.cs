
using Domain.Entities;
using Domain.Repositories;

namespace Mty.Infrastructure.Repositories;

public class FakeUnitOFWork : IUnitOfWork
{
    
    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
       return Task.CompletedTask;
    }
}
