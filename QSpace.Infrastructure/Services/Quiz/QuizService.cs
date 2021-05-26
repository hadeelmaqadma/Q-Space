using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QSpace.Core.Dtos;
using QSpace.Core.ViewModels;
using QSpace.Data.Data;
using QSpace.Data.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QSpace.Infrastructure.Services.Quiz
{
    public class QuizService : IQuizService
    {
        private readonly QSpaceDbContext _DB;
        private readonly IMapper _mapper;
        public QuizService(QSpaceDbContext DB, IMapper mapper)
        {
            _DB = DB;
            _mapper = mapper;
        }
        public List<QuizViewModel> GetAll() {
            var quizzes = _DB.Quizzes.Where(x => x.IsActive).ToList();
            return _mapper.Map<List<QuizViewModel>>(quizzes);
        }

        public QuizViewModel GetById(int Id) {
            var quiz = _DB.Quizzes.Find(Id);
            return quiz == null ? null : _mapper.Map<QuizViewModel>(quiz);
        }
        public List<MCQuestionViewModel> GetQuestions(int Id) {
            var questions = _DB.Quizzes.Include(x => x.Questions).Where(y => !y.IsDeleted && y.IsActive && y.IsActive)
                .Select(q => q.Questions).ToList();
            return _mapper.Map<List<MCQuestionViewModel>>(questions);
        }
        public void Create(CreateQuizDto dto)
        {
            /*var quiz = new QuizDbEntity()
            {
                Name = dto.Name
            };*/
            var quiz = _mapper.Map<QuizDbEntity>(dto);
            _DB.Quizzes.Add(quiz);
            _DB.SaveChanges();
        }
        public void Update(UpdateQuizDto dto) {
            var quiz = _DB.Quizzes.Find(dto.Id);
            if (quiz != null) {
                if (dto.Name != null && !dto.Name.Equals("") && !dto.Name.Equals(quiz.Name))
                {
                    quiz.Name = dto.Name;
                }
                quiz.IsActive = dto.IsActive;
                quiz.IsCompleted = dto.IsCompleted;
            }
            _DB.Quizzes.Update(quiz);
            _DB.SaveChanges();
        }
        public bool Delete(int Id)
        {
            var quiz = _DB.Quizzes.Find(Id);
            if (quiz == null)
                return false;
            else
            {
                _DB.Quizzes.Remove(quiz);
                _DB.SaveChanges();
                return true;
            }
        }
    }
}
