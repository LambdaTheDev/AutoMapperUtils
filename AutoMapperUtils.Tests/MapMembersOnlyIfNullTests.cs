using System;
using System.Text.Json;
using AutoMapper;
using NUnit.Framework;

namespace LambdaTheDev.AutoMapperUtils.Tests
{
    [TestFixture]
    public partial class MapMembersOnlyIfNullTests
    {
        private static readonly MapperConfiguration MapperCfg = new MapperConfiguration(mapper =>
        {
            mapper.AddProfile<TestProfile>();
        });


        [Test]
        public void BasicTest()
        {
            User user = new User
            {
                Id = 1234,
                Name = "BestTestSubject",
                Bio = "Some profile description",
                Value1 = 567,
                Value2 = 890,
            };

            UserUpdateDto updateRequest = new UserUpdateDto()
            {
                Bio = "New description",
                Value2 = 9876543,
            };

            User updatedUser = MapperCfg.CreateMapper().Map(updateRequest, user);
            Assert.That(updatedUser.Id == 1234 && updatedUser.Name == "BestTestSubject" && updatedUser.Value1 == 567);
            Assert.That(updatedUser.Bio == "New description" && updatedUser.Value2 == 9876543);
        }
    }
}