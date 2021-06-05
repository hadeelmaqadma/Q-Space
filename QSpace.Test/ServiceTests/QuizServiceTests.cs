using QSpace.Data;
using QSpace.Data.DbEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using QSpace.Infrastructure.Services.Quiz;
using AutoMapper;
using QSpace.Infrastructure.AutoMapper;

namespace QSpace.Test
{
    public class QuizServiceTests : BaseTest
    {
        [Fact]
        public async Task GetAll_Should_Return_List_of_Quizzes()
        {
            using var dbContext = GetDbContext();
            var mapper = GetMapper();
            var instructors = dbContext.Users.ToList();
            Assert.NotEmpty(instructors);

            var instructor = instructors.FirstOrDefault();
            // Arrange 
            dbContext.Quizzes.Add(new QuizDbEntity { Name = "TDD Quiz", InstructorId = instructor.Id, IsActive = true});
            dbContext.Quizzes.Add(new QuizDbEntity { Name = "Design 2", InstructorId = instructor.Id, IsActive = true });
            await dbContext.SaveChangesAsync();

            // Act
            var service = new QuizService(dbContext, mapper);
            var result =  service.GetAll();

            // Assert
            Assert.NotNull(result);
            //Assert.Equal(4, result.Count);
            Assert.NotEmpty(result);
        }
        [Fact]
        public void GetById_should_return_null_for_missing_Quiz()
        {
            using var dbContext = GetDbContext();
            var mapper = GetMapper();
            var id = -1;

            var service = new QuizService(dbContext, mapper);
            var result =  service.GetById(id);

            Assert.Null(result);
        }

        [Fact]
        public async Task GetById_should_return_model_for_existing_Quiz()
        {
            using var dbContext = GetDbContext();
            var mapper = GetMapper();
            
            var instructors = dbContext.Users.ToList();
            var instructor = instructors.FirstOrDefault();
            var quiz = new QuizDbEntity { Name = "TDD Quiz 2", InstructorId = instructor.Id, IsActive = true };
            dbContext.Quizzes.Add(quiz);
            await dbContext.SaveChangesAsync();
            
            var id = quiz.Id;
            var service = new QuizService(dbContext, mapper);
            var result = service.GetById(id);

            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }

        [Fact]
        public async Task GetQuestions_should_return_empty_for_NoAddedQuestionsYetQuiz()
        {
            using var dbContext = GetDbContext();
            var mapper = GetMapper();

            var instructors = dbContext.Users.ToList();
            var instructor = instructors.FirstOrDefault();

            var quiz = new QuizDbEntity { Name = "Design Quiz", InstructorId = instructor.Id, IsActive = true };
            dbContext.Quizzes.Add(quiz);
            await dbContext.SaveChangesAsync();

            var service = new QuizService(dbContext, mapper);
            var result = service.GetQuestions(quiz.Id);

            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}
