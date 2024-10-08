﻿using Core.Application.ComandQueryBus.Queries;
using Core.Application.Mapping;
using ESCMB.Application.DataTransferObjects;
using ESCMB.Application.Repositories.Sql;

namespace ESCMB.Application.UseCases.DummyEntity.Queries.GetAllDummyEntities
{
    internal class GetAllDummyEntitiesHandler(IDummyEntityRepository context) : IRequestQueryHandler<GetAllDummyEntitiesQuery, QueryResult<DummyEntityDto>>
    {
        private readonly IDummyEntityRepository _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<QueryResult<DummyEntityDto>> Handle(GetAllDummyEntitiesQuery request, CancellationToken cancellationToken)
        {
            IList<Domain.Entities.DummyEntity> entities = await _context.FindAllAsync();

            return new QueryResult<DummyEntityDto>(entities.To<DummyEntityDto>(), entities.Count, request.PageIndex, request.PageSize);
        }
    }
}
