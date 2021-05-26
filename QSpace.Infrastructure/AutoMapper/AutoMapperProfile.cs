using AutoMapper;
using QSpace.Core.Dtos;
using QSpace.Core.ViewModels;
using QSpace.Data.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSpace.Infrastructure.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateStudentDto, StudentDbEntity>();
            CreateMap<StudentDbEntity, StudentViewModel>();
            CreateMap<CreateQuizDto, QuizDbEntity>();
            CreateMap<QuizDbEntity, QuizViewModel>();
            CreateMap<CreateMCQuestionDto, MCQuestionDbEntity>();
            CreateMap<MCQuestionDbEntity, MCQuestionViewModel>();
        }
       
    }
}
