using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutomapperUnityInterceptionTest.ViewObjects;
using Microsoft.Practices.Unity;

namespace AutomapperUnityInterceptionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var unityContainer = UnityConfig.GetConfiguredContainer();
            AutoMapperConfig.RegisterMaps();


            Console.WriteLine("Using Automapper : ");
            var viewModelObject = new ExampleViewObject();
            var mappedDomainObject = Mapper.Map<ExampleViewObject, IExampleDomainObject>(viewModelObject);
            Console.WriteLine("Object has been mapped.");
            mappedDomainObject.InterceptedMethod();

            Console.WriteLine("");
            Console.WriteLine("Using Unity Directly : ");

            var unityResolvedDomainObject = unityContainer.Resolve<IExampleDomainObject>();
            
            unityResolvedDomainObject.InterceptedMethod();
            Console.ReadLine();
        }
    }
}
