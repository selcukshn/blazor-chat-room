using Application.Repository.Base;
using AutoMapper;
using MediatR;

namespace Application.Mediator.Base
{
    public abstract class GenericHandler<TRepository, TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TRepository : IBaseRepository
    {
        public GenericHandler(TRepository repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public TRepository Repository { get; set; }
        public IMapper Mapper { get; set; }
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}