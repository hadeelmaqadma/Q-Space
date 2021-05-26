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
        void Create(CreateQuizDto dto);
        void Update(UpdateQuizDto dto);
        
        bool Delete(int Id);
    }
}
