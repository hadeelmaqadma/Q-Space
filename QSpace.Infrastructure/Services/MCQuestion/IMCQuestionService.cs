using QSpace.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QSpace.Infrastructure.Services.MCQuestion
{
    public interface IMCQuestionService
    {
        Task Create(CreateMCQuestionDto dto);
        Task Update(UpdateMCQuestionDto dto);
        void ChangeActive(int Id);
        bool Delete(int Id);

    }
}
