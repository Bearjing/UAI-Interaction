
using AutoMapper;
using AutomapperUnityInterceptionTest.ViewObjects;


namespace AutomapperUnityInterceptionTest
{
    public class ExampleObjectProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ExampleViewObject, IExampleDomainObject>()
                .As<ExampleDomainObject>();
            Mapper.CreateMap<ExampleViewObject, ExampleDomainObject>()
                .ConstructUsingServiceLocator();
        }
    }
}
