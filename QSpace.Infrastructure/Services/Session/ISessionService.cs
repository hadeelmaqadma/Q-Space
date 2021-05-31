using QSpace.Core.Dtos;
using QSpace.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QSpace.Infrastructure.Services.Session
{
    public interface ISessionService
    {
        List<SessionViewModel> GetSessions();
        SessionViewModel GetSessionById(int sessionId);
        QuizViewModel GetQuiz(int sessionId);
        List<StudentViewModel> GetStudents(int sessionId);
        void Create(CreateSessionDto dto);
        void Update(UpdateSessionDto dto);
        void UpdateStudentsCount(int sessionId, bool increase);
        bool Delete(int Id);
    }
}