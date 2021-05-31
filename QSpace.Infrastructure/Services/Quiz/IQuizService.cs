using QSpace.Core.Dtos;
using QSpace.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace QSpace.Infrastructure.Services.Quiz
{
    public interface IQuizService
    {
        QuizViewModel GetById(int Id);
        List<QuizViewModel> GetAll();
        List<MCQuestionViewModel> GetQuestions(int Id);
        List<SessionViewModel> GetHostingSessions(int quizId);
        void Create(CreateQuizDto dto);
        void Update(UpdateQuizDto dto);        
        void Deactivate(int Id);
        void Activate(int Id);
        void MarkAsInCompleted(int Id);
        void MarkAsCompleted(int Id);
        bool Delete(int Id);
    }
}
