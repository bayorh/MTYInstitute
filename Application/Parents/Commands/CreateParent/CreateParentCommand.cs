
using Application.Abstraction.Messaging;
using Domain.Enums;

namespace Application.Parents.Commands.CreateParent;

public sealed record  CreateParentCommand(Guid id, string name, string address, string email, int phoneNumber, Tittle? tittle)
    : ICommand;

