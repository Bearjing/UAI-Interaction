

using System;
using System.Reflection;
using AutoMapper;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace AutomapperUnityInterceptionTest
{
    public class UnityConfig
    {
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }

        public static void RegisterTypes(IUnityContainer unityContainer)
        {
            unityContainer.RegisterTypes(
                AllClasses.FromAssemblies(Assembly.GetExecutingAssembly()),     // pulls from a specific list in real code.
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.ContainerControlled);

            unityContainer.RegisterType<ConfigurationStore, ConfigurationStore>(
                new ContainerControlledLifetimeManager(),
                new InjectionConstructor(typeof (ITypeMapFactory), AutoMapper.Mappers.MapperRegistry.Mappers))
                .RegisterType<IConfigurationProvider, ConfigurationStore>()
                .RegisterType<IConfiguration, ConfigurationStore>()
                .RegisterType<IMappingEngine, MappingEngine>()
                .RegisterType<ITypeMapFactory, TypeMapFactory>();

            unityContainer.AddNewExtension<Interception>();

            // register as interface interceptor.
            //foreach (var registration in unityContainer.Registrations)
            //{
            //    if (registration.RegisteredType.IsInterface)
            //        unityContainer.RegisterType(
            //            registration.RegisteredType,
            //            registration.MappedToType,
            //            registration.Name,
            //            new Interceptor<InterfaceInterceptor>(),
            //            new InterceptionBehavior<TestInterceptorBehavior>())
            //            ;
            //}
            // register as virtual method interceptor.
            foreach (var registration in unityContainer.Registrations)
            {
                if (registration.RegisteredType.IsInterface)
                    unityContainer.RegisterType(
                        registration.RegisteredType,
                        registration.MappedToType,
                        registration.Name,
                        new Interceptor<VirtualMethodInterceptor>(),
                        new InterceptionBehavior<TestInterceptorBehavior>())
                        ;
            }
        }
    }
}
