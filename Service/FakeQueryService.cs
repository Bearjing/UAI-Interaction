using System;

namespace AutomapperUnityInterceptionTest
{
    public class FakeQueryService : IFakeQueryService
    {
        public string GetAString()
        {
            return String.Format("This string holds the current time : {0}", DateTime.Now.ToShortDateString());
        }
    }
}
