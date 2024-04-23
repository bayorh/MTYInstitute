

using Domain.Shared;
using MediatR;

namespace Mty.Application.Abstraction.Messaging;

public interface IQuesryHandler<TQuery,TResponse>: IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{

}
