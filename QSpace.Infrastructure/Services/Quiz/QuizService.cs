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
             var quizzes = _DB.Quizzes.Include(x => x.Questions).Where(x => x.IsActive).ToList();
             return _mapper.Map<List<QuizViewModel>>(quizzes);
        }

        public QuizViewModel GetById(int Id) {
            var quiz = _DB.Quizzes.Include(x => x.Questions).SingleOrDefault(x => x.Id == Id);
            return quiz == null ? null : _mapper.Map<QuizViewModel>(quiz);
        }
        public List<MCQuestionViewModel> GetQuestions(int Id) {
            var questions = _DB.Quizzes.Include(x => x.Questions).
                Where(y => !y.IsDeleted && y.IsActive && y.IsCompleted && y.Id == Id)
                .Select(q => q.Questions).ToList();
            return _mapper.Map<List<MCQuestionViewModel>>(questions);
        }
        public List<SessionViewModel> GetHostingSessions(int quizId) {
            var sessions = _DB.Sessions.Where(z => z.QuizId == quizId).ToList();
            if(sessions.Count > 0)
                return _mapper.Map<List<SessionViewModel>>(sessions);
            return null;
        }
        public void Create(CreateQuizDto dto)
        {
            var quiz = _mapper.Map<QuizDbEntity>(dto);
            _DB.Quizzes.Add(quiz);
            _DB.SaveChanges();
        }
        public void Update(UpdateQuizDto dto) {
            var quiz = _DB.Quizzes.SingleOrDefault(x => x.Id == dto.Id);
            if (!dto.Name.Equals(""))
                quiz.Name = dto.Name;
            if (quiz != null) {
                _mapper.Map<UpdateQuizDto, QuizDbEntity>(dto, quiz);
            }
            _DB.Quizzes.Update(quiz);
            _DB.SaveChanges();
        }

        public void Deactivate(int Id) 
        {
            var quiz = _DB.Quizzes.Find(Id);
            if (quiz == null) {
                throw new Exception();
            }
            else
            {
                quiz.IsActive = false;
                _DB.Quizzes.Update(quiz);
                _DB.SaveChanges();
            }
        }
        public void Activate(int Id)
        {
            var quiz = _DB.Quizzes.Find(Id);
            if (quiz == null)
            {
                throw new Exception();
            }
            else
            {
                quiz.IsActive = true;
                _DB.Quizzes.Update(quiz);
                _DB.SaveChanges();
            }
        }
        public void MarkAsCompleted(int Id)
        {
            var quiz = _DB.Quizzes.Find(Id);
            if (quiz == null)
            {
                throw new Exception();
            }
            else
            {
                quiz.IsCompleted = true;
                _DB.Quizzes.Update(quiz);
                _DB.SaveChanges();
            }
        }
        public void MarkAsInCompleted(int Id)
        {
            var quiz = _DB.Quizzes.Find(Id);
            if (quiz == null)
            {
                throw new Exception();
            }
            else
            {
                quiz.IsCompleted = false;
                _DB.Quizzes.Update(quiz);
                _DB.SaveChanges();
            }
        }
        public bool Delete(int Id)
        {
            var quiz = _DB.Quizzes.Find(Id);
            if (quiz == null)
                return false;
            else
            {
                quiz.IsDeleted = true;
                _DB.Quizzes.Update(quiz);
                _DB.SaveChanges();
                return true;
            }
        }
    }
}
