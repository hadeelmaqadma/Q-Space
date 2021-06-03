using AutoMapper;
using QSpace.Core.Dtos;
using QSpace.Data.Data;
using QSpace.Data.DbEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QSpace.Infrastructure.Services.Student
{
    public class StudentService :  IStudentService
    {
        private readonly QSpaceDbContext _DB;
        private readonly IMapper _mapper;

        public StudentService(QSpaceDbContext DB, IMapper mapper)
        {
            _DB = DB;
            _mapper = mapper;
        }
        public void Create(CreateStudentDto dto) {
            var student = _mapper.Map<StudentDbEntity>(dto);
            _DB.Students.Add(student);
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
