using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using QSpace.Core.Dtos;
using QSpace.Core.ViewModels;
using QSpace.Data.Data;
using QSpace.Data.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSpace.Infrastructure.Services.Session
{
    public class SessionService : ISessionService
    {
        private readonly QSpaceDbContext _DB;
        private readonly IMapper _mapper;

        public SessionService(QSpaceDbContext DB, IMapper mapper, IUrlHelperFactory urlHelperFactory,
                   IActionContextAccessor actionContextAccessor)
        {
            _DB = DB;
            _mapper = mapper;
            var urlHelper =
              urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);
        }
        public List<StudentSessionViewModel> GetAll()
        {
            var sessions = _DB.Sessions.ToList();
            if (sessions.Count != 0)
                return _mapper.Map<List<StudentSessionViewModel>>(sessions);
            return null;
        }
        public List<StudentSessionViewModel> GetFutureSessions()
        {
            var sessions = _DB.Sessions.Where(x => x.HeldAt > DateTime.Now).ToList();
            if (sessions.Count != 0)
                return _mapper.Map<List<StudentSessionViewModel>>(sessions);
            return null;
        }

        public SessionViewModel GetSessionById(int sessionId)
        {
            var session = _DB.Sessions.SingleOrDefault(x => x.Id == sessionId);
            if (session != null)
                return _mapper.Map<SessionViewModel>(session);
            return null;
        }
        public StudentSessionViewModel GetSessionByCode(string sessionCode)
        {
            var session = _DB.Sessions.SingleOrDefault(x => x.Code == sessionCode);
            if (session != null && session.IsActive)
                return _mapper.Map<StudentSessionViewModel>(session);
            return null;
        }
        public QuizViewModel GetQuiz(int sessionId) {
            var session =_DB.Sessions.Include(x => x.Quiz).SingleOrDefault(x => x.Id == sessionId);
            return _mapper.Map<QuizViewModel>(session.Quiz);
        }
        public List<StudentViewModel> GetStudents(int sessionId) { 
            var session = _DB.Sessions.Include(y => y.Students).SingleOrDefault(x => x.Id == sessionId);
            return _mapper.Map<List<StudentViewModel>>(session.Students);
        }
        public void Create(CreateSessionDto dto) {
            var session = _mapper.Map<SessionDbEntity>(dto);
            _DB.Sessions.Add(session);
            _DB.SaveChanges();
        }
        public void Update(UpdateSessionDto dto)
        {
            var session = _DB.Sessions.Find(dto.Id);
            _mapper.Map<UpdateSessionDto, SessionDbEntity>(dto, session);
            _DB.Sessions.Update(session);
            _DB.SaveChanges();
        }
        public StudentSessionViewModel Launch(int sessionId)
        {
            var session = _DB.Sessions.Find(sessionId);
            session.IsActive = true;
            _DB.Sessions.Update(session);
            _DB.SaveChanges();
            return _mapper.Map<StudentSessionViewModel>(session);
        }
        public void Close(int sessionId)
        {
            var session = _DB.Sessions.Find(sessionId);
            session.IsActive = false;
            _DB.Sessions.Update(session);
            _DB.SaveChanges();
        }
        public void UpdateStudentsCount(int sessionId, bool increase) {
            var session =  _DB.Sessions.Find(sessionId);
            if (increase)
                session.StudentsCount = session.StudentsCount + 1;
            else
                session.StudentsCount = session.StudentsCount - 1;
           _DB.Sessions.Update(session);
           _DB.SaveChanges();
        }
        public bool Delete(int Id) {
            var session = _DB.Sessions.Find(Id);
            if (session != null) {
                session.IsDeleted = true;
                _DB.Sessions.Update(session);
                _DB.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
