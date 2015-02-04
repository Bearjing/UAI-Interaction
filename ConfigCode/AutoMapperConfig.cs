using System;
using AutoMapper;
using Microsoft.Practices.Unity;


namespace AutomapperUnityInterceptionTest
{
   public static class AutoMapperConfig
    {
       public static void RegisterMaps()
       {
           Mapper.Initialize(config =>
           {
               config.ConstructServicesUsing(type => UnityConfig.GetConfiguredContainer().Resolve(type, type.Name, new ParameterOverrides()));
               config.AddProfile(new ExampleObjectProfile());
           });

           Mapper.AssertConfigurationIsValid();
       }
    }
}
