using AutoMapper;
using QSpace.Core.Dtos;
using QSpace.Data.Data;
using QSpace.Data.DbEntities;
using QSpace.Infrastructure.Services.Session;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QSpace.Infrastructure.Services.Student
{
    public class StudentService :  IStudentService
    {
        private readonly QSpaceDbContext _DB;
        private readonly IMapper _mapper;
        private readonly ISessionService _sessionService;
        public StudentService(QSpaceDbContext DB, IMapper mapper, ISessionService sessionService)
        {
            _DB = DB;
            _mapper = mapper;
            _sessionService = sessionService;
        }
        public void Create(CreateStudentDto dto) {
            var student = (StudentDbEntity)_mapper.Map<StudentDbEntity>(dto);
            _DB.Students.Add(student);
            _sessionService.UpdateStudentsCount(dto.SessionId, increase:true);
            _DB.SaveChanges();
        }

        public void Update(UpdateStudentDto dto) {
            var student = _DB.Students.Find(dto.Id);
            student.Score = dto.Score;
            _DB.Students.Update(student);
            _DB.SaveChanges();
        }
    }
}
