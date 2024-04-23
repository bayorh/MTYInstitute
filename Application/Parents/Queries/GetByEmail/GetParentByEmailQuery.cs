using Mty.Application.Abstraction.Messaging;

namespace Mty.Application.Parents.Queries.GetByEmail;

public sealed record GetParentByEmailQuery(string email): IQuery<ParentResponse>;
