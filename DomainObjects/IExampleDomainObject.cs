

namespace AutomapperUnityInterceptionTest
{
    public interface IExampleDomainObject
    {
        string StringProperty { get; set; }
        bool BooleanProperty { get; set; }
        int IntProperty { get; set; }

        void InterceptedMethod();
    }


}
