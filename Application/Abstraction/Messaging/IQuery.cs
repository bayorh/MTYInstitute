
using Domain.Shared;
using MediatR;

namespace Mty.Application.Abstraction.Messaging;

public interface IQuery<TResponse> :IRequest<Result<TResponse>>
{
}
