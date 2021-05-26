using AutoMapper;
using QSpace.Core.Dtos;
using QSpace.Data.Data;
using QSpace.Data.DbEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QSpace.Infrastructure.Services.MCQuestion
{
    public class MCQuestionService : IMCQuestionService
    {
        private readonly QSpaceDbContext _DB;
        private readonly IMapper _mapper;

        public MCQuestionService(QSpaceDbContext DB, IMapper mapper)
        {
            _DB = DB;
            _mapper = mapper;
        }

        public void Create(CreateMCQuestionDto dto) {
            var mcq = _mapper.Map<MCQuestionDbEntity>(dto);
            _DB.MCQustions.Add(mcq);
            _DB.SaveChanges();
        }

    }
}
