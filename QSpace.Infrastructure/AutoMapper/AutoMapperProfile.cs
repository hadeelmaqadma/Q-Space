using AutoMapper;
using QSpace.Core.Dtos;
using QSpace.Core.Enums;
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
            CreateMap<UpdateQuizDto, QuizDbEntity>();
            CreateMap<MCQuestionDbEntity, MCQuestionViewModel>();
            CreateMap<CreateMCQuestionDto, MCQuestionDbEntity>();
            CreateMap<QuizDbEntity, QuizViewModel>().ForMember(dest => dest.Questions, act => act.MapFrom(src => src.Questions));
            CreateMap<CreateSessionDto, SessionDbEntity>();
            CreateMap<UpdateSessionDto, SessionDbEntity>();
            CreateMap<SessionDbEntity, SessionViewModel>();

            // For Tests
            CreateMap<byte, DifficultyLevel>().ConvertUsing(
                x => Enum.GetValues(typeof(DifficultyLevel))
                    .Cast<DifficultyLevel>().First(y => (byte)y == x));
        }
       
    }
}
