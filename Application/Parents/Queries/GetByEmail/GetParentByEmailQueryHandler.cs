

using Domain.Repositories;
using Domain.Shared;
using Mty.Application.Abstraction.Messaging;

namespace Mty.Application.Parents.Queries.GetByEmail;

internal sealed class GetParentByEmailQueryHandler : IQuesryHandler<GetParentByEmailQuery, ParentResponse>
{
    private readonly IParentRepository _parentRepository;

    public GetParentByEmailQueryHandler(IParentRepository parentRepository)
    {
        _parentRepository = parentRepository;
    }

    public async  Task<Result<ParentResponse>> Handle(
        GetParentByEmailQuery request,
        CancellationToken cancellationToken)
    {
        var parent = await _parentRepository.GetByEmailAsync(request.email, cancellationToken);
        if (parent is null)
        {
            return Result.Failure<ParentResponse>(new Error(
                "Parent.NotFound",
                $"Parent with Email: {request.email} was not found."));
        }
        var response = new ParentResponse(parent.Id,parent.Name,parent.Email, parent.PhoneNumber);
        return response;
    }

}
