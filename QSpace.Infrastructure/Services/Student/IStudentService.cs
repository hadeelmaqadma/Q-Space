using QSpace.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace QSpace.Infrastructure.Services.Student
{
    public interface IStudentService
    {
        void Create(CreateStudentDto dto);
        void Update(UpdateStudentDto dto);
    }
}
