﻿using Core.Application;
using Core.Application.ComandQueryBus.Queries;
using ESCMB.Application.DataTransferObjects;
using System.ComponentModel.DataAnnotations;

namespace ESCMB.Application.UseCases.DummyEntity.Queries.GetDummyEntityBy
{
    public class GetDummyEntityByQuery : IRequestQuery<DummyEntityDto>
    {
        [Required]
        public int DummyIdProperty { get; set; }

        public GetDummyEntityByQuery()
        {
        }
    }
}
