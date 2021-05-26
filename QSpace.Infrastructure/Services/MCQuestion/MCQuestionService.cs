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
        public void Update(UpdateMCQuestionDto dto) {
            var mcq = _DB.MCQustions.Find(dto.Id);
            if (mcq != null) {
                if (!dto.A.Equals(mcq.A))
                    mcq.A = dto.A;
                if (!dto.B.Equals(mcq.B))
                    mcq.B = dto.B;
                if (!dto.C.Equals(mcq.C))
                    mcq.C = dto.C;
                if (!dto.D.Equals(mcq.D))
                    mcq.D = dto.D;
                if (!dto.CorrectAnswer.Equals(mcq.CorrectAnswer))
                    mcq.CorrectAnswer = dto.CorrectAnswer;
                if (!dto.Statement.Equals(mcq.Statement))
                    mcq.Statement = dto.Statement;
                if (dto.Time != mcq.Time)
                    mcq.Time = dto.Time;
                if (dto.Score != mcq.Score)
                    mcq.Score = dto.Score;
                if (dto.DifficultyLevel != mcq.DifficultyLevel)
                    mcq.DifficultyLevel = dto.DifficultyLevel;
            }
            _DB.MCQustions.Update(mcq);
            _DB.SaveChanges();
        }
        public bool Delete(int Id)
        {
            var mcq = _DB.MCQustions.Find(Id);
            if (mcq != null)
            {
                mcq.IsDeleted = true;
                _DB.MCQustions.Update(mcq);
                _DB.SaveChanges();
                return true;
            }
            return false;
        }
       
    }
}
