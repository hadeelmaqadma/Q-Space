using QSpace.Data.DbEntities;
using QSpace.Infrastructure.Services.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace QSpace.Test.ServiceTests
{
    public class SessionServiceTest : BaseTest
    {
        [Fact]
        public void GetAll_Should_Return_Empty_for_Zero_Sessions()
        {
            // Arrange
            using var dbContext = GetDbContext();
            //Act
            var sessions = dbContext.Sessions.ToList();
            //Assert
            Assert.Empty(sessions);
        }
        [Fact]
        public async Task GetAll_Should_Return_List_of_Sessions()
        {
            // Arrange 
            using var dbContext = GetDbContext();
            var mapper = GetMapper();
            var quizzes = dbContext.Quizzes.ToList();
            Assert.NotEmpty(quizzes);

            var quiz = quizzes.FirstOrDefault();
            dbContext.Sessions.Add(new SessionDbEntity { HeldAt = DateTime.Now, QuizId = quiz.Id });
            await dbContext.SaveChangesAsync();

            // Act
            var service = new SessionService(dbContext, mapper);
            var result = service.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
        [Fact]
        public void GetSessionById_should_return_null_for_missing_Session()
        {
            // Arrange 
            using var dbContext = GetDbContext();
            var mapper = GetMapper();
            var id = -1;
            // Act
            var service = new SessionService(dbContext, mapper);
            var result = service.GetSessionById(id);

            Assert.Null(result);
        }
        [Fact]
        public async Task GetSessionById_should_return_sessionVM_for_exsiting_Session()
        {
            using var dbContext = GetDbContext();
            var mapper = GetMapper();

            var quizzes = dbContext.Quizzes.ToList();
            var quiz = quizzes.FirstOrDefault();
            var DateNow = DateTime.Now;
            var session = new SessionDbEntity {
                HeldAt = DateNow,
                QuizId = quiz.Id
            };
            dbContext.Sessions.Add(session);
            await dbContext.SaveChangesAsync();

            var id = session.Id;
            var service = new SessionService(dbContext, mapper);
            var result = service.GetSessionById(id);

            Assert.NotNull(result);
            Assert.True(result.HeldAt.Second == DateNow.Second);
        }
    }
}
