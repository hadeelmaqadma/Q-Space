using QSpace.Data.DbEntities;
using QSpace.Infrastructure.Services.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace QSpace.Test.AuthTests
{
    public class AuthTest : BaseTest
    {
        [Fact]
        public void Creat_User_Return_True_If_Not_Null()
        {
            // Arrange
            using var dbContext = GetDbContext();
            //Act
            var res = dbContext.Users.Add(new User { Name = "TestUser", Email = "TestUser@gmail.com", PhoneNumber = "0567776873", PasswordHash =  "Password$1"});
            //Assert
            Assert.NotNull(res);
        }
        [Fact]
        public void GetAll_Should_Return_List_of_Users_More_Than_One_In_Length()
        {
            // Arrange 
            using var dbContext = GetDbContext();
            var mapper = GetMapper();
            var res = dbContext.Users.ToList();
            Assert.NotNull(res);
            Assert.NotEmpty(res);

            // Assert
            Assert.True(res.Count() >= 1);
        }
        [Fact]
        public void GetSessionById_should_return_null_for_missing_User()
        {
            // Arrange 
            using var dbContext = GetDbContext();
            var id = " ";
            // Act
            var result = dbContext.Users.FirstOrDefault(x => x.Id == id);

            Assert.Null(result);
        }
    }
}
