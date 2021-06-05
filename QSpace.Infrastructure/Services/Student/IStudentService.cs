using QSpace.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QSpace.Infrastructure.Services.Student
{
    public interface IStudentService
    {
        void Create(CreateStudentDto dto);
        void Update(UpdateStudentDto dto);
    }
}
