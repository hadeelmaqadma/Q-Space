using Microsoft.AspNetCore.Mvc;
using Moq;
using QSpace.API.Controllers;
using QSpace.Core.ViewModels;
using QSpace.Infrastructure.Services.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Xunit;

namespace QSpace.Test.ControllerTests
{
    public class SessionControllerTest
    {
        #region Property  
        private static Mock<ISessionService> mock = new Mock<ISessionService>();
        SessionController sessionCtr = new SessionController(mock.Object);
        #endregion
        [Fact]
        public void GetSessionById_should_return_null_for_not_existing_session()
        { 
            IActionResult actionResult = sessionCtr.GetSessionById(-1);
            var contentResult = actionResult as OkNegotiatedContentResult<SessionViewModel>;
            Assert.Null(contentResult);
        }
        //[Fact]
        //public void GetSessionById_should_return_True_for_existing_session()
        //{

        //    IActionResult actionResult = sessionCtr.GetSessionById(1);
        //    var contentResult = actionResult as OkNegotiatedContentResult<SessionViewModel>;
        //    Assert.NotNull(contentResult);
        //    Assert.NotNull(contentResult.ContentNegotiator);
        //    Assert.True(contentResult.Content.CreatedAt.Second == contentResult.Content.HeldAt.Second);
        //}
    }
}
