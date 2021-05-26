using QSpace.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace QSpace.Infrastructure.Services.MCQuestion
{
    public interface IMCQuestionService
    {
        void Create(CreateMCQuestionDto dto);
        void Update(UpdateMCQuestionDto dto);
        bool Delete(int Id);
    }
}
