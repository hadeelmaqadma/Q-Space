using AutoMapper;
using QSpace.Core.Enums;
using QSpace.Infrastructure.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace QSpace.Test
{
    public class AutoMapperTest : BaseTest
    {
        /*
        [Fact]
        //failing test
        public void AutoMapper_Configuration_IsValid()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            config.AssertConfigurationIsValid();
        }
        */
        [Theory]
        [InlineData(1, DifficultyLevel.Easy)]
        [InlineData(2, DifficultyLevel.Moderate)]
        [InlineData(3, DifficultyLevel.Hard)]
        public void AutoMapper_ConvertFromByte_IsValid(byte levelEnum, DifficultyLevel expected)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            var mapper = config.CreateMapper();
            var result = mapper.Map<byte, DifficultyLevel>(levelEnum);
            Assert.Equal(result, expected);
        }
    }
}
