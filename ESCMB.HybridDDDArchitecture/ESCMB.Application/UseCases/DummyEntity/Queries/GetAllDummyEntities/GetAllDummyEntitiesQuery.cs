﻿using Core.Application.ComandQueryBus.Queries;
using ESCMB.Application.DataTransferObjects;

namespace ESCMB.Application.UseCases.DummyEntity.Queries.GetAllDummyEntities
{
    public class GetAllDummyEntitiesQuery : QueryRequest<QueryResult<DummyEntityDto>>
    {
    }
}
