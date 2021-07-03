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
        List<StudentSessionViewModel> GetAll();
        List<StudentSessionViewModel> GetFutureSessions();
        SessionViewModel GetSessionById(int sessionId);
        StudentSessionViewModel GetSessionByCode(string sessionCode);
        QuizViewModel GetQuiz(int sessionId);
        List<StudentViewModel> GetStudents(int sessionId);
        void Create(CreateSessionDto dto);
        void Update(UpdateSessionDto dto);
        public StudentSessionViewModel Launch(int sessionId);
        public void Close(int sessionId);
        void UpdateStudentsCount(int sessionId, bool increase);
        bool Delete(int Id);
    }
}