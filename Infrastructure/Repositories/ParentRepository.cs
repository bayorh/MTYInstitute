
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Mty.Infrastructure.DataAccess;

namespace Mty.Infrastructure.Repositories;

public sealed  class ParentRepository : IParentRepository
{
    private readonly MtyContext _context;

    public ParentRepository(MtyContext context) => _context = context;

    public void Add(Parent parent)
    {
        _context.Parents.Add(parent);
    }

    public async Task<Parent?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        var parent =  await _context.Parents.FirstOrDefaultAsync( e => e.Email == email);
        return parent;
    }

    public async Task<Parent?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var parent = await _context.Parents.FirstOrDefaultAsync(e => e.Id == id);
        return parent;
    }
}
