
using Application.Abstraction.Messaging;
using Domain.Entities;
using Domain.Repositories;
using Domain.Shared;


namespace Application.Parents.Commands.CreateParent;


public sealed class CreateParentCommandHandler : ICommandHandler<CreateParentCommand>
{
    private readonly IParentRepository _parentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateParentCommandHandler(IParentRepository parentRepository, IUnitOfWork unitOfWork)
    {
        _parentRepository = parentRepository;
        _unitOfWork = unitOfWork;
    }

    public  async Task<Result> Handle(CreateParentCommand request, CancellationToken cancellationToken)
    {
        //check for parent existence
       /* var parent = _parentRepository.GetByEmailAsync(request.email, cancellationToken);
        if (parent != null) return Result.Failure(DomainErrors.Parent.EmailAlreadyExist);*/

        var parenToCreate = Parent.Create(
            new Guid(), request.name, request.address, request.email, request.phoneNumber, request.tittle);
       await  _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}

