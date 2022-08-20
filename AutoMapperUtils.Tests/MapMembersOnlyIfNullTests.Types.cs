using AutoMapper;
using LambdaTheDev.AutoMapperUtils.Functionalities;

namespace LambdaTheDev.AutoMapperUtils.Tests
{
    public partial class MapMembersOnlyIfNullTests
    {
        private class TestProfile : Profile
        {
            public TestProfile()
            {
                CreateMap<UserUpdateDto, User>().CreateMappingsOnlyIfNotNull();
            }
        }

        private class User
        {
            public int Id { get; set; }
            public string Name { get; set; } = "";
            public string Bio { get; set; } = "";
            public int Value1 { get; set; }
            public int Value2 { get; set; }
            public string Secret { get; set; } = "Something";
            public float OtherValue { get; set; } = 325.525234f;
        }

        private class UserUpdateDto
        {
            public string? Name { get; set; }
            public string? Bio { get; set; }
            public int? Value1 { get; set; }
            public int? Value2 { get; set; }
        }
    }
}