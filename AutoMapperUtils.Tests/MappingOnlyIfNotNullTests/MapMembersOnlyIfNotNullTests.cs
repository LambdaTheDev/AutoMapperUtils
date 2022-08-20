using AutoMapper;
using LambdaTheDev.AutoMapperUtils.Functionalities;
using NUnit.Framework;

namespace LambdaTheDev.AutoMapperUtils.Tests.MappingOnlyIfNotNullTests
{
    [TestFixture]
    public class MapMembersOnlyIfNotNullTests
    {
        private MapperConfiguration _config;
        
        [SetUp]
        public void SetUp()
        {
            _config = new MapperConfiguration(map =>
            {
                map.CreateMap<TestUserAUpdateDto, TestUserA>().CreateMappingsOnlyIfNotNull();
            });
            
        }

        [Test]
        public void MappingOnlyIfNotNullTest()
        {
            TestUserA user = new TestUserA
            {
                Id = 1234,
                Name = "BestTestSubject",
                Bio = "Some profile description",
                Value1 = 567,
                Value2 = 890,
            };

            TestUserAUpdateDto updateRequest = new TestUserAUpdateDto
            {
                Bio = "New description",
                Value2 = 9876543,
            };

            TestUserA updatedUser = _config.CreateMapper().Map(updateRequest, user);
            Assert.That(updatedUser.Id == 1234 && updatedUser.Name == "BestTestSubject" && updatedUser.Value1 == 567);
            Assert.That(updatedUser.Bio == "New description" && updatedUser.Value2 == 9876543);
        }
    }
}