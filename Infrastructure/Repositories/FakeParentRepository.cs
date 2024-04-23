using Domain.Entities;
using Domain.Repositories;

namespace Mty.Infrastructure.Repositories;

public class FakeParentRepository : IParentRepository
{
    private static List<Parent> _parents = new List<Parent>();
    public FakeParentRepository()
    {
        _parents = new List<Parent>
        {
           
        };

    }


    public void Add(Parent parent)
    {
        _parents.Add(parent);
    }

    public async  Task<Parent?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return _parents.FirstOrDefault(p => p.Email == email );
    }

    public async Task<Parent?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
       return  _parents.FirstOrDefault(p => p.Id == id);
    }
}
