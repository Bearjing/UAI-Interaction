
using System;

namespace AutomapperUnityInterceptionTest
{
    public class ExampleDomainObject : IExampleDomainObject
    {
        private readonly IFakeQueryService _fakeQueryService;
        public string StringProperty { get; set; }
        public bool BooleanProperty { get; set; }
        public int IntProperty { get; set; }

        public ExampleDomainObject(IFakeQueryService fakeQueryService)
        {
            if (fakeQueryService == null) throw new ArgumentNullException("fakeQueryService");
            _fakeQueryService = fakeQueryService;

            Console.WriteLine("Constructed Domain Obj using overloaded ctor.");
        }

        public virtual void InterceptedMethod()
        {
            Console.WriteLine("This Method should be intercepted.");
        }
    }
}
