using AutoMapper;
using MovieFanatic.Web.Infrastructure.AutoMapper;
using NUnit.Framework;

namespace MovieFanatic.Web.Tests
{
    [TestFixture]
    public class AutoMapperTests
    {
        [Test]
        public void AutoMapper_IsConfiguredProperly()
        {
            //Act
            AutoMapperConfiguration.Initialize();

            //Assert
            Mapper.AssertConfigurationIsValid();
        }
    }
}
