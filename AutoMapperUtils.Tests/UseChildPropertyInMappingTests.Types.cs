using AutoMapper;
using LambdaTheDev.AutoMapperUtils.Functionalities;

namespace LambdaTheDev.AutoMapperUtils.Tests
{
    public partial class UseChildPropertyInMappingTests
    {
        private class TestProfile : Profile
        {
            public TestProfile()
            {
                CreateMap<ModelContainer, ModelDto>()
                    .MapSourceMemberProperty(x => x.Model);

                CreateMap<Model, ModelDto>();
            }
        }
        
        private class Model
        {
            public int Id { get; set; }
            public float MutualFloat { get; set; }
            public string Something { get; set; } = "";
            public string Secret { get; set; } = "";
        }

        private class ModelDto
        {
            public int Id { get; set; }
            public float MutualFloat { get; set; }
            public string Something { get; set; } = "";
        }

        private class ModelContainer
        {
            public int Id { get; set; }
            public float MutualFloat { get; set; }
            public Model Model { get; set; }
        }
    }
}