using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WarehousingWebApi.Buildings
{
    public interface ISpaceQueryResultDto { }

    public class QueryDtoRequest<TSpace> : IRequest<TSpace> where TSpace : List<ISpaceQueryResultDto>
    {
    }

    public class BuildingQuery : IRequest<BuildingResponse>
    { }

    public class BuildingResponse : ISpaceQueryResultDto
    { }

    public class BuildingSearchHandler : IRequestHandler<BuildingQuery, BuildingResponse>
    {
        public async Task<BuildingResponse> Handle(BuildingQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(default(BuildingResponse));
        }
    }
}
